namespace VCB_Entry.ENTRY.ImageForm
{
    partial class frmShowImage
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
            this.imgTempPL_TR = new ImageViewerTR.ImageViewerTR();
            this.SuspendLayout();
            // 
            // imgTempPL_TR
            // 
            this.imgTempPL_TR.BackColor = System.Drawing.Color.LightGray;
            this.imgTempPL_TR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgTempPL_TR.CurrentZoom = 1F;
            this.imgTempPL_TR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgTempPL_TR.Image = null;
            this.imgTempPL_TR.Location = new System.Drawing.Point(0, 0);
            this.imgTempPL_TR.MaxZoom = 20F;
            this.imgTempPL_TR.MinZoom = 0.05F;
            this.imgTempPL_TR.Name = "imgTempPL_TR";
            this.imgTempPL_TR.Size = new System.Drawing.Size(844, 701);
            this.imgTempPL_TR.TabIndex = 1;
            // 
            // frmShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 701);
            this.Controls.Add(this.imgTempPL_TR);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmShowImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowImage";
            this.Load += new System.EventHandler(this.frmShowImage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowImage_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageViewerTR.ImageViewerTR imgTempPL_TR;
    }
}