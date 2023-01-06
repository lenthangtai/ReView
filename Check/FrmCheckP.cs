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
    public partial class FrmCheckP : Form
    {
        public static bool selecthitpoint = true;
        public int batchId;
        public int userId;
        public int pair;
        public int ImgId;
        private double scale = 1;
        public string userName;
        public string batchName;
        private int numbertrtxt = 0;
        int chuoiclick = 0;
        int idimg;
        bool getanh = false;
        DataTable dtbinary = new DataTable();
        DataTable dtbinary2;
        DataTable get_lstimage = new DataTable();
        DataTable get_lstimage2 = new DataTable();
        DataTable dtcontent = new DataTable();
        Bitmap imageSource;
        Image Image;
        Image Image2;
        Image Image3;
        List<BOImageContent_Check> ListImage = new List<BOImageContent_Check>();
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private DAEntry_Check dACheck = new DAEntry_Check();
        private BOImageContent_Check img = new BOImageContent_Check();
        private bool finish = false;
        DataTable dtall = new DataTable();
        DataTable dtallkt = new DataTable();
        private int zoomLevel;
        bool check = false;
        bool zoom = false;
        int tbindex = 0;
        int[] INFImage;
        int limitTime = 0;
        //var 140716
        int zom = 20;
        double tyle;
        double tyleImageNew = 1;
        Bitmap bm_out;
        List<TextBox> lsttxt = new List<TextBox>();
        double tong1 = 0;
        double tong2 = 0;
        int demsohang;
        string chuoi;
        string chuoi2;
        float dbzome;
        DateTime dtimeBefore = new DateTime();
        public FrmCheckP()
        { 
            InitializeComponent();
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {
            // hiển thị thông tin user
            this.Text = "Entry" + "                     UserName: " + userName;
            lblusername.Text = userName;
            lblbatchname.Text = batchName;
            dtall = dACheck.Get_AllTemplate();
            dtallkt = dACheck.Get_AllTemplate();
            grTemp.DataSource = dtall;
            grTempV.Columns[0].Visible = false;
            grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            idimg = dACheck.GetIdCheckP();
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
                    img = dACheck.GetImageCheckP(idimg);
                    imageSource = new Bitmap(Io_Entry.byteArrayToImage(dACheck.getImageOnServer(img.Uri)));
                    imageSource_clone = imageSource;
                    getbinary = dAEntry.ImageToByteArray(imageSource);
                    view_Image_TN.Image = imageSource;
                    dbzome = view_Image_TN.CurrentZoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sever chưa có ảnh");
                    this.Close();
                    return;
                }
            }
            txtTemp.ForeColor = Color.Red;
            txtTemp.Text = img.Contentp1;
            numbertrtxt = 0;
            string s1, s2;
            s1 = img.Contentp1;
            s2 = img.Contentp2;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length);
            try
            {
                lbluser1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
                lbluser2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            }
            catch
            {
                lbluser1.Text = "";
                lbluser2.Text = "";
            }
            lbluser1.ForeColor = Color.Red;
            lbluser2.ForeColor = Color.RoyalBlue;
            lblpage.Text = img.Uri;
            //grTempV.FindFilterText = txtTemp.Text;

            lblsoluong.Text = dACheck.ImageExistCP().ToString();// + ListImage.Count)
            dtimeBefore = DateTime.Now;
            txtTemp.Focus();
            txtTemp.Select(txtTemp.Text.Length, 0);
            //txtTem1.Focus();
            grTempV.RowCellClick += gridView1_RowCellClick;
            timergetanh.Start();
            grTempV.BestFitColumns();
        }
        Bitmap imageSource_clone;
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
                txtTemp.Text = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString();
                string colum1 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_1").ToString();
                string colum2 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_2").ToString();
                string colum3 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_3").ToString();
                if (grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString().Length > 0)
                {
                    txtText.Text = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString() + "|" + colum1 + "|" + colum2 + "|" + colum3;
                }
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
                }
                else
                {
                    view_Image_TN.Image = imageSource;
                    dbzome = view_Image_TN.CurrentZoom;
                }
            }
            else if (e.Clicks == 2)
            {
                chuoi = "";
                chuoi = grTempV.GetRowCellValue(e.RowHandle, "TemplateName").ToString();
                chuoi = chuoi.Substring(5);
                chuoiclick = 1;
            }
        }
        byte[] getbinary;
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
                    if (idimg != 0)
                    {
                        dACheck.Return_Hitpoint(idimg);
                        dACheck.Return_Hitpoint(img.Id);
                        for (int i = 0; i < ListImage.Count; i++)
                        {
                            dACheck.Return_Hitpoint(ListImage[i].Id);
                        }
                    }
                    else
                    {

                    }
                }
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                if (ms < 0)
                { ms = 4000; }
                dAEntry.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,Timeout,TypeOut, Lvl) values (" + batchId + ",N'" + batchName + "'," + userId + "," + ms + ",2, 0)");
            }
            catch { }
            return;
        }
        private void btnRR_Click(object sender, EventArgs e)
        {

        }

        private void btnRL_Click(object sender, EventArgs e)
        {

        }

        private void frmEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                //btnNotgood_Click_1(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (btnSubmit.Enabled == true)
                {
                    btnSubmit_Click(sender, e); e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Sự kiện Submit đang bị khóa !!!");
                    e.Handled = true;
                    return;
                }

            }
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
                    ////    view_Image_TN.Image = bm_out;
                    //}
                    //catch
                    //{

                    //}
                    #endregion
                    try
                    {
                        view_Image_TN.RotateImage("270");
                    }
                    catch
                    {
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    try
                    {
                        view_Image_TN.RotateImage("90");
                    }
                    catch
                    {
                    }

                    e.Handled = true;
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

                    //e.Handled = true;
                    #endregion
                }
                else if (e.KeyCode == Keys.F)
                {
                    view_Image_TN.CurrentZoom = dbzome;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Q)
                {

                        using (frmShowImage frmS = new frmShowImage())
                        {
                        //txtsoptem.Text = grTempV.GetRowCellValue(e.RowHandle, "TempName").ToString();
                        frmS.tempName = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString();
                            frmS.tempText = txtTemp.Text;
                            frmS.ShowDialog();
                        }
                    
                }
            }

        }

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

        private void bgwGetImage_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (ListImage.Count < 2)
            //{
            //    get_lstimage = dAEntry.Get_Binary(dtimage.Rows[0][0].ToString(), Convert.ToInt32(dtimage.Rows[0][0]), pair);
            //    if (get_lstimage.Rows.Count > 0)
            //    {
            //        try
            //        {
            //            Image2 = dAEntry.byteArrayToImage((byte[])get_lstimage.Rows[0][0]);
            //        }
            //        catch { Image2 = null; }
            //        ListImage.Add(Image2);
            //    }
            //    else
            //        break;
            //}
        }

        private void bgwGetImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblsoluong.Text = (dACheck.ImageExist()).ToString();
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
        int stt_type_PhanLoai;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int loisai1 = 0;
            int loisai2 = 0;
            if (txtTemp.Text == "")
            {
                MessageBox.Show("Form trống --> Return ", "Thông Báo");
                return;
                //if (MessageBox.Show("Mã số trống, bạn có báo Notgood không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //{
                //    btnNotgood_Click_1(sender, e);
                //}
                //else
                //{
                //    return;
                //}
            }
            DataRow[] index_data = dtallkt.Select("TemplateName ='" + txtTemp.Text + "'");
            stt_type_PhanLoai = Convert.ToInt32(index_data[0].ItemArray[0].ToString());
            if (dtallkt.Select("TemplateName ='" + txtTemp.Text + "'").Length > 0)
                chuoi = txtTemp.Text;
            else
            {
                MessageBox.Show("Vui lòng chọn lại dữ liệu");
                return;
            }
            view_Image_TN.Dispose();
            string rsCheck = "";
            string rsEntr1 = img.Contentp1;
            string rsEntr2 = img.Contentp2;
            rsCheck = chuoi;
            if (rsEntr1 != chuoi)
                loisai1 = 1;
            if (rsEntr2 != chuoi)
                loisai2 = 1;
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
            dACheck.Insert_ContentP(img.Id, loisai1, loisai2, chuoi.ToString(), userId, ms, 0);
            //dtimage
            idimg = 0;
            view_Image_TN.Dispose();
            imageSource = null;
            if (ListImage.Count > 0)
            {
                img = ListImage[0];
                idimg = img.Id;
                ListImage.RemoveAt(0);
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
                    while (ListImage.Count == 0)
                    {
                        btnNotgood.Enabled = false;
                        finish = true;
                        MessageBox.Show("Batch đã hoàn thành");
                        this.Close();
                        return;
                    }
                    img = ListImage[0];
                    ListImage.RemoveAt(0);
                }
            }
            try
            {
                //Get Image
                imageSource = (Bitmap)img.Imagesource.Clone();
                imageSource_clone = imageSource;
                getbinary = dAEntry.ImageToByteArray(imageSource);
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.Uri, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtTemp.ForeColor = Color.Red;
            txtTemp.Text = img.Contentp1;
            numbertrtxt = 0;
            string s1, s2;
            s1 = img.Contentp1;
            s2 = img.Contentp2;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length);
            try
            {
                lbluser1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
                lbluser2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            }
            catch
            {
                lbluser1.Text = "";
                lbluser2.Text = "";
            }
            lbluser1.ForeColor = Color.Red;
            lbluser2.ForeColor = Color.RoyalBlue;
            lblpage.Text = img.Uri;
            chuoiclick = 0;
            lblsoluong.Text = (dACheck.ImageExistCP() + ListImage.Count).ToString();
            dtimeBefore = DateTime.Now;
            txtTemp.Focus();
            txtTemp.Select(txtTemp.Text.Length, 0);
            timergetanh.Start();
        }

        private void btnNotgood_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg";
            saveFileDialog1.FileName = img.Uri;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string tenfile = saveFileDialog1.FileName;
                imageSource.Save(tenfile, ImageFormat.Tiff);
                dACheck.Insert_ContentNGP(img.Id, userId);
            }
            else
            {
                return;
            }
            view_Image_TN.Dispose();
            imageSource = null;
            idimg = 0;
            if (ListImage.Count > 0)
            {
                img = ListImage[0];
                idimg = img.Id;
                ListImage.RemoveAt(0);
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
                    while (ListImage.Count == 0)
                    {
                        btnNotgood.Enabled = false;
                        finish = true;
                        MessageBox.Show("Batch đã hoàn thành");
                        this.Close();
                        return;
                    }
                    img = ListImage[0];
                    ListImage.RemoveAt(0);
                }
            }
            try
            {
                //Get Image
                imageSource = (Bitmap)img.Imagesource.Clone();
                imageSource_clone = imageSource;
                getbinary = dAEntry.ImageToByteArray(imageSource);
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.Uri, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtTemp.ForeColor = Color.Red;
            txtTemp.Text = img.Contentp1;
            numbertrtxt = 0;
            string s1, s2;
            s1 = img.Contentp1;
            s2 = img.Contentp2;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length);
            try
            {
                lbluser1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
                lbluser2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            }
            catch
            {
                lbluser1.Text = "";
                lbluser2.Text = "";
            }
            lblpage.Text = img.Uri;
            grTempV.FindFilterText = txtTemp.Text;
            lblsoluong.Text = (dACheck.ImageExistCP() + ListImage.Count).ToString();
            dtimeBefore = DateTime.Now;
            txtTemp.Focus();
            txtTemp.Select(txtTemp.Text.Length, 0);
        }

        private void txtTemp_TextChanged(object sender, EventArgs e)
        {

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

        private void btnZO_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
        }

        private void btnZI_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
        }
        #region Compare string
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        static int[,] c;
        //Prints one LCS
        private string BackTrack(string s1, string s2, int i, int j)
        {
            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
            {
                txtTemp.SelectionStart = i - 1;
                txtTemp.SelectionLength = 1;
                txtTemp.SelectionColor = Color.Black;
                return BackTrack(s1, s2, i - 1, j - 1) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
                return BackTrack(s1, s2, i - 1, j);

            else
                return BackTrack(s1, s2, i, j - 1);

        }
        //Nghịch       
        private string BackTrack2(string s1, string s2, int i, int j)
        {
            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
            {
                return BackTrack2(s1, s2, i - 1, j - 1) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
                return BackTrack2(s1, s2, i - 1, j);

            else
                return BackTrack2(s1, s2, i, j - 1);

        }
        static int LCS(string s1, string s2)
        {
            for (int i = 1; i <= s1.Length; i++)
                c[i, 0] = 0;
            for (int i = 1; i <= s2.Length; i++)
                c[0, i] = 0;

            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                    {
                        c[i, j] = max(c[i - 1, j], c[i, j - 1]);

                    }

                }

            return c[s1.Length, s2.Length];

        }
        #endregion

        private void txtTemp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (txtTemp.Text == img.Contentp1)
                {
                    txtTemp.SelectionStart = 0;
                    txtTemp.SelectionLength = txtTemp.Text.Length;
                    txtTemp.SelectionColor = Color.Red;
                    txtTemp.Text = img.Contentp2;
                    numbertrtxt = txtTemp.TabIndex;
                    string s1, s2;
                    s1 = img.Contentp2;
                    s2 = img.Contentp1;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                    lbluser2.ForeColor = Color.Red;
                    lbluser1.ForeColor = Color.RoyalBlue;
                }
                else if (txtTemp.Text == img.Contentp2)
                {
                    txtTemp.SelectionStart = 0;
                    txtTemp.SelectionLength = txtTemp.Text.Length;
                    txtTemp.SelectionColor = Color.Red;
                    txtTemp.Text = img.Contentp1;
                    numbertrtxt = txtTemp.TabIndex;
                    string s1, s2;
                    s1 = img.Contentp1;
                    s2 = img.Contentp2;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                    lbluser1.ForeColor = Color.Red;
                    lbluser2.ForeColor = Color.RoyalBlue;
                }
                else
                {
                    txtTemp.SelectionStart = 0;
                    txtTemp.SelectionLength = txtTemp.Text.Length;
                    txtTemp.SelectionColor = Color.Red;
                    txtTemp.Text = img.Contentp1;
                    numbertrtxt = txtTemp.TabIndex;
                    string s1, s2;
                    s1 = img.Contentp1;
                    s2 = img.Contentp2;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                    lbluser1.ForeColor = Color.Red;
                    lbluser2.ForeColor = Color.RoyalBlue;
                }
            }
        }

        private void txtTemp_TextChanged_1(object sender, EventArgs e)
        {
            //grTempV.FindRow = txtTemp.Text;
            grTempV.FindFilterText = txtTemp.Text;
            //if (txtTemp.Text != "")
            //{
            try
            {
                string data = grTempV.GetRowCellValue(0, grTempV.Columns["TemplateName"]).ToString();
                chuoi = data;
                string colum1 = grTempV.GetRowCellValue(0, "Colum1_1").ToString();
                string colum2 = grTempV.GetRowCellValue(0, "Colum1_2").ToString();
                string colum3 = grTempV.GetRowCellValue(0, "Colum1_3").ToString();
                if (chuoi.Length > 0)
                {
                    txtText.Text = chuoi + "|" + colum1 + "|" + colum2 + "|" + colum3;
                };
                btnSubmit.Enabled = true;
            }
            catch
            {
                txtTemp.Text = "";
                MessageBox.Show("Không có Form --> Return ", "Thông Báo");
                btnSubmit.Enabled = false;
                return;
            }
            //}
        }

        private void txtTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 43)
                e.Handled = true;
        }

        private void timergetanh_Tick(object sender, EventArgs e)
        {
            if (ListImage.Count < 2)
            {
                try
                {
                    int idmg = dACheck.GetIdCheckP();
                    if (idmg > 0)
                    {
                        BOImageContent_Check img2 = dACheck.GetImageCheckP(idmg);
                        try
                        {
                            img2.Imagesource = new Bitmap(Io_Entry.byteArrayToImage(dACheck.getImageOnServer(img2.Uri)));
                        }
                        catch { img2.Imagesource = null; }
                        ListImage.Add(img2);
                        if (ListImage.Count == 0)
                        {
                            getanh = true;
                        }
                    }
                }
                catch
                {
                }
            }
            else { timergetanh.Stop(); }
        }

        private void grTempV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int r = grTempV.FocusedRowHandle;
            try
            {
                if (r > -1)
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
                }
            }
            catch { }
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
            //int dong = grTempV.FocusedRowHandle;

        }

        private void grTempV_RowCountChanged(object sender, EventArgs e)
        {
            //if (txtTemp.Text != "")
            //{
            //    string data = grTempV.GetRowCellValue(0, grTempV.Columns["TemplateName"]).ToString();
            //    txtTemp.Text = data.Substring(5);
            //    chuoi = data;
            //    stt_type_PhanLoai = Convert.ToInt32(data.Substring(0, 3));
            //}
        }

        private void txtTem1_TextChanged(object sender, EventArgs e)
        {
            //grTempV.FindFilterText = txtTem1.Text;
        }

        private void grTempV_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //if (e.Clicks == 1)
            //{
            //    txtTemp.Text = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString();
            //    string colum1 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_1").ToString();
            //    string colum2 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_2").ToString();
            //    string colum3 = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Colum1_3").ToString();
            //    if (grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString().Length > 0)
            //    {
            //        txtText.Text = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "TemplateName").ToString() + "|" + colum1 + "|" + colum2 + "|" + colum3;
            //    }
            //    string poi_role = grTempV.GetRowCellValue(grTempV.FocusedRowHandle, "Poi_Rules_Truong1").ToString();
            //    DataTable role_tem = new DataTable();
            //    role_tem = new DataTable();
            //    role_tem.Columns.Add("Role");
            //    role_tem.Columns.Add("Poi");
            //    if (poi_role != "")
            //    {
            //        for (int i = 0; i < poi_role.Split('|').Length; i++)
            //        {
            //            role_tem.Rows.Add((i + 1).ToString(), poi_role.Split('|')[i].ToString());
            //        }
            //        imageSource_clone = new Bitmap(Io_Entry.byteArrayToImage(getbinary));
            //        view_Image_TN.Image = drawimage(imageSource_clone, role_tem);
            //        view_Image_TN.Invalidate(new Rectangle(1, 1, 1, 1));
            //    }
            //    else
            //    {
            //        view_Image_TN.Image = imageSource;
            //        dbzome = view_Image_TN.CurrentZoom;
            //    }
            //}
            //else if (e.Clicks == 2)
            //{
            //    chuoi = "";
            //    chuoi = grTempV.GetRowCellValue(e.RowHandle, "TemplateName").ToString();
            //    chuoi = chuoi.Substring(5);
            //    chuoiclick = 1;
            //}
        }

        #region updateCode
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
        private void grTempV_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion
    }
}
