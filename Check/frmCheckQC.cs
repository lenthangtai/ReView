using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace VCB_TEGAKI
{
    public partial class frmCheckQC : Form
    {
        public int formId;
        public int batchId;
        public int userId;
        public string userName;
        public string batchName;
        public string template;
        public string level;
        Bitmap imageSource;
        int demsohang;
        string[] arrsh = new string[0];
        string[] arrsl = new string[0];
        string[] arrgm = new string[0];
        string[] arrgb = new string[0];
        string x2, x3, x4, x5;
        bool zoom = false;
        bool getanh = false;
        private double scale = 1;
        private int numbertrtxt = 0;
        DateTime dtimeBefore = new DateTime();
        int idreturn;
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private DAEntry_Check dACheck = new DAEntry_Check();
        private BOImageContent_Check img = new BOImageContent_Check();
        //private BOImageContent_Check imgContent = new BOImageContent_Check();
        private bool finish = false;
        DataTable dtbinary = new DataTable();
        DataTable dtbinary2 = new DataTable();
        double zom = 20;
        double tong1 = 0;
        int id = 0;
        int lbtong;
        double tong2 = 0;
        int demid = 0;
        int[] arr2 = Enumerable.Range(1, 1000).ToArray();
        int[] arr3 = Enumerable.Range(1, 1000).ToArray();
        int[] arr4 = Enumerable.Range(1, 1000).ToArray();
        int[] arr8 = Enumerable.Range(1, 1000).ToArray();
        private System.Windows.Forms.TextBox txtAutoComplete = new System.Windows.Forms.TextBox();
        List<BOImageContent_Check> ListImage = new List<BOImageContent_Check>();
        double tyleImageNew = 1;
        Bitmap bm_out;
        byte[] binary;
        string resul;
        string maso = "";
        int saveimageid = 0;
        double zomm = 1;
        float dbzome;
        public string[] INFperformance = new string[2];
        List<RichTextBox> lsttxt = new List<RichTextBox>();
        List<Label> lstlb = new List<Label>();
        public frmCheckQC()
        {
            InitializeComponent();
            lsttxt = new List<RichTextBox>() { txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10 };
            lstlb = new List<Label>() { lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10 };
        }
        private void frmCheck_Load(object sender, EventArgs e)
        {
            txt7.Size = new Size(152, 27);
            // set bien toan cuc         
            lsttxt.ForEach(a =>
            {
                a.Enter += new System.EventHandler(this.textBox1_Enter);
                a.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
                a.Leave += new System.EventHandler(this.textBox1_Leave);
                a.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
                a.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtxtsbd_MouseDown);
                a.Click += new System.EventHandler(this.txttBox1_Click);
            });
            int idimg = dACheck.GetkQC();
            if (idimg == 0)
            {
                btnSubmit.Enabled = false;
                btnBack.Enabled = false;
                finish = true;
                MessageBox.Show("Batch đã hoàn thành");
                this.Close();
                return;
            }
            else
            {
                try
                {
                    img = dACheck.GetImageQC(idimg);
                    imageSource = new Bitmap(Io_Entry.byteArrayToImage(dACheck.getImageOnServer(img.Uri)));
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
            Logic(idimg);
            for (int i = 0; i < 9; i++)
            {
                lsttxt[i].ForeColor = Color.Red;
                lsttxt[i].Text = img.Content1[i + 1];
                numbertrtxt = i;
                string s1, s2;
                s1 = img.Content1[i + 1];
                s2 = img.Content2[i + 1];
                if (s1 != s2)
                {
                    lstlb[i].BackColor = Color.Red;
                }
                c = null;
                c = new int[s1.Length + 1, s2.Length + 1];
                LCS(s1, s2);
                BackTrack(s1, s2, s1.Length, s2.Length);
            }
            if (img.Notgood1 != 0)
            { lblEntry1.BackColor = Color.Red; }
            if (img.Notgood2 != 0)
            { lblEntry2.BackColor = Color.Red; }
            if (lsttxt[2].Visible == true)
            {
                //txtt4.Visible = true;
                //txtt4.BringToFront();
                //txtt4.Text = txt4.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[4].Visible == true)
            {
                txtt6.Visible = true;
                txtt6.BringToFront();
                txtt6.Text = txt6.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[6].Visible == true)
            {
                txtt8.Visible = true;
                txtt8.BringToFront();
                txtt8.Text = txt8.Text.Replace("\n", "\r\n");
            }
            txtt2.Text = txt2.Text.Replace("\n", "\r\n");
            txtt3.Text = txt3.Text.Replace("\n", "\r\n");
            // hiển thị user name của user đã entry         
            lblEntry1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
            lblEntry2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            lblpage.Text = img.Uri;
            lblsoluong.Text = (dACheck.ImageExistQC() + ListImage.Count).ToString();
            dtimeBefore = DateTime.Now;
            timergetanh.Start();

            //string test1 = ToHalfWidth("");

        }
        public Bitmap ResizeHeight(Bitmap image, int newWidth, int newHeight, string message)
        {
            try
            {
                Bitmap newImage = new Bitmap(newWidth, CalculationsHeight(image.Width, image.Height, newWidth));

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
                Bitmap newImage = new Bitmap(CalculationsWith(image.Height, image.Width, newHeight), newHeight);

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
        #region focus
        public void Logic(int id)
        {
            //try
            //{
            //    string resul = dACheck.Get_Result(id);
            //    string str = dACheck.Get_Rules(resul);
            //    string[] arrrole = str.Split(',');
            //    lsttxt[7].Text = "";
            //    for (int i = 0; i < arrrole.Length; i++)
            //    {
            //        lstlbl2[Convert.ToInt32(arrrole[i]) - 2].BackColor = Color.PowderBlue;
            //    }
            //}
            //catch
            //{
            //    for (int i = 0; i < lsttxt.Count; i++)
            //    {
            //        lsttxt[i].Visible = true;
            //        lstlbl[i].Visible = true;
            //        lstlbl2[i].Visible = true;
            //    }
            //}
            resul = "";
            string str = "";
            //txtt4.Visible = false;
            txtt6.Visible = false;
            txtt8.Visible = false;
            //txtt4.Text = "";
            txtt6.Text = "";
            txtt8.Text = "";
            binary = null;
            string[] arrrole = null;
            int temid = 0;
            for (int i = 0; i < lsttxt.Count; i++)
            {
                lstlb[i].BackColor = SystemColors.Control;
                lsttxt[i].Text = "";
                lsttxt[i].Visible = false;
                lstlb[i].Visible = false;
            }
            resul = dAEntry.Get_Result(id);
            if (id != 0)
            {
                Type_Image = dAEntry.Get_Type_Image(id);
            }
            str = dAEntry.Get_Rules(resul);
            maso = dAEntry.Get_maso(resul);
            temid = dAEntry.Get_Temid(resul);
            arrrole = str.Split(',');
            lsttxt[7].Text = "";
            for (int i = 0; i < arrrole.Length; i++)
            {
                lsttxt[Convert.ToInt32(arrrole[i]) - 2].Visible = true;
                lstlb[Convert.ToInt32(arrrole[i]) - 2].Visible = true;
            }
            //lsttxt[7].Visible = false;
            //lstlb[7].Visible = false;
            //lsttxt[8].Visible = false;
            //lstlb[8].Visible = false;
            //if (temid > 6 && temid < 13)
            //{
            //    lsttxt[7].Enabled = false;
            //    lsttxt[7].Visible = true;
            //    lsttxt[8].Visible = true;
            //    lstlb[7].Visible = true;
            //    lstlb[8].Visible = true;
            //}
            if (lsttxt[4].Visible == true)
            {
                lsttxt[4].Focus();
                return;
            }
            else if (lsttxt[3].Visible == true)
            {
                lsttxt[3].Focus();
                return;
            }
            else if (lsttxt[5].Visible == true)
            {
                lsttxt[5].Focus();
                return;
            }
            else if (lsttxt[8].Visible == true)
            {
                lsttxt[8].Focus();
                return;
            }
            else if (lsttxt[0].Visible == true)
            {
                lsttxt[0].Focus();
                return;
            }
            else if (lsttxt[1].Visible == true)
            {
                lsttxt[1].Focus();
                return;
            }
            else if (lsttxt[2].Visible == true)
            {
                lsttxt[2].Focus();
                return;
            }
            else if (lsttxt[6].Visible == true)
            {
                lsttxt[6].Focus();
                return;
            }
        #endregion
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            timergetanh.Stop();
            try
            {
                if (!finish)
                {
                    dACheck.Return_HitpointCheck(img.Id);
                    for (int i = 0; i < ListImage.Count; i++)
                    {
                        dACheck.Return_HitpointCheck(ListImage[i].Id);
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
                lsttxt[numbertrtxt].SelectionStart = i - 1;
                lsttxt[numbertrtxt].SelectionLength = 1;
                lsttxt[numbertrtxt].SelectionColor = Color.Black;
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
        protected System.Drawing.Point clickPosition;
        protected System.Drawing.Point scrollPosition;
        private void picBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            this.clickPosition.X = e.X;
            this.clickPosition.Y = e.Y;
        }
        private void frmCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Q)
                {
                    btnsop_Click(sender, e);
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.F)
                {
                    view_Image_TN.CurrentZoom = dbzome;
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
                if (e.KeyCode == Keys.Right)
                {
                    try
                    {
                        //zoom = true;
                        //Bitmap bm_in = new Bitmap(imageSource);
                        //Int32 wid = bm_in.Width;
                        //Int32 hgt = bm_in.Height;
                        //Point[] corners;
                        //corners = new Point[4];
                        //corners[0] = new Point(0, 0);
                        //corners[1] = new Point(wid, 0);
                        //corners[2] = new Point(0, hgt);
                        //corners[3] = new Point(wid, hgt);
                        //int cx = wid / 2;
                        //int cy = hgt / 2;

                        //for (int i = 0; i < 4; i++)
                        //{
                        //    corners[i].X -= cx;
                        //    corners[i].Y -= cy;

                        //}

                        //double theta = int.Parse("-90") * Math.PI / 180.0;
                        //double sin_theta = Math.Sin(theta);
                        //double cos_theta = Math.Cos(theta);
                        //double x;
                        //double y;
                        //for (int i = 0; i < 4; i++)
                        //{
                        //    x = corners[i].X;
                        //    y = corners[i].Y;

                        //    corners[i].X = Convert.ToInt32(x * cos_theta + y * sin_theta);

                        //    corners[i].Y = Convert.ToInt32(-x * sin_theta + y * cos_theta);
                        //}
                        //int xmin = corners[0].X;
                        //int ymin = corners[0].Y;
                        //for (int i = 0; i < 4; i++)
                        //{
                        //    if (xmin > corners[i].X)
                        //    {
                        //        xmin = corners[i].X;
                        //    }
                        //    if (ymin > corners[i].Y)
                        //    {
                        //        ymin = corners[i].Y;
                        //    }

                        //}

                        //for (int i = 0; i < 4; i++)
                        //{
                        //    corners[i].X -= xmin;
                        //    corners[i].Y -= ymin;

                        //}
                        //bm_out = new Bitmap(Convert.ToInt32(-2 * xmin), Convert.ToInt32(-2 * ymin));
                        //Graphics gr_out = Graphics.FromImage(bm_out);
                        ////ReDim Preserve corners(2)
                        //Array.Resize(ref corners, 3);
                        //gr_out.DrawImage(bm_in, corners);
                        //view_Image_TN.Image = bm_out;
                        view_Image_TN.RotateImage("270");
                    }
                    catch
                    {

                    }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    try
                    {
                        //Bitmap bm_in = new Bitmap(imageSource);
                        //Int32 wid = bm_in.Width;
                        //Int32 hgt = bm_in.Height;
                        //Point[] corners;
                        //corners = new Point[4];
                        //corners[0] = new Point(0, 0);
                        //corners[1] = new Point(wid, 0);
                        //corners[2] = new Point(0, hgt);
                        //corners[3] = new Point(wid, hgt);
                        //int cx = wid / 2;
                        //int cy = hgt / 2;

                        //for (int i = 0; i < 4; i++)
                        //{
                        //    corners[i].X -= cx;
                        //    corners[i].Y -= cy;

                        //}

                        //double theta = int.Parse("90") * Math.PI / 180.0;
                        //double sin_theta = Math.Sin(theta);
                        //double cos_theta = Math.Cos(theta);
                        //double x;
                        //double y;
                        //for (int i = 0; i < 4; i++)
                        //{
                        //    x = corners[i].X;
                        //    y = corners[i].Y;

                        //    corners[i].X = Convert.ToInt32(x * cos_theta + y * sin_theta);

                        //    corners[i].Y = Convert.ToInt32(-x * sin_theta + y * cos_theta);
                        //}
                        //int xmin = corners[0].X;
                        //int ymin = corners[0].Y;
                        //for (int i = 0; i < 4; i++)
                        //{
                        //    if (xmin > corners[i].X)
                        //    {
                        //        xmin = corners[i].X;
                        //    }
                        //    if (ymin > corners[i].Y)
                        //    {
                        //        ymin = corners[i].Y;
                        //    }

                        //}

                        //for (int i = 0; i < 4; i++)
                        //{
                        //    corners[i].X -= xmin;
                        //    corners[i].Y -= ymin;

                        //}

                        //bm_out = new Bitmap(Convert.ToInt32(-2 * xmin), Convert.ToInt32(-2 * ymin));
                        //Graphics gr_out = Graphics.FromImage(bm_out);
                        ////ReDim Preserve corners(2)
                        //Array.Resize(ref corners, 3);

                        //gr_out.DrawImage(bm_in, corners);
                        //view_Image_TN.Image = bm_out;
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
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            imageSource = (Bitmap)bm_out.Clone();
            imageSource = new Bitmap(imageSource, view_Image_TN.Width, view_Image_TN.Height);
            view_Image_TN.Image = imageSource;
        }      
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
            if (tb.TabIndex == 0 || tb.TabIndex == 1 || tb.TabIndex == 2 || tb.TabIndex == 6)
            {
                if (e.KeyCode == Keys.Add)
                {
                    tb.Text = tb.Text + "\n";
                }
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.NumPad1)
                {
                    tb.Text = tb.Text + "4977564";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                if (e.KeyCode == Keys.NumPad2)
                {
                    tb.Text = tb.Text + "AM必着";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                if (e.KeyCode == Keys.NumPad3)
                {
                    tb.Text = tb.Text + "階定番分";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                if (e.KeyCode == Keys.NumPad4)
                {
                    tb.Text = tb.Text + "様";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    tb.Text = tb.Text + "ﾒｰｶｰ別棚";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                else if (e.KeyCode == Keys.NumPad6)
                {

                    tb.Text = tb.Text + "ﾌｼﾞ棚";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                else if (e.KeyCode == Keys.NumPad7)
                {

                    tb.Text = tb.Text + "共通棚";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                else if (e.KeyCode == Keys.NumPad8)
                {

                    tb.Text = tb.Text + "ネット　東港午前必着";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
                else if (e.KeyCode == Keys.NumPad9)
                {
                    tb.Text = tb.Text + "×";
                    tb.SelectionStart = tb.Text.Length + 1;
                }
            }           
        }
        private void txttBox1_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
        }
        private void rtxtsbd_MouseDown(object sender, MouseEventArgs e)
        {
            RichTextBox rtxt = (RichTextBox)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (rtxt.Text == img.Content1[rtxt.TabIndex+1])
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = img.Content2[rtxt.TabIndex + 1];
                    if (rtxt.TabIndex == 6)
                    { txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    if (rtxt.TabIndex == 4)
                    { txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = img.Content2[rtxt.TabIndex + 1];
                    s2 = img.Content1[rtxt.TabIndex + 1];
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                    lblEntry2.ForeColor = Color.DodgerBlue;
                    lblEntry1.ForeColor = Color.Black;
                }
                else if (rtxt.Text == img.Content2[rtxt.TabIndex + 1])
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = img.Content1[rtxt.TabIndex + 1];
                    if (rtxt.TabIndex == 6)
                    { txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    if (rtxt.TabIndex == 4)
                    { txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = img.Content1[rtxt.TabIndex + 1];
                    s2 = img.Content2[rtxt.TabIndex + 1];
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                    lblEntry2.ForeColor = Color.Black;
                    lblEntry1.ForeColor = Color.DodgerBlue;
                }
                else
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = img.Content1[rtxt.TabIndex + 1];
                    if (rtxt.TabIndex == 6)
                    { txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    if (rtxt.TabIndex == 4)
                    { txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = img.Content1[rtxt.TabIndex + 1];
                    s2 = img.Content2[rtxt.TabIndex + 1];
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
            tb.BackColor = Color.PowderBlue;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
            if (e.KeyChar == 43)
                e.Handled = true;
            if (e.KeyChar == 13)
                e.Handled = true;         
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
            tb.BackColor = SystemColors.Window;
        }
        int Type_Image;
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
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] arr22 = null;
            string[] arr3 = null;
            int sohang2 = 0;
            int sohang3 = 0;
            int sohang4 = 0;
            int sohang5 = 0;
            int madathang7 = 0;
            if (txt7.Text.Contains("\n") == true)
            {
                madathang7 = txt7.Text.Split('\n').Count();
                for (int i = 0; i < madathang7; i++)
                {
                    if (txt7.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                    {
                        MessageBox.Show("Quy Định Trường 7 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                        txt7.Focus();
                        return;
                    }
                }
            }
            //if (txt5.Visible == true)
            //{
            //    if (txt5.Text != "" && txt5.Text.Length != 8)
            //    {
            //        MessageBox.Show("Quy tắc Sai  Trường 5: Ngày Tháng !", "Thông Báo");
            //        txt5.Focus();
            //        txt5.SelectionStart = txt5.Text.Length;
            //        return;
            //    }

            //}
            if (txt10.Visible == true)
            {
                if (txt10.Text == "")
                {
                    return;
                }
                if (txt10.Text.Length != 10)
                {
                    MessageBox.Show("Quy tắc Sai  Trường 10: Số Điện Thoại !", "Thông Báo");
                    txt10.Focus();
                    txt10.SelectionStart = txt10.Text.Length;
                    return;
                }
            }
            int sohang8 = 0;
            sohang2 = txt2.Text.Split('\n').Length;
            if (txt2.Visible == true)
            {
                for (int i = 0; i < sohang2; i++)
                {
                    if (txt2.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                    {
                        MessageBox.Show("Quy Định Trường 2 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                        txt2.Focus();
                        return;
                    }
                }
            }
            sohang3 = txt3.Text.Split('\n').Length;
            if (txt3.Visible == true)
            {
                for (int i = 0; i < sohang3; i++)
                {
                    if (txt3.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                    {
                        MessageBox.Show("Quy Định Trường 2 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                        txt3.Focus();
                        return;
                    }
                }
            }
            arr22 = txt2.Text.Split('\n').ToArray();
            arr3 = txt3.Text.Split('\n').ToArray();
            sohang4 = txt4.Text.Split('\n').Length;
            if (txt4.Visible == true)
            {
                for (int i = 0; i < sohang4; i++)
                {
                    if (txt4.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                    {
                        MessageBox.Show("Quy Định Trường 4 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                        txt4.Focus();
                        return;
                    }
                }

            }
            #region Haipm thêm yêu cầu mới 19042021
            // thêm mới 19042021 Haipm
            sohang5 = txt5.Text.Split('\n').Length;
            bool checktruong8 = false;
            #endregion
            sohang8 = txtt8.Text.Split('\n').Length;
            if (txtt8.Visible == true)
            {
                sohang8 = txtt8.Text.Split('\n').Length;
                int rule_8 = dAEntry.GetIntSQL("Select isnull(set_Rule_8,0)  as N'set_Rule_8' from dbo.[Template] where Id = " + Type_Image + "");
                if (rule_8 == 1)
                {
                    if (txtt8.Text != "")
                    {
                        for (int i = 0; i < sohang8; i++)
                        {
                            if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                            {
                                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                                txtt8.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Trường số 8 trống bạn có muốn qua phiếu không?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            txt8.Focus();
                            return;
                        }
                        else
                        {
                            checktruong8 = true;

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < sohang8; i++)
                    {
                        if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                        {
                            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                            txtt8.Focus();
                            return;
                        }
                    }
                }
                #region đóng
                //if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
                //{
                //    if (txtt8.Text != "")
                //    {
                //        for (int i = 0; i < sohang8; i++)
                //        {
                //            if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                //            {
                //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                //                txtt8.Focus();
                //                return;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        DialogResult dialogResult = MessageBox.Show("Trường số 8 trống bạn có muốn qua phiếu không?", "Thông báo", MessageBoxButtons.YesNo);
                //        if (dialogResult == DialogResult.No)
                //        {
                //            txt8.Focus();
                //            return;
                //        }
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < sohang8; i++)
                //    {
                //        if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
                //        {
                //            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
                //            txtt8.Focus();
                //            return;
                //        }
                //    }
                //}
                //sohang8 = txt8.Text.Split('\n').Length;
                #endregion
                string rule_8_name = dAEntry.GetStringSQL("Select Rules from dbo.[Template] where Id = " + Type_Image + "");
                if (rule_8_name.Contains(",8") == true)
                {
                    string dulieu = ToHalfWidth(txt8.Text);
                    for (int i = 0; i < sohang8; i++)
                    {
                        string dong8 = dulieu.Replace("\r", "").Split('\n')[i].ToString();
                        if (dong8.Length > 15)
                        {
                            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Sai Quy Tắc Lượng kí tự cho phép (15) !", "Thông Báo");
                            return;
                        }
                    }
                }
                #region đogs
                //if (Type_Image == 13 || Type_Image == 16 || Type_Image == 28 || Type_Image == 90)
                //{
                //    string dulieu = ToHalfWidth(txtt8.Text);
                //    for (int i = 0; i < sohang8; i++)
                //    {
                //        string dong8 = dulieu.Replace("\r", "").Split('\n')[i].ToString();
                //        if (dong8.Length > 15)
                //        {
                //            MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Sai Quy Tắc ( Form 13, 16, 28, 90 ) !", "Thông Báo");
                //            return;
                //        }
                //    }
                //    //txtt8.Text = ToHalfWidth(txtt8.Text);
                //}
                #endregion
            }
            if (checktruong8 == false)
            {
                if (sohang2 != sohang3)
                {
                    MessageBox.Show("Số hàng 2, 3   không đồng đều");
                    return;
                }
                if (sohang2 != sohang8 && txtt8.Visible == true)
                {
                    if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
                    {
                        if (txt8.Text != "")
                        {
                            MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
                        return;
                    }
                }
                if (sohang2 != sohang4 && txt4.Visible == true) // Sua txtt4     // || sohang2 != sohang8 && txt8.Visible == true)
                {
                    MessageBox.Show("Số hàng 2, 3, 4   không đồng đều");
                    return;
                }

                if (txt4.Visible == true && txtt8.Visible == true)
                {
                    if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
                    {
                        if (txt8.Text != "")
                        {
                            if (sohang2 != sohang4 || sohang2 != sohang8)
                            {
                                MessageBox.Show("Số hàng Trường 2, 3, 4, 8 không đồng đều");
                                return;
                            }
                        }

                    }
                    else
                    {
                        if (sohang2 != sohang4 || sohang2 != sohang8)
                        {
                            MessageBox.Show("Số hàng Trường 2, 3, 4, 8 không đồng đều");
                            return;
                        }
                    }
                }
                else if (txt2.Text == "" || txt3.Text == "")
                {
                    MessageBox.Show("Mã SP hoặc Số lượng trống");
                    return;
                }
                else if (arr22[arr22.Length - 1] == "" || arr3[arr3.Length - 1] == "")
                {
                    MessageBox.Show("Mã SP hoặc Số lượng có hàng trống");
                    return;
                }
            }
            #region
            //if (txtt8.Visible == true)
            //{
            //    sohang8 = txtt8.Text.Split('\n').Length;
            //    if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            //    {
            //        if (txtt8.Text != "")
            //        {
            //            for (int i = 0; i < sohang8; i++)
            //            {
            //                if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //                {
            //                    MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //                    txtt8.Focus();
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            DialogResult dialogResult = MessageBox.Show("Trường số 8 trống bạn có muốn qua phiếu không?", "Thông báo", MessageBoxButtons.YesNo);
            //            if (dialogResult == DialogResult.No)
            //            {
            //                txt8.Focus();
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
            //            if (txtt8.Text.Replace("\r", "").Split('\n')[i].ToString() == "")
            //            {
            //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Không Có Dữ Liệu !", "Thông Báo");
            //                txtt8.Focus();
            //                return;
            //            }
            //        }
            //    }
            //    if (Type_Image == 13 || Type_Image == 16 || Type_Image == 28 || Type_Image == 90)
            //    {
            //        string dulieu = ToHalfWidth(txtt8.Text);
            //        for (int i = 0; i < sohang8; i++)
            //        {
            //            string dong8 = dulieu.Replace("\r", "").Split('\n')[i].ToString();
            //            if (dong8.Length > 15)
            //            {
            //                MessageBox.Show("Quy Định Trường 8 . Dòng " + (i + 1) + " Sai Quy Tắc ( Form 13, 16, 28, 90 ) !", "Thông Báo");
            //                return;
            //            }
            //        }
            //        //txtt8.Text = ToHalfWidth(txtt8.Text);
            //    }
            //}
            //if (txt7.Text.Contains("\n") == true)
            //{
            //    if (madathang7 != sohang2 && madathang7 != sohang3)
            //    {
            //        MessageBox.Show("Số hàng ở Mã đặt hàng không đồng đều với Mã SP và Số Lượng");
            //        return;
            //    }
            //}
            //if (sohang2 != sohang3)
            //{
            //    MessageBox.Show("Số hàng 2, 3   không đồng đều");
            //    return;
            //}
            //if (checktruong8 == false)
            //{
            //    if (sohang2 != sohang8 && txtt8.Visible == true)
            //    {
            //        if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            //        {
            //            if (txt8.Text != "")
            //            {
            //                MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
            //                return;
            //            }

            //        }
            //        else
            //        {
            //            MessageBox.Show("Số hàng 2, 3 , 8  không đồng đều");
            //            return;
            //        }
            //    }
            //    if (sohang2 != sohang4 && txt4.Visible == true)// || sohang2 != sohang8 && txt8.Visible == true)
            //    {
            //        MessageBox.Show("Số hàng 2, 3, 4   không đồng đều");
            //        return;
            //    }

            //    if (txt4.Visible == true && txt8.Visible == true)
            //    {
            //        if (Type_Image == 29 || Type_Image == 61 || Type_Image == 62 || Type_Image == 63 || Type_Image == 95 || Type_Image == 96 || Type_Image == 97 || Type_Image == 150 || Type_Image == 151 || Type_Image == 152 || Type_Image == 153 || Type_Image == 179)
            //        {
            //            if (txt8.Text != "")
            //            {
            //                if (sohang2 != sohang4 || sohang2 != sohang8)
            //                {
            //                    MessageBox.Show("Số hàng Trường 2, 3, 4, 8 không đồng đều");
            //                    return;
            //                }
            //            }

            //        }
            //        else
            //        {
            //            if (sohang2 != sohang4 || sohang2 != sohang3)
            //            {
            //                MessageBox.Show("Số hàng Trường 2, 3, 4 không đồng đều");
            //                return;
            //            }
            //        }
            //    }
            //}
            #endregion
            #region Haipm update thêm chức năng 19042021

            if (sohang5 != sohang2 && sohang5 > 1)
            {
                MessageBox.Show("Số hàng 2 , 5  không đồng đều");
                return;
            }
            #endregion
            if (txt2.Text == "" || txt3.Text == "")
            {
                MessageBox.Show("Mã SP hoặc Số lượng trống");
                return;
            }
            else if (arr22[arr22.Length - 1] == "" || arr3[arr3.Length - 1] == "")
            {
                MessageBox.Show("Mã SP hoặc Số lượng có hàng trống");
                return;
            }
            lblEntry1.BackColor = SystemColors.Control;
            lblEntry2.BackColor = SystemColors.Control;
            zom = 20;
            bm_out = null;
            string rsEntr1 = "";
            string rsEntr2 = "";
            // update image content vao DB
            for (int i = 1; i < 10; i++)
            {
                if (i < 9)
                {
                    rsEntr1 = rsEntr1 + img.Content1[i] + "|";
                    rsEntr2 = rsEntr2 + img.Content2[i] + "|";
                }
                if (i == 9)
                {
                    rsEntr1 = rsEntr1 + img.Content1[i];
                    rsEntr2 = rsEntr2 + img.Content2[i];
                }
            }
            if (Type_Image == 13 || Type_Image == 16 || Type_Image == 28 || Type_Image == 90)
            {
                txtt8.Text = ToHalfWidth(txtt8.Text);
            }
            string rsCheck = "";
            string imgContentContent = txt2.Text.Trim().ToUpper() + "|" + txt3.Text.Trim().ToUpper() + "|" + txt4.Text.Trim().ToUpper() + "|" + txt5.Text.ToUpper() + "|" + txtt6.Text.Trim().ToUpper() + "|" + txt7.Text.Trim().ToUpper() + "|" + txtt8.Text.ToUpper() + "|" + txt9.Text.Trim().ToUpper() + "|" + txt10.Text.Trim().ToUpper();
            rsCheck = imgContentContent.Replace("\r", "");
            lsttxt.ForEach(s => { s.Text = ""; s.BackColor = SystemColors.Window; });
            //Lỗi sai E1
            //c = null;
            //c = new int[rsCheck.Length + 1, rsEntr1.Length + 1];
            //int vlLCS = LCS(rsCheck, rsEntr1);
            int tongloiE1 = 0;
            for (int i = 0; i < 9; i++)
            {
                string check = rsCheck.Split('|')[i].ToString();
                string entry = rsEntr1.Split('|')[i].ToString();
                if (check.Split('\n').Length >= entry.Split('\n').Length)
                {
                    string chuoiCheck = "";
                    string chuoiEntry = "";
                    for (int t = 0; t < entry.Split('\n').Length; t++)
                    {
                        string dong_entry = entry.Split('\n')[t].ToString();
                        string dong_check = check.Split('\n')[t].ToString();
                        if (dong_entry.Contains("*") == false)
                        {
                            chuoiCheck = chuoiCheck + dong_check;
                            chuoiEntry = chuoiEntry + dong_entry;
                            //int error_phieu = return_error(dong_entry, dong_check);
                            //tongloiE1 = tongloiE1 + error_phieu;
                        }

                    }
                    if (check.Split('\n').Length > entry.Split('\n').Length)
                    {
                        for (int t = entry.Split('\n').Length; t < check.Split('\n').Length; t++)
                        {
                            
                            string dong_check = check.Split('\n')[t].ToString();
                            chuoiCheck = chuoiCheck + dong_check;
                            //int error = dong_check.ToCharArray().Count(c => c == '*');
                            //tongloiE1 = tongloiE1 + (dong_check.Length - error);
                        }
                    }
                    tongloiE1 = tongloiE1 +  return_error(chuoiEntry, chuoiCheck);
                }
                else
                {

                    string chuoiCheck = "";
                    string chuoiEntry = "";
                    for (int t = 0; t < check.Split('\n').Length; t++)
                    {
                        string dong_entry = entry.Split('\n')[t].ToString();
                        string dong_check = check.Split('\n')[t].ToString();
                        if (dong_entry.Contains("*") == false)
                        {
                            chuoiCheck = chuoiCheck + dong_check;
                            chuoiEntry = chuoiEntry + dong_entry;
                            //int error_phieu = return_error(dong_entry, dong_check);
                            //tongloiE1 = tongloiE1 + error_phieu;
                        }

                    }
                    //if (check.Split('\n').Length > entry.Split('\n').Length)
                    //{
                    //if (check.Split('\n').Length > entry.Split('\n').Length)
                    //{
                    //    for (int t = check.Split('\n').Length - 1; t < entry.Split('\n').Length; t++)
                    //    {
                    //        string dong_entry = entry.Split('\n')[t].ToString();
                    //        if (dong_entry.Contains("*") == false)
                    //        {
                    //            tongloiE1 = tongloiE1 + dong_entry.Length;
                    //        }
                    //        //int error = dong_entry.ToCharArray().Count(c => c == '*');

                    //    }
                    //}
                    if (check.Split('\n').Length < entry.Split('\n').Length)
                    {
                        for (int t = check.Split('\n').Length; t < entry.Split('\n').Length; t++)
                        {
                            string dong_entry = entry.Split('\n')[t].ToString();
                            if (dong_entry.Contains("*") == false)
                            {
                                chuoiEntry = chuoiEntry + dong_entry;
                            }
                            //int error = dong_entry.ToCharArray().Count(c => c == '*');

                        }
                    }
                    tongloiE1 = tongloiE1 + return_error(chuoiEntry, chuoiCheck);
                    //}
                }
            }
            
            // Tính lỗi của E2
            int tongloiE2 = 0;

            for (int i = 0; i < 9; i++)
            {
                string check = rsCheck.Split('|')[i].ToString();
                string entry = rsEntr2.Split('|')[i].ToString();
                if (check.Split('\n').Length >= entry.Split('\n').Length)
                {
                    string chuoiCheck = "";
                    string chuoiEntry = "";
                    for (int t = 0; t < entry.Split('\n').Length; t++)
                    {
                        string dong_entry = entry.Split('\n')[t].ToString();
                        string dong_check = check.Split('\n')[t].ToString();
                        if (dong_entry.Contains("*") == false)
                        {
                            chuoiCheck = chuoiCheck + dong_check;
                            chuoiEntry = chuoiEntry + dong_entry;
                            //int error_phieu = return_error(dong_entry, dong_check);
                            //tongloiE2 = tongloiE2 + error_phieu;
                        }

                    }
                    if (check.Split('\n').Length > entry.Split('\n').Length)
                    {
                        for (int t = entry.Split('\n').Length; t < check.Split('\n').Length; t++)
                        {
                            //string dong_check = check.Split('\n')[t].ToString();
                            //int error = dong_check.ToCharArray().Count(c => c == '*');
                            //tongloiE2 = tongloiE2 + (dong_check.Length - error);
                            string dong_check = check.Split('\n')[t].ToString();
                            chuoiCheck = chuoiCheck + dong_check;
                        }
                    }
                    tongloiE2 = tongloiE2 + return_error(chuoiEntry, chuoiCheck);
                }
                else
                {
                    string chuoiCheck = "";
                    string chuoiEntry = "";
                    for (int t = 0; t < check.Split('\n').Length; t++)
                    {
                        string dong_entry = entry.Split('\n')[t].ToString();
                        string dong_check = check.Split('\n')[t].ToString();
                        if (dong_entry.Contains("*") == false)
                        {
                            //int error_phieu = return_error(dong_entry, dong_check);
                            //tongloiE2 = tongloiE2 + error_phieu;
                            chuoiCheck = chuoiCheck + dong_check;
                            chuoiEntry = chuoiEntry + dong_entry;
                        }

                    }
                    //if (check.Split('\n').Length > entry.Split('\n').Length)
                    //{
                    for (int t = check.Split('\n').Length; t < entry.Split('\n').Length; t++)
                    {
                        string dong_entry = entry.Split('\n')[t].ToString();
                        if (dong_entry.Contains("*") == false)
                        {
                            chuoiEntry = chuoiEntry + dong_entry;
                            //tongloiE2 = tongloiE2 + dong_entry.Length;
                        }
                        //int error = dong_entry.ToCharArray().Count(c => c == '*');

                    }
                    tongloiE2 = tongloiE2 +  return_error(chuoiEntry, chuoiCheck);
                    //}
                }
            }
            //if (rsEntr2.Length > rsCheck.Length)
            //{
            //    if (rsEntr2.Contains("*") == true)
            //    {
            //        int result3 = rsEntr2.ToCharArray().Count(c => c == '*');
            //        img.Loisai2 = rsEntr2.Length - vlLCS - result3;
            //        if (img.Loisai2 < 0)
            //        {
            //            img.Loisai2 = 0;
            //        }
            //    }
            //    else
            //    {
            //        img.Loisai2 = rsEntr2.Length - vlLCS;
            //    }
            //}
            //    //img.Loisai2 = rsEntr2.Length - vlLCS;
            //else
            //{
            //    if (rsEntr2.Contains("*") == true)
            //    {
                    
            //        //int result3 = rsEntr2.ToCharArray().Count(c => c == '*');
            //        //img.Loisai2 = rsCheck.Length - vlLCS - result3;
            //        //if (img.Loisai2 < 0)
            //        //{
            //        //    img.Loisai2 = 0;
            //        //}

            //    }
            //    else
            //    {
            //        img.Loisai2 = rsCheck.Length - vlLCS;
            //    }
            //    //img.Loisai2 = rsCheck.Length - vlLCS;
            //}
                
            img.Tongkytu = rsCheck.Length - 8;
            img.Result = img.Content1[0] + "|" + imgContentContent + "|" + img.Content1[10] + "|" + img.Content1[11] + "|" + img.Content1[12] + "|" + img.Content1[13];
            img.CheckerId = userId;
            // Thêm chức năng màu khi qua Check 24/06/2019
            string ResultE1 = dACheck.GetStringSQL("select Content1 from db_owner.ImageContent where AllImageId = " + img.Id);

            if (img.Result.ToString().Replace("\r", "").Replace("\n", "") == ResultE1.Replace("\r", "").Replace("\n", ""))
            {
                dACheck.ExecuteSQL("Update db_owner.ImageContent SET Color_Check_QC = N'0,0' where AllImageId = " + img.Id);
            }
            else
            {
                string Update_colum = "";
                string ResultE2 = dACheck.GetStringSQL("select Content2 from db_owner.ImageContent where AllImageId = " + img.Id);
                for (int i = 0; i < img.Result.ToString().Split('|').Count(); i++)
                {
                    string e1_test = ResultE1.Split('|')[i].ToString();
                    string e2_test = ResultE2.Split('|')[i].ToString();
                    string rsCheck_test = img.Result.Split('|')[i].ToString();
                    if (i == 0)
                    {
                        if (rsCheck_test != e1_test && rsCheck_test != e2_test)
                        {
                            Update_colum = Update_colum + (i + 1) + "|";
                        }
                    }
                    else
                    {
                        if (rsCheck_test.Replace("\r", "").Replace("\n", "") != e1_test.Replace("\r", "").Replace("\n", "") )
                        {
                            for (int t = 0; t < rsCheck_test.Replace("\r", "").Split('\n').Length; t++)
                            {
                                try
                                {
                                    //string t1 = e1_test.Replace("\r", "").Split('\n')[t].ToString();
                                    //string t2 = e2_test.Replace("\r", "").Split('\n')[t].ToString();
                                    //string c3 = rsCheck_test.Replace("\r", "").Split('\n')[t].ToString();
                                    if (rsCheck_test.Replace("\r", "").Split('\n')[t].ToString() != e1_test.Replace("\r", "").Split('\n')[t].ToString())
                                    {
                                        if (e2_test.Replace("\r", "").Split('\n').Length >= t + 1)
                                        {
                                            if (rsCheck_test.Replace("\r", "").Split('\n')[t].ToString() != e1_test.Replace("\r", "").Split('\n')[t].ToString())
                                            { Update_colum = Update_colum + (i + 1) + "," + (t + 1) + "‡"; }
                                        }
                                        else
                                        {
                                            Update_colum = Update_colum + (i + 1) + "," + (t + 1) + "‡";
                                        }
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        if (rsCheck_test.Replace("\r", "").Split('\n')[t].ToString() != e1_test.Replace("\r", "").Split('\n')[t].ToString())
                                        {
                                            //if (rsCheck_test.Replace("\r", "").Split('\n')[t].ToString() != e1_test.Replace("\r", "").Split('\n')[t].ToString())
                                            //{
                                                Update_colum = Update_colum + (i + 1) + "," + (t + 1) + "‡";
                                            //}
                                            //else
                                            //{
                                            //    Update_colum = Update_colum + (i + 1) + "," + (t + 1) + "‡";
                                            //}
                                        }
                                    }
                                    catch { Update_colum = Update_colum + (i + 1) + "," + (t + 1) + "‡"; }
                                }
                            }
                            Update_colum = Update_colum + "|";
                        }
                    }
                }
                dACheck.ExecuteSQL("Update db_owner.ImageContent SET Color_Check_QC = N'" + Update_colum + "' where AllImageId = " + img.Id);
            }
            // Hết chức năng mới
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
            // add image content
            try
            {
                dACheck.UpdateResutlQC(img,ms,tongloiE1,tongloiE2);
            }
            catch (Exception exception)
            {
                // rool back hitpoint
                dACheck.Return_HitpointCheck(img.Id);
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            btnBack.Enabled = true;
            saveimageid = img.Id;
            view_Image_TN.Dispose();
            // load image mới lên form
            // lấy id image entry
            imageSource = null;
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
                        btnBack.Enabled = false;
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
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Không load được ảnh: " + img.Uri, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Logic(img.Id);
            for (int i = 0; i < 9; i++)
            {
                lsttxt[i].ForeColor = Color.Red;
                lsttxt[i].Text = img.Content1[i + 1];
                numbertrtxt = i;
                string s1, s2;
                s1 = img.Content1[i + 1];
                s2 = img.Content2[i + 1];
                if (s1 != s2)
                {
                    lstlb[i].BackColor = Color.Red;
                }
                c = null;
                c = new int[s1.Length + 1, s2.Length + 1];
                LCS(s1, s2);
                BackTrack(s1, s2, s1.Length, s2.Length);
            }
            if (img.Notgood1 != 0)
            { lblEntry1.BackColor = Color.Red; }
            if (img.Notgood2 != 0)
            { lblEntry2.BackColor = Color.Red; }
            if (lsttxt[2].Visible == true)
            {
                //txtt4.Visible = true;
                //txtt4.BringToFront();
                //txtt4.Text = txt4.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[4].Visible == true)
            {
                txtt6.Visible = true;
                txtt6.BringToFront();
                txtt6.Text = txt6.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[6].Visible == true)
            {
                txtt8.Visible = true;
                txtt8.BringToFront();
                txtt8.Text = txt8.Text.Replace("\n", "\r\n");
            }
            txtt2.Text = txt2.Text.Replace("\n", "\r\n");
            txtt3.Text = txt3.Text.Replace("\n", "\r\n");
            // hiển thị user name của user đã entry            
            lblEntry1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
            lblEntry2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            lblpage.Text = img.Uri;
            lblsoluong.Text = (dACheck.ImageExistQC() + ListImage.Count).ToString();
            dtimeBefore = DateTime.Now;
        }
        public int return_error(string vl1, string vl2)
        {
            int eror = 0;
            c = null;
            c = new int[vl1.Length + 1, vl2.Length + 1];
            int vlLCS = LCS(vl1, vl2);
            if (vl1 == vl2)
                eror = 0;
            if (vl1.Length > vl2.Length)
                eror = vl1.Length - vlLCS;
            else
                eror = vl2.Length - vlLCS;
            return eror;
        }
        private void timergetanh_Tick(object sender, EventArgs e)
        {
            if (ListImage.Count < 2)
            {
                try
                {
                    int idmg = dACheck.GetkQC();
                    if (idmg > 0)
                    {
                        BOImageContent_Check img2 = dACheck.GetImageQC(idmg);
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
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            zom = 20;
            bm_out = null;
            dtimeBefore = DateTime.Now;
            if (saveimageid == 0)
            {
                MessageBox.Show("Can not back", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // load image mới lên form
            // lấy id image entry
            id = 0;
            try
            {
                dACheck.SetHitPointImage_QC(img.Id);
                dACheck.Set_result_null_QC(saveimageid);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //lấy Imageid trước           
            try
            {
                id = saveimageid;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            saveimageid = 0;
            // lay image đã entry
            try
            {
                img = dACheck.GetImageCheck(id);
                    dtbinary = dACheck.Get_BinaryCheck(img.Uri, img.Id);               
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Batch đã hoàn thành");
                finish = true;
                this.Close();
                return;
            }

            // lay image free
            try
            {
                imageSource = new Bitmap(Io_Entry.byteArrayToImage((byte[])dtbinary.Rows[0][0]));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Batch đã hoàn thành");
                this.Close();
                return;
            }

            //Get Image
            try
            {
                view_Image_TN.Dispose();
                //imageSource = (Bitmap)img.Imagesource.Clone();
                view_Image_TN.Image = imageSource;
                dbzome = view_Image_TN.CurrentZoom;
            }
            catch
            {
                MessageBox.Show("Server chưa có ảnh: " + img.Uri, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Logic(img.Id);
            for (int i = 0; i < 9; i++)
            {
                lsttxt[i].ForeColor = Color.Red;
                lsttxt[i].Text = img.Content1[i + 1];
                numbertrtxt = i;
                string s1, s2;
                s1 = img.Content1[i + 1];
                s2 = img.Content2[i + 1];
                if (s1 != s2)
                {                    
                    lstlb[i].BackColor = Color.Red;
                }
                c = null;
                c = new int[s1.Length + 1, s2.Length + 1];
                LCS(s1, s2);
                BackTrack(s1, s2, s1.Length, s2.Length);
            }
            if (img.Notgood1 != 0)
            { lblEntry1.BackColor = Color.Red; }
            if (img.Notgood2 != 0)
            { lblEntry2.BackColor = Color.Red; }
            if (lsttxt[2].Visible == true)
            {
                //txtt4.Visible = true;
                //txtt4.BringToFront();
                //txtt4.Text = txt4.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[4].Visible == true)
            {
                txtt6.Visible = true;
                txtt6.BringToFront();
                txtt6.Text = txt6.Text.Replace("\n", "\r\n");
            }
            if (lsttxt[6].Visible == true)
            {
                txtt8.Visible = true;
                txtt8.BringToFront();
                txtt8.Text = txt8.Text.Replace("\n", "\r\n");
            }
            txtt2.Text = txt2.Text.Replace("\n", "\r\n");
            txtt3.Text = txt3.Text.Replace("\n", "\r\n");
            // hiển thị user name của user đã entry         
            lblEntry1.Text = img.Ms1 + " - " + img.Name1 + " - " + img.Group1;
            lblEntry2.Text = img.Ms2 + " - " + img.Name2 + " - " + img.Group2;
            lblpage.Text = img.Uri;
            lblsoluong.Text = (dACheck.ImageExistQC() + ListImage.Count).ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnsop_Click(object sender, EventArgs e)
        {
            FrmSOP frmsop = new FrmSOP();
            binary = dAEntry.Get_imgsop(resul);
            frmsop.getimg = binary;
            frmsop.ShowDialog();
        }

        private void btnrtr_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("270");
        }

        private void btnrtl_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("90");
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            txtt2.Text = txt2.Text.Replace("\n", "\r\n");
            int sohang = txtt2.Text.Split('\r').Length;
            txtlb2.Text = string.Join("\r\n", arr2.Take(sohang));
            txtlb2.AppendText("\r\n");
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            txtt3.Text = txt3.Text.Replace("\n", "\r\n");
            int sohang = txtt3.Text.Split('\r').Length;
            txtlb3.Text = string.Join("\r\n", arr3.Take(sohang));
            txtlb3.AppendText("\r\n");
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            txt4.Text = txt4.Text.Replace("\n", "\r\n");
            int sohang = txt4.Text.Split('\r').Length;
            txtlb4.Text = string.Join("\r\n", arr4.Take(sohang));
            txtlb4.AppendText("\r\n");
        }

        private void txtt8_TextChanged(object sender, EventArgs e)
        {
            int sohang = txtt8.Text.Split('\r').Length;
            txtlb8.Text = string.Join("\r\n", arr8.Take(sohang));
            txtlb8.AppendText("\r\n");
        }

        private void txt8_Click(object sender, EventArgs e)
        {
            chckcheck.Checked = false;
            txt8.SendToBack();
            txt6.SendToBack();
            //txt4.SendToBack();
        }

        private void chckcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chckcheck.Checked)
            {
                txt6.BringToFront();
                txtlb8.BringToFront();
                txt8.BringToFront();
                //txt4.BringToFront();
            }
            else
            {
                txt6.SendToBack();
                txtlb8.SendToBack();
                txt8.SendToBack();
                //txt4.SendToBack();
            }
        }

        private void view_Image_TN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                view_Image_TN.RotateImage("90");
        }

        private void txt6_Click(object sender, EventArgs e)
        {
            chckcheck.Checked = false;
            txt6.SendToBack();
            txt8.SendToBack();
            //txt4.SendToBack();
        }

        private void txtt6_TextChanged(object sender, EventArgs e)
        {
            txt6.Text = txtt6.Text;
        }

        private void txt7_Leave(object sender, EventArgs e)
        {
            txt7.Size = new Size(152, 27);
            if (txt7.Text.Contains("\n") == true)
            {
                //txt7.Size = new Size(152, 511);
                lbl3.Visible = true;
                txt3.Visible = true;
                //txt4.Visible = true;
                txtlb3.Visible = true;
                //txtlb4.Visible = true;
                //lbl4.Visible = true;
                if (bien4 == 2)
                {
                    txt4.Visible = true;
                    lbl4.Visible = true;
                    txtlb4.Visible = true;
                }
                txtlb7.Multiline = false;
                txtlb7.Text = "1";

            }
            else
            {

            }
        }
        int bien4;
        private void txt7_Click(object sender, EventArgs e)
        {
            if (txt7.Text.Contains("\n") == true)
            {
                txt7.Size = new Size(152, 511);
                txt3.Visible = false;
                //txt4.Visible = false;
                txtlb3.Visible = false;

                lbl3.Visible = false;
                //lbl4.Visible = false;
                //if (txt4.Visible == false)
                //{
                //    bien4 = 1;
                //    txt4.Visible = false;
                //    lbl4.Visible = false;
                //}
                if (txt4.Visible == true)
                {

                    bien4 = 2;
                    txt4.Visible = false;
                    lbl4.Visible = false;
                    txtlb4.Visible = false;
                }
                txtlb7.Multiline = true;
                int sohang = txt5.Text.Split('\r').Length;
                if (sohang > 1)
                {
                    txtlb7.Multiline = true;
                    txtlb7.Height = 511;
                }
                txtlb7.Text = string.Join("\r\n", arr2.Take(sohang));
                txtlb7.AppendText("\r\n");
            }
            else
            {
            }
        }

        private void txt5_Click(object sender, EventArgs e)
        {
            if (txt5.Text.Contains("\n") == true)
            {
                txt5.Size = new Size(152, 511);
                txt2.Visible = false;
                //txt4.Visible = false;
                txtlb2.Visible = false;
                lbl2.Visible = false;
                txtlb5.Multiline = true;
                txtlb5.Height = 511;
                int sohang = txt5.Text.Split('\n').Length;
                if (sohang > 1)
                {
                    txtlb5.Multiline = true;
                    txtlb5.Height = 511;
                }
                txtlb5.Text = string.Join("\r\n", arr2.Take(sohang));
                txtlb5.AppendText("\r\n");
            }
            else
            {
            }
        }

        private void txt5_Leave(object sender, EventArgs e)
        {
            txt5.Size = new Size(152, 27);
            for (int i = 0; i < txt5.Text.Replace("\r", "").Split('\n').Length; i++)
            {
                if (txt5.Text.Replace("\r", "").Split('\n')[i].Length != 8 && txt5.Text.Replace("\r", "").Split('\n')[i].Length != 0)
                {
                    MessageBox.Show("Trường số 5: Dòng " + (i + 1) + " sai quy tắc 8 kí tự và bỏ trống !");
                    txt5.Focus();
                    txt5.SelectionStart = txt5.Text.Length;
                    return;
                }
            }
            if (txt5.Text.Contains("\n") == true)
            {
                //txt7.Size = new Size(152, 511);
                lbl2.Visible = true;
                txt2.Visible = true;
                //txt4.Visible = true;
                txtlb2.Visible = true;
                txtlb5.Multiline = false;
                txtlb5.Text = "1";
            }
            else
            {

            }
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sohang = txt5.Text.Split('\n').Length;
                if (sohang > 1)
                {
                    txtlb5.Multiline = true;
                    txtlb5.Height = 511;
                }
                txtlb5.Text = string.Join("\r\n", arr2.Take(sohang));
                txtlb5.AppendText("\r\n");
            }
            catch { }
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sohang = txt7.Text.Split('\n').Length;
                if (sohang > 1)
                {
                    txtlb7.Multiline = true;
                    txtlb7.Height = 511;
                }
                txtlb7.Text = string.Join("\r\n", arr2.Take(sohang));
                txtlb7.AppendText("\r\n");
            }
            catch { }
        }

        private void txtt4_TextChanged(object sender, EventArgs e)
        {
            //int sohang = txtt4.Text.Split('\r').Length;
            //txtlb4.Text = string.Join("\r\n", arr4.Take(sohang));
            //txtlb4.AppendText("\r\n");
        }

        private void txt4_Click(object sender, EventArgs e)
        {
            //chckcheck.Checked = false;
            //txt8.SendToBack();
            //txt6.SendToBack();
            //txt4.SendToBack();
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            txtt8.Text = txt8.Text.Replace("\n", "\r\n");
            int sohang = txtt8.Text.Split('\r').Length;
            txtlb8.Text = string.Join("\r\n", arr8.Take(sohang));
            txtlb8.AppendText("\r\n");
        }
    }
}

