using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using VCB_Entry.ENTRY.ImageForm;

namespace VCB_TEGAKI
{
    public partial class FrmEntryP : Form
    {
        public static bool selecthitpoint = true;
        public int batchId;
        public int userId;
        public int pair;
        public int ImgId;
        int idreturn;
        private double scale = 1;
        public string userName;
        public string batchName;
        DataTable dtimage = new DataTable();
        DataTable dtbinary = new DataTable();
        byte[] getbinary;
        DataTable dtbinary2;
        string tenanh;
        DataTable get_lstimage = new DataTable();
        DataTable get_lstimage2 = new DataTable();
        Bitmap imageSource, imageSource_clone;
        bool getanh = false;
        List<BOImage_Entry> listImage;
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private BOImage_Entry img = new BOImage_Entry();
        private bool finish = false;
        DataTable dtall = new DataTable();
        float dbzome;
        List<TextBox> lsttxt = new List<TextBox>();
        string chuoi;
        string[] arrsave = new string[2];
        string[] arrsh = new string[0];
        string[] arrsl = new string[0];
        string[] arrgm = new string[0];
        string[] arrgb = new string[0];
        DateTime dtimeBefore = new DateTime();
        public FrmEntryP()
        {
            InitializeComponent();
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {

            listImage = new List<BOImage_Entry>();
            resul = "";
            // hiển thị thông tin user
            this.Text = "Entry" + "                     UserName: " + userName;
            lblusername.Text = userName;
            lblbatchname.Text = batchName;
            dtall = dAEntry.Get_AllTemplate();
            //grTemp.DataSource = dtall;
            //grTempV.RowCellClick += gridView1_RowCellClick;
            //grTempV.Columns[0].Visible = false;
            //userid
            //int uID = userId;

            //// hien thi giua man hinh
            //this.CenterToScreen();          
            int idimg = dAEntry.GetIDImage(pair);
            resul = dAEntry.Get_Result(idimg);
            if (idimg == 0)
            {
                btnNotgood.Enabled = false;
                finish = true;
                MessageBox.Show("Batch đã hoàn thành");
                this.Close();
                return;
            }
            else
            {
                try
                {
                    tenanh = dAEntry.Get_imgname(idimg);
                    imageSource = new Bitmap(Io_Entry.byteArrayToImage(dAEntry.getImageOnServer(tenanh)));
                    imageSource_clone = imageSource;
                    getbinary = dAEntry.ImageToByteArray(imageSource);
                    view_Image_TN.Image = imageSource;
                    dbzome = view_Image_TN.CurrentZoom;
                    lblpage.Text = tenanh;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Server chưa có ảnh");
                    this.Close();
                    return;
                }
            }
            idreturn = idimg;
            dtimeBefore = DateTime.Now;
            timergetanh.Start();
            txtTemp.Focus();
            grTemp.DataSource = dtall;
            txtTemp.Focus();
            //grTempV.RowCellClick += gridView1_RowCellClick;
            grTempV.Columns[0].Visible = false;
            grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            grTempV.BestFitColumns();
            txtText.Text = "";
        }
        private Graphics graphics;
        Pen PEN_DRAW = new Pen(Color.Red, 2);
        Pen PEN_DRAW_BLUE = new Pen(Color.Blue, 2);
        Brush BRUSH = new SolidBrush(Color.FromArgb(30, 127, 255, 0));
        Pen LineRed = new Pen(Color.Red, 3);
        public Bitmap drawimage(Bitmap bmp, DataTable role_tem)
        {
            DataTable dtv = role_tem;
            //DataTable dtvmsdt = role_tem;
            int _x = 0;
            int _y = 0;
            int wid = 0;
            int hei = 0;
            for (int i = 0; i < dtv.Rows.Count; i++)
            {
                try
                {
                    //dtv.Rows[i][0] = (i + 1).ToString().PadLeft(2, '0');
                    _x = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[0]) * scale);
                    _y = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[1]) * scale);
                    wid = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[2]) * scale);
                    hei = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[3]) * scale);
                    using (graphics = Graphics.FromImage(bmp))
                    {
                        graphics.DrawRectangle(LineRed, _x, _y, wid, hei);
                        graphics.DrawString(dtv.Rows[i][0].ToString(), new Font("Arial", 50), new SolidBrush(Color.Red), _x, _y);
                    }
                }
                catch
                {
                }
            }
            #region close
            //DataTable dt_truong1 = role_tem_truong1;
            //for (int i = 0; i < dt_truong1.Rows.Count; i++)
            //{
            //    try
            //    {
            //        //dtvmsdt.Rows[0][0] = "01";
            //        _x = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[0]) * scale);
            //        _y = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[1]) * scale);
            //        wid = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[2]) * scale);
            //        hei = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[3]) * scale);
            //        graphics = pbimg.CreateGraphics();
            //        graphics.DrawRectangle(PEN_DRAW_BLUE, _x, _y, wid, hei);
            //        graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
            //        graphics.DrawString(dt_truong1.Rows[i][0].ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Blue), _x, _y);
            //    }
            //    catch { }
            //}
            #endregion
            return bmp;
        }
        void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                chuoi = grTempV.GetRowCellValue(e.RowHandle, "TemplateName").ToString();
                string colum1 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_1").ToString();
                string colum2 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_2").ToString();
                string colum3 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_3").ToString();
                if (chuoi.Length > 0)
                {
                    txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                }
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            timergetanh.Stop();
            try
            {
                if (!finish)
                {
                    dAEntry.Return_HitpointP(idreturn, pair);
                    dAEntry.Return_HitpointP(img.Id, pair);
                    //    e.Cancel = true;
                    //dAEntry.ReturnPairANDHitpointEntry(img.Id, userId);
                    //// unlock image       
                    for (int i = 0; i < listImage.Count; i++)
                    {
                        dAEntry.Return_HitpointP(listImage[i].Id, pair);
                    }
                }
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                if (ms < 0)
                { ms = 4000; }
                //string[] arr = lsttxt.Select(x => x.Text.Trim().ToLower()).ToArray();
                //string imgContentContent = String.Join("", arr);
                //int lng = txtcten.Text.Length;
                int lng = 0;
                if (conten_saveout == null)
                { lng = 0; }
                else
                {
                    lng = conten_saveout.Length;
                }
                dAEntry.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,Timeout,Charout,TypeOut, Lvl) values (" + batchId + ",N'" + batchName + "'," + userId + "," + ms + "," + lng + ",1, 0)");
            }
            catch { }
            return;
        }
        string conten_saveout = "";
        private void btnRR_Click(object sender, EventArgs e)
        {

        }

        private void btnRL_Click(object sender, EventArgs e)
        {

        }
        private void frmEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Home)
            {
                txtTemp.Focus();
                txtTemp.SelectionStart = txtTemp.Text.Length;
            }
            // new 09-07-2019
            //else if ( e.KeyCode == Keys.Up)
            //{
            //    if (grTempV.Focus())
            //    {
            //        if (grTempV.TopRowChanged == 0)
            //        {
            //            grTempV.FocusedRowHandle = grTempV.RowCount;
            //        }
            //    }
            //}
            //
            if (e.Control)
            {
                if (e.KeyCode == Keys.Up)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    #region
                    //try
                    //{
                    //    zoom = true;
                    //    Bitmap bm_in = new Bitmap(imageSource);
                    //    Int32 wid = bm_in.Width;
                    //    Int32 hgt = bm_in.Height;
                    //    Point[] corners;
                    //    corners = new Point[4];
                    //    corners[0] = new Point(0, 0);
                    //    corners[1] = new Point(wid, 0);
                    //    corners[2] = new Point(0, hgt);
                    //    corners[3] = new Point(wid, hgt);
                    //    int cx = wid / 2;
                    //    int cy = hgt / 2;

                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        corners[i].X -= cx;
                    //        corners[i].Y -= cy;

                    //    }

                    //    double theta = int.Parse("-90") * Math.PI / 180.0;
                    //    double sin_theta = Math.Sin(theta);
                    //    double cos_theta = Math.Cos(theta);
                    //    double x;
                    //    double y;
                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        x = corners[i].X;
                    //        y = corners[i].Y;

                    //        corners[i].X = Convert.ToInt32(x * cos_theta + y * sin_theta);

                    //        corners[i].Y = Convert.ToInt32(-x * sin_theta + y * cos_theta);
                    //    }
                    //    int xmin = corners[0].X;
                    //    int ymin = corners[0].Y;
                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        if (xmin > corners[i].X)
                    //        {
                    //            xmin = corners[i].X;
                    //        }
                    //        if (ymin > corners[i].Y)
                    //        {
                    //            ymin = corners[i].Y;
                    //        }

                    //    }

                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        corners[i].X -= xmin;
                    //        corners[i].Y -= ymin;

                    //    }
                    //    bm_out = new Bitmap(Convert.ToInt32(-2 * xmin), Convert.ToInt32(-2 * ymin));
                    //    Graphics gr_out = Graphics.FromImage(bm_out);
                    //    //ReDim Preserve corners(2)
                    //    Array.Resize(ref corners, 3);
                    //    gr_out.DrawImage(bm_in, corners);
                    //    view_Image_TN.Image = bm_out;
                    //}
                    //catch
                    //{

                    //}   
                    #endregion
                    view_Image_TN.RotateImage("270");
                    //imageSource = view_Image_TN.Image;
                    byte[] anhdaxoay = dAEntry.ImageToByteArray(imageSource);
                    if (idreturn != 0)
                    {
                        dAEntry.UP_IMAGE_XOAY(anhdaxoay, tenanh, idreturn);
                    }
                    else
                    {
                        dAEntry.UP_IMAGE_XOAY(anhdaxoay, tenanh, img.Id);
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    #region
                    //try
                    //{
                    //    Bitmap bm_in = new Bitmap(imageSource);
                    //    Int32 wid = bm_in.Width;
                    //    Int32 hgt = bm_in.Height;
                    //    Point[] corners;
                    //    corners = new Point[4];
                    //    corners[0] = new Point(0, 0);
                    //    corners[1] = new Point(wid, 0);
                    //    corners[2] = new Point(0, hgt);
                    //    corners[3] = new Point(wid, hgt);
                    //    int cx = wid / 2;
                    //    int cy = hgt / 2;

                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        corners[i].X -= cx;
                    //        corners[i].Y -= cy;

                    //    }

                    //    double theta = int.Parse("90") * Math.PI / 180.0;
                    //    double sin_theta = Math.Sin(theta);
                    //    double cos_theta = Math.Cos(theta);
                    //    double x;
                    //    double y;
                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        x = corners[i].X;
                    //        y = corners[i].Y;

                    //        corners[i].X = Convert.ToInt32(x * cos_theta + y * sin_theta);

                    //        corners[i].Y = Convert.ToInt32(-x * sin_theta + y * cos_theta);
                    //    }
                    //    int xmin = corners[0].X;
                    //    int ymin = corners[0].Y;
                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        if (xmin > corners[i].X)
                    //        {
                    //            xmin = corners[i].X;
                    //        }
                    //        if (ymin > corners[i].Y)
                    //        {
                    //            ymin = corners[i].Y;
                    //        }

                    //    }

                    //    for (int i = 0; i < 4; i++)
                    //    {
                    //        corners[i].X -= xmin;
                    //        corners[i].Y -= ymin;

                    //    }

                    //    bm_out = new Bitmap(Convert.ToInt32(-2 * xmin), Convert.ToInt32(-2 * ymin));
                    //    Graphics gr_out = Graphics.FromImage(bm_out);
                    //    //ReDim Preserve corners(2)
                    //    Array.Resize(ref corners, 3);

                    //    gr_out.DrawImage(bm_in, corners);
                    //    view_Image_TN.Image = bm_out;
                    //}
                    //catch
                    //{

                    //}
                    #endregion
                    view_Image_TN.RotateImage("90");

                    view_Image_TN.Image = imageSource;
                    //imageSource = view_Image_TN.RotateImage("90");
                    byte[] anhdaxoay = dAEntry.ImageToByteArray(imageSource);
                    if (idreturn != 0)
                    {
                        dAEntry.UP_IMAGE_XOAY(anhdaxoay, tenanh, idreturn);
                    }
                    else
                    {
                        dAEntry.UP_IMAGE_XOAY(anhdaxoay, tenanh, img.Id);
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F)
                {
                    view_Image_TN.CurrentZoom = dbzome;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.N)
                {
                    btnNotgood_Click_1(sender, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Q)
                {

                    using (frmShowImage frmS = new frmShowImage())
                    {
                        frmS.tempName = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString();
                        frmS.tempText = "";
                        frmS.ShowDialog();
                    }

                    //try
                    //{
                    //    if(string.IsNullOrEmpty(txtTemp.Text))
                    //    {
                    //        if (dAEntry.GetIntSQL("SELECT Binary_Poi_SOP_PL FROM dbo. WHERE TempName='" + grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString() + "'") < 1)
                    //        {
                    //            MessageBox.Show("Empty Image");
                    //        }
                    //        else
                    //        {
                    //            dAEntry.GetDatatableSQL("SELECT Binary_Poi_SOP_PL FROM dbo.Template_Demo WHERE TempName='" + grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString() + "'");
                    //            //using (frmShowImage form = new frmShowImage())
                    //            //{
                    //            //    imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString())));
                    //            //    PictureBox imgTempPL = new PictureBox();
                    //            //    imgTempPL.Image = imageSource;
                    //            //    imgTempPL.Location = new Point(0, 0);
                    //            //    imgTempPL.Size = new Size(800, 500);
                    //            //    imgTempPL.Visible = true;
                    //            //    imgTempPL.Dock = DockStyle.Fill;
                    //            //    imgTempPL.SizeMode = PictureBoxSizeMode.Zoom;
                    //            //    form.Size = imgTempPL.Size;
                    //            //    form.StartPosition = FormStartPosition.CenterScreen;
                    //            //    form.Controls.Add(imgTempPL);
                    //            //    form.ShowDialog();
                    //            //}
                    //            using (frmShowImage form = new frmShowImage())
                    //            {
                    //                imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(txtTemp.Text)));
                    //                //Bitmap imgTempPL = new Bitmap();
                    //                PictureBox imgTempPL = new PictureBox();
                    //                imgTempPL.Image = imageSource;
                    //                imgTempPL.Location = new System.Drawing.Point(0, 0);
                    //                imgTempPL.Size = new Size(1200, 960);
                    //                imgTempPL.Visible = true;
                    //                imgTempPL.Dock = DockStyle.Fill;
                    //                imgTempPL.SizeMode = PictureBoxSizeMode.StretchImage;
                    //                //SizeMode = PictureBoxSizeMode.Zoom
                    //                form.AutoSize = true;
                    //                form.Size = imgTempPL.Size;


                    //                form.StartPosition = FormStartPosition.CenterScreen;
                    //                form.Controls.Add(imgTempPL);
                    //                form.ShowDialog();
                    //            }

                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (dAEntry.GetIntSQL("SELECT Binary_Poi_SOP_PL FROM dbo.Template_Demo WHERE TempName='" +txtTemp.Text + "'") < 1)
                    //        {
                    //            MessageBox.Show("Empty Image");
                    //        }
                    //        else
                    //        {
                    //            dAEntry.GetDatatableSQL("SELECT Binary_Poi_SOP_PL FROM dbo.Template_Demo WHERE TempName='" + txtTemp.Text + "'");
                    //            using (frmShowImage form = new frmShowImage())
                    //            {
                    //                imageSource = new Bitmap(byteArrayToImage(dAEntry.getImageSOPPL(txtTemp.Text)));
                    //                PictureBox imgTempPL = new PictureBox();
                    //                imgTempPL.Image = imageSource;
                    //                imgTempPL.Location = new Point(0, 0);
                    //                imgTempPL.Size = new Size(800, 500);
                    //                imgTempPL.Visible = true;
                    //                imgTempPL.Dock = DockStyle.Fill;
                    //                imgTempPL.SizeMode = PictureBoxSizeMode.Zoom;
                    //                form.Size = imgTempPL.Size;
                    //                form.StartPosition = FormStartPosition.CenterScreen;
                    //                form.Controls.Add(imgTempPL);
                    //                form.ShowDialog();
                    //            }

                    //        }
                    //    }


                    //}
                    //catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }

            }
        }


        #region Update-Code
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
        System.Data.DataTable dtImgTempPL = new System.Data.DataTable();
        #endregion


        private void frmEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 43)
                e.Handled = true;
            if (e.KeyChar == 110)
                e.Handled = true;
        }

        private void frmEntry_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void btnFullImage_Click(object sender, EventArgs e)
        {

        }

        private void btnzoomout_Click(object sender, EventArgs e)
        {

        }
        private void btnzoomin_Click(object sender, EventArgs e)
        {

        }
        private void bgwGetImage1_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (ListImage.Count < 2)
            //{
            //    get_lstimage = dAEntry.Get_Binary(dtimage.Rows[0][0].ToString(), Convert.ToInt32(dtimage.Rows[0][0]), pair);
            //    if (get_lstimage.Rows.Count > 0)
            //    {
            //        BOImage_Entry img2 = dAEntry.GetImage(Convert.ToInt32(get_lstimage.Rows[0][1]));
            //        try
            //        {
            //            img2.Imagesource = new Bitmap(Io_Entry.byteArrayToImage(dAEntry.getImageOnServer(img2.PageUrl, batchName)));
            //        }
            //        catch { img2.Imagesource = null; }
            //        ListImage.Add(img2);
            //    }
            //    else
            //        break;
            //}
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtText.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn Form-- > Return", "Thông Báo");
                return;
            }
            if (chuoi == null)
            {
                if (MessageBox.Show("Mã số trống, bạn có báo Notgood không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    btnNotgood_Click_1(sender, e);
                }
                else
                {
                    return;
                }
            }
            chuoi = txtText.Text.Trim().Split('|')[0].ToString();
            conten_saveout = chuoi;
            TimeSpan span = DateTime.Now - dtimeBefore;
            int ms = (int)span.TotalMilliseconds;
            try
            {
                while (ms < 0)
                {
                    span = DateTime.Now - dtimeBefore;
                    ms = (int)span.TotalMilliseconds;
                    if (ms > 0)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (idreturn != 0)
            {
                if (pair == 3)
                {
                    string E1_old = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND AllImage.NGP1 = 0 ");
                    if (E1_old == "")
                    {
                        dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 1 where  Id =" + idreturn);
                        dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + chuoi.Trim() + "', UserP1 = " + userId + ", DateP1=getdate(), TongkytuP1 =1,TimemilionP1 = " + ms + " where AllImageId=" + idreturn);
                        string E2_test = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND  NGP1 = 0 AND NGP2 = 0");
                        string E2_NG = dAEntry.GetStringSQL("select NGP2 from db_owner.AllImage where Id = " + idreturn + "");
                        //byte[] bytesE1 = Encoding.ASCII.GetBytes(chuoi.ToString());
                        //byte[] bytesE2 = Encoding.ASCII.GetBytes(E2_test);
                        if (E2_NG != "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + idreturn);
                        }
                        if (chuoi.Trim() != E2_test && E2_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + idreturn);
                        }
                        else if (chuoi.Trim() == E2_test && E2_test != "" && E2_NG == "0")
                        {
                            //HUYPT
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 2,Hitpoint2 = 2, InfoP = 0 where  Id =" + idreturn);
                            dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = null,Content2 = null, ResultP=N'" + chuoi.Trim().ToString() + "' where  AllImageId =" + idreturn); //,STT_ID_PL = " + stt_type_PhanLoai + "
                        }
                    }
                    //dAEntry.AddImageContentP1(idreturn, chuoi.ToString(), userId, ms, stt_type_PhanLoai);
                }
                if (pair == 4)
                {
                    string E1_old = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND AllImage.NGP2 = 0 ");
                    if (E1_old == "")
                    {
                        dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 1 where  Id =" + idreturn);
                        dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + chuoi.Trim() + "', UserP2 = " + userId + ", DateP2=getdate(), TongkytuP2 =1,TimemilionP2 = " + ms + " where AllImageId=" + idreturn);
                        string E1_test = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND NGP1 = 0 AND NGP2 = 0");
                        string E2_NG = dAEntry.GetStringSQL("select NGP1 from db_owner.AllImage where Id = " + idreturn + "");
                        //byte[] bytesE1 = Encoding.ASCII.GetBytes(chuoi.ToString());
                        //byte[] bytesE2 = Encoding.ASCII.GetBytes(E2_test);
                        if (E2_NG != "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + idreturn);
                        }

                        if (chuoi.Trim() != E1_test && E1_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + idreturn);
                        }
                        else if (chuoi.Trim() == E1_test && E1_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 2,Hitpoint2 = 2, InfoP = 0 where  Id =" + idreturn);
                            dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = null,Content2 = null, ResultP=N'" + chuoi.Trim().ToString() + "' where  AllImageId =" + idreturn); //,STT_ID_PL = " + stt_type_PhanLoai + "
                        }
                    }
                    //dAEntry.AddImageContentP2(idreturn, chuoi.ToString(), userId, ms, stt_type_PhanLoai);
                }
            }
            else
            {
                if (pair == 3)
                {
                    string E1_old = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + img.Id + " AND AllImage.NGP1 = 0 ");
                    if (E1_old == "")
                    {
                        dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 1 where  Id =" + img.Id);
                        dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + chuoi.Trim() + "', UserP1 = " + userId + ", DateP1=getdate(), TongkytuP1 =1,TimemilionP1 = " + ms + " where AllImageId=" + img.Id);
                        string E2_test = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + img.Id + " AND NGP1 = 0 AND NGP2 = 0");
                        string E2_NG = dAEntry.GetStringSQL("select NGP2 from db_owner.AllImage where Id = " + img.Id + "");

                        if (E2_NG != "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + img.Id);
                        }
                        //byte[] bytesE1 = Encoding.ASCII.GetBytes(chuoi.ToString());
                        //byte[] bytesE2 = Encoding.ASCII.GetBytes(E2_test);
                        if (chuoi.Trim() != E2_test && E2_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + img.Id);
                        }
                        else if (chuoi.Trim() == E2_test && E2_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 2,Hitpoint2 = 2, InfoP = 0 where  Id =" + img.Id);
                            dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = null,Content2 = null, ResultP=N'" + chuoi.Trim().ToString() + "' where  AllImageId =" + img.Id); //,STT_ID_PL = " + stt_type_PhanLoai + "
                        }
                    }
                    //dAEntry.AddImageContentP1(img.Id, chuoi.ToString(), userId, ms, stt_type_PhanLoai);
                }
                if (pair == 4)
                {
                    string E1_old = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + img.Id + " AND AllImage.NGP2 = 0 ");
                    if (E1_old == "")
                    {
                        dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 1 where  Id =" + img.Id);
                        dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + chuoi.Trim() + "', UserP2 = " + userId + ", DateP2=getdate(), TongkytuP2 =1,TimemilionP2 = " + ms + " where AllImageId=" + img.Id);
                        string E1_test = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + img.Id + " AND NGP1 = 0 AND NGP2 = 0");

                        string E2_NG = dAEntry.GetStringSQL("select NGP1 from db_owner.AllImage where Id = " + img.Id + "");
                        //byte[] bytesE1 = Encoding.ASCII.GetBytes(chuoi.ToString());
                        //byte[] bytesE2 = Encoding.ASCII.GetBytes(E2_test);
                        if (E2_NG != "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + img.Id);
                        }
                        if (chuoi.Trim() != E1_test && E1_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2 where  Id =" + img.Id);
                        }
                        else if (chuoi.Trim() == E1_test && E1_test != "" && E2_NG == "0")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 2,Hitpoint2 = 2, InfoP = 0 where  Id =" + img.Id);
                            dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = null,Content2 = null, ResultP=N'" + chuoi.Trim().ToString() + "' where  AllImageId =" + img.Id); //,STT_ID_PL = " + stt_type_PhanLoai + "
                        }
                    }
                    //dAEntry.AddImageContentP2(img.Id, chuoi.ToString(), userId, ms, stt_type_PhanLoai);
                }
            }
            view_Image_TN.Dispose();
            imageSource = null;
            idreturn = 0;
            if (listImage.Count > 0)
            {
                img = listImage[0];
                listImage.RemoveAt(0);
            }
            else
            {
                if (getanh)
                {
                    finish = true;
                    this.Close();
                    return;
                }
                else
                {
                    while (listImage.Count == 0)
                    {
                        btnNotgood.Enabled = false;
                        finish = true;
                        MessageBox.Show("Batch đã hoàn thành");
                        this.Close();
                        return;
                    }
                    img = listImage[0];
                    listImage.RemoveAt(0);
                }
            }
            try
            {
                idreturn = img.Id;
                //Get Image
                tenanh = dAEntry.Get_imgname(img.Id);
                imageSource = (Bitmap)img.Imagesource.Clone();
                imageSource_clone = imageSource;
                getbinary = dAEntry.ImageToByteArray(imageSource);
                //byte[] anhdaxoay = dAEntry.ImageToByteArray(imageSource);
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
                lblpage.Text = tenanh;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.PageUrl, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            grTempV.FindFilterText = "";
            //grTempV.FocusedRowHandle = get_index;
            dtimeBefore = DateTime.Now;
            //dtall = dAEntry.Get_AllTemplate();
            //grTemp.DataSource = dtall;
            //grTempV.RowCellClick += gridView1_RowCellClick;
            chuoi = "";
            txtTemp.Text = "";
            txtTemp.Focus();
            txtText.Text = "";
            lblpage.Text = img.PageUrl;
            txtTemp.Focus();
        }

        private void btnNotgood_Click_1(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - dtimeBefore;
            int ms = (int)span.TotalMilliseconds;
            chuoi = txtText.Text.Trim().Split('|')[0].ToString();
            if (idreturn != 0)
            {
                if (pair == 3)
                {
                    dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + chuoi + "', UserP1 = " + userId + ", DateP1=getdate(), TongkytuP1 =1,TimemilionP1 = " + ms + " where AllImageId=" + idreturn);
                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2,NGP1 =" + userId + " where  Id =" + idreturn);
                    // dAEntry.GetStringSQL("select NGP1 from db_owner.AllImage where Id = " + idreturn + "");
                    //    dAEntry.AddImageContentNGP1(idreturn, userId, ms);
                }
                if (pair == 4)
                {
                    dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + chuoi + "', UserP2 = " + userId + ", DateP2=getdate(), TongkytuP2 =1,TimemilionP2 = " + ms + " where AllImageId=" + idreturn);
                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2,NGP2 =" + userId + " where  Id =" + idreturn);
                    //    dAEntry.AddImageContentNGP2(idreturn, userId, ms);
                }
            }
            else
            {
                if (pair == 3)
                {
                    dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + chuoi + "', UserP1 = " + userId + ", DateP1=getdate(), TongkytuP1 =1,TimemilionP1 = " + ms + " where AllImageId=" + img.Id);
                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2,NGP1 =" + userId + " where  Id =" + img.Id);
                    //dAEntry.AddImageContentNGP1(img.Id, userId, ms);
                }
                if (pair == 4)
                {
                    dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + chuoi + "', UserP2 = " + userId + ", DateP2=getdate(), TongkytuP2 =1,TimemilionP2 = " + ms + " where AllImageId=" + img.Id);
                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoP = 2,NGP2 =" + userId + " where  Id =" + img.Id);
                    //dAEntry.AddImageContentNGP2(img.Id, userId, ms);
                }
            }
            view_Image_TN.Dispose();
            imageSource = null;
            idreturn = 0;
            if (listImage.Count > 0)
            {
                img = listImage[0];
                listImage.RemoveAt(0);
            }
            else
            {
                while (listImage.Count == 0)
                {
                    btnNotgood.Enabled = false;
                    finish = true;
                    MessageBox.Show("Batch đã hoàn thành");
                    this.Close();
                    return;
                }
                img = listImage[0];
                listImage.RemoveAt(0);
            }
            try
            {
                //Get Image
                idreturn = img.Id;
                //Get Image
                tenanh = dAEntry.Get_imgname(img.Id);
                imageSource = (Bitmap)img.Imagesource.Clone();
                imageSource_clone = imageSource;
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.PageUrl, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            grTempV.FindFilterText = "";
            //grTempV.FocusedRowHandle = get_index;
            dtimeBefore = DateTime.Now;
            //dtall = dAEntry.Get_AllTemplate();
            //grTemp.DataSource = dtall;
            //grTempV.RowCellClick += gridView1_RowCellClick;
            chuoi = "";
            txtTemp.Text = "";
            //txtText.Text = "";
            lblpage.Text = img.PageUrl;
            txtTemp.Focus();
            txtText.Text = "";
        }

        int row_now = 0;
        private void txtTemp_TextChanged(object sender, EventArgs e)
        {
            grTempV.FindFilterText = txtTemp.Text;
        }

        private void btnRtR_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("270");
        }

        private void btnRtL_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("90");
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = 0.2f;
        }

        private void timergetanh_Tick(object sender, EventArgs e)
        {
            if (listImage.Count < 2)
            {
                try
                {
                    int id = dAEntry.GetIDImage(pair);
                    if (id > 0)
                    {
                        BOImage_Entry img2 = new BOImage_Entry();
                        img2.PageUrl = dAEntry.Get_imgname(id);
                        img2.Id = id;
                        img2.Imagesource = new Bitmap(Io_Entry.byteArrayToImage(dAEntry.getImageOnServer(img2.PageUrl)));
                        listImage.Add(img2);
                        //if (listImage.Count == 0)
                        //{
                        //    getanh = true;
                        //}
                    }
                }
                catch
                {
                }
            }
            lblsoluong.Text = (dAEntry.ImageExistP(pair) + listImage.Count).ToString();
        }

        private void grTempV_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //int r = e.RowHandle;
            //if (r > -1)
            //{
            //    try
            //    {
            //        string color = "";
            //        for (int i = 0; i < dtall.Rows.Count; i++)
            //        {
            //            color = dtall.Rows[i][1].ToString().Substring(1,1);
            //            if (Convert.ToInt32(color) % 2 == 0)
            //            {
            //                e.Appearance.BackColor = Color.DeepSkyBlue;
            //                e.Appearance.BackColor2 = Color.LightCyan;
            //            }
            //            else
            //            {
            //                e.Appearance.BackColor = Color.White;
            //            }
            //        }
            //    }
            //    catch
            //    {
            //    }
            //}
        }

        private void grTempV_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            var cl = e.Column;
            string vl = "";
            if (e.CellValue != null)
            {
                vl = e.CellValue.ToString();
            }
            if (r > -1)
            {
                try
                {
                    if (cl.FieldName == "TemplateName")
                    {
                        string color = "";
                        color = vl.Substring(0, 5).Trim();
                        if (Convert.ToInt32(color) % 2 == 0)
                        {
                            e.Appearance.BackColor = Color.PowderBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.White;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void txtTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtTemp_Leave(sender, e);
            }
        }

        private void txtTemp_Leave(object sender, EventArgs e)
        {
            grTempV.Focus();
            //grTempV.FocusedRowHandle = 0;
            grTempV.FocusedColumn = grTempV.Columns[1];
        }
        int get_index = 0;
        private void grTempV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int r = grTempV.FocusedRowHandle;
            try
            {
                if (r > -1)
                {
                    if (get_index != 0)
                    {
                        //r = grTempV.FocusedRowHandle;
                        string data = grTempV.GetRowCellValue(get_index, grTempV.Columns["TemplateName"]).ToString();
                        chuoi = data;
                        string colum1 = grTempV.GetRowCellValue(r, "Colum1_1").ToString();
                        string colum2 = grTempV.GetRowCellValue(r, "Colum1_2").ToString();
                        string colum3 = grTempV.GetRowCellValue(r, "Colum1_3").ToString();
                        if (chuoi.Length > 0)
                        {
                            txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                        };
                        string poi_role = grTempV.GetRowCellValue(get_index, "Poi_Rules_Truong1").ToString();
                        DataTable role_tem = new DataTable();
                        role_tem = new DataTable();
                        role_tem.Columns.Add("Role");
                        role_tem.Columns.Add("Poi");
                        if (poi_role != "")
                        {
                            for (int i = 0; i < poi_role.Split('|').Length; i++)
                            {
                                role_tem.Rows.Add((i + 1).ToString(), poi_role.Split('|')[i].ToString());
                            }
                            imageSource_clone = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                            view_Image_TN.Image = drawimage(imageSource_clone, role_tem);
                            view_Image_TN.Invalidate(new Rectangle(1, 1, 1, 1));
                        }
                        else
                        {
                            view_Image_TN.Image = null;
                            //imageSource = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                            view_Image_TN.Image = imageSource;
                        }
                    }
                    else
                    {
                        string data = grTempV.GetRowCellValue(r, grTempV.Columns["TemplateName"]).ToString();
                        chuoi = data;
                        string colum1 = grTempV.GetRowCellValue(r, "Colum1_1").ToString();
                        string colum2 = grTempV.GetRowCellValue(r, "Colum1_2").ToString();
                        string colum3 = grTempV.GetRowCellValue(r, "Colum1_3").ToString();
                        if (chuoi.Length > 0)
                        {
                            txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                        };
                        string poi_role = grTempV.GetRowCellValue(r, "Poi_Rules_Truong1").ToString();
                        DataTable role_tem = new DataTable();
                        role_tem = new DataTable();
                        role_tem.Columns.Add("Role");
                        role_tem.Columns.Add("Poi");
                        if (poi_role != "" && poi_role != "||")
                        {
                            for (int i = 0; i < poi_role.Split('|').Length; i++)
                            {
                                role_tem.Rows.Add((i + 1).ToString(), poi_role.Split('|')[i].ToString());
                            }
                            imageSource_clone = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                            view_Image_TN.Image = drawimage(imageSource_clone, role_tem);
                            view_Image_TN.Invalidate(new Rectangle(1, 1, 1, 1));
                        }
                        else
                        {
                            //view_Image_TN.Dispose();
                            //imageSource = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                            //getbinary = dAEntry.ImageToByteArray(imageSource);
                            view_Image_TN.Image = imageSource;
                        }
                    }
                }
            }
            catch { Exception exception; }
        }
        int stt_type_PhanLoai;
        private void grTempV_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTemp.Text != "")
                {
                    string data = grTempV.GetRowCellValue(0, grTempV.Columns["TemplateName"]).ToString();
                    chuoi = data;
                    string colum1 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_1").ToString();
                    string colum2 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_2").ToString();
                    string colum3 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_3").ToString();
                    if (chuoi.Length > 0)
                    {
                        txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                    };
                    //stt_type_PhanLoai = Convert.ToInt32(data.Substring(0, 3));
                }
                else if (get_index > 0)
                {
                    string data = grTempV.GetRowCellValue(get_index, grTempV.Columns["TemplateName"]).ToString();
                    chuoi = data;
                    string colum1 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_1").ToString();
                    string colum2 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_2").ToString();
                    string colum3 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_3").ToString();
                    if (chuoi.Length > 0)
                    {
                        txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                    };
                    string poi_role = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Poi_Rules_Truong1").ToString();
                    DataTable role_tem = new DataTable();
                    role_tem = new DataTable();
                    role_tem.Columns.Add("Role");
                    role_tem.Columns.Add("Poi");
                    if (poi_role != "")
                    {
                        for (int i = 0; i < poi_role.Split('|').Length; i++)
                        {
                            role_tem.Rows.Add((i + 1).ToString(), poi_role.Split('|')[i].ToString());
                        }
                        imageSource_clone = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                        view_Image_TN.Image = drawimage(imageSource_clone, role_tem);
                        view_Image_TN.Invalidate(new Rectangle(1, 1, 1, 1));
                        dbzome = view_Image_TN.CurrentZoom;
                    }
                    else
                    {
                        //view_Image_TN.Image = null;
                        //imageSource = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
                        view_Image_TN.Image = imageSource;
                        dbzome = view_Image_TN.CurrentZoom;
                    }
                }
            }
            catch { Exception exception; }
        }
        private void grTempV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (grTempV.FocusedRowHandle == grTempV.RowCount - 1)
                {
                    grTempV.FocusedRowHandle = 0;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (grTempV.FocusedRowHandle == 0)
                {
                    grTempV.FocusedRowHandle = grTempV.RowCount - 1;
                    e.Handled = true;
                }
            }
           

        }
        byte[] binary;
        string resul;

        private void grTempV_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                chuoi = grTempV.GetRowCellValue(e.RowHandle, "TemplateName").ToString();
                string colum1 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_1").ToString();
                string colum2 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_2").ToString();
                string colum3 = grTempV.GetRowCellValue(e.RowHandle, "Colum1_3").ToString();
                if (chuoi.Length > 0)
                {
                    txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;

                }

            }
        }
        private void btnsop_Click(object sender, EventArgs e)
        {
            FrmSOP frmsop = new FrmSOP();
            binary = dAEntry.Get_imgsop(resul);
            frmsop.getimg = binary;
            frmsop.ShowDialog();
        }

        private void btnZI_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
        }

        private void btnZO_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
        }

        private void grTemp_Click(object sender, EventArgs e)
        {

        }

        private void grTemp_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
