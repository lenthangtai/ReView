namespace VCB_TEGAKI
{
    partial class FrmSOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSOP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImgV = new ImageViewerTR.ImageViewerTR();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ImgV);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 841);
            this.panel1.TabIndex = 0;
            // 
            // ImgV
            // 
            this.ImgV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgV.AutoSize = true;
            this.ImgV.BackColor = System.Drawing.Color.LightGray;
            this.ImgV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgV.CurrentZoom = 1F;
            this.ImgV.Image = null;
            this.ImgV.Location = new System.Drawing.Point(0, 0);
            this.ImgV.Margin = new System.Windows.Forms.Padding(4);
            this.ImgV.MaxZoom = 20F;
            this.ImgV.MinZoom = 0.05F;
            this.ImgV.Name = "ImgV";
            this.ImgV.Size = new System.Drawing.Size(1000, 841);
            this.ImgV.TabIndex = 130;
            this.ImgV.TabStop = false;
            // 
            // FrmSOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 841);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmSOP";
            this.Text = "Screen View SOP";
            this.Load += new System.EventHandler(this.FrmSOP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSOP_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ImageViewerTR.ImageViewerTR ImgV;
    }
}