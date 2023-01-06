using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry.ENTRY.ImageForm
{
    public partial class frmShowImage : Form
    {
        public frmShowImage()
        {
            InitializeComponent();
        }

        public string tempText;
        public string tempName;
        DAEntry_Entry dAEntry = new DAEntry_Entry();
        //public DataGridView grTempV = new DataGridView();
        public Bitmap imageSource;


        private void frmShowImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Q)
                {
                    this.Close();
                }
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void frmShowImage_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tempText))
                {
                    if (dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = '" + tempName + "')") < 1)
                    {
                        MessageBox.Show("Empty Image");
                    }
                    else
                    {
                        dAEntry.GetDatatableSQL("SELECT Binary_Poi_SOP_PL FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = '" + tempName + "')");
                        imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(tempName)));
                        //PictureBox imgTempPL = new PictureBox();
                        imgTempPL_TR.Image = imageSource;
                        imgTempPL_TR.Location = new Point(0, 0);
                        imgTempPL_TR.Visible = true;

                    }
                }
                else
                {
                    if (dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = N'" + tempText + "')") < 1 || dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE Colum1_1 = N'" + tempText + "')") < 1 || dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE Colum1_2 = N'" + tempText + "')") < 1 || dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE Colum1_3 = N'" + tempText + "')") < 1)
                    {
                        if (dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = '" + tempName + "')") == 1)
                        {
                            dAEntry.GetDatatableSQL("SELECT Binary_Poi_SOP_PL FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = '" + tempName + "')");
                            imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(tempName)));
                            imgTempPL_TR.Image = imageSource;
                            imgTempPL_TR.Location = new Point(0, 0);
                            imgTempPL_TR.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Không Có kí tự cần tìm");
                        }
                    }
                    else if (dAEntry.GetIntSQL("SELECT COUNT(Binary_Poi_SOP_PL) FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = N'" + tempText + "')") == 1)
                    {
                        dAEntry.GetDatatableSQL("SELECT Binary_Poi_SOP_PL FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = N'" + tempText + "')");
                        imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(tempName)));
                        //PictureBox imgTempPL = new PictureBox();
                        imgTempPL_TR.Image = imageSource;
                        imgTempPL_TR.Location = new Point(0, 0);
                        imgTempPL_TR.Visible = true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
        }
    }
}
