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
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace VCB_TEGAKI
{
    public partial class frmEntry : Form
    {
        public static bool selecthitpoint = true;    
        public int batchId;
        public int userId;
        public int pair;
        private double scale = 1;
        public string userName;
        public string batchName;
        int idreturn;
        DataTable dtimage;
        DataTable dtbinary;
        DataTable dtbinary2;
        Bitmap imageSource;
        List<BOImage_Entry> ListImage = new List<BOImage_Entry>();     
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private BOImage_Entry img = new BOImage_Entry();
        FrmSOP frmsop = new FrmSOP();
        private bool finish = false;
        bool getanh = false;
        byte[] binary;
        string x2, x3, x4, x5;
        private int zoomLevel;
        bool check = false;
        bool zoom = false;
        int tbindex = 0;
        string resul;
        int lbtong;
        string tenanh;
        int[] INFImage;
        int idimg;
        int[] arr2 = Enumerable.Range(1, 1000).ToArray();
        int[] arr3 = Enumerable.Range(1, 1000).ToArray();
        int[] arr4 = Enumerable.Range(1, 1000).ToArray();
        int[] arr5 = Enumerable.Range(1, 1000).ToArray();
        int[] arr6 = Enumerable.Range(1, 1000).ToArray();
        int[] arr7 = Enumerable.Range(1, 1000).ToArray();
        int[] arr8 = Enumerable.Range(1, 1000).ToArray();
        int[] arr9 = Enumerable.Range(1, 1000).ToArray();
        int limitTime = 0;
        //var 140716
        int zom = 20;
        string maso = "";
        double tyle;
        double tyleImageNew = 1;
        Bitmap bm_out;
        List<TextBox> lsttxt = new List<TextBox>();
        List<Label> lstlb = new List<Label>();
        List<TextBox> lstlb_dong = new List<TextBox>();
        double tong1 = 0;
        double tong2 = 0;
        double zomm = 1;
        float dbzome;
        int demsohang;
        //List<TextBox> lst_strCoopy;
        DateTime dtimeBefore = new DateTime();
        string str_Coopy = "";
        List<TextBox> lst_truot;
        public frmEntry()
        {
            InitializeComponent();
            System.Drawing.Size size;
            lsttxt = new List<TextBox>() { txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9};
            lstlb = new List<Label>() { lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9};
            lstlb_dong = new List<TextBox>() { txtlb2, txtlb3, txtlb4, txtlb5, txtlb6, txtlb7, txtlb8, txtlb9 };
            //lst_strCoopy = new List<TextBox>() { txt5, txt8, txt10 };txtlb2
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {            
            lsttxt.ForEach(a =>
            {
                a.Enter += new System.EventHandler(this.TextBox_Enter);
                a.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
                a.Leave += new System.EventHandler(this.TextBox_Leave);
                a.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
                a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
                a.Click += new System.EventHandler(this.TextBox_Click);
                a.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt1_KeyUp);                
            });
            // hiển thị thông tin user
            this.Text = "Entry" + "                     UserName: " + userName + " -- Batch:  " + batchName;
            //userid
            int uID = userId;
            this.CenterToScreen();
            idimg = dAEntry.GetIDImage(pair);
            if (idimg == 0)
            {
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
                    view_Image_TN.Image = imageSource;
                    dbzome = view_Image_TN.CurrentZoom;                   
                    lblpage.Text = tenanh;
                }
                catch
                {
                    MessageBox.Show("Server chưa có ảnh");
                    this.Close();
                    return;
                }
            }
            idreturn = idimg;
            Logic(idreturn);
            //bgwGetImage.RunWorkerAsync();
            timergetimage.Start();
            dtimeBefore = DateTime.Now;
            zom = 20;
            lblsoluong.Text = (dAEntry.ImageExistEntry(pair) + ListImage.Count).ToString();
            finish = false;
        }

        #region focus
        public Bitmap ResizeHeight(Bitmap image, int newWidth, int newHeight, string message)
        {
            try
            {
                Bitmap newImage = new Bitmap(image, newWidth, newHeight);

                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));

                    var myBrush = new SolidBrush(Color.FromArgb(70, 205, 205, 205));

                    double diagonal = Math.Sqrt(newImage.Width * newImage.Width + newImage.Height * newImage.Height);

                    Rectangle containerBox = new Rectangle();

                    containerBox.X = (int)(diagonal / 10);
                    float messageLength = (float)(diagonal / message.Length * 1);
                    containerBox.Y = -(int)(messageLength / 1.6);

                    Font stringFont = new Font("verdana", messageLength);

                    StringFormat sf = new StringFormat();

                    float slope = (float)(Math.Atan2(newImage.Height, newImage.Width) * 180 / Math.PI);

                    gr.RotateTransform(slope);
                    gr.DrawString(message, stringFont, myBrush, containerBox, sf);
                    return newImage;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public int CalculationsHeight(decimal w1, decimal h1, int newWidth)
        {
            decimal height = 0;
            decimal ratio = 0;


            if (newWidth < w1)
            {
                ratio = w1 / newWidth;
                height = h1 / ratio;

                return Convert.ToInt32(height);
            }

            if (w1 < newWidth)
            {
                ratio = newWidth / w1;
                height = h1 * ratio;
                return Convert.ToInt32(height);
            }

            return Convert.ToInt32(height);
        }
        public Bitmap ResizeWith(Bitmap image, int newWidth, int newHeight, string message)
        {
            try
            {
                Bitmap newImage = new Bitmap(image, newWidth, newHeight);

                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));

                    var myBrush = new SolidBrush(Color.FromArgb(70, 205, 205, 205));

                    double diagonal = Math.Sqrt(newImage.Width * newImage.Width + newImage.Height * newImage.Height);

                    Rectangle containerBox = new Rectangle();

                    containerBox.X = (int)(diagonal / 10);
                    float messageLength = (float)(diagonal / message.Length * 1);
                    containerBox.Y = -(int)(messageLength / 1.6);

                    Font stringFont = new Font("verdana", messageLength);

                    StringFormat sf = new StringFormat();

                    float slope = (float)(Math.Atan2(newImage.Height, newImage.Width) * 180 / Math.PI);

                    gr.RotateTransform(slope);
                    gr.DrawString(message, stringFont, myBrush, containerBox, sf);
                    return newImage;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public int CalculationsWith(decimal w1, decimal h1, int newWidth)
        {
            decimal height = 0;
            decimal ratio = 0;


            if (newWidth < w1)
            {
                ratio = w1 / newWidth;
                height = h1 / ratio;
                return Convert.ToInt32(height);
            }

            if (w1 < newWidth)
            {
                ratio = newWidth / w1;
                height = h1 * ratio;
                return Convert.ToInt32(height);
            }

            return Convert.ToInt32(height);
        }
        int Type_Image; string data_form6 = "";
        DataTable role_tem = new DataTable();
        public void Logic(int id)
        {
            resul = "";
            string str = "";
            binary = null;
            string[] arrrole = null;
            int temid = 0;
            lsttxt.ForEach(x => x.Text = ""); lstlb_dong.ForEach(x => x.Text = "");
            for (int i = 0; i < lsttxt.Count; i++)
            {
                lsttxt[i].Visible = false;
                lstlb[i].Visible = false;
                lstlb_dong[i].Visible = false;
            }
            resul = dAEntry.Get_Result(id);
            DataTable dt_info_ID = new DataTable();
            dt_info_ID = dAEntry.GetDatatableSQL("Select * from dbo.[Template] where TempName = N'" + resul + "'");
            str = dt_info_ID.Rows[0]["Rules"].ToString();
            maso = dt_info_ID.Rows[0]["CodeNumber"].ToString();
            temid = Convert.ToInt32(dt_info_ID.Rows[0]["Id"].ToString());
            data_form6 = dt_info_ID.Rows[0]["Form6"].ToString();
            if (data_form6 != "")
            {
                string data_show_6 = "";
                for (int i = 0; i < data_form6.Split('|').Length; i++)
                {
                    data_show_6 += data_form6.Split('|')[i].Split('‡')[0].ToString() + "\r\n";
                }
                lbl_6_chuthich.Text = data_show_6;
            }
            else
            {
                lbl_6_chuthich.Text = "";
            }
            arrrole = str.Split(',');
            //lsttxt[7].Text = "";
            // SHow or Hide Truong
            for (int i = 0; i < arrrole.Length; i++)
            {
                lsttxt[Convert.ToInt32(arrrole[i]) - 2].Visible = true;
                lstlb[Convert.ToInt32(arrrole[i]) - 2].Visible = true;
                lstlb_dong[Convert.ToInt32(arrrole[i]) - 2].Visible = true;
            }
            // Design Truong 7 8 9
            
            if (lsttxt[1].Visible == true)
            {
                lsttxt[1].Focus();
                return;
            }
            else if (lsttxt[6].Visible == true)
            {
                lsttxt[6].Focus();
                return;
            }
            else
            {
                for (int i = 0; i < lsttxt.Count; i++)
                {
                    if (lsttxt[i].Visible == true)
                    {
                        lsttxt[i].Focus();
                        break;
                    }
                }
            }
            string poi_rule = dt_info_ID.Rows[0]["Poi_Rules"].ToString();
            role_tem = new DataTable();
            role_tem.Columns.Add("Role");
            role_tem.Columns.Add("Poi");
            for (int i = 0; i < poi_rule.Split('|').Length; i++)
            {
                role_tem.Rows.Add(arrrole[i], poi_rule.Split('|')[i].ToString());
            }
            drawimage();
            txtlb3.Visible = false;
        }
        #endregion
        private Graphics graphics;
        Pen PEN_DRAW = new Pen(Color.Red, 2);
        Pen PEN_DRAW_BLUE = new Pen(Color.Blue, 2);
        Brush BRUSH = new SolidBrush(Color.FromArgb(30, 127, 255, 0));
        Pen LineRed = new Pen(Color.Red, 3);
        //public void zoomimage()
        //{
        //    if (pb_img.Image != null)
        //    {
        //        scale = (double)dbzome / 9;
        //        //this.Text = valuezom + " - " + scale.ToString();
        //        pb_img.Image = Common.ZoomImage((Bitmap)imageSource, scale);
        //        drawimage();
        //    }
        //}
        public void drawimage()
        {
            DataTable dtv = role_tem;
            //DataTable dtvmsdt = role_tem;
            int _x = 0;
            int _y = 0;
            int wid = 0;
            int hei = 0;
            pb_img.Refresh();
            for (int i = 0; i < dtv.Rows.Count; i++)
            {
                try
                {
                    //dtv.Rows[i][0] = (i + 1).ToString().PadLeft(2, '0');
                    _x = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[0]) * scale);
                    _y = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[1]) * scale);
                    wid = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[2]) * scale);
                    hei = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[3]) * scale);
                    //graphics = pb_img.CreateGraphics();
                    //graphics.DrawRectangle(PEN_DRAW, _x, _y, wid, hei);
                    //graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
                    //graphics.DrawString((i + 1).ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Red), _x, _y);
                    //graphics.DrawString(dtv.Rows[i][0].ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Red), _x, _y);
                    using (Graphics graphics = Graphics.FromImage(imageSource))
                    {
                        graphics.DrawRectangle(LineRed, _x, _y, wid, hei);
                        graphics.DrawString(dtv.Rows[i][0].ToString(), new Font("Arial", 50), new SolidBrush(Color.Red), _x,_y);
                    }
                }
                catch { }
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
        }
        #region close
        //public Bitmap ResizeByWidth(Image img, int width)
        //{
        //    // lấy chiều rộng và chiều cao ban đầu của ảnh
        //    int originalW = img.Width;
        //    int originalH = img.Height;

        //    // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh
        //    int resizedW = width;
        //    int resizedH = (originalH * resizedW) / originalW;

        //    // tạo một Bitmap có kích thước tương ứng với chiều rộng và chiều cao mới
        //    Bitmap bmp = new Bitmap(resizedW, resizedH);

        //    // tạo mới một đối tượng từ Bitmap
        //    Graphics graphic = Graphics.FromImage((Image)bmp);
        //    graphic.InterpolationMode = InterpolationMode.High;

        //    // vẽ lại ảnh với kích thước mới
        //    graphic.DrawImage(img, 0, 0, resizedW, resizedH);

        //    // gải phóng resource cho đối tượng graphic
        //    graphic.Dispose();

        //    // trả về anh sau khi đã resize
        //    return bmp;
        //}
        //public Bitmap ResizeByHeight(Image img, int height)
        //{
        //    // lấy chiều rộng và chiều cao ban đầu của ảnh
        //    int originalW = img.Width;
        //    int originalH = img.Height;

        //    // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh


        //    int resizedH = height;
        //    int resizedW = (originalW * resizedH) / originalH;
        //    // tạo một Bitmap có kích thước tương ứng với chiều rộng và chiều cao mới
        //    Bitmap bmp = new Bitmap(resizedW, resizedH);

        //    // tạo mới một đối tượng từ Bitmap
        //    Graphics graphic = Graphics.FromImage((Image)bmp);
        //    graphic.InterpolationMode = InterpolationMode.High;

        //    // vẽ lại ảnh với kích thước mới
        //    graphic.DrawImage(img, 0, 0, resizedW, resizedH);

        //    // gải phóng resource cho đối tượng graphic
        //    graphic.Dispose();

        //    // trả về anh sau khi đã resize
        //    return bmp;
        //}
        #endregion
        private void frmEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!finish)
                {
                    dAEntry.Return_HitpointEntry(idreturn, pair);
                    dAEntry.Return_HitpointEntry(img.Id, pair);       
                    for (int i = 0; i < ListImage.Count; i++)
                    {
                        dAEntry.Return_HitpointEntry(ListImage[i].Id, pair);
                    }
                    try
                    {
                        if(idreturn <= 0)
                        {
                            idreturn = img.Id;
                        }
                        string User_exit = dAEntry.GetStringSQL("Select User_Exit_Img_E" + pair + " from db_owner.[ImageContent] where Id = " + idreturn + "");
                        string UserName = dAEntry.GetStringSQL("Select Fullname from db_owner.[AllUser] where Id = " + userId + "");
                        if (User_exit == "" || User_exit == "NULL")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set User_Exit_Img_E" + pair + " = N'" + UserName + " -- " + DateTime.Now.ToString("yyyyMMdd:HHmmss") + "' where Id = " + idreturn + "");
                        }
                        else
                        {
                            string info_user_error = User_exit + "\r\n" + UserName + "-- " + DateTime.Now.ToString("yyyyMMdd: HHmmss");
                            dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set User_Exit_Img_E" + pair + " = N'"+ info_user_error + "' where Id = " + idreturn + "");
                        }
                    }
                    catch {}
                }
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                if (ms < 0)
                { ms = 4000; }
                //string[] arr = lsttxt.Select(x => x.Text.Trim().ToLower()).ToArray();
                //string imgContentContent = String.Join("", arr);
                //int lng = txtcten.Text.Length;
                string[] arr = lsttxt.Select(x => x.Text.Trim()).ToArray();
                string imgContentContent = String.Join("|", arr);

                imgContentContent = imgContentContent.Replace("\r", "");
                int lng = imgContentContent.Length - 8;
                string imgContent = "";
                int imgContentImageId = 0;
                int lng_saveout = Convert.ToInt32(imgContentContent.Replace("|", "").Length);
                dAEntry.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,Timeout,Charout,TypeOut, Lvl) values (" + batchId + ",N'" + batchName + "'," + userId + "," + ms + "," + lng_saveout + ",1, 0)");
                
            }
            catch { }
            return;
        }        
        protected System.Drawing.Point clickPosition;
        protected System.Drawing.Point scrollPosition;
        private void picBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            this.clickPosition.X = e.X;
            this.clickPosition.Y = e.Y;
        }
        private void frmEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.Control)
            {
                //if (e.KeyCode == Keys.N)
                //{
                //    btnNotgood_Click(sender, e);
                //}
                if (e.KeyCode == Keys.E)
                {
                    txt3.Text = str_data_truong3;
                    txt3.Focus();
                    txt3.SelectionStart = txt3.Text.Length;
                }
                 if (e.KeyCode == Keys.Enter)
                {
                    btnSubmit_Click(sender, e);
                    e.Handled = true;
                }
                
                if (e.KeyCode == Keys.Q)
                {
                    btnsop_Click(sender, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F)
                {
                    view_Image_TN.CurrentZoom = dbzome;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
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
                }
                else if (e.KeyCode == Keys.Add)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
            }
        }
        private void frmEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == 43)
                    e.Handled = true;
                //if (e.KeyChar == 10)
                //    e.Handled = true;
                if (e.KeyChar == 13)
                    e.Handled = true;
        }
        private void frmEntry_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ( e.KeyCode == Keys.Enter)
            {
            }
            if (e.KeyCode == Keys.Delete)
            {
                tb.Text = ""; tb.Focus();tb.SelectionStart = 0;
            }
            if (e.KeyCode == Keys.Add)
            {
                #region
                try
                {
                    string str_data_select = lsttxt[tb.TabIndex - 2].Text.ToString();
                    if (str_data_select.Split('\n').Length > 1)
                    {
                        lsttxt[tb.TabIndex - 2].Text = str_data_select + lsttxt[tb.TabIndex - 2].Text.ToString().Split('\n')[lsttxt[tb.TabIndex - 2].Text.ToString().Split('\n').Length - 2].ToString().Replace("\r","").ToString();
                    }
                    lsttxt[tb.TabIndex - 2].SelectionStart = lsttxt[tb.TabIndex - 2].Text.Length;
                }
                catch
                {
                }
                #region
                //try
                //{
                //    if ( tb.TabIndex ==2)
                //    {

                //        string[] arrtach = null;
                //        arrtach = tb.Text.Split('\r').ToArray();
                //        tb.Text = tb.Text + arrtach[arrtach.Length - 2].Replace("\n", ""); //+ "\n";
                //        tb.SelectionStart = tb.Text.Length;
                //    }
                ////    if (tb.TabIndex == 9)
                ////    {
                ////        string[] arrtach = null;
                ////        arrtach = tb.Text.Split('\r').ToArray();
                ////        //tb.Text = tb.Text + arrtach[arrtach.Length - 2]; //+ "\n";
                ////        Clipboard.Clear();
                ////        Clipboard.SetText(arrtach[arrtach.Length - 2].Replace("\n", ""));
                ////        SendKeys.Send("^{v}");
                ////        tb.SelectionStart = tb.Text.Length;
                ////    }
                ////    else
                ////    {
                //    if (tb.TabIndex == 5 || tb.TabIndex == 6 || tb.TabIndex == 7 || tb.TabIndex == 8 || tb.TabIndex == 1)
                //    {
                //        string[] arrtach = null;
                //        arrtach = tb.Text.Split('\r').ToArray();
                //        tb.Text = tb.Text + arrtach[arrtach.Length - 2].Replace("\n", ""); //+ "\n";
                //        tb.SelectionStart = tb.Text.Length;
                //    }
                //    //}
                //}
                //catch
                //{
                //}
                #endregion
                #endregion
            }
            if (e.Control)
            {
                #region
                //if (e.KeyCode == Keys.NumPad1)
                //{
                //    //Clipboard.Clear();
                //    //Clipboard.SetText("4977564");
                //    //SendKeys.Send("^{v}");
                //    ////tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    tb.Text = tb.Text + "4977564";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad2)
                //{
                //    //Clipboard.Clear();
                //    //Clipboard.SetText("AM必着");
                //    //SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "AM必着";
                //    tb.AppendText("AM必着");
                //    return;
                //    //tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad3)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("階定番分");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "階定番分";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad4)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("様");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad5)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("ﾒｰｶｰ別棚");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad6)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("ﾌｼﾞ棚");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad7)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("共通棚");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad8)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("ネット　東港午前必着");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else if (e.KeyCode == Keys.NumPad9)
                //{
                //    Clipboard.Clear();
                //    Clipboard.SetText("×");
                //    SendKeys.Send("^{v}");
                //    //tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //tb.Text = tb.Text + "様";
                //    tb.SelectionStart = tb.Text.Length;
                //}
                //else 
                if (e.KeyCode == Keys.Subtract)
                {
                    tb.Text = "";
                }
                if (e.KeyCode == Keys.E)
                {
                    #region
                    //if (type_1 == Type_Image)
                    //{
                    //    if (tb.TabIndex == 0)
                    //    {
                    //        txt8.Text = str_Coopy.Split('‡')[1].ToString();
                    //        tb.SelectionStart = tb.Text.Length;
                    //    }
                    //    else if (tb.TabIndex == 1)
                    //    {
                    //        txt5.Text = str_Coopy.Split('‡')[0].ToString();
                    //        tb.SelectionStart = tb.Text.Length;
                    //    }
                    //    else if (tb.TabIndex == 4)
                    //    {
                    //        txt10.Text = str_Coopy.Split('‡')[2].ToString();
                    //        tb.SelectionStart = tb.Text.Length;
                    //    }
                    //    //for (int i = 0; i < lst_strCoopy.Count; i++)
                    //    //{
                    //    //    if (lst_strCoopy[i].Visible == true)
                    //    //    {
                    //    //        if ( txt5.Focus() == true)
                    //    //        {
                    //    //            txt5.Text = str_Coopy.Split('‡')[0].ToString();
                    //    //        }
                    //    //        else if ( txt6.Focus() ==true)
                    //    //        {
                    //    //            txt6.Text = str_Coopy.Split('‡')[1].ToString();
                    //    //        }
                    //    //        else if (txt10.Focus() == true)
                    //    //        {
                    //    //            txt10.Text = str_Coopy.Split('‡')[2].ToString();
                    //    //        }
                    //    //    }
                    //    //}
                    //}
                    //e.Handled = true;
                    #endregion
                }
                #endregion
            }
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.PowderBlue;
            tb.SelectionStart = tb.Text.Length + 1;
        }
        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;           
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = SystemColors.Window;
            tb.Text = tb.Text.ToUpper();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (e.KeyChar == 43)
                e.Handled = true;
            if (e.KeyChar == 13)
                e.Handled = true;
            if (e.KeyChar == 10)
                e.Handled = true;
            if (tb.TabIndex == 5)
            {
                if (e.KeyChar == 45)
                {
                    e.Handled = true;
                }
            }
            if (tb.TabIndex == 5)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            else if (tb.TabIndex == 6)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }      
        private void timergetimage_Tick(object sender, EventArgs e)
        {
            if (ListImage.Count < 1)
            {
                int id = dAEntry.GetIDImage(pair);
                if (id>0)
                {
                    BOImage_Entry img2 = new BOImage_Entry();
                    img2.PageUrl = dAEntry.Get_imgname(id);
                    img2.Id = id;
                    img2.Imagesource = new Bitmap(Io_Entry.byteArrayToImage(dAEntry.getImageOnServer(img2.PageUrl)));
                    ListImage.Add(img2);
                    if (ListImage.Count == 0)
                    {
                        getanh = true;
                    }           
                }               
            }            
        }
        private void txt2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }
        private void txt1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;           
        }
        private void view_Image_TN_MouseHover(object sender, EventArgs e)
        {
            view_Image_TN.Focus();
        }
        string conten_saveout = "";
        int type_1 = 0;
        private const uint LOCALE_SYSTEM_DEFAULT = 0x0800;
        private const uint LCMAP_HALFWIDTH = 0x00400000;
        public static string ToHalfWidth(string fullWidth)
        {
            StringBuilder sb = new StringBuilder(6144);
            LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_HALFWIDTH, fullWidth, -1, sb, sb.Capacity);
            return sb.ToString();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int LCMapString(uint Locale, uint dwMapFlags, string lpSrcStr, int cchSrc, StringBuilder lpDestStr, int cchDest);
        private const uint LCMAP_FULLWIDTH = 0x00800000;
        public static string ToFullWidth(string halfWidth)
        {
            StringBuilder sb = new StringBuilder(256);
            LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_FULLWIDTH, halfWidth, -1, sb, sb.Capacity);
            return sb.ToString();
        }
        string str_data_truong3 = "";
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int sohang4 = 0;            
            sohang4 =  txt4.Text.Split('\n').Length;
            for (int i = 0; i < lsttxt.Count; i++)
            {
                if (lsttxt[i].Visible == true)
                {
                    if (i != 1 && i != 6)
                    {
                        if (i == 5)
                        {
                            if (resul != "11-1" && resul != "11-2")
                            {
                                int sohang_txt = lsttxt[i].Text.Split('\n').Length;
                                if (sohang4 != sohang_txt)
                                {
                                    MessageBox.Show("Dữ liệu các trường khác nhau -- Trường " + (i + 2) + " khác Trường 4 ");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            int sohang_txt = lsttxt[i].Text.Split('\n').Length;
                            if (sohang4 != sohang_txt)
                            {
                                MessageBox.Show("Dữ liệu các trường khác nhau -- Trường " + (i + 2) + " khác Trường 4 ");
                                return;
                            }
                        }
                    }
                }
            }
            if (txt6.Visible == true)
            {
                if (data_form6 != "")
                {
                    string str_txt6 = txt6.Text.ToString();
                    str_txt6 = str_txt6.Replace("\r", "").Replace("\n", "‡").ToString();
                    string[] lst_str_content6 = str_txt6.Split('‡');
                    List<string> array_1 = new List<string> { };
                    List<string> array_2 = new List<string> { };
                    for (int i = 0; i < data_form6.Split('|').Length; i++)
                    {
                        array_1.Add(data_form6.Split('|')[i].ToString().Split(':')[0].ToString());
                        array_2.Add(data_form6.Split('|')[i].ToString().Split('‡')[1].ToString());
                    }
                    for (int i = 0; i < lst_str_content6.Length; i++)
                    {
                        int index_array_1 = array_1.IndexOf(lst_str_content6[i].ToString());
                        if (index_array_1 > -1)
                        {
                            lst_str_content6[i] = array_2[index_array_1].ToString();
                        }
                        else
                        {
                            lst_str_content6[i] = "";
                        }
                    }
                    txt6.Text = string.Join("\n", lst_str_content6);
                }
            }
            #region
            //// Set điều kiện ở trường 7
            ////if (txt5.Visible == true)
            ////{
            ////    if (txt5.Text != "" && txt5.Text.Length != 8)
            ////    {
            ////        MessageBox.Show("Quy tắc Sai Trường 5: Ngày Tháng !", "Thông Báo");
            ////        txt5.Focus();
            ////        txt5.SelectionStart = txt5.Text.Length;
            ////        return;
            ////    }
            ////}

            //if (txt2.Text == "" || txt4.Text == "")
            //{
            //    MessageBox.Show("Quy tắc Sai: Trường 2, 3 bắt buộc phải có dữ liệu !", "Thông Báo");
            //    return;
            //}
            //sohang2 = txt2.Text.Split('\n').Length;
            //if (txt2.Visible == true)
            //{
            //    for (int i = 0; i < sohang2; i++)
            //    {
            //        if (txt2.Text.Replace("\r","").Split('\n')[i].ToString() == "")
            //        {
            //            MessageBox.Show("Quy Định Trường 2 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //            txt2.Focus();
            //            return;
            //        }
            //    }
            //}
            //sohang3 = txt4.Text.Split('\n').Length;
            //if (txt4.Visible == true)
            //{
            //    for (int i = 0; i < sohang3; i++)
            //    {
            //        if (txt4.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //        {
            //            MessageBox.Show("Quy Định Trường 2 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //            txt4.Focus();
            //            return;
            //        }
            //    }
            //}
            //arr2 = txt2.Text.Split('\n').ToArray();
            //arr3 = txt4.Text.Split('\n').ToArray();
            //sohang4 = txt5.Text.Split('\n').Length;
            //if (txt5.Visible == true)
            //{
            //    for (int i = 0; i < sohang4; i++)
            //    {
            //        if (txt5.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //        {
            //            MessageBox.Show("Quy Định Trường 4 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //            txt5.Focus();
            //            return;
            //        }
            //    }

            //}
            //#region Haipm thêm yêu cầu mới 19042021
            //// thêm mới 19042021 Haipm
            //sohang5 = txt5.Text.Split('\n').Length;
            //arr5 = txt5.Text.Split('\n').ToArray();

            //#endregion
            //if ( txt9.Visible == true )
            //{
            //    sohang8 = txt9.Text.Split('\n').Length;
            //}

            ////sohang8 = txt8.Text.Split('\n').Length;
            //bool checktruong8 = false;
            //if (txt9.Visible == true )
            //{
            //    sohang8 = txt9.Text.Split('\n').Length;
            //    int rule_8 = dAEntry.GetIntSQL("Select isnull(set_Rule_8,0)  as N'set_Rule_8' from dbo.[Template] where Id = " + Type_Image + "");
            //    if(rule_8 ==1)
            //    {
            //        if (txt9.Text != "")
            //        {
            //            for (int i = 0; i < sohang8; i++)
            //            {
            //                if (txt9.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //                {
            //                    MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //                    txt9.Focus();
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            DialogResult dialogResult = MessageBox.Show("Trường số 8 trống bạn có muốn qua phiếu không?", "Thông báo", MessageBoxButtons.YesNo);
            //            if (dialogResult == DialogResult.No)
            //            {
            //                txt9.Focus();
            //                return;
            //            }
            //            else
            //            {
            //                checktruong8 = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < sohang8; i++)
            //        {
            //            if (txt9.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //            {
            //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //                txt9.Focus();
            //                return;
            //            }
            //        }
            //    }
            //    #region đóng code
            //    //if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            //    //{
            //    //    if (txt8.Text != "")
            //    //    {
            //    //        for (int i = 0; i < sohang8; i++)
            //    //        {
            //    //            if (txt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //    //            {
            //    //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //    //                txt8.Focus();
            //    //                return;
            //    //            }
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        DialogResult dialogResult = MessageBox.Show( "Trường số 8 trống bạn có muốn qua phiếu không?","Thông báo", MessageBoxButtons.YesNo);
            //    //        if (dialogResult == DialogResult.No)
            //    //        {
            //    //            txt8.Focus();
            //    //            return;
            //    //        }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    for (int i = 0; i < sohang8; i++)
            //    //    {
            //    //        if (txt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //    //        {
            //    //            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //    //            txt8.Focus();
            //    //            return;
            //    //        }
            //    //    }
            //    //}
            //    #endregion
            //    string rule_8_name = dAEntry.GetStringSQL("Select Rules from dbo.[Template] where Id = " + Type_Image + "");
            //    if(rule_8_name.Contains(",8") == true)
            //    {
            //        string dulieu = ToHalfWidth(txt9.Text);
            //        for (int i = 0; i < sohang8; i++)
            //        {
            //            string dong8 = dulieu.Replace("\r", "").Split('\n')[i].ToString();
            //            if (dong8.Length > 15)
            //            {
            //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Sai Quy Tắc Lượng kí tự cho phép (15) !", "Thông Báo");
            //                return;
            //            }
            //        }
            //    }
            //    #region đóng code
            //    //if (Type_Image == 13 || Type_Image == 16 || Type_Image == 28 || Type_Image == 90)
            //    //{
            //    //    string dulieu = ToHalfWidth(txt8.Text);
            //    //    for (int i = 0; i < sohang8; i++)
            //    //    {
            //    //        string dong8 = dulieu.Replace("\r","").Split('\n')[i].ToString();
            //    //        if (dong8.Length >15)
            //    //        {
            //    //            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Sai Quy Tắc ( Form 13, 16, 28, 90 ) !", "Thông Báo");
            //    //            return;
            //    //        }
            //    //    }
            //    //    //txt8.Text = ToHalfWidth(txt8.Text);
            //    //}
            //    #endregion
            //}
            //#region đóng code
            ////if (checktruong8 == false)
            ////{
            ////    // khi summit ở trường 7
            ////    if (txt7test.Text.Contains("\n") == true)
            ////    {
            ////        if (madathang7 != sohang2 && madathang7 != sohang3)
            ////        {
            ////            MessageBox.Show("Số hàng ở Mã đặt hàng không đồng đều với Mã SP và Số Lượng");
            ////            return;
            ////        }
            ////    }
            ////    if (sohang2 != sohang3)
            ////    {
            ////        MessageBox.Show("Số hàng 2, 3   không đồng đều");
            ////        return;
            ////    }
            ////    if (sohang2 != sohang8 && txt9.Visible == true)
            ////    {
            ////        if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            ////        {
            ////            if (txt9.Text != "")
            ////            {
            ////                MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
            ////                return;
            ////            }
            ////        }
            ////        else
            ////        {
            ////            MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
            ////            return;
            ////        }
            ////    }

            ////    if (sohang2 != sohang4 && txt5.Visible == true)// || sohang2 != sohang8 && txt8.Visible == true)
            ////    {
            ////        MessageBox.Show("Số hàng 2, 3, 4   không đồng đều");
            ////        return;
            ////    }
            ////    if (txt5.Visible == true && txt9.Visible == true)
            ////    {
            ////        if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            ////        {
            ////            if (txt9.Text != "")
            ////            {
            ////                if (sohang2 != sohang4 || sohang2 != sohang8)
            ////                {
            ////                    MessageBox.Show("Số hàng Trường 2, 3, 4, 8 không đồng đều");
            ////                    return;
            ////                }
            ////            }
            ////        }
            ////        else
            ////        {
            ////            if (sohang2 != sohang4 || sohang2 != sohang8)
            ////            {
            ////                MessageBox.Show("Số hàng Trường 2, 3, 4, 8 không đồng đều");
            ////                return;
            ////            }
            ////        }
            ////    }
            ////}
            //#endregion
            //#region Haipm update thêm chức năng 19042021

            //if (txt5.Visible == true)
            //{
            //    if (sohang5 != sohang2 && sohang5 > 1)
            //    {
            //        MessageBox.Show("Số hàng 2 , 5  không đồng đều");
            //        return;
            //    }
            //}
            //#endregion
            #endregion
            if (txt4.Text == "")
            {
                MessageBox.Show("Mã SP trống");
                return;
            }
            else
            {                
                btnSubmit.Focus();                               
                //txt3.Text = ToHalfWidth(txt3.Text.Trim());
                string imgContentContent = txt2.Text + "|" + txt3.Text + "|" + txt4.Text + "|" + txt5.Text + "|" + txt6.Text + "|" + txt7.Text + "|" +  txt8.Text + "|" + txt9.Text ;
                str_data_truong3 = txt3.Text;
                imgContentContent = imgContentContent.Replace("\r", "");
                int lng = imgContentContent.Length - 7;
                string imgContent = "";
                int imgContentImageId = 0;
                #region
                //string allinfo = tenanh;
                //string ngaythang = "";// allinfo.Split('_')[1].Substring(0, 8);
                //string giophut = "";// allinfo.Split('_')[1].Substring(8, 4);
                //string nameanh_kitu = new string(allinfo.Where(c => !char.IsControl(c)).ToArray());
                //string data_datetime = nameanh_kitu.Split('_')[nameanh_kitu.Split('_').Length - 3].ToString();
                //string image_info = data_datetime.Substring(data_datetime.Length - 14, 14).ToString();
                //if (image_info.ToString().Length > 10)
                //{
                //    ngaythang = image_info.Substring(0, 8);
                //    giophut = image_info.Substring(8, 4);
                //}
                //else
                //{
                //    MessageBox.Show("Thông tin Ngày Tháng Năm trong tên ảnh đang có vấn đề !!!.. Xác nhận lại với đội dự án \r\n Tên ảnh: " + allinfo);
                //    return;
                //}
                #endregion
                string ngaythang = tenanh.Substring(0, 8).ToString(); //dAEntry.GetStringSQL("Select CONVERT(nvarchar(8),DateCreated,112) as 'Date' from dbo.[ServerImage] where NameImage = N'"+ tenanh+"'");
                imgContent = resul + "|" + imgContentContent + "|" + ngaythang ;
                imgContentImageId = img.Id;
                if (imgContent.Trim().Contains("*") == true)
                {
                    btnNotgood_Click(sender, e);
                    return;
                }
                int uID = userId;
                int imgContentUserId = userId;
                tyleImageNew = 1;
                zom = 11;
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
                try
                {
                    if (idreturn != 0)
                    {
                        if (pair == 1)
                        {
                            string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND AllImage.NG1 = 0 ");
                            //Thay doi 02/07/2019 If exists (select 1 from db_owner.ImageContent join db_owner.AllImage on AllImageId= AllImage.Id where AllImageId=@imgContentImageId and Content1=@imgContentContent AND NG1=0 AND NG2=0)
                            // Update Hitpoint and ressult
                            if (E1_Content == "")
                            {
                                dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 3 where  Id =" + idreturn);
                                dAEntry.UP_conten1_new(imgContent, imgContentUserId, lng, ms, idreturn);
                                //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + imgContent.Trim() + "',UserId1 = " + imgContentUserId + ",InputDate1=getdate(),Tongkytu1 =" + lng + ",TimemilionE1 = " + ms + " where AllImageId=" + idreturn);
                                string E2_Content = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND AllImage.NG1 = 0 AND AllImage.NG2 = 0");
                                string E2_NG = dAEntry.GetStringSQL("select NG2 from db_owner.AllImage where Id = " + idreturn + "");                                
                                if (E2_NG != "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3 where  Id =" + idreturn);
                                }

                                if (imgContent != E2_Content && E2_Content != "" && E2_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 2 where  Id =" + idreturn);
                                }
                                else if (imgContent == E2_Content && E2_Content != "" && E2_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 4,Hitpoint2=4, InfoE = 0 where  Id =" + idreturn);
                                    dAEntry.UP_conten_Result_new(imgContent, idreturn);
                                    //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Checkresult = N'" + imgContent.Trim() + "', Result = N'" + imgContent.Trim() + "'  where  Id =" + idreturn);
                                }
                            }
                        }
                        else if (pair == 2)
                        {
                            string E2_Content = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND AllImage.NG2 = 0");
                            if (E2_Content == "")
                            {
                                dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 3 where  Id =" + idreturn);
                                dAEntry.UP_conten2_new(imgContent, imgContentUserId, lng, ms, idreturn);
                                //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + imgContent.Trim() + "',UserId2 = " + imgContentUserId + ",InputDate2=getdate(),Tongkytu2 =" + lng + ",TimemilionE2 = " + ms + " where AllImageId=" + idreturn);

                                string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + " AND NG1 = 0 AND NG2 = 0");
                                string E1_NG = dAEntry.GetStringSQL("select NG1 from db_owner.AllImage where Id = " + idreturn + "");
                                
                                if (E1_NG != "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3 where  Id =" + idreturn);
                                }

                                if (E1_Content != imgContent && E1_Content != "" && E1_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 2 where  Id =" + idreturn);
                                }
                                else if (E1_Content == imgContent && E1_Content != "" && E1_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 4,Hitpoint2=4, InfoE = 0 where  Id =" + idreturn);
                                    dAEntry.UP_conten_Result_new(imgContent, idreturn);
                                    //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Checkresult = N'" + imgContent.Trim() + "', Result = N'" + imgContent.Trim() + "'  where  Id =" + idreturn);
                                }
                            }
                            //dAEntry.AddImageContent2(idreturn.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                        }
                    }
                    else
                    {
                        if (pair == 1)
                        {
                            string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + " AND  AllImage.NG1 = 0");
                            if (E1_Content == "")
                            {
                                dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 3 where  Id =" + imgContentImageId);
                                dAEntry.UP_conten1_new(imgContent, imgContentUserId, lng, ms, imgContentImageId);
                                //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + imgContent.Trim() + "',UserId1 = " + imgContentUserId + ",InputDate1=getdate(),Tongkytu1 =" + lng + ",TimemilionE1 = " + ms + " where AllImageId=" + imgContentImageId);
                                string E2_Content = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + " AND AllImage.NG1 = 0 AND AllImage.NG2 = 0");
                                //byte[] bytesE1 = Encoding.ASCII.GetBytes(imgContent);
                                //byte[] bytesE2 = Encoding.ASCII.GetBytes(E2_test);
                                string E2_NG = dAEntry.GetStringSQL("select NG2 from db_owner.AllImage where Id = " + imgContentImageId + "");

                                if (E2_NG != "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3 where  Id =" + imgContentImageId);
                                }
                                if (imgContent != E2_Content && E2_Content != "" && E2_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 2 where  Id =" + imgContentImageId);
                                }
                                else if (imgContent == E2_Content && E2_Content != "" && E2_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 4,Hitpoint2=4, InfoE = 0 where  Id =" + imgContentImageId);
                                    dAEntry.UP_conten_Result_new(imgContent, imgContentImageId);
                                    //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Checkresult = N'" + imgContent.Trim() + "', Result = N'" + imgContent.Trim() + "'  where  Id =" + imgContentImageId);
                                }
                            }
                            //dAEntry.AddImageContent1(imgContentImageId.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                        }
                        else if (pair == 2)
                        {
                            string E2_test = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + " AND  AllImage.NG2 = 0");
                            if (E2_test == "")
                            {
                                dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 3 where  Id =" + imgContentImageId);

                                dAEntry.UP_conten2_new(imgContent, imgContentUserId, lng, ms, imgContentImageId);
                                //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + imgContent.Trim() + "',UserId2 = " + imgContentUserId + ",InputDate2=getdate(),Tongkytu2 =" + lng + ",TimemilionE2 = " + ms + " where AllImageId=" + imgContentImageId);
                                //string E2_test = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + " AND NG1 = 0 AND NG2 = 0");
                                string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + " AND AllImage.NG1 = 0 AND AllImage.NG2 = 0");
                                //byte[] bytesE1 = Encoding.ASCII.GetBytes(E1_test);
                                string E1_NG = dAEntry.GetStringSQL("select NG1 from db_owner.AllImage where Id = " + imgContentImageId + "");

                                if (E1_NG != "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3 where  Id =" + imgContentImageId);
                                }
                                //byte[] bytesE2 = Encoding.ASCII.GetBytes(imgContent);
                                if (E1_Content != imgContent && E1_Content != "" && E1_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 2 where  Id =" + imgContentImageId);
                                }
                                else if (E1_Content == imgContent && E1_Content != "" && E1_NG == "0")
                                {
                                    dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 4,Hitpoint2=4, InfoE = 0 where  Id =" + imgContentImageId);
                                    dAEntry.UP_conten_Result_new(imgContent, imgContentImageId);
                                    //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Checkresult = N'" + imgContent.Trim() + "', Result = N'" + imgContent.Trim() + "'  where  Id =" + imgContentImageId);
                                }
                                //dAEntry.AddImageContent2(imgContentImageId.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                bm_out = null;
                imageSource = null;
                view_Image_TN.Dispose();
                tenanh = "";
                maso = "";
                idreturn = 0;
                img = new BOImage_Entry();
                if (ListImage.Count > 0)
                {
                    img = ListImage[0];
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
                            btnSubmit.Enabled = false;
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
                    tenanh = img.PageUrl;
                    imageSource = (Bitmap)img.Imagesource.Clone();
                    view_Image_TN.Image = imageSource;
                    dbzome = view_Image_TN.CurrentZoom;
                }
                catch
                {
                    MessageBox.Show("Không load được ảnh: " + img.PageUrl, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                // hiển thị tên field name      
                type_1 = Type_Image;
                lblpage.Text = img.PageUrl;
                lsttxt.ForEach(s => s.Text = "");
                dtimeBefore = DateTime.Now;
                lblsoluong.Text = (dAEntry.ImageExistEntry(pair) + ListImage.Count).ToString();
                zom = 20;
                idreturn = img.Id;
                Logic(img.Id);
            }
        }
        private void btnNotgood_Click(object sender, EventArgs e)
        {
            string[] arr2 = null;
            try
            {
                arr2 = txt2.Text.Split('\n').ToArray();
            }
            catch
            {
            }
            //btnSubmit.Focus();            
            // Upnew  Không xóa dấu space cuối cùng (Yêu cầu đội dự án )
            string imgContentContent = txt2.Text + "|" + txt3.Text + "|" + txt4.Text + "|" + txt5.Text + "|" + txt6.Text + "|" + txt7.Text + "|" + txt8.Text + "|" + txt9.Text;
            // End
            //string imgContentContent = String.Join("|", arr);
            imgContentContent = imgContentContent.Replace("\r", "");
            int lng = imgContentContent.Length - 8;
            bm_out = null;
            int uID = userId;
            tyleImageNew = 1;
            zom = 11;
            string imgContent = "";
            int imgContentImageId = 0;
            string ngaythang = "" + DateTime.Now.ToString("yyyyMMdd");
            imgContent = resul + "|" + imgContentContent + "|" + ngaythang;
            imgContentImageId = img.Id;
            if (imgContent.Contains("*") == false)
            {
                MessageBox.Show("Không có Ký tự * ", "Thông Báo !");
                return;
            }
            int imgContentUserId = userId;
            TimeSpan span = DateTime.Now - dtimeBefore;
            int ms = (int)span.TotalMilliseconds;
            try
            {
                if (idreturn != 0)
                {
                    if (pair == 1)
                    {
                        string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + "");
                        if (E1_Content == "")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 3,InfoE = 3,NG1 = " + imgContentUserId + " where  Id =" + idreturn);
                            dAEntry.UP_conten1_new(imgContent, imgContentUserId, lng, ms, idreturn);
                            
                        }
                    }
                    else if (pair == 2)
                    {
                        string E2_test = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + idreturn + "");
                        if (E2_test == "")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 3,InfoE = 3,NG2 = " + imgContentUserId + " where  Id =" + idreturn);
                            dAEntry.UP_conten2_new(imgContent, imgContentUserId, lng, ms, idreturn);
                            //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + imgContent.Trim() + "',UserId2 = " + imgContentUserId + ",InputDate2=getdate(),Tongkytu2 =" + lng + ",TimemilionE2 = " + ms + " where AllImageId=" + idreturn);

                            //dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3,NG2 = " + imgContentUserId + " where  Id =" + idreturn);
                            //dAEntry.AddImageContentNG2(idreturn.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                        }
                        
                    }
                }
                else
                {
                    if (pair == 1)
                    {
                        string E1_Content = dAEntry.GetStringSQL("select Content1 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + "");
                        if (E1_Content == "")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint1 = 3,InfoE = 3,NG1 = " + imgContentUserId + " where  Id =" + imgContentImageId);
                            dAEntry.UP_conten1_new(imgContent, imgContentUserId, lng, ms, imgContentImageId);
                            //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content1 = N'" + imgContent.Trim() + "',UserId1 = " + imgContentUserId + ",InputDate1=getdate(),Tongkytu1 =" + lng + ",TimemilionE1 = " + ms + " where AllImageId=" + imgContentImageId);

                            //dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3,NG1 = " + imgContentUserId + " where  Id =" + imgContentImageId);
                            //dAEntry.AddImageContentNG1(imgContentImageId.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                        }
                        
                    }
                    else if (pair == 2)
                    {
                        string E2_test = dAEntry.GetStringSQL("select Content2 from db_owner.ImageContent join db_owner.AllImage on AllImageId = AllImage.Id where AllImageId =" + imgContentImageId + "");
                        if (E2_test =="")
                        {
                            dAEntry.ExecuteSQL("Update db_owner.AllImage set Hitpoint2 = 3,InfoE = 3,NG2 = " + imgContentUserId + " where  Id =" + imgContentImageId);
                            dAEntry.UP_conten2_new(imgContent, imgContentUserId, lng, ms, imgContentImageId);
                            //dAEntry.ExecuteSQL("Update db_owner.ImageContent set Content2 = N'" + imgContent.Trim() + "',UserId2 = " + imgContentUserId + ",InputDate2=getdate(),Tongkytu2 =" + lng + ",TimemilionE2 = " + ms + " where AllImageId=" + imgContentImageId);

                            //dAEntry.ExecuteSQL("Update db_owner.AllImage set InfoE = 3,NG2 = " + imgContentUserId + " where  Id =" + imgContentImageId);
                            //dAEntry.AddImageContentNG2(imgContentImageId.ToString(), imgContent.Trim(), imgContentUserId.ToString(), lng.ToString(), ms);
                        }
                        
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bm_out = null;
            imageSource = null;
            view_Image_TN.Dispose();   
            maso = "";
            tenanh = "";
            idreturn = 0;
            if (ListImage.Count > 0)
            {
                img = ListImage[0];
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
                        btnSubmit.Enabled = false;
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
                tenanh = img.PageUrl;
                imageSource = (Bitmap)img.Imagesource.Clone();
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.PageUrl, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            // hiển thị tên field name         
            lblpage.Text = img.PageUrl;
            lsttxt.ForEach(s => s.Text = "");
            demsohang = 0;
            lblsoluong.Text = (dAEntry.ImageExistEntry(pair) + ListImage.Count).ToString();
            dtimeBefore = DateTime.Now;
            zom = 20;
            Logic(img.Id);
        }
        private void view_Image_TN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                view_Image_TN.RotateImage("90");
        }
        private void btnsop_Click(object sender, EventArgs e)
        {
            try
            {
                binary = dAEntry.Get_imgsop(resul);
                if (binary != null)
                {
                    frmsop.getimg = binary;
                    frmsop.Anchor = AnchorStyles.Right;
                    frmsop.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có ảnh SOP ");
                    return;
                }
            }
            catch {
                MessageBox.Show("Không có ảnh SOP ");
                return;
            }
        }
        private void txt2_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt2.Text.Split('\r').Length;
            txtlb2.Text = string.Join("\r\n", arr2.Take(sohang));
            txtlb2.AppendText("\r\n");
        }
        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt2.Text.Substring(0, txt2.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt2.Text.Split('\r').ToArray();
                if (bb == arrt2.Length)
                    txt2.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];                    
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt2.Text = join;
                    txt2.SelectionStart = select + bb + 1;
                }
            }
        }
        private void txt3_TextChanged(object sender, EventArgs e)
        {
            //int sohang = txt4.Text.Split('\r').Length;
            //txtlb4.Text = string.Join("\r\n", arr3.Take(sohang));
            //txtlb4.AppendText("\r\n");
        }
        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    int bb = txt4.Text.Substring(0, txt4.SelectionStart).Split('\n').Length;
            //    string[] arrt2 = txt4.Text.Split('\r').ToArray();
            //    if (bb == arrt2.Length)
            //        txt4.AppendText("\r\n");
            //    else
            //    {
            //        arrt2[bb] = "\n\r" + arrt2[bb];
            //        int select = 0;
            //        for (int i = 0; i < bb; i++)
            //        {
            //            select = select + arrt2[i].Length;
            //        }
            //        string join = string.Join("\r", arrt2);
            //        txt4.Text = join;
            //        txt4.SelectionStart = select + bb + 1;
            //    }
            //}
        }
        private void txt4_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt4.Text.Split('\r').Length;
            txtlb4.Text = string.Join("\r\n", arr4.Take(sohang));
            txtlb4.AppendText("\r\n");
        }
        private void txt4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt4.Text.Substring(0, txt4.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt4.Text.Split('\r').ToArray();
                if (bb == arrt2.Length)
                    txt4.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt4.Text = join;
                    txt4.SelectionStart = select + bb + 1;
                }
            }
        }
        private void txt7_Leave(object sender, EventArgs e)
        {
            txt7.Text = txt7.Text.ToUpper();
            //txt7test.Multiline = false;
            //txt7test.Text = txt7test.Text.ToUpper();
            //lbl4.Visible = true;
            //txt4.Visible = true;
            //txtlb4.Visible = true;
            //if ( bien4 ==2)
            //{
            //    lbl5.Visible = true;
            //    txt5.Visible = true;
            //    txtlb5.Visible = true;
            //}
            //txtlb7.Visible = false;

        }
        //private void txt7_Leave_1(object sender, EventArgs e)
        //{
        //    txt7test.Multiline = false;
        //}
        int bien4;
        private void txt7test_TextChanged(object sender, EventArgs e)
        {
            //if (txt7.Text.Contains("\r\n") == true)
            //{
            //    lbl4.Visible = false;
            //    txt4.Visible = false;
            //    txtlb4.Visible = false;
            //    if (txt5.Visible == true)
            //    {
            //        bien4 = 2;
            //        lbl5.Visible = false;
            //        txt5.Visible = false;
            //        txtlb5.Visible = false;
            //    }
            //}
            int sohang = txt7.Text.Split('\r').Length;
            txtlb7.Text = string.Join("\r\n", arr2.Take(sohang));
            txtlb7.AppendText("\r\n");
        }
        private void txt7test_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    int bb = txt7test.Text.Substring(0, txt7test.SelectionStart).Split('\n').Length;
            //    string[] arrt2 = txt7test.Text.Split('\r').ToArray();
            //    if (bb == arrt2.Length)
            //        txt7test.AppendText("\r\n");
            //    else
            //    {
            //        arrt2[bb] = "\n\r" + arrt2[bb];
            //        int select = 0;
            //        for (int i = 0; i < bb; i++)
            //        {
            //            select = select + arrt2[i].Length;
            //        }
            //        string join = string.Join("\r", arrt2);
            //        txt7test.Text = join;
            //        txt7test.SelectionStart = select + bb + 1;
            //    }
            //}
        }
        private void txt6_Leave(object sender, EventArgs e)
        {
            txt6.Text = txt6.Text.ToUpper();
        }
        private void txt5_Leave(object sender, EventArgs e)
        {
            //for(int i = 0; i <  txt5.Text.Replace("\r","").Split('\n').Length; i ++)
            //{
            //    if(txt5.Text.Replace("\r", "").Split('\n')[i].Length != 8 && txt5.Text.Replace("\r", "").Split('\n')[i].Length != 0)
            //    {
            //        MessageBox.Show("Trường số 5: Dòng " + (i + 1) + " sai quy tắc 8 kí tự !");
            //        txt5.Focus();
            //        txt5.SelectionStart = txt5.Text.Length;                    
            //        return;
            //    }
            //}
            //txtlb5.Multiline = false; txtlb5.Text = "1";
            ////txtlb5.Visible = false;
            //txt5.Multiline = false;
            //txt5.Text = txt5.Text.ToUpper();
            //lbl2.Visible = true;
            //txt2.Visible = true;
            //txtlb2.Visible = true;
        }
        private void txt9_Leave(object sender, EventArgs e)
        {
            txt9.Text = txt9.Text.ToUpper();
        }
        private void txt10_Leave(object sender, EventArgs e)
        {
            
        }
        private void txt2_Leave(object sender, EventArgs e)
        {
            txt2.Text = txt2.Text.ToUpper();
            txt4.Focus();
        }
        private void txt4_Leave(object sender, EventArgs e)
        {
            txt4.Text = txt4.Text.ToUpper();
        }
        private void txt3_Leave(object sender, EventArgs e)
        {
            //txt4.Text = txt4.Text.ToUpper();
        }
        private void txt8_Leave(object sender, EventArgs e)
        {
            txt8.Text = txt8.Text.ToUpper();
            if (txt2.Visible == true)
            {
                txt2.Focus();
                txt2.SelectionStart = txt2.Text.Length;
            }
            else if (txt4.Visible == true)
            {
                txt4.Focus();
                txt4.SelectionStart = txt4.Text.Length;
            }
            //thoat = 0;
        }
        private void txt3_Leave_1(object sender, EventArgs e)
        {
            //txt4.Text = txt4.Text.ToUpper();
            if (txt8.Visible == true)
            {
                txt8.Focus();
                txt8.SelectionStart = txt8.Text.Length;
            }
            else if (txt2.Visible == true)
            {
                txt2.Focus();
                return;
            }
            else
            {
                txt4.Focus();
                return;
            }
        }
        int thoat = 0;
        int dem = 0;
        private void txt7test_Click(object sender, EventArgs e)
        {
            
        }
        private void txt5_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt5.Text.Split('\r').Length;
            
            txtlb5.Text = string.Join("\r\n", arr2.Take(sohang));
            txtlb5.AppendText("\r\n");
        }
        private void txt5_Click(object sender, EventArgs e)
        {
            //if (txt5.Text.Contains("\n") == true)
            //{
            //    txt5.Size = new Size(152, 511);
            //    txt2.Visible = false;
            //    //txt4.Visible = false;
            //    txtlb2.Visible = false;
            //    lbl2.Visible = false;
            //    //if (txt4.Visible == true)
            //    //{
            //    //    bien4 = 2;
            //    //    txt4.Visible = false;
            //    //    lbl4.Visible = false;
            //    //    txtlb4.Visible = false;
            //    //}
            //    txt5.Multiline = true;
            //    int sohang = txt5.Text.Split('\r').Length;
            //    if (sohang > 1)
            //    {
            //        txtlb5.Multiline = true;
            //        txtlb5.Height = 511;
            //    }
            //    txtlb5.Text = string.Join("\r\n", arr2.Take(sohang));
            //    txtlb5.AppendText("\r\n");
            //}
        }
        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt5.Text.Substring(0, txt5.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt5.Text.Split('\r').ToArray();
                
                if (bb == arrt2.Length)
                    txt5.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt5.Text = join;
                    txt5.SelectionStart = select + bb + 1;
                }
            }
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt7.Text.Split('\r').Length;
            txtlb7.Text = string.Join("\r\n", arr7.Take(sohang));
            txtlb7.AppendText("\r\n");
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt6.Text.Split('\r').Length;
            txtlb6.Text = string.Join("\r\n", arr6.Take(sohang));
            txtlb6.AppendText("\r\n");
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt6.Text.Substring(0, txt6.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt6.Text.Split('\r').ToArray();

                if (bb == arrt2.Length)
                    txt6.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt6.Text = join;
                    txt6.SelectionStart = select + bb + 1;
                }
            }
        }

        private void txt7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt7.Text.Substring(0, txt7.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt7.Text.Split('\r').ToArray();
                if (bb == arrt2.Length)
                    txt7.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt7.Text = join;
                    txt7.SelectionStart = select + bb + 1;
                }
            }
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            int sohang = txt9.Text.Split('\r').Length;
            txtlb9.Text = string.Join("\r\n", arr8.Take(sohang));
            txtlb9.AppendText("\r\n");
        }

        private void txt9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bb = txt9.Text.Substring(0, txt9.SelectionStart).Split('\n').Length;
                string[] arrt2 = txt9.Text.Split('\r').ToArray();
                if (bb == arrt2.Length)
                    txt9.AppendText("\r\n");
                else
                {
                    arrt2[bb] = "\n\r" + arrt2[bb];
                    int select = 0;
                    for (int i = 0; i < bb; i++)
                    {
                        select = select + arrt2[i].Length;
                    }
                    string join = string.Join("\r", arrt2);
                    txt9.Text = join;
                    txt9.SelectionStart = select + bb + 1;
                }
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtlb2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            //int sohang = txt8.Text.Split('\r').Length;
            //txtlb8.Text = string.Join("\r\n", arr8.Take(sohang));
            //txtlb8.AppendText("\r\n");
            //string [] str_15 = txt8.
        }
        private void txt8_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    int bb = txt8.Text.Substring(0, txt8.SelectionStart).Split('\n').Length;
            //    string[] arrt2 = txt8.Text.Split('\r').ToArray();
            //    if (bb == arrt2.Length)
            //        txt8.AppendText("\r\n");
            //    else
            //    {
            //        arrt2[bb] = "\n\r" + arrt2[bb];
            //        int select = 0;
            //        for (int i = 0; i < bb; i++)
            //        {
            //            select = select + arrt2[i].Length;
            //        }
            //        string join = string.Join("\r", arrt2);
            //        txt8.Text = join;
            //        txt8.SelectionStart = select + bb + 1;
            //    }
            //}
            //if (e.Control)
            //{
            //    //if ( e.KeyCode == Keys.Divide)
            //    //{
            //    //    string cop = txt7test.Text;
            //    //    txt9.Text = cop;
            //    //    txt9.SelectionStart = txt9.Text.Length;
            //    //}
            //}
        }
        private void lbl5_Click(object sender, EventArgs e)
        {

        }
    }
}
