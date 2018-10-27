namespace MyShrink
{
    partial class frmShrink
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShrink));
            this.lbldraginfo = new System.Windows.Forms.Label();
            this.listfiles = new System.Windows.Forms.ListBox();
            this.mystrip = new System.Windows.Forms.StatusStrip();
            this.mystatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdconvert = new System.Windows.Forms.Button();
            this.cmdclear = new System.Windows.Forms.Button();
            this.cmdexit = new System.Windows.Forms.Button();
            this.labelmethod = new System.Windows.Forms.Label();
            this.listUIAlgs = new System.Windows.Forms.ComboBox();
            this.lblamount = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.txtprogress = new System.Windows.Forms.TextBox();
            this.lblprogress = new System.Windows.Forms.Label();
            this.cmdabout = new System.Windows.Forms.Button();
            this.mystrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbldraginfo
            // 
            this.lbldraginfo.AutoSize = true;
            this.lbldraginfo.Location = new System.Drawing.Point(12, 60);
            this.lbldraginfo.Name = "lbldraginfo";
            this.lbldraginfo.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lbldraginfo.Size = new System.Drawing.Size(130, 19);
            this.lbldraginfo.TabIndex = 0;
            this.lbldraginfo.Text = "Drag and Drop Files Here:";
            // 
            // listfiles
            // 
            this.listfiles.AllowDrop = true;
            this.listfiles.FormattingEnabled = true;
            this.listfiles.Location = new System.Drawing.Point(15, 79);
            this.listfiles.Name = "listfiles";
            this.listfiles.Size = new System.Drawing.Size(556, 134);
            this.listfiles.TabIndex = 1;
            this.listfiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listfiles_DragDrop);
            this.listfiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listfiles_DragEnter);
            // 
            // mystrip
            // 
            this.mystrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mystatus});
            this.mystrip.Location = new System.Drawing.Point(0, 419);
            this.mystrip.Name = "mystrip";
            this.mystrip.Size = new System.Drawing.Size(588, 22);
            this.mystrip.SizingGrip = false;
            this.mystrip.TabIndex = 2;
            this.mystrip.Text = "statusStrip1";
            // 
            // mystatus
            // 
            this.mystatus.Name = "mystatus";
            this.mystatus.Size = new System.Drawing.Size(42, 17);
            this.mystatus.Text = "Ready.";
            // 
            // cmdconvert
            // 
            this.cmdconvert.Location = new System.Drawing.Point(336, 219);
            this.cmdconvert.Name = "cmdconvert";
            this.cmdconvert.Size = new System.Drawing.Size(75, 23);
            this.cmdconvert.TabIndex = 3;
            this.cmdconvert.Text = "Convert";
            this.cmdconvert.UseVisualStyleBackColor = true;
            this.cmdconvert.Click += new System.EventHandler(this.cmdconvert_Click);
            // 
            // cmdclear
            // 
            this.cmdclear.Location = new System.Drawing.Point(417, 219);
            this.cmdclear.Name = "cmdclear";
            this.cmdclear.Size = new System.Drawing.Size(73, 23);
            this.cmdclear.TabIndex = 4;
            this.cmdclear.Text = "Clear";
            this.cmdclear.UseVisualStyleBackColor = true;
            this.cmdclear.Click += new System.EventHandler(this.cmdclear_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.Location = new System.Drawing.Point(496, 219);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(75, 23);
            this.cmdexit.TabIndex = 5;
            this.cmdexit.Text = "Exit";
            this.cmdexit.UseVisualStyleBackColor = true;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // labelmethod
            // 
            this.labelmethod.AutoSize = true;
            this.labelmethod.Location = new System.Drawing.Point(12, 20);
            this.labelmethod.Name = "labelmethod";
            this.labelmethod.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelmethod.Size = new System.Drawing.Size(80, 19);
            this.labelmethod.TabIndex = 0;
            this.labelmethod.Text = "Rezize method:";
            // 
            // listUIAlgs
            // 
            this.listUIAlgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listUIAlgs.FormattingEnabled = true;
            this.listUIAlgs.Location = new System.Drawing.Point(99, 20);
            this.listUIAlgs.Name = "listUIAlgs";
            this.listUIAlgs.Size = new System.Drawing.Size(219, 21);
            this.listUIAlgs.TabIndex = 1;
            // 
            // lblamount
            // 
            this.lblamount.AutoSize = true;
            this.lblamount.Location = new System.Drawing.Point(336, 20);
            this.lblamount.Name = "lblamount";
            this.lblamount.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblamount.Size = new System.Drawing.Size(176, 19);
            this.lblamount.TabIndex = 2;
            this.lblamount.Text = "Shrink to this percentage of original:";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(513, 23);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(58, 20);
            this.txtamount.TabIndex = 3;
            this.txtamount.Text = "50";
            // 
            // txtprogress
            // 
            this.txtprogress.Location = new System.Drawing.Point(15, 274);
            this.txtprogress.Multiline = true;
            this.txtprogress.Name = "txtprogress";
            this.txtprogress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtprogress.Size = new System.Drawing.Size(556, 128);
            this.txtprogress.TabIndex = 6;
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(12, 258);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(51, 13);
            this.lblprogress.TabIndex = 7;
            this.lblprogress.Text = "Progress:";
            // 
            // cmdabout
            // 
            this.cmdabout.Location = new System.Drawing.Point(15, 218);
            this.cmdabout.Name = "cmdabout";
            this.cmdabout.Size = new System.Drawing.Size(31, 23);
            this.cmdabout.TabIndex = 8;
            this.cmdabout.Text = "?";
            this.cmdabout.UseVisualStyleBackColor = true;
            this.cmdabout.Click += new System.EventHandler(this.cmdabout_Click);
            // 
            // frmShrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 441);
            this.Controls.Add(this.cmdabout);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.txtprogress);
            this.Controls.Add(this.listfiles);
            this.Controls.Add(this.lbldraginfo);
            this.Controls.Add(this.labelmethod);
            this.Controls.Add(this.cmdconvert);
            this.Controls.Add(this.listUIAlgs);
            this.Controls.Add(this.cmdexit);
            this.Controls.Add(this.lblamount);
            this.Controls.Add(this.cmdclear);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.mystrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmShrink";
            this.Text = "Batch Shrink Ray for Images";
            this.mystrip.ResumeLayout(false);
            this.mystrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldraginfo;
        private System.Windows.Forms.ListBox listfiles;
        private System.Windows.Forms.StatusStrip mystrip;
        private System.Windows.Forms.Button cmdconvert;
        private System.Windows.Forms.Button cmdclear;
        private System.Windows.Forms.Button cmdexit;
        private System.Windows.Forms.Label labelmethod;
        private System.Windows.Forms.ComboBox listUIAlgs;
        private System.Windows.Forms.Label lblamount;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.ToolStripStatusLabel mystatus;
        private System.Windows.Forms.TextBox txtprogress;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.Button cmdabout;
    }
}

