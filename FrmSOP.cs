using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_TEGAKI
{
    public partial class FrmSOP : Form
    {
        public byte[] getimg;
        Bitmap imageSource;
        public FrmSOP()
        {
            InitializeComponent();
                     
        }

        private void FrmSOP_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            //this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(x/2 - 100, y/10);
            imageSource = new Bitmap(Io_Entry.byteArrayToImage(getimg));
            ImgV.Image = new Bitmap(imageSource);
            //MessageBox.Show(ImgV.CurrentZoom.ToString());
            //if (ImgV.CurrentZoom > 0.8)
            //{
            //    ImgV.CurrentZoom = 1.0f;
            //}

        }

        private void FrmSOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.Q)
                {
                    this.Close();
                }
                if (e.KeyCode == Keys.Add)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Subtract)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom <= 0.1f ? 0.1f : ImgV.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    try
                    {
                        ImgV.RotateImage("270");
                    }
                    catch { }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    try
                    {
                        ImgV.RotateImage("90");
                    }
                    catch { }
                    e.Handled = true;
                }
            }
        }
    }
}
