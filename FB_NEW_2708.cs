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

namespace VCB_Entry
{
    public partial class FB_NEW_2708 : Form
    {
        DAEntry_Entry daEntry = new DAEntry_Entry();
        public int uID;
        Bitmap bitmapTmp;
        public string user_login;
        string[] info_User;
        DataTable dt_viewFB = new DataTable();
        string[] Name_TruongPLus;
        int[] lst_vitrisai;
        public FB_NEW_2708()
        {
            lst_vitrisai = new int[] {0,0,0,0,0,0,0,0,0};
            Name_TruongPLus = new string [] {"2-Mã SP/品番/JANコード/商品名", "3-Số lượng/数量", "4-Đơn giá/単価", "5-Thời gian/指定納品日", "6-Ghi chú 1/摘要", "7-Mã đặt hàng/仕入先コード", "8-Ghi chú 2/備考", "9-Phân loại/直送区分", "10-Mã nơi GH/直送先コード" };
            InitializeComponent();
        }
        private string BackTrack(string s1, string s2, int i, int j, RichTextBox rtb)
        {
            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
            {
                rtb.SelectionStart = i - 1;
                rtb.SelectionLength = 1;
                rtb.SelectionColor = Color.Black;
                return BackTrack(s1, s2, i - 1, j - 1, rtb) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
            {
                
                return BackTrack(s1, s2, i - 1, j, rtb);
            }
            else
            {
                
                return BackTrack(s1, s2, i, j - 1, rtb);
            }
        }
        private string BackTrack2(string s1, string s2, int i, int j, RichTextBox rtb)
        {
            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
            {
                rtb.SelectionStart = i - 1;
                rtb.SelectionLength = 1;
                rtb.SelectionColor = Color.Black;
                return BackTrack2(s1, s2, i - 1, j - 1, rtb) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
            {

                return BackTrack2(s1, s2, i - 1, j, rtb);
            }
            else
            {

                return BackTrack2(s1, s2, i, j - 1, rtb);
            }
        }
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        static int[,] c;
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
        static int LCS2(string s1, string s2)
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
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        int bienngay;
        private void btn_viewNgay_Click(object sender, EventArgs e)
        {
            grThongke.DataSource = null;
            truongloi = 0;
            truongloi = 0;
            tongtruong_Entrynhap=0;
            lst_vitrisai = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            vitri =0;
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd");
            if (ngaycuoi == timeNow)
            {
                info_User = daEntry.usr_FB(user_login);
                string hour = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();
                if (min.ToString().Length < 2)
                {
                    min = "0" + min;
                }
                string time_now = hour.ToString() + min.ToString();
                //string time_now = "1430";
                if (Convert.ToInt32(time_now) >= 1420)
                {
                    // Xem được ca 1,2,3, 4 
                    if (info_User[2] == "1")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content2 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2,3,4)");
                    }
                    else if (info_User[2] == "2")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content1 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2,3,4)");
                    }
                    
                    if (dt_viewFB.Rows.Count > 0)
                    {
                        Ham_Show_info();
                    }
                }
                else if (Convert.ToInt32(time_now) >= 1120)
                {
                    // Xem được ca 1,2,3
                    if (info_User[2] == "1")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content2 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2,3)");
                    }
                    else if (info_User[2] == "2")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content1 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2,3)");
                    }

                    if (dt_viewFB.Rows.Count > 0)
                    {
                        Ham_Show_info();
                    }

                }
                else if (Convert.ToInt32(time_now) >= 920)
                {
                    // Xem được ca 1,2

                    if (info_User[2] == "1")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content2 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2)");
                    }
                    else if (info_User[2] == "2")
                    {
                        dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName ,Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content1 as 'ContentEntryOther' from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " > 0 and TurnUp in (1,2)");
                    }
                    //.DataSource = dt_viewFB;
                    if (dt_viewFB.Rows.Count > 0)
                    {
                        Ham_Show_info();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa tới giờ xem FB nhé !", "Thông Báo");
                    this.Close();
                    return;
                }
            }
            else
            {
                bienngay = 1;
                info_User = daEntry.usr_FB(user_login);
                string hour = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();

                //string time_now = hour.ToString() + min.ToString();
                //string time_now = "1110";

                // Xem được ca 1,2,3, 4 
                if (info_User[2] == "1")
                {
                    dt_viewFB = daEntry.GetDatatableSQL("select ImageName , Loisai" + info_User[2] + " as'LoiSai',Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content2 as 'ContentEntryOther' from db_owner.[BackUp_ImageContent] join dbo.[ServerImage_BACKUP] on BackUp_ImageContent.ImageName = [ServerImage_BACKUP].NameImage where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and Time = '" + ngaycuoi + "'");
                }
                else if (info_User[2] == "2")
                {
                    dt_viewFB = daEntry.GetDatatableSQL("select ImageName , Loisai" + info_User[2] + " as'LoiSai',Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId,Content1 as 'ContentEntryOther' from db_owner.[BackUp_ImageContent] join dbo.[ServerImage_BACKUP] on BackUp_ImageContent.ImageName = [ServerImage_BACKUP].NameImage where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and Time = '" + ngaycuoi + "'");
                }

                if (dt_viewFB.Rows.Count > 0)
                {
                    Ham_Show_info();
                }
            }
            if ( info_User[2] == "1")
            {
                lbvaitro.Text = "E - 1";
                lbE_vitri.Text = "E1";
            }
            else
            {
                lbvaitro.Text = "E - 2";
                lbE_vitri.Text = "E2";
            }
        }
        string ngaycuoi;
        private void dtpngaycuoi_ValueChanged(object sender, EventArgs e)
        {
            string d = dtpngaycuoi.Value.Day.ToString();
            string m = dtpngaycuoi.Value.Month.ToString();
            if (Convert.ToInt16(d) < 10)
            {
                d = "0" + d;
            }
            if (Convert.ToInt16(m) < 10)
            {
                m = "0" + m;
            }
            ngaycuoi = +dtpngaycuoi.Value.Year + "-" + m + "-" + d;
            if (ngaycuoi != null)
            {
                btn_viewNgay.Enabled = true;
            }
        }

        string content_other = "";
        string content_entry = "";
        string content_Check = "";
        string content_LC = "";
        string nameImage;
        string[] tach_entry;
        string[] tach_check;
        string[] tach_LC;
        string[] tach_EntryOther;
        string str_data_Entry1;
        string str_data_Check1;
        string str_data_LC1;
        string str_data_entryOther;
        public void Ham_Show_info()
        {
            content_entry = dt_viewFB.Rows[0]["ContentEntry"].ToString();

            content_Check = dt_viewFB.Rows[0]["ContentCheckQC"].ToString();
            content_LC = dt_viewFB.Rows[0]["ContentLC"].ToString();
            
            nameImage = content_entry.Split('|')[content_entry.Split('|').Length - 1];
            string checker = dt_viewFB.Rows[0]["CheckerId"].ToString();
            string name_checker = daEntry.name_checker(checker);
            tach_entry = content_entry.Replace("\r", "").Split('|');
            tach_check = content_Check.Replace("\r", "").Split('|');
            tach_LC = content_LC.Replace("\r", "").Split('|');
            content_other = dt_viewFB.Rows[0]["ContentEntryOther"].ToString();
            tach_EntryOther = content_other.Replace("\r", "").Split('|');
            //lbCheck.Text = name_checker;
            //lb_User.Text = info_User[4].ToString();
            //

            //Sum_tongloi = dt_viewFB.Compute("Sum(LoiSai)", string.Empty);
            //
            //lbTongloi.Text = Convert.ToString(Sum_tongloi);
            //lbLoi.Text = dt_viewFB.Rows[0]["LoiSai"].ToString();
            Add_Data();
            if (bienngay == 1)
            {
                grThongke.DataSource = dt_viewFB;
                grThongkeV.Columns[2].Visible = false;
                grThongkeV.Columns[3].Visible = false;
                grThongkeV.Columns[4].Visible = false;
                grThongkeV.Columns[5].Visible = false;
                grThongkeV.Columns[6].Visible = false;
                grThongkeV.Columns[0].Width = 1000;
                grThongkeV.Columns[1].Width = 300;
                //grThongkeV.Columns[2].Width = 200;

            }
            else
            {
                grThongke.DataSource = dt_viewFB;
                grThongkeV.Columns[2].Visible = false;
                grThongkeV.Columns[3].Visible = false;
                grThongkeV.Columns[4].Visible = false;
                grThongkeV.Columns[5].Visible = false;
                if (dt_viewFB.Columns.Count > 5)
                {
                    try
                    {
                        grThongkeV.Columns[2].Visible = true;
                        grThongkeV.Columns[6].Visible = false;
                        grThongkeV.Columns[7].Visible = false;
                    }
                    catch { }
                }
                grThongkeV.Columns[0].Width = 100;
                grThongkeV.Columns[1].Width = 800;
                grThongkeV.Columns[2].Width = 200;
            }
            //grThongkeV.BestFitColumns();
        }
        int truongloi ;
        int tongtruong_Entrynhap;
        
        int vitri;
        public void Add_Data()
        {
            truongloi = 0;
            truongloi = 0;
            tongtruong_Entrynhap = 0;
            lst_vitrisai = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            vitri = 0;
            //lst_rtb_entry.ForEach(x => x.Text = "");
            //lst_rtb_check.ForEach(x => x.Text = "");
            //lst_rtb_lastcheck.ForEach(x => x.Text = "");
            //lstlb_entry.ForEach(x => x.BackColor = Color.White);
            //lstlb_Cheeck.ForEach(x => x.BackColor = Color.White);
            //lstlb_LC.ForEach(x => x.BackColor = Color.White);
            tach_entry = content_entry.Replace("\r", "").Split('|');
            tach_check = content_Check.Replace("\r", "").Split('|');
            tach_LC = content_LC.Replace("\r", "").Split('|');
            //content_other = dt_viewFB.Rows[0]["ContentEntryOther"].ToString();
            tach_EntryOther = content_other.Replace("\r", "").Split('|');
            

            for (int i = 1; i < 10; i++)
            {
                if (tach_entry[i].ToString() != "")
                {
                    tongtruong_Entrynhap++;
                }
            }
            for (int i = 1; i < 10; i++)
            {
                string str_data_Entry = tach_entry[i].ToString();
                string str_data_Check = tach_check[i].ToString();
                string str_data_LC = tach_LC[i].ToString();

                if (str_data_Entry != str_data_Check || str_data_Entry != str_data_LC && str_data_LC.Replace("\n","") != "")
                {
                    lst_vitrisai[truongloi] = i;
                    truongloi++;

                }
            }
            lbSoTruongSai.Text = truongloi.ToString();
            lbTongTruongSai.Text = tongtruong_Entrynhap.ToString();
            //for (int i = 1; i < 9; i++)
            //{
            str_data_Entry1 = tach_entry[Convert.ToInt32(lst_vitrisai[0])].ToString();
            str_data_Check1 = tach_check[Convert.ToInt32(lst_vitrisai[0])].ToString();
            str_data_LC1 = tach_LC[Convert.ToInt32(lst_vitrisai[0])].ToString();
            str_data_entryOther = tach_EntryOther[Convert.ToInt32(lst_vitrisai[0])].ToString();

            //    if (str_data_Entry != str_data_Check || str_data_Entry != str_data_LC)
            //    {
            lbTruongSai.Text = Name_TruongPLus[Convert.ToInt32(lst_vitrisai[0]) -1].ToString();
            rtb_entry.Text = str_data_Entry1;
            rtb_check.Text = str_data_Check1;
            rtb_LC.Text = str_data_LC1;
            //tô đỏ nhưng chữ sai của entry
            rtb_entry.SelectionStart = 0;
            rtb_entry.SelectionLength = rtb_entry.Text.Length;
            rtb_entry.SelectionColor = Color.Red;

            rtb_check.SelectionStart = 0;
            rtb_check.SelectionLength = rtb_check.Text.Length;
            rtb_check.SelectionColor = Color.Red;

            rtb_LC.SelectionStart = 0;
            rtb_LC.SelectionLength = rtb_LC.Text.Length;
            rtb_LC.SelectionColor = Color.Red;
            //hiển thị chữ cái sai entry.
            string s1, s2;
            s1 = rtb_entry.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);

            //BackTrack(s1, s2, s1.Length, s2.Length, rtbLC);
            //hiển thị chữ cái sai Check.               
            s1 = rtb_check.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_check);
            //break;
            //}
            //lst_rtb_entry[i].Text = tach_entry[i + 1].ToString();
            //lst_rtb_check[i].Text = tach_check[i + 1].ToString();
            //lst_rtb_lastcheck[i].Text = tach_LC[i + 1].ToString();


            //hiển thị chữ cái sai lc  
            s2 = rtb_entry.Text;
            s1 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS2(s1, s2);
            BackTrack2(s1, s2, s1.Length, s2.Length, rtb_LC);
            //}
            btn_back.Enabled = false;
            if ( truongloi == 1)
            {
                btn_back.Enabled = false;
                btn_next.Enabled = false;
            }
            else
            {
                //btn_back.Enabled = true;
                btn_next.Enabled = true;
            }
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd");
            if ( ngaycuoi == timeNow)
            {
                bitmapTmp = new Bitmap(byteArrayToImage(daEntry.getImageOnServer(nameImage)));
            }
            else
            {
                bitmapTmp = new Bitmap(byteArrayToImage(daEntry.getImageOnServer_BK(nameImage)));
            }
            
            ImgV.Image = bitmapTmp;
            
        }
        static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void grThongkeV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int r = grThongkeV.FocusedRowHandle;
            try
            {
                if (r > -1)
                {
                    //string data = grThongkeV.GetRowCellValue(r, grThongkeV.Columns["ImageName"]).ToString();
                    //nameImage = data;
                    content_entry = dt_viewFB.Rows[r]["ContentEntry"].ToString();
                    content_Check = dt_viewFB.Rows[r]["ContentCheckQC"].ToString();
                    content_LC = dt_viewFB.Rows[r]["ContentLC"].ToString();
                    content_other = dt_viewFB.Rows[r]["ContentEntryOther"].ToString();
                    nameImage = content_entry.Split('|')[content_entry.Split('|').Length - 1];
                    string checker = dt_viewFB.Rows[r]["CheckerId"].ToString();
                    string name_checker = daEntry.name_checker(checker);
                    lbCheck.Text = name_checker;
                    lb_User.Text = info_User[4].ToString();
                    lbLoi.Text = dt_viewFB.Rows[r]["LoiSai"].ToString();
                    Add_Data();
                    //txtText.Text = data.dataSubstring(5);
                    //chuoi = data;
                }
            }
            catch { }
        }

        private void FB_NEW_2708_Load(object sender, EventArgs e)
        {
            //tableLayoutPanel3.ColumnStyles =  SizeType.
            tableLayoutPanel3.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel3.ColumnStyles[0].Width = 50;
            tableLayoutPanel3.RowStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[0].Height = 40;
            tableLayoutPanel3.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[1].Height = (tableLayoutPanel3.Height -40)/3;
            tableLayoutPanel3.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[2].Height = (tableLayoutPanel3.Height - 40) / 3;
            tableLayoutPanel4.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel4.RowStyles[1].Height = 100;

            string d = dtpngaycuoi.Value.Day.ToString();
            string m = dtpngaycuoi.Value.Month.ToString();
            if (Convert.ToInt16(d) < 10)
            {
                d = "0" + d;
            }
            if (Convert.ToInt16(m) < 10)
            {
                m = "0" + m;
            }
            ngaycuoi = +dtpngaycuoi.Value.Year + "-" + m + "-" + d;
        }
        
        
        private void btn_next_Click(object sender, EventArgs e)
        {
            vitri++;
            btn_back.Enabled = true;
            tach_entry = content_entry.Replace("\r", "").Split('|');
            tach_check = content_Check.Replace("\r", "").Split('|');
            tach_LC = content_LC.Replace("\r", "").Split('|');
            //content_other = dt_viewFB.Rows[0]["ContentEntryOther"].ToString();
            
            str_data_Entry1 = tach_entry[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            str_data_Check1 = tach_check[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            str_data_LC1 = tach_LC[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            tach_EntryOther = content_other.Replace("\r", "").Split('|');
            str_data_entryOther = tach_EntryOther[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            //    if (str_data_Entry != str_data_Check || str_data_Entry != str_data_LC)
            //    {
            lbTruongSai.Text = Name_TruongPLus[Convert.ToInt32(lst_vitrisai[vitri]) - 1].ToString();
            rtb_entry.Text = str_data_Entry1;
            rtb_check.Text = str_data_Check1;
            rtb_LC.Text = str_data_LC1;
            //tô đỏ nhưng chữ sai của entry
            rtb_entry.SelectionStart = 0;
            rtb_entry.SelectionLength = rtb_entry.Text.Length;
            rtb_entry.SelectionColor = Color.Red;

            rtb_check.SelectionStart = 0;
            rtb_check.SelectionLength = rtb_check.Text.Length;
            rtb_check.SelectionColor = Color.Red;

            rtb_LC.SelectionStart = 0;
            rtb_LC.SelectionLength = rtb_LC.Text.Length;
            rtb_LC.SelectionColor = Color.Red;
            //hiển thị chữ cái sai entry.
            string s1, s2;
            s1 = rtb_entry.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);

            //BackTrack(s1, s2, s1.Length, s2.Length, rtbLC);
            //hiển thị chữ cái sai Check.               
            s1 = rtb_check.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_check);


            //hiển thị chữ cái sai lc  
            s1 = rtb_LC.Text;
            s2 = rtb_entry.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_LC);
            if ( vitri == truongloi -1)
            {
                btn_next.Enabled = false;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            vitri--;
            btn_next.Enabled = true;
            tach_entry = content_entry.Replace("\r", "").Split('|');
            tach_check = content_Check.Replace("\r", "").Split('|');
            tach_LC = content_LC.Replace("\r", "").Split('|');
            //content_other = dt_viewFB.Rows[0]["ContentEntryOther"].ToString();
            
            str_data_Entry1 = tach_entry[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            str_data_Check1 = tach_check[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            str_data_LC1 = tach_LC[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            tach_EntryOther = content_other.Replace("\r", "").Split('|');
            str_data_entryOther = tach_EntryOther[Convert.ToInt32(lst_vitrisai[vitri])].ToString();
            //    if (str_data_Entry != str_data_Check || str_data_Entry != str_data_LC)
            //    {
            lbTruongSai.Text = Name_TruongPLus[Convert.ToInt32(lst_vitrisai[vitri]) - 1].ToString();
            rtb_entry.Text = str_data_Entry1;
            rtb_check.Text = str_data_Check1;
            rtb_LC.Text = str_data_LC1;
            //tô đỏ nhưng chữ sai của entry
            rtb_entry.SelectionStart = 0;
            rtb_entry.SelectionLength = rtb_entry.Text.Length;
            rtb_entry.SelectionColor = Color.Red;

            rtb_check.SelectionStart = 0;
            rtb_check.SelectionLength = rtb_check.Text.Length;
            rtb_check.SelectionColor = Color.Red;

            rtb_LC.SelectionStart = 0;
            rtb_LC.SelectionLength = rtb_LC.Text.Length;
            rtb_LC.SelectionColor = Color.Red;
            //hiển thị chữ cái sai entry.
            string s1, s2;
            s1 = rtb_entry.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);

            //BackTrack(s1, s2, s1.Length, s2.Length, rtbLC);
            //hiển thị chữ cái sai Check.               
            s1 = rtb_check.Text;
            s2 = rtb_LC.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_check);

            //hiển thị chữ cái sai lc  
            s1 = rtb_LC.Text;
            s2 = rtb_entry.Text;
            c = null;
            c = new int[s1.Length + 1, s2.Length + 1];
            LCS(s1, s2);
            BackTrack(s1, s2, s1.Length, s2.Length, rtb_LC);
            if ( vitri ==0)
            {
                btn_back.Enabled = false;
            }
        }

        private void grThongkeV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void rtb_entry_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rtb_entry_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtb_entry_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void rtb_entry_MouseDown_1(object sender, MouseEventArgs e)
        {
            RichTextBox rtxt = (RichTextBox)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (rtxt.Text == str_data_Entry1)
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = str_data_entryOther;
                    //if (rtxt.TabIndex == 6)
                    //{ txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //if (rtxt.TabIndex == 4)
                    //{ txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = rtxt.Text;
                    s2 = rtb_LC.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);
                    if (lbE_vitri.Text == "E1")
                    {
                        //lbvaitro.Text = "E - 1";
                        lbE_vitri.Text = "E2";
                    }
                    else
                    {
                        //lbvaitro.Text = "E - 2";
                        lbE_vitri.Text = "E1";
                    }
                    rtb_LC.SelectionStart = 0;
                    rtb_LC.SelectionLength = rtb_LC.Text.Length;
                    rtb_LC.SelectionColor = Color.Red;
                    //hiển thị chữ cái sai lc  
                    s1 = rtb_LC.Text;
                    s2 = rtxt.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_LC);
                }
                else if (rtxt.Text == str_data_entryOther)
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = str_data_Entry1;
                    //if (rtxt.TabIndex == 6)
                    //{ txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //if (rtxt.TabIndex == 4)
                    //{ txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = rtxt.Text;
                    s2 = rtb_LC.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);
                    if (lbE_vitri.Text == "E1")
                    {
                        //lbvaitro.Text = "E - 1";
                        lbE_vitri.Text = "E2";
                    }
                    else
                    {
                        //lbvaitro.Text = "E - 2";
                        lbE_vitri.Text = "E1";
                    }
                    rtb_LC.SelectionStart = 0;
                    rtb_LC.SelectionLength = rtb_LC.Text.Length;
                    rtb_LC.SelectionColor = Color.Red;
                    //hiển thị chữ cái sai lc  
                    s1 = rtb_LC.Text;
                    s2 = rtxt.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_LC);
                }
                else
                {
                    rtxt.SelectionStart = 0;
                    rtxt.SelectionLength = rtxt.Text.Length;
                    rtxt.SelectionColor = Color.Red;
                    rtxt.Text = str_data_Entry1;
                    //if (rtxt.TabIndex == 6)
                    //{ txtt8.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //if (rtxt.TabIndex == 4)
                    //{ txtt6.Text = rtxt.Text.Replace("\n", "\r\n"); }
                    //numbertrtxt = rtxt.TabIndex;
                    string s1, s2;
                    s1 = rtxt.Text;
                    s2 = rtb_LC.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_entry);
                    if (lbE_vitri.Text == "E1")
                    {
                        //lbvaitro.Text = "E - 1";
                        lbE_vitri.Text = "E2";
                    }
                    else
                    {
                        //lbvaitro.Text = "E - 2";
                        lbE_vitri.Text = "E1";
                    }
                    rtb_LC.SelectionStart = 0;
                    rtb_LC.SelectionLength = rtb_LC.Text.Length;
                    rtb_LC.SelectionColor = Color.Red;
                    //hiển thị chữ cái sai lc  
                    s1 = rtb_LC.Text;
                    s2 = rtxt.Text;
                    c = null;
                    c = new int[s1.Length + 1, s2.Length + 1];
                    LCS(s1, s2);
                    BackTrack(s1, s2, s1.Length, s2.Length, rtb_LC);
                }
            }
        }
    }
}
