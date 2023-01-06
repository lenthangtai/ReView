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
    public partial class FB : Form
    {
        public int uID;
        Bitmap bitmapTmp;
        public string user_login;
        DAEntry_Entry daEntry = new DAEntry_Entry();
        List<RichTextBox> lst_rtb_entry;
        List<RichTextBox> lst_rtb_check;
        List<RichTextBox> lst_rtb_lastcheck;
        List<Label> lstlb_entry;
        List<Label> lstlb_Cheeck;
        List<Label> lstlb_LC;
        string[] info_User;
        public FB()
        {
            InitializeComponent();            
            lst_rtb_entry = new List<RichTextBox>() { rtb_2_entry, rtb_3_entry, rtb_4_entry, rtb_5_entry, rtb_6_entry, rtb_7_entry, rtb_8_entry, rtb_9_entry, rtb_10_entry };
            lst_rtb_check = new List<RichTextBox>() { rtb_2_Check, rtb_3_check, rtb_4_check, rtb_5_check, rtb_6_check, rtb_7_check, rtb_8_check, rtb_9_check, rtb_10_check };
            lst_rtb_lastcheck = new List<RichTextBox>() { rtb_2_lc, rtb_3_lc, rtb_4_lc, rtb_5_lc, rtb_6_lc, rtb_7_lc, rtb_8_lc, rtb_9_lc, rtb_10_lc };

            lstlb_entry = new List<Label>() { lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10 };
            lstlb_Cheeck = new List<Label>() { lbcheck2, lbcheck3, lbcheck4, lbcheck5, lbcheck6, lbcheck7, lbcheck8, lbcheck9, lbcheck10 };
            lstlb_LC = new List<Label>() { lbLC2, lbLC3, lbLC4, lbLC5, lbLC6, lbLC7, lbLC8, lbLC9, lbLC10 };

        }
        int ID_User;
        DataTable dt_viewFB = new DataTable();
        string content_entry = "";
        string content_Check = "";
        string content_LC = "";
        object Sum_tongloi;
        string nameImage;
        float dbzome;
        private void FB_Load(object sender, EventArgs e)
        {

        }
        private string BackTrack(string s1, string s2, int i, int j, RichTextBox rtb, Label label)
        {
            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
            {
                rtb.SelectionStart = i - 1;
                rtb.SelectionLength = 1;
                rtb.SelectionColor = Color.Black;
                return BackTrack(s1, s2, i - 1, j - 1, rtb, label) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
            {
                label.BackColor = Color.Red;
                return BackTrack(s1, s2, i - 1, j, rtb, label);
            }
            else
            {
                label.BackColor = Color.Red;
                return BackTrack(s1, s2, i, j - 1, rtb, label);
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

        public void Add_Data()
        {
            lst_rtb_entry.ForEach(x => x.Text = "");
            lst_rtb_check.ForEach(x => x.Text = "");
            lst_rtb_lastcheck.ForEach(x => x.Text = "");
            lstlb_entry.ForEach(x => x.BackColor = Color.White);
            lstlb_Cheeck.ForEach(x => x.BackColor = Color.White);
            lstlb_LC.ForEach(x => x.BackColor = Color.White);
            string[] tach_entry = content_entry.Replace("\r", "").Split('|');
            string[] tach_check = content_Check.Replace("\r", "").Split('|');
            string[] tach_LC = content_LC.Replace("\r", "").Split('|');
            for (int i = 0; i < 9; i++)
            {
                lst_rtb_entry[i].Text = tach_entry[i + 1].ToString();
                lst_rtb_check[i].Text = tach_check[i + 1].ToString();
                lst_rtb_lastcheck[i].Text = tach_LC[i + 1].ToString();
                //tô đỏ nhưng chữ sai của entry
                lst_rtb_entry[i].SelectionStart = 0;
                lst_rtb_entry[i].SelectionLength = lst_rtb_entry[i].Text.Length;
                lst_rtb_entry[i].SelectionColor = Color.Red;

                lst_rtb_check[i].SelectionStart = 0;
                lst_rtb_check[i].SelectionLength = lst_rtb_check[i].Text.Length;
                lst_rtb_check[i].SelectionColor = Color.Red;

                //lst_rtb_lastcheck[i].SelectionStart = 0;
                //lst_rtb_lastcheck[i].SelectionLength = lst_rtb_lastcheck[i].Text.Length;
                //lst_rtb_lastcheck[i].SelectionColor = Color.Red;
                //hiển thị chữ cái sai entry.
                string s1, s2;
                s1 = lst_rtb_entry[i].Text;
                s2 = lst_rtb_lastcheck[i].Text;
                c = null;
                c = new int[s1.Length + 1, s2.Length + 1];
                LCS(s1, s2);
                BackTrack(s1, s2, s1.Length, s2.Length, lst_rtb_entry[i], lstlb_entry[i]);

                //  BackTrack(s1, s2, s1.Length, s2.Length, rtbLC);
                //hiển thị chữ cái sai Check.               
                s1 = lst_rtb_check[i].Text;
                s2 = lst_rtb_lastcheck[i].Text;
                c = null;
                c = new int[s1.Length + 1, s2.Length + 1];
                LCS(s1, s2);
                BackTrack(s1, s2, s1.Length, s2.Length, lst_rtb_check[i], lstlb_Cheeck[i]);

                ////hiển thị chữ cái sai lc  
                //s1 = lst_rtb_lastcheck[i].Text;
                //s2 = lst_rtb_entry[i].Text;
                //c = null;
                //c = new int[s1.Length + 1, s2.Length + 1];
                //LCS(s1, s2);
                //BackTrack(s1, s2, s1.Length, s2.Length, lst_rtb_lastcheck[i]);
            }
            bitmapTmp = new Bitmap(byteArrayToImage(daEntry.getImageOnServer(nameImage)));
            ImgV.Image = bitmapTmp;
            ImgV.CurrentZoom = 0.5f;
        }
        public void Ham_Show_info()
        {
            content_entry = dt_viewFB.Rows[0]["ContentEntry"].ToString();
            content_Check = dt_viewFB.Rows[0]["ContentCheckQC"].ToString();
            content_LC = dt_viewFB.Rows[0]["ContentLC"].ToString();
            nameImage = dt_viewFB.Rows[0]["ImageName"].ToString();
            string checker = dt_viewFB.Rows[0]["CheckerId"].ToString();
            string name_checker = daEntry.name_checker(checker);
            lbCheck.Text = name_checker;
            lb_User.Text = info_User[4].ToString();
            //

            Sum_tongloi = dt_viewFB.Compute("Sum(LoiSai)", string.Empty);
            //
            lbTongloi.Text = Convert.ToString(Sum_tongloi);
            lbLoi.Text = dt_viewFB.Rows[0]["LoiSai"].ToString();
            Add_Data();
            grThongke.DataSource = dt_viewFB;
            grThongkeV.Columns[2].Visible = false;
            grThongkeV.Columns[3].Visible = false;
            grThongkeV.Columns[4].Visible = false;
            grThongkeV.Columns[5].Visible = false;
            if (dt_viewFB.Columns.Count > 5)
            {
                grThongkeV.Columns[2].Visible = true;
                grThongkeV.Columns[6].Visible = false;
                grThongkeV.Columns[7].Visible = false;
            }
            grThongkeV.Columns[0].Width = 100;
            grThongkeV.Columns[1].Width = 800;
            grThongkeV.Columns[2].Width = 200;
            //grThongkeV.BestFitColumns();
        }

        private void grThongkeV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
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
                    string data = grThongkeV.GetRowCellValue(r, grThongkeV.Columns["ImageName"]).ToString();
                    nameImage = data;
                    content_entry = dt_viewFB.Rows[r]["ContentEntry"].ToString();
                    content_Check = dt_viewFB.Rows[r]["ContentCheckQC"].ToString();
                    content_LC = dt_viewFB.Rows[r]["ContentLC"].ToString();
                    nameImage = dt_viewFB.Rows[r]["ImageName"].ToString();
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
        string ngaycuoi;
        private void btn_viewNgay_Click(object sender, EventArgs e)
        {
            grThongke.DataSource = null;
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
                    dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName , Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and TurnUp in (1,2,3,4)");
                    if (dt_viewFB.Rows.Count > 0)
                    {
                        Ham_Show_info();
                    }
                }
                else if (Convert.ToInt32(time_now) >= 1120)
                {
                    // Xem được ca 1,2,3
                    dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName , Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and TurnUp in (1,2,3)");

                    if (dt_viewFB.Rows.Count > 0)
                    {
                        Ham_Show_info();
                    }

                }
                else if (Convert.ToInt32(time_now) >= 920)
                {
                    // Xem được ca 1,2
                    dt_viewFB = daEntry.GetDatatableSQL("select TurnUp as 'CA', ImageName , Loisai" + info_User[2] + " as'LoiSai',AllImageId ,Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId from db_owner.[ImageContent] join db_owner.[AllImage] on ImageContent.AllImageId = [AllImage].Id where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and TurnUp in (1,2)"); //
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
                info_User = daEntry.usr_FB(user_login);
                string hour = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();

                //string time_now = hour.ToString() + min.ToString();
                //string time_now = "1110";

                // Xem được ca 1,2,3, 4 

                dt_viewFB = daEntry.GetDatatableSQL("select ImageName , Loisai" + info_User[2] + " as'LoiSai',Content" + info_User[2] + " as 'ContentEntry',result as 'ContentLC', Checkresult as 'ContentCheckQC',CheckerId from db_owner.[BackUp_ImageContent] join dbo.[ServerImage_BACKUP] on BackUp_ImageContent.ImageName = [ServerImage_BACKUP].NameImage where  UserId" + info_User[2] + " = " + Convert.ToInt32(info_User[0]) + " and Loisai" + info_User[2] + " >0 and Time = '" + ngaycuoi + "'");
                if (dt_viewFB.Rows.Count > 0)
                {
                    Ham_Show_info();
                }
            }
        }

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
    }
}
