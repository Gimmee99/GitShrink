using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MyShrink
{
    
    public partial class frmShrink : Form
    {
        List<string> origfiles = new List<string>();
        List<string> sizedfiles = new List<string>();
        List<string> listAlgs = new List<string> { "Low", "High", "BiLinear (<50% only)", "BiCubic (<25% only)", "Nearest Neighbor", "HiQualityLinear", "HiQualityBiCubic" };

        public frmShrink()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetDefaults()
        {
            listUIAlgs.DataSource = listAlgs;
            listUIAlgs.SelectedIndex = 6;  //HiQualityBiCubic
        }

        private void cmdconvert_Click(object sender, EventArgs e)
        {

            // Validate UI choices a little bit ...

            int ihowmuch = 50;
            try
            {
                 ihowmuch = int.Parse(txtamount.Text);
            }
            catch
            {
                MessageBox.Show("Please verify you have a valid percentage (1-99) specified.", "Batch Shrink", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((ihowmuch < 1) || (ihowmuch>99))
            {
                MessageBox.Show("The compression percentage must be between 1 and 99.", "Batch Shrink", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((listUIAlgs.SelectedIndex == 2) && (ihowmuch >49))
            {
                MessageBox.Show("The BiLinear compression algorithm can only be used for <50% compression.", "Batch Shrink", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((listUIAlgs.SelectedIndex == 3) && (ihowmuch > 24))
            {
                MessageBox.Show("The BiCubic algorithm can only be used for <25% compression.", "Batch Shrink", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listfiles.Items.Count == 0)
            {
                MessageBox.Show("You must specify at least one file to convert.", "Batch Shrink", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DoTheConversion(ihowmuch);

        }

        private void DoTheConversion(int ihowmuch)
        {

            // Pick up the Interpolation Algorithm choice from the UI

            InterpolationMode mymode = new InterpolationMode();
            mymode = InterpolationMode.HighQualityBicubic;

            switch (listUIAlgs.SelectedIndex)
            {
                case 0:             // Low
                    mymode = InterpolationMode.Low;
                    break;
                case 1:             // High
                    mymode = InterpolationMode.High;

                    break;
                case 2:             // BiLenear
                    mymode = InterpolationMode.Bilinear;

                    break;
                case 3:             // BiCubic
                    mymode = InterpolationMode.Bicubic;

                    break;
                case 4:             // Nearest Neighbor
                    mymode = InterpolationMode.NearestNeighbor;
                    break;
                case 5:             // HiQualityBiLinear
                    mymode = InterpolationMode.HighQualityBilinear;
                    break;
                case 6:             // HiQualityBiCubic
                    mymode = InterpolationMode.HighQualityBicubic;
                    break;
            }

            // Loop through each file in the file list and convert it ...

            foreach (var onefile in listfiles.Items)
            {
                mystatus.Text = "Converting " + onefile.ToString() + " ...";
                ConvertOneFile(onefile.ToString(), ihowmuch, mymode);
                mystatus.Text = "Done.";
            }
        }

        private void ConvertOneFile(string oneoriginalfile, int ihowmuch, InterpolationMode modetouse)
        {
            Image original;
            try
            {
                original = Image.FromFile(oneoriginalfile);
            }
            catch (Exception e)
            {
                txtprogress.AppendText(oneoriginalfile + " could not be converted to an image.\n");
                Application.DoEvents();
                return;
            }
            

            // The resize function takes a new absoloute width/height so we have to calculate what X% of that means
            // Take the original width and height, then multiply the UI percentage to get the new abosolutes
            // The alg always preserves aspect ratio so you may not get an exact match


            Size mysize = new Size();

            float ratio = (float)ihowmuch / 100;
            float rwidth = original.Width * ratio;
            float rheight = original.Height * ratio;

            mysize.Width = (int)rwidth;
            mysize.Height = (int)rheight;

            // Call the resize code to do the work
            Image resized = ResizeImage(original, mysize, modetouse);

            // New file name is old file name plus 'resized' at the end. Save the new file.
            string newfilename = oneoriginalfile + "_resized.jpg";
            resized.Save(newfilename, ImageFormat.Jpeg);

            // Put up a little progress and status so people know things are working ...
            mystatus.Text = newfilename + " resized successfully.";
            txtprogress.AppendText(newfilename + " resized successfully.\n");
            newfilename = "";
            Application.DoEvents();
        }

        private void listfiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    origfiles.Add(filePath);
                }
                listfiles.DataSource = origfiles;
            }
        }

        private void listfiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        
        /*
            ResizeImage() code is adapted from http://www.codeproject.com/Articles/191424/Resizing-an-Image-On-The-Fly-using-NET
        */
        
        public static Image ResizeImage(Image image, Size size, InterpolationMode mode,bool preserveAspectRatio = true )
        {
            int newWidth;
            int newHeight;
            
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                // Set in the mode that was chosen in the UI
                graphicsHandle.InterpolationMode = mode;

                // Note that the smoothing mode is always static. TODO: Add this choice to the UI as well
                graphicsHandle.SmoothingMode = SmoothingMode.HighQuality;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        private void cmdclear_Click(object sender, EventArgs e)
        {
            // Clear UI for another pass
            listfiles.DataSource = null;
            listfiles.Items.Clear();
            origfiles.Clear();
            txtprogress.Clear();
            mystatus.Text = "Ready";

        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdabout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scott Bradley (gimmee99@hotmail.com)" + "\n" + "Version: " + ProductVersion.ToString() + " April 2016","Sample Batch Image Resizing Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
