using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Configuration;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using VCB_Entry.Lastcheck;
using System.Globalization;

namespace VCB_TEGAKI
{
    public partial class frmLastCheck : Form
    {
        public static string datestring = "";
        List<string> listReslt;
        //class workDB
        WorkDB_LC workdb = new WorkDB_LC();
        string strError = "";
        //class other
        other_LC Other = new other_LC();
        public static int LastcheckID;
        //Số row của dgvthongke
        int row = 0;
        //Đường dẫn đối tượng csv
        string path = "";
        //String Text
        string text;
        double zom = 20;
        private double scale = 1;
        Bitmap imageSource;
        double tyleImageNew = 1;
        public string[] INFperformance = new string[2];
        Bitmap Oribm;
        Bitmap bm_out;
        Bitmap bitmapTmp;
        int demlc;
        bool allow = true;
        public static int dot;
        public static bool save = false;
        public static bool db = false;
        public static bool exit = false;
        public static string batchname;
        public static int batchID;
        public static int userID;
        public static int formID;
        public static string formName;
        DataTable dt = new DataTable();
        DataTable dtexp = new DataTable();
        DataTable dtkt = new DataTable();
        DataTable ktcspd = new DataTable();
        DataTable ktcsps = new DataTable();
        DataTable kttx2 = new DataTable();
        DataTable kttx3 = new DataTable();
        DataTable kttx4 = new DataTable();
        DataTable kttx5 = new DataTable();
        public static string imgLocation;
        float dbzome;
        string filename = "";
        DevExpress.XtraGrid.Columns.GridColumn cl = new DevExpress.XtraGrid.Columns.GridColumn();
        int rw;
        int tongC3 = 0;
        int tongC4 = 0;
        int tong34 = 0;
        int soDong = 0;
        DataTable dtTemp;
        string folderImage = "";
        string[] arError = null;
        string[] arrcd = new string[0];
        string[] arrcs = new string[0];
        string[] arrttp = new string[0];
        List<int> countf = new List<int>();
        List<int> counta = new List<int>();
        List<string> lstcd = new List<string>();
        List<string> lstcs = new List<string>();
        List<string> lstttpx2 = new List<string>();
        List<string> lstttpx3 = new List<string>();
        List<string> lstttpx4 = new List<string>();
        List<string> lstttpx5 = new List<string>();
        List<string> lst_name_colum = new List<string>();
        DateTime dtimeBefore = new DateTime();
        public frmLastCheck()
        {
            InitializeComponent();
            this.CenterToScreen();
            grThongkeV.IndicatorWidth = 40;
            lst_name_colum = new List<string>() { "顧客名", "顧客コード", "品目コード", "数量", "単価", "希望納期", "摘要", "発注番号（ヘッダー）", "備考", "直送区分", "直送先コード" };
            folderImage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ImagePlus";
            if (Directory.Exists(folderImage))
            {
                try
                {
                    Directory.Delete(folderImage, true);
                    Directory.CreateDirectory(folderImage);
                }
                catch { }
            }
            else
            {
                Directory.CreateDirectory(folderImage);
            }
            //all_master_error = new DataTable();
            //all_master_error.Columns.Add("Dòng");

            //all_master_error.Columns.Add("Tên Ảnh");
            //all_master_error.Columns.Add("Trường Sai");
            //all_master_error.Columns.Add("Chuỗi Số");
            //all_master_error.Columns.Add("Master Khách Hàng");
            //all_master_error.Columns.Add("Master Entry Nhập");
            //dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            //dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
            //dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            //dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            //dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            dt = new DataTable();
            dt.Columns.Add("Image", typeof(String));
            dt.Columns.Add("Form", typeof(String));
            dt.Columns.Add("発注 NO", typeof(String));
            dt.Columns.Add("メッセージ", typeof(String));
            dt.Columns.Add("取引数量（バラ）", typeof(String));
            dt.Columns.Add("形態", typeof(String));
            dt.Columns.Add("予備項目1", typeof(String));
            dt.Columns.Add("予備項目2", typeof(String));
            dt.Columns.Add("予備項目3", typeof(String));
            //dt.Columns.Add("発注番号（ヘッダー）", typeof(String));
            //dt.Columns.Add("備考", typeof(String));
            //dt.Columns.Add("直送区分", typeof(String));
            //dt.Columns.Add("直送先コード", typeof(String));
            //dt.Columns.Add("受信日", typeof(String));
            //dt.Columns.Add("受信時刻", typeof(String));
            //dt.Columns.Add("担当者コード", typeof(String));
            //dt.Columns.Add("FAXのファイル名", typeof(String));
            dt.Columns.Add("AllImageId", typeof(String));
            dt.Columns.Add("Vitri_Check", typeof(String));
            dt.Columns.Add("Vitri_LC", typeof(String));
            dt.Columns.Add("STT_Dong_Image", typeof(String));
            #region viet
            //dt.Columns.Add("Image", typeof(String));
            //dt.Columns.Add("code", typeof(String));
            //dt.Columns.Add("Mã KH", typeof(String));
            //dt.Columns.Add("MSP", typeof(String));
            //dt.Columns.Add("SL", typeof(String));
            //dt.Columns.Add("Đơn giá", typeof(String));
            //dt.Columns.Add("Time GH", typeof(String));
            //dt.Columns.Add("Ghi chú 1", typeof(String));
            //dt.Columns.Add("MS Đặt hàng", typeof(String));
            //dt.Columns.Add("Ghi chú 2", typeof(String));
            //dt.Columns.Add("Phần loại GH", typeof(String));
            //dt.Columns.Add("Mã nơi GH", typeof(String));
            //dt.Columns.Add("Ngày nhận Fax", typeof(String));
            //dt.Columns.Add("Time nhận Fax", typeof(String));
            //dt.Columns.Add("Người thực hiện", typeof(String));
            //dt.Columns.Add("File ID", typeof(String));
            //dt.Columns.Add("AllImageId", typeof(String));
            #endregion
        }
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private void frmThongke_FormClosing(object sender, FormClosingEventArgs e)
        {
            //return;
            if (save == true)
            {
                var msb = MessageBox.Show("Bạn có muốn save giá trị đã thay đổi không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msb == DialogResult.Yes)
                {
                    btnSaveN_Click(sender, e);
                    save = false;
                    return;
                }
                else if (msb == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                if (ms < 0)
                { ms = 3000; }
                dAEntry.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,Timeout,TypeOut, Lvl) values (" + batchID + ",N'" + batchname + "'," + userID + "," + ms + ",3, 0)");
            }
            else
            {
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                if (ms < 0)
                { ms = 3000; }
                workdb.Save_PFM(dot, ms.ToString(), userID);
                //dAEntry.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,Timeout,TypeOut, Lvl) values (" + batchID + ",N'" + batchname + "'," + userID + "," + ms + ",3, 0)");
            }
            try
            {
                File.Delete(path);
            }
            catch { }
            if (Directory.Exists(folderImage))
            {
                try
                {
                    Directory.Delete(folderImage, true);
                }
                catch { }
            }
            return;
        }

        static byte[] Getbytes(string str)
        {
            Encoding encoding = Encoding.GetEncoding("Shift_jis");
            byte[] array = encoding.GetBytes(str);
            return array;
        }
        static byte Getbyteschar(string str)
        {
            byte temp;
            Encoding encoding = Encoding.GetEncoding("Shift_jis");
            byte[] array = encoding.GetBytes(str);
            temp = array[0];
            return temp;
        }
        static string Getstring(byte[] b)
        {
            Encoding encoding = Encoding.GetEncoding("Shift_jis");
            string array = encoding.GetString(b);
            return array;
        }

        private void cboimage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboimage.SelectedIndex != -1)
            {
                view_Image_TN.Dispose();
                try
                {
                    string strfile = folderImage + @"\" + cboimage.Text;
                    if (!File.Exists(strfile))
                    {
                        bitmapTmp = new Bitmap(byteArrayToImage(workdb.getImageOnServer(cboimage.Text)));
                        using (Image img = (Bitmap)bitmapTmp.Clone())
                        {
                            img.Save(strfile, System.Drawing.Imaging.ImageFormat.Tiff);
                        }
                        view_Image_TN.Image = bitmapTmp;
                        dbzome = view_Image_TN.CurrentZoom;
                    }
                    else
                    {
                        bitmapTmp = null;
                        using (Image img = Image.FromFile(strfile))
                        {
                            bitmapTmp = (Bitmap)img.Clone();
                            view_Image_TN.Image = bitmapTmp;
                            dbzome = view_Image_TN.CurrentZoom;
                        }
                    }

                }
                catch
                {
                    view_Image_TN.Dispose();
                }
            }
        }
        private void bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {

                //int stt_dong = 0;
                //string strtemp = dtTemp.Rows[i][1].ToString();
                //strtemp = strtemp.Replace("\r", "");
                //string[] arrsohang = strtemp.Split('|').ToArray();
                //string msp = arrsohang[2].ToString();
                //string[] masp = msp.Split('\n');
                //string sl = arrsohang[3].ToString();
                //string[] sluong = sl.Split('\n');
                //string dg = arrsohang[4].ToString();
                //if (dg == "")
                //{
                //    for (int j = 0; j < masp.Length - 1; j++)
                //    {
                //        dg = dg + "\n";
                //    }
                //}
                //string[] dongia = dg.Split('\n');
                //string[] ngaythang = arrsohang[5].Split('\n');
                //string gc = arrsohang[8].ToString();
                //string[] ghichu2 = gc.Split('\n');
                //if (masp.Length - ghichu2.Length > 0)
                //{
                //    for (int j = ghichu2.Length; j < masp.Length; j++)
                //    {
                //        gc = gc + "\n";
                //    }
                //}
                //string[] ghichu = gc.Split('\n');
                //int max = masp.Count();
                //string tenanh = dtTemp.Rows[i][0].ToString();
                //string id = dtTemp.Rows[i][2].ToString();

                //string Vitri_Checker = dtTemp.Rows[i][3].ToString();
                //string dong = "";
                //if (Vitri_Checker != "")
                //{  
                //    if (Vitri_Checker == "0,0")
                //    {
                //        //for ( )
                //    }
                //    else
                //    {
                //        for ( int t=0; t < max; t ++)
                //        {
                //            string them = "Dong";
                //            dong = dong + them + (t + 1) + ":";
                //            string[] data_dong_Check = Vitri_Checker.Replace("|", "").Split('‡');
                //            for ( int z= 0; z < data_dong_Check.Length; z ++)
                //            {
                //                if (data_dong_Check[z].ToString() != "")
                //                {
                //                    if (data_dong_Check[z].Split(',')[1].ToString() == Convert.ToString(t + 1))
                //                    {
                //                        dong = dong + data_dong_Check[z].Split(',')[0].ToString()+",";
                //                    }
                //                }
                //            }
                //            dong = dong.Substring(0, dong.Length - 1);
                //            dong = dong + "|";
                //        }
                //        dong = dong.Substring(0, dong.Length - 1);
                //    }
                //}
                //for (int j = 0; j < max; j++)
                //{
                //    string[] ToaDo_Vao = dong.Split('|');
                //    if (arrsohang[7].Contains("\n") == true)
                //    {
                //        if (ToaDo_Vao.Length == max)
                //        {
                //            if (ToaDo_Vao[j].ToString().Contains(":") == false)
                //            {
                //                if(ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "","", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                if (ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "",  stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (Vitri_Checker == "0,0")
                //            {
                //                if (j == 0)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id,"0,0", "",  stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id ,"0,0", "",  stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    if(ngaythang.Length > 1)
                //                    {
                //                        try
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                        catch
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                    }
                //                    else
                //                    {
                //                        try
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                        catch
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                    }
                                    
                //                }
                //            }
                //            else
                //            {
                //                if(ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7].Split('\n')[j], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }

                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (ToaDo_Vao.Length == max)
                //        {
                //            if (Vitri_Checker == "0,0")
                //            {
                //                if (ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "",  stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "",  stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "",  stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "",  stt_dong++.ToString() });
                //                    }
                //                }
                //            }
                //            else if (ToaDo_Vao[j].ToString().Contains(":") == false)
                //            {
                //                if (ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                if (ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, ToaDo_Vao[j].ToString().Split(':')[1].ToString(), "", stt_dong++.ToString() });
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (Vitri_Checker == "0,0")
                //            {
                //                if (j == 0)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "0,0", "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    if (ngaythang.Length > 1)
                //                    {
                //                        try
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                        catch
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                    }
                //                    else
                //                    {
                //                        try
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                        catch
                //                        {
                //                            dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                        }
                //                    }
                                   
                //                }
                //            }
                //            else
                //            {
                //                if(ngaythang.Length > 1)
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], ngaythang[j], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", ngaythang[j], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], dongia[j], arrsohang[5], arrsohang[6], arrsohang[7], ghichu[j], arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                    catch
                //                    {
                //                        dt.Rows.Add(new string[20] { tenanh, arrsohang[0], arrsohang[1], masp[j], sluong[j], "$$$$$$$", arrsohang[5], arrsohang[6], arrsohang[7], "$$$$$$$", arrsohang[9], arrsohang[10], arrsohang[11], arrsohang[12], arrsohang[13], arrsohang[14], id, "", "", stt_dong++.ToString() });
                //                    }
                //                }
                                
                //            }
                //        }
                //    }
                //}
            }
        }
        private void bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //DataView dv = dt.DefaultView;
            //dv.Sort = "Image";
            //dt = dv.ToTable();
            cboimage.ComboBox.DataSource = dt;
            lbsodong.Text = "--" + dt.Rows.Count.ToString();
            cboimage.ComboBox.DisplayMember = "Image";
            grThongke.DataSource = dt;
            Tb_datacooopy = dt.Copy();

            DataView view = new DataView(Tb_datacooopy);
            DataTable distinctValues = view.ToTable(true, "Image");
            grThongkeV.Columns[12].Visible = false;
            grThongkeV.Columns[13].Visible = false;
            grThongkeV.Columns[14].Visible = false;
            grThongkeV.Columns[15].Visible = false;
            grThongkeV.Columns[16].Visible = false;
            grThongkeV.Columns[17].Visible = false;
            grThongkeV.Columns[18].Visible = false;
            grThongkeV.Columns[19].Visible = false;
            row = grThongkeV.RowCount;
            grThongkeV.BestFitColumns();
        }
        string LC_change ;
        DataTable datasave;
        private void grThongkeV_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            save = true;
            string vlcell = "";
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            if (e.RowHandle > -1)
            {
                string idImage = grThongkeV.GetRowCellValue(grThongkeV.FocusedRowHandle, grThongkeV.Columns["AllImageId"]).ToString();
                string colum = e.Column.FieldName;
                string data_change = grThongkeV.GetRowCellValue(grThongkeV.FocusedRowHandle, grThongkeV.Columns[colum]).ToString();
                string index_dong_image = grThongkeV.GetRowCellValue(grThongkeV.FocusedRowHandle, grThongkeV.Columns["STT_Dong_Image"]).ToString();
                datasave.Rows.Add(r.ToString(), cl.ToString(), idImage, data_change, index_dong_image);

            }
        }

        int i = 0;


        private void bgwLoadExel_DoWork(object sender, DoWorkEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            DataView view1 = new DataView(datasave);
            DataTable distinctValues1 = view1.ToTable(true, "IdImage");
             
            for (int i = 0; i < distinctValues1.Rows.Count; i++)
            {
                string idimage = distinctValues1.Rows[i][0].ToString();
                var arrrows = dt.Select("AllImageId='" + idimage + "'");
                int leng = arrrows.Length;
                //string LCSua = "";
                if (leng > 0)
                {
                    string[] arrvl = new string[14];
                    arrvl[0] = arrrows[0].ItemArray[2].ToString();

                    //if (arrvl[0] != dtTemp.Rows[i][1] )
                    //{
                    //    LCSua = LCSua + "Cột2‡";
                    //}

                    //HaiPM Update 20402021
                    //arrvl[4] = arrrows[0].ItemArray[6].ToString();

                    //
                    //if (arrvl[4] != dtTemp.Rows[i][5])
                    //{
                    //    LCSua = LCSua + "Cột6‡";
                    //}
                    arrvl[5] = arrrows[0].ItemArray[7].ToString();
                    //if (arrvl[5] != dtTemp.Rows[i][6])
                    //{
                    //    LCSua = LCSua + "Cột7‡";
                    //}
                    //arrvl[6] = arrrows[0].ItemArray[8].ToString();
                    arrvl[8] = arrrows[0].ItemArray[10].ToString();
                    //if (arrvl[5] != dtTemp.Rows[i][6])
                    //{
                    //    LCSua = LCSua + "Cột7‡";
                    //}
                    arrvl[9] = arrrows[0].ItemArray[11].ToString();
                    arrvl[10] = arrrows[0].ItemArray[12].ToString();
                    arrvl[11] = arrrows[0].ItemArray[13].ToString();
                    arrvl[12] = arrrows[0].ItemArray[14].ToString();
                    arrvl[13] = arrrows[0].ItemArray[15].ToString();
                    for (int k = 0; k < leng; k++)
                    {
                        if (k < leng - 1)
                        {
                            arrvl[6] = arrvl[6] + arrrows[k].ItemArray[8].ToString() + "\n";
                            arrvl[4] = arrvl[4] + arrrows[k].ItemArray[6].ToString() + "\n";
                        }
                        else
                        {
                            arrvl[6] = arrvl[6] + arrrows[k].ItemArray[8].ToString();
                            arrvl[4] = arrvl[4] + arrrows[k].ItemArray[6].ToString();
                        }
                    }

                    for (int j = 0; j < leng; j++)
                    {
                        if (j < leng - 1)
                        {
                            arrvl[1] = arrvl[1] + arrrows[j].ItemArray[3].ToString() + "\n";
                            arrvl[2] = arrvl[2] + arrrows[j].ItemArray[4].ToString() + "\n";
                            arrvl[3] = arrvl[3] + arrrows[j].ItemArray[5].ToString() + "\n";
                            arrvl[7] = arrvl[7] + arrrows[j].ItemArray[9].ToString() + "\n";
                        }
                        else
                        {
                            arrvl[1] = arrvl[1] + arrrows[j].ItemArray[3].ToString();
                            arrvl[2] = arrvl[2] + arrrows[j].ItemArray[4].ToString();
                            arrvl[3] = arrvl[3] + arrrows[j].ItemArray[5].ToString();
                            arrvl[7] = arrvl[7] + arrrows[j].ItemArray[9].ToString();
                        }
                    }
                    string strvl = string.Join("|", arrvl);

                    //Kiểm tra  màu ở LC
                    
                    //
                    workdb.Save_LC(strvl, idimage);
                    try
                    {
                        DataTable dtauperror = new DataTable();
                        dtauperror = workdb.GetDatatableSQL("select Id,Content1, UserId1, Content2, UserId2, Result,Checkresult, CheckerId, QCID from db_owner.ImageContent  where Id =  " + idimage + "");
                        //dtallss = ClassData.GetDatatableSQL("select BatchName, ImageContent.AllImageId as 'Id', Content1, UserId1, Content2, UserId2, ResultCheck, CheckerId, NG1, NG2 from dbo.AllImage join dbo.ImageContent on AllImage.Id = ImageContent.AllImageId where BatchName in (" + lstbatchname + ")");
                        DataRow[] dtrct1 = dtauperror.Select("Id = " + idimage);
                        string ct1 = dtrct1[0].ItemArray[1].ToString().Replace("\n", "");
                        string userid1 = dtrct1[0].ItemArray[2].ToString();
                        string ct2 = dtrct1[0].ItemArray[3].ToString().Replace("\n", "");
                        string userid2 = dtrct1[0].ItemArray[4].ToString();
                        //string ct3 = dtrct1[0].ItemArray[5].ToString();
                        //string userid3 = dtrct1[0].ItemArray[6].ToString();
                        string ctlc = dtrct1[0].ItemArray[5].ToString().Replace("\n", "");
                        string usercheck = dtrct1[0].ItemArray[7].ToString();
                        //string ng1 = dtrct1[0].ItemArray[8].ToString();
                        //string ng2 = dtrct1[0].ItemArray[9].ToString();
                        string resultcheck = dtrct1[0].ItemArray[6].ToString().Replace("\n", "");
                        workdb.ExecuteSQL("Delete from dbo.[save_out] where Identry = " + idimage + "");
                        int error1 = return_error(ct1, ctlc);
                        int error2 = return_error(ct2, ctlc);

                        int errorcheck = return_error(resultcheck, ctlc);

                        if (errorcheck != 0)
                        {
                            workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + idimage + "," + userid1 + ", 1, 1," + error1 + "," + userid1 + ",1)");
                            workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + idimage + "," + userid2 + ", 1, 1," + error2 + "," + userid1 + ",1)");
                            if (usercheck != "0" && usercheck != "") { workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + idimage + "," + usercheck + ", 2, 1," + errorcheck + "," + userid1 + ",1)"); }
                        }
                        //workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + batchid + "," + userid1 + ", 1, 1," + error1 + "," + dtsave.Rows[i].ItemArray[crc - 6].ToString() + "," + typelc + ")");
                        //workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + batchid + "," + userid2 + ", 1, 1," + error2 + "," + dtsave.Rows[i].ItemArray[crc - 6].ToString() + "," + typelc + ")");
                        //if (userlc != "0" && userlc != "") { workdb.ExecuteSQL("Insert into dbo.[save_out] (BatchId,BatchName,UserId,TypeOut, Lvl,ErrorLc,Identry,LevelLC) values (" + batchid + "," + userlc + ", 2, 1," + errorlc + "," + dtsave.Rows[i].ItemArray[crc - 6].ToString() + "," + typelc + ")"); }
                    }
                    catch
                    { }
                }
            }
            // Add thông tin của LC sau khi sửa lên màu
            DataView view = new DataView(datasave);
            DataTable tb_changeLC = new DataTable();
            tb_changeLC = view.ToTable(true);
            DataTable distinct = view.ToTable(true, "DÒNG", "CỘT");
            //string data_Color_LC_old = dtTemp.Rows[i][4].ToString();
            string data_them = "";

            DataTable distinct_Id = view.ToTable(true, "IdImage");
            for (int i = 0; i < distinct_Id.Rows.Count; i++)
            {
                //string data_Color_LC_old = dtTemp.Rows[i][4].ToString();
                
                string dong_boimau = "";
                int id_anh = Convert.ToInt32(distinct_Id.Rows[i]["IdImage"].ToString());
                DataTable Dong_anh = tb_changeLC.Select("IdImage = '" + id_anh + "'").CopyToDataTable();
                string data_Color_LC_old = dtTemp.Select("AllImageID = '" + id_anh + "'").CopyToDataTable().Rows[0][4].ToString();
                for (int t = 0; t < Dong_anh.Rows.Count; t++)
                {
                    string dong = Dong_anh.Rows[t]["Index_Dong"].ToString();
                    string cot = Dong_anh.Rows[t]["CỘT"].ToString();
                    dong_boimau += dong + "," + cot + "‡";
                }
                data_Color_LC_old += dong_boimau;
                workdb.ExecuteSQL("Update db_owner.ImageContent set Color_LC = N'" + dong_boimau + "' where AllImageId = " + id_anh);
            } 
            
            // Đóng           
            //for ( int i = 0; i < distinct.Rows.Count; i ++)
            //{
            //    string dong = distinct.Rows[i]["DÒNG"].ToString();
            //    string cot = distinct.Rows[i]["CỘT"].ToString();
            //    var data_dong = datasave.Select("DÒNG = '" + dong + "' and CỘT = '"+ cot + "'");
            //    string data = data_dong[data_dong.Length - 1][3].ToString();
            //    //string cot = data_dong[data_dong.Length - 1][1].ToString();

            //    string data_old = Tb_datacooopy.Rows[Convert.ToInt32(dong)][Convert.ToInt32(cot)].ToString();
            //    if (data_old != data)
            //    {
            //        data_them = data_them + dong + "," + cot + "‡";
            //    }
            //}
            //string Id_dautien = workdb.GetStringSQL("select top 1 Id from db_owner.AllImage where TurnUp = " + dot);
            //data_Color_LC_old = data_Color_LC_old + data_them;
            
            //workdb.ExecuteSQL("Update db_owner.ImageContent set Color_LC = N'" + data_Color_LC_old + "' where AllImageId = " + Convert.ToInt32(Id_dautien) );
            
            TimeSpan span = DateTime.Now - dtimeBefore;
            int ms = (int)span.TotalMilliseconds;
            workdb.Save_PFM(dot, ms.ToString(), userID);
            // Kiểm tra Đợt đã có chưa 
            int check_dot = workdb.Check_Dot(dot);
            int ImageOfTurnUp = workdb.Check_TurnUp(dot);
            workdb.Save_DemDong(dot, Convert.ToInt32(lblsoluonganh.Text), dt.Rows.Count , check_dot, ImageOfTurnUp);
            dtimeBefore = DateTime.Now;
            save = false;
            splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Complete");
            

        }
        #region sosanh
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        static int[,] c;
        //Prints one LCS
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
        private void bgwLoadExel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dt.Columns[0].ColumnName = "Image";
                cboimage.ComboBox.DataSource = dt;
                cboimage.ComboBox.DisplayMember = "Image";
                grThongke.DataSource = dt;
                row = grThongkeV.RowCount;
            }
            catch
            { }
        }
        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (_findForm != null)
        //        _findForm.ForceClose();

        //    // if there are unclosed forms in your application,
        //    // e.Cancel will be true
        //    e.Cancel = false;

        //    base.OnFormClosing(e);
        //}
        private void grThongkeV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void frmLastCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    btnSaveN_Click(sender, e);
                }
                if (e.KeyCode == Keys.T)
                {
                    btnSavetxtN_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    view_Image_TN.RotateImage("90");
                }
                else if (e.KeyCode == Keys.Right)
                {
                    view_Image_TN.RotateImage("270");
                }
                

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void btnSaveN_Click(object sender, EventArgs e)
        {
            btncheck_Click(sender, e);
            if (allow == true)
            {
                if (!bgwLoadExel.IsBusy)
                {
                    bgwLoadExel.RunWorkerAsync();
                }
            }
        }
        List<byte> listByteCSV = new List<byte>();
        private void btnSavetxtN_Click(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //string datestring = now.Year.ToString() + String.Format("{0:00}", int.Parse(now.Month.ToString())) + String.Format("{0:00}", int.Parse(now.Day.ToString()));
            //btncheck_Click(sender, e);
            //if (allow == true)
            //{
            //    grThongkeV.Columns[0].Visible = false;
            //    grThongkeV.Columns[12].Visible = true;
            //    grThongkeV.Columns[15].Visible = true;
            //    grThongkeV.Columns[14].Visible = true;
            //    grThongkeV.Columns[13].Visible = true;
            //    SaveFileDialog svFD = new SaveFileDialog();
            //    if (grThongkeV.Columns.Count > 0)
            //    {
            //        using (SaveFileDialog saveDialog = new SaveFileDialog())
            //        {
            //            saveDialog.FileName = "Plus_" + datestring + "_0" + dot + "";
            //            saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
            //            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            //            {
            //                grThongkeV.ClearColumnsFilter();
            //                grThongkeV.ClearSorting();
            //                grThongkeV.ClearGrouping();
            //                grThongkeV.ClearSelection();
            //                grThongkeV.FindFilterText = "";
            //                grThongkeV.Columns["顧客名"].Visible = false;
            //                string exportFilePath = saveDialog.FileName;
            //                grThongkeV.ExportToXlsx(exportFilePath);
            //                grThongkeV.Columns["顧客名"].Visible = true;
            //                btnSaveN_Click(sender, e);
            //            }
            //            //StringBuilder sb = new StringBuilder();

            //            //IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
            //            //                                  Select(column => column.ColumnName);
            //            //sb.AppendLine(string.Join(",", columnNames));

            //            //foreach (DataRow row in dt.Rows)d
            //            //{
            //            //    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            //            //    sb.AppendLine(string.Join(",", fields));
            //            //}

            //            //File.WriteAllText("test.csv", sb.ToString());
            //        }
            //    }
            //    grThongke.DataSource = dt;
            //    grThongkeV.Columns[0].Visible = true;
            //    grThongkeV.Columns[12].Visible = false;
            //    grThongkeV.Columns[13].Visible = false;
            //    grThongkeV.Columns[14].Visible = false;
            //    grThongkeV.Columns[15].Visible = false;
            //}

            if(!allow){
                MessageBox.Show("Có lỗi ko xuất được!");
                return;
            }
            // Thêm thông báo so sánh ảnh với Status lúc Up ảnh lên Server
            int soanh_STT = 0;
            DataTable Sosanh = new DataTable();
            int soanh_inLC = Convert.ToInt32(lblsoluonganh.Text);

            if ( dot ==1)
            {
                Sosanh = workdb.Get_LC1();
            }
            else if (dot == 2)
            {
                Sosanh = workdb.Get_LC2();
            }
            else if(dot == 3)
            {
                Sosanh = workdb.Get_LC3();
            }
            else if (dot == 4)
            {
                Sosanh = workdb.Get_LC4();
            }

            if (Sosanh.Rows.Count != soanh_inLC)
            {
                //MessageBox.Show("Số lượng ảnh trong Form và Status không trùng khớp với nhau ");
                List<string> list_image_STT = new List<string>();
                List<string> list_image_LC = new List<string>();
                for ( int i = 0; i < Sosanh.Rows.Count; i++)
                {
                    list_image_STT.Add(Sosanh.Rows[i]["ImageName"].ToString());
                }
                
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    list_image_LC.Add(dtTemp.Rows[i]["ImageName"].ToString());
                }
                string listImage_khongxuathien = "";
                IEnumerable<string> differenceQuery = list_image_STT.Except(list_image_LC);
                foreach (string s in differenceQuery)
                {
                    listImage_khongxuathien = listImage_khongxuathien +   s + "\r\n";
                }
                string listImage_khongxuathien1 = "";
                IEnumerable<string> differenceQuery1 = list_image_LC.Except(list_image_STT);
                foreach (string t in differenceQuery1)
                {
                    listImage_khongxuathien1 = listImage_khongxuathien1 + t + "\r\n";
                }

                MessageBox.Show("Số Lượng Ảnh Trong LC và Status không trùng với nhau. \r\n Ảnh xuất hiện ở Status nhưng không xuất hiện ở LC \r\n"+ listImage_khongxuathien + " \r\n Ảnh xuất hiện ở LC nhưng không xuất hiện ở Status: \r\n " + listImage_khongxuathien1);

                return;
            }
            // HẾt thông báo
            if (grThongkeV.Columns.Count > 0)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    DateTime now = DateTime.Now;
                    string datestring2 = now.Year.ToString() + String.Format("{0:00}", int.Parse(now.Month.ToString())) + String.Format("{0:00}", int.Parse(now.Day.ToString()));
                    saveDialog.FileName = "Plus_" + datestring2 + "_" + dot + ".csv";
                    //saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        byte[] bytetemp;
                        System.IO.StreamWriter objWriter1 = new System.IO.StreamWriter(saveDialog.FileName, false, Encoding.GetEncoding("Shift_jis"));
                        try
                        {
                            //    grThongkeV.Columns[0].Visible = false;
                            //    grThongkeV.Columns[12].Visible = true;
                            //    grThongkeV.Columns[15].Visible = true;
                            //    grThongkeV.Columns[14].Visible = true;
                            //    grThongkeV.Columns[13].Visible = true;
                            //dt.Columns.Add("顧客コード", typeof(String));
                            //dt.Columns.Add("品目コード", typeof(String));
                            //dt.Columns.Add("数量", typeof(String));
                            //dt.Columns.Add("単価", typeof(String));
                            int slc = dt.Rows.Count;
                            int slcolum = dt.Columns.Count;
                            string textrow_first = "";
                            for (int i = 0; i < slc; i++)
                            {
                                for (int j = 0; j < slcolum; j++)
                                {
                                    if (j != 0 && j != 16 && j != 1 && j < 17)
                                    {
                                        if (i == 0){
                                            if (j != 15)
                                                textrow_first += dt.Columns[j].ColumnName + ",";
                                            else
                                                textrow_first += dt.Columns[j].ColumnName + Environment.NewLine;
                                        }
                                        string cten = dt.Rows[i][j].ToString();
                                        if (j == 2 || j == 4 || j == 5)
                                        {
                                            if (cten != "")
                                            {
                                                if (cten.Substring(0, 1) == "0")
                                                {
                                                    do
                                                    {
                                                        if (cten.Length > 0)
                                                            cten = cten.Substring(1, cten.Length - 1);
                                                    }
                                                    while (cten.Substring(0, 1) == "0");
                                                }
                                            }
                                        }
                                        bytetemp = Getbytes(cten);
                                        for (int k = 0; k < bytetemp.Length; k++)
                                        { listByteCSV.Add(bytetemp[k]); }
                                        
                                        bytetemp = null;
                                        if(j!=15)
                                        listByteCSV.Add(44);
                                    }
                                }
                               // listByteCSV.Add(44);
                                string textrow = Getstring(listByteCSV.ToArray()) + Environment.NewLine;
                                listByteCSV = new List<byte>();
                                if (i == 0) {
                                    objWriter1.Write(textrow_first);
                                }
                                objWriter1.Write(textrow);
                            }
                        }
                        catch
                        { }
                        finally
                        { objWriter1.Close(); }
                    }
                    MessageBox.Show("Complete!");
                }
            }
        }
        private void btnRRN_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("270");
        }

        private void btnRRLN_Click(object sender, EventArgs e)
        {
            view_Image_TN.RotateImage("90");
        }
        private void btnReplate_Click(object sender, EventArgs e)
        {
            //if (txtContentReplace.Text != "")
            //{
            //    var msb = MessageBox.Show("Ban có muốn thay đổi các giá trị tìm được?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (msb == DialogResult.No)
            //    {
            //        return;
            //    }
            //    List<string> colsToUpdate = new List<string> { "顧客コード", "品目コード", "数量", "単価", "希望納期", "摘要", "発注番号（ヘッダー）", "備考", "直送区分", "直送先コード" };
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        foreach (String colName in colsToUpdate)
            //        {
            //            string oldValue = row.Field<string>(colName);
            //            if (oldValue != null)
            //                if (oldValue.Contains(txtContentReplace.Text))
            //                    row.SetField(colName, oldValue.Replace(txtContentReplace.Text, txtReplaceText.Text));
            //        }
            //    }
            //}
        }

        private void txtContentReplace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnReplate_Click(sender, e);
        }

        private void txtContentReplace_TextChanged(object sender, EventArgs e)
        {
            grThongkeV.FindFilterText = txtContentReplace.Text;
        }

        static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnfull_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = 0.2f;
        }
        DataTable Tb_datacooopy;
        private void frmLastCheck_Load_1(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Panel2MinSize = 0;
            //dtTemp = workdb.dtLastcheck(dot);
            int soluong = dtTemp.Rows.Count;
            dtimeBefore = DateTime.Now;
            lblsoluonganh.Text = soluong.ToString();
            //bgwLoad.RunWorkerAsync();
            datasave = new DataTable();
            datasave.Columns.Add("DÒNG");
            datasave.Columns.Add("CỘT");
            datasave.Columns.Add("IdImage");
            datasave.Columns.Add("Data");
            datasave.Columns.Add("Index_Dong");
            view_Image_TN.Dock = DockStyle.Fill;
            gridVCheck.RowCellClick += gridVCheck_RowCellClick;
            splitContainer1.SplitterDistance = splitContainer1.Width - 20;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                string dataRow = dtTemp.Rows[i][1].ToString();


            }
            splashScreenManager1.CloseWaitForm();
        }

        private void btnZoomin_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom + 0.1f;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            view_Image_TN.CurrentZoom = view_Image_TN.CurrentZoom <= 0.1f ? 0.1f : view_Image_TN.CurrentZoom - 0.1f;
        }

        private void grThongkeV_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //demff = Convert.ToString(e.CellValue);
            //demlcc = Convert.ToString(e.CellValue);
            //if (demff.ToUpper().Contains("F"))
            //{
            //    demfusen = demfusen + 1;
            //}
            //if (demlcc.ToUpper().Contains("A"))
            //{
            //    dema = dema + 1;
            //}
            //lblfusen.Text = demfusen.ToString();
            //lblLC.Text = dema.ToString();

        }
        DataTable dt_Master_Truong1 = new DataTable();
        DataTable dt_Master_Truong4 = new DataTable();
        DataTable dt_Master_Truong6 = new DataTable();
        DataTable dt_Master_Truong8 = new DataTable();
        DataTable dt_Master_Truong10 = new DataTable();
        DataTable all_master_error;
        private void btncheck_Click(object sender, EventArgs e)
        {
            
            
            allow = true;
            int byby = 0;
            string chuoi = "";
            lblbao.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                #region quy định cũ
                string strkt = String.Join("", dt.Rows[i].ItemArray);
                if (strkt.Contains("$$$$$$$"))
                {
                    MessageBox.Show("Hàng " + (i + 1) + " , đơn giá hoặc ghi chú 2 chứa dữ liệu trống");
                    return;
                }
                string tenanh = dt.Rows[i][0].ToString();
                chuoi = dt.Rows[i][2].ToString();
                int vitri = i + 1;
                byby = Getbytes(chuoi).Length;
                if (byby > 8 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Mã khách hàng lớn hơn 8 byte:   " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][3].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 13 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Mã sản phẩm lớn hơn 13 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][4].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 11 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Số lượng lớn hơn 11 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][5].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 13 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Đơn giá lớn hơn 13 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][6].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 8 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Thời gian giao hàng lớn hơn 8 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }                
                chuoi = dt.Rows[i][7].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 40 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú 1 lớn hơn 40 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][8].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 8 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " MS đặt hàng lớn hơn 8 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][9].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 15 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú 2 lớn hơn 15 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][10].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 1 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú 2 lớn hơn 1 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][11].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 12 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Mã nơi giao hàng lớn hơn 12 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][12].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby >8 && byby != 0)
                {
                    //string test 1 = 
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú " + dt.Columns[12].ColumnName + " lớn hơn 8 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][13].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 4 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú " + dt.Columns[13].ColumnName + " lớn hơn 4 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }
                chuoi = dt.Rows[i][14].ToString();
                byby = Getbytes(chuoi).Length;
                if (byby > 10 && byby != 0)
                {
                    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú " + dt.Columns[14].ColumnName + " lớn hơn 10 byte:  " + byby + "byte");
                    allow = false;
                    break;
                }


                //chuoi = dt.Rows[i][15].ToString();
                //byby = Getbytes(chuoi).Length;
                //if (byby > 10 && byby != 0)
                //{
                //    MessageBox.Show("Ảnh " + tenanh + " hàng thứ " + vitri + " Ghi chú "+dt.Columns[15].ColumnName+" lớn hơn 10 byte:  " + byby + "byte");
                //    allow = false;
                //    break;
                //}

                #endregion
                // Yêu cầu đợt nâng cấp

                #region
                if (dt.Rows.Count > 0)
                {
                    for ( int z = 1; z <=11; z ++ )
                    {
                        string data_colum_row = dt.Rows[i][z].ToString();
                        if(data_colum_row.Contains("*") == true || data_colum_row.Contains("＊") == true)  //＊
                        {
                            MessageBox.Show(" Giá trị hàng " + (i + 1) + " của cột "+ lst_name_colum[z-1].ToString() + " đang có dấu * !, ERROR ");
                            allow = false;
                            break;
                        }
                    }
                }

                if (dt.Rows[i][1].ToString() == "")
                {
                    MessageBox.Show(" Giá trị hàng " + (i + 1) + " của cột  顧客名 hiện tại đang trống !, ERROR ");
                    allow = false;
                    break;
                }
                if (dt.Rows[i][2].ToString() == "")
                {
                    MessageBox.Show(" Giá trị hàng " + (i + 1) + " của cột  顧客コード hiện tại đang trống !, ERROR ");
                    allow = false;
                    break;
                }
                if (dt.Rows[i][3].ToString() == "")
                {
                    MessageBox.Show(" Giá trị hàng " + (i + 1) + " của cột  品目コード hiện tại đang trống !, ERROR ");
                    allow = false;
                    break;
                }
                if (dt.Rows[i][4].ToString() == "")
                {
                    MessageBox.Show(" Giá trị hàng " + (i + 1) + " của cột  数量 hiện tại đang trống !, ERROR ");
                    allow = false;
                    break;
                }
                
                else
                {
                    lblbao.Text = "Success!!!";
                }

                #endregion
                // update yêu cầu khách hàng 30-07-2019

                #region So sánh các trường Master khách hàng và của Entry nhập
                
                //// Trường số 6
                //if (dt.Rows[i]["摘要"].ToString() != "")
                //{
                //    int xacnhan = 0;
                //    string master_server = "";
                //    string data_codo_truong6 = dt.Rows[i]["摘要"].ToString();
                //    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                //    string tenanh_old = "";
                //    if (i > 0)
                //    {
                //        tenanh_old = dt.Rows[i - 1]["Image"].ToString();
                //    }
                //    if (tenanh_old!= tenanh_lc)
                //    { 
                //        for (int t = 0; t < dt_Master_Truong6.Rows.Count; t++)
                //            {
                //                master_server = dt_Master_Truong6.Rows[t]["NoiDung"].ToString();
                //                if (data_codo_truong6.Contains(master_server) == true)
                //                {
                //                    bool sosanh = data_codo_truong6.EndsWith(master_server);
                //                    if (sosanh == true)
                //                    {
                //                        xacnhan = 1;
                //                    }
                //                }
                //            }
                //        if (xacnhan == 0)
                //        {
                //            all_master_error.Rows.Add();
                //            all_master_error.Rows[dong]["Dòng"] = (i + 1).ToString();
                //            all_master_error.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                //            all_master_error.Rows[dong]["Trường Sai"] = "摘要";
                //            //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                //            all_master_error.Rows[dong]["Master Khách Hàng"] = "Không Có";
                //            all_master_error.Rows[dong]["Master Entry Nhập"] = data_codo_truong6;
                //            //allow = false;
                //            //break;
                //            dong++;
                //            //MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 摘要 không đúng với File Master Trường 6 !", "Thông Báo !");
                //            //allow = false;
                //            //break;
                //        }
                //    }
                //    //    
                //    //DataRow[] data_sosanh = dt_Master_Truong6.Select("MaSoPhu = '" + data_codo_truong6 + "' or MaSoChinh = '" + data_codo_truong6 + "'");

                //    //if (data_sosanh.Length < 1)
                //    //{
                //    //    MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 品目コード không đúng với File Master Trường 4 !", "Thông Báo !");
                //    //    allow = false;
                //    //    break;
                //    //}

                //}

                

                
                #endregion

            }
            if ( allow == false)
            {
                lblbao.Text = "ERROR !!!";
            }
            

        }

        private void grThongkeV_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle > 0)
            {
                if (grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Image"]).ToString() != grThongkeV.GetRowCellValue(e.RowHandle - 1, grThongkeV.Columns["Image"]).ToString())
                {
                    e.Appearance.BackColor = Color.PowderBlue;
                }
            }
            else if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.PowderBlue;
            }
        }

        private void grThongke_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void grThongke_EditorKeyDown(object sender, KeyEventArgs e)
        {
            ColumnView View1 = (ColumnView)grThongke.FocusedView;
            GridColumn column = View1.Columns[grThongkeV.FocusedColumn.FieldName];
            if (e.Control && e.KeyCode == Keys.NumPad9)
            {
                string vitri = grThongkeV.GetRowCellValue(row, grThongkeV.FocusedColumn).ToString();
                vitri = vitri + "×";
                grThongkeV.SetRowCellValue(grThongkeV.FocusedRowHandle, grThongkeV.FocusedColumn, vitri);

                grThongkeV.Focus();
                View1.FocusedRowHandle = grThongkeV.FocusedRowHandle;
                View1.FocusedColumn = column;
            }
        }

        private void grThongkeV_RowCellStyle_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            {
                if (r > -1)
                {
                    string sosanh1 = grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Vitri_Check"]).ToString();
                    if (sosanh1 != "" && sosanh1 != "0,0")
                    {
                        string[] get_Color = sosanh1.Split(',');
                        for ( int i = 0; i < get_Color.Length; i++)
                        {
                            
                            if (e.Column.ColumnHandle == Convert.ToInt32(get_Color[i]) + 1)
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                            
                        }
                    }
                    else if (sosanh1 == "0,0")
                    {
                        if (columname == "Image")
                        {
                            e.Appearance.BackColor = Color.BlueViolet;
                        }
                    }

                    string data1= grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns[columname]).ToString();
                    string data2 = Tb_datacooopy.Rows[r][columname].ToString();
                    if (data1 != data2)
                    {
                        e.Appearance.BackColor = Color.LightPink;
                    }
                    for (int x = 0; x < dtTemp.Rows.Count; x++)
                    {
                        
                        string color = dtTemp.Rows[x][4].ToString();
                        if (color != "")
                        {
                            string tenanh_dong = dtTemp.Rows[x][0].ToString();
                            string[] get_Color_LC = color.Split('‡');
                            for (int i = 0; i < get_Color_LC.Length; i++)
                            {
                                if (get_Color_LC[i] != "")
                                {
                                    int cot = Convert.ToInt32(get_Color_LC[i].Split(',')[1].ToString());
                                    int dong = Convert.ToInt32(get_Color_LC[i].Split(',')[0].ToString());
                                    if ( grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Image"]).ToString() == tenanh_dong)
                                    {
                                        if(e.Column.ColumnHandle == cot )
                                        {
                                            if(dong == Convert.ToInt32(grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["STT_Dong_Image"]).ToString()))
                                            {
                                                e.Appearance.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
                                    //int cot1 = Convert.ToInt32(get_Color_LC[i].Split(',')[1].ToString());
                                    //int dong1 = Convert.ToInt32(get_Color_LC[i].Split(',')[0].ToString());
                                    //if (e.RowHandle == dong)
                                    //{
                                    //    if (e.Column.ColumnHandle == cot)
                                    //    {
                                    //        e.Appearance.BackColor = Color.LightPink;
                                    //    }
                                    //}
                                }
                            }
                        }
                    }
                    if ( mau_anhtrung == false)
                    {
                        if ( columname == "顧客名")
                        {
                            string name_image = grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Image"]).ToString();
                            if (e.RowHandle > 0)
                            {
                                if (anhtrung.Contains(name_image) && grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Image"]).ToString() != grThongkeV.GetRowCellValue(e.RowHandle - 1, grThongkeV.Columns["Image"]).ToString())
                                {
                                    e.Appearance.BackColor = Color.Green;
                                }
                            }
                            else if (e.RowHandle == 0)
                            {
                                if (anhtrung.Contains(name_image) )
                                {
                                    e.Appearance.BackColor = Color.Green;
                                }
                            }
                            
                        }
                    }
                }
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpMaster_Click(object sender, EventArgs e)
        {
            Up_Master frm_upMaster = new Up_Master();
            frm_upMaster.IdLc = userID;
            frm_upMaster.Show();
        }

        private void splitContainerControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridVCheck_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //all_master_error.Columns.Add("Dòng");
            //all_master_error.Columns.Add("Tên Ảnh");
            //all_master_error.Columns.Add("Trường Sai");
            //all_master_error.Columns.Add("Chuỗi Số");
            //all_master_error.Columns.Add("Master Khách Hàng");
            //all_master_error.Columns.Add("Master Entry Nhập");
            if (e.Clicks == 1)
            {
                gridCheck.Focus();
                string tenanh = gridVCheck.GetRowCellValue(e.RowHandle, "Tên Ảnh").ToString();
                string rowofImage = gridVCheck.GetRowCellValue(e.RowHandle, "Dòng").ToString();
                string Cotsai = gridVCheck.GetRowCellValue(e.RowHandle, "Trường Sai").ToString();

                
                grThongkeV.Focus();
                grThongkeV.FocusedRowHandle = Convert.ToInt32(rowofImage) - 1;
                grThongkeV.GetFocusedRowCellValue(Cotsai);
                
                gridCheck.Focus();
                //grThongkeV.GetFocusedRow();
                //txtUsername.Text = grvUsers.GetRowCellValue(e.RowHandle, "User").ToString();
                //txtUsername.Enabled = false;
                //txtFullname.Text = grvUsers.GetRowCellValue(e.RowHandle, "Fullname").ToString();
                //txtMSNV.Text = grvUsers.GetRowCellValue(e.RowHandle, "MSNV").ToString();
                ////txtEmail.Text = grvUsers.GetRowCellValue(e.RowHandle, "Email").ToString();
                //cboGroup.Text = grvUsers.GetRowCellValue(e.RowHandle, "Center").ToString(); ;
                //cboRole.Text = grvUsers.GetRowCellValue(e.RowHandle, "Role").ToString();
                //cboPair.Text = grvUsers.GetRowCellValue(e.RowHandle, "Pair").ToString();
                //PExitNewUser();
            }
        }

        DataTable all_master_error_tr1;
        private void bgwTr1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        private void Run_tr1()
        {
            int dong = 0;
            all_master_error_tr1 = new DataTable();
            all_master_error_tr1.Columns.Add("Dòng");

            all_master_error_tr1.Columns.Add("Tên Ảnh");
            all_master_error_tr1.Columns.Add("Trường Sai");
            all_master_error_tr1.Columns.Add("Chuỗi Số");
            all_master_error_tr1.Columns.Add("Master Khách Hàng");
            all_master_error_tr1.Columns.Add("Master Entry Nhập");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["顧客コード"].ToString() != "")
                {
                    string data_codo_truong1 = dt.Rows[i]["顧客コード"].ToString();
                    string kanji_truong1 = dt.Rows[i]["顧客名"].ToString();
                    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                    string tenanh_old = "";
                    if (i > 0)
                    {
                        tenanh_old = dt.Rows[i - 1]["Image"].ToString();
                    }
                    DataRow[] data_sosanh = dt_Master_Truong1.Select("Maso = '" + data_codo_truong1 + "'");

                    if (tenanh_lc != tenanh_old)
                    {
                        if (data_sosanh.Length > 0)
                        {
                            if (data_sosanh[0].ItemArray[2].ToString() != kanji_truong1)
                            {
                                //MessageBox.Show("Giá trị hàng  " + (i + 1) + " của cột 顧客名 không trùng với dữ liệu File Master ! \r\n Master Khách Hàng : " + data_sosanh[0].ItemArray[2].ToString() + "\r\n Dữ liệu LC: " + kanji_truong1 + "", "Thông Báo !");

                                all_master_error_tr1.Rows.Add();
                                all_master_error_tr1.Rows[dong]["Dòng"] = (i + 1).ToString();
                                all_master_error_tr1.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                                all_master_error_tr1.Rows[dong]["Trường Sai"] = "顧客コード";
                                all_master_error_tr1.Rows[dong]["Chuỗi Số"] = data_codo_truong1;
                                all_master_error_tr1.Rows[dong]["Master Khách Hàng"] = data_sosanh[0].ItemArray[2].ToString();
                                all_master_error_tr1.Rows[dong]["Master Entry Nhập"] = kanji_truong1;
                                //allow = false;
                                //break;
                                dong++;
                            }
                        }
                        else
                        {
                            all_master_error_tr1.Rows.Add();
                            all_master_error_tr1.Rows[dong]["Dòng"] = (i + 1).ToString();
                            all_master_error_tr1.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                            all_master_error_tr1.Rows[dong]["Trường Sai"] = "顧客コード";
                            all_master_error_tr1.Rows[dong]["Chuỗi Số"] = data_codo_truong1;
                            all_master_error_tr1.Rows[dong]["Master Khách Hàng"] = "Không Có";
                            all_master_error_tr1.Rows[dong]["Master Entry Nhập"] = kanji_truong1;
                            //allow = false;
                            //break;
                            dong++;
                        }
                    }
                }
            }
            all_master_error.Merge(all_master_error_tr1);
            if (all_master_error.Rows.Count > 0)
            {
                gridCheck.Visible = true;
                gridCheck.DataSource = all_master_error;
                gridVCheck.Columns["Dòng"].Width = 70;
                gridVCheck.Columns["Tên Ảnh"].Width = 70;
                gridVCheck.Columns["Trường Sai"].Width = 100;
                gridVCheck.Columns["Chuỗi Số"].Width = 100;
                gridVCheck.Columns["Master Khách Hàng"].Width = 200;
                gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            }
        }
        DataTable all_master_error_tr4;
        private void bgwTr4_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        private void Run_tr4()
        {
            int dong = 0;
            all_master_error_tr4 = new DataTable();
            all_master_error_tr4.Columns.Add("Dòng");
            all_master_error_tr4.Columns.Add("Tên Ảnh");
            all_master_error_tr4.Columns.Add("Trường Sai");
            all_master_error_tr4.Columns.Add("Chuỗi Số");
            all_master_error_tr4.Columns.Add("Master Khách Hàng");
            all_master_error_tr4.Columns.Add("Master Entry Nhập");
            // Trường 4
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["品目コード"].ToString() != "")
                {
                    string data_codo_truong4 = dt.Rows[i]["品目コード"].ToString();
                    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                    DataRow[] data_sosanh = dt_Master_Truong4.Select("MaSoPhu = '" + data_codo_truong4 + "' or MaSoChinh = '" + data_codo_truong4 + "'");
                    string tenanh_old = "";
                    if (i > 0)
                    {
                        tenanh_old = dt.Rows[i - 1]["Image"].ToString();
                    }
                    if (data_sosanh.Length > 0)
                    {
                        //if (data_sosanh.Length < 1)
                        //{
                        //    //MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 品目コード không đúng với File Master Trường 4 !", "Thông Báo !");
                        //    all_master_error_tr4.Rows.Add();
                        //    all_master_error_tr4.Rows[dong]["Dòng"] = (i + 1).ToString();
                        //    all_master_error_tr4.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                        //    all_master_error_tr4.Rows[dong]["Trường Sai"] = "品目コード";
                        //    all_master_error_tr4.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                        //    all_master_error_tr4.Rows[dong]["Master Khách Hàng"] = data_sosanh[0].ItemArray[2].ToString();
                        //    //all_master_error.Rows[dong]["Master Entry Nhập"] = kanji_truong1;
                        //    //allow = false;
                        //    //break;
                        //    dong++;


                        //    //allow = false;
                        //    //break;
                        //}
                    }
                    else
                    {
                        all_master_error_tr4.Rows.Add();
                        all_master_error_tr4.Rows[dong]["Dòng"] = (i + 1).ToString();
                        all_master_error_tr4.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                        all_master_error_tr4.Rows[dong]["Trường Sai"] = "品目コード";
                        //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                        all_master_error_tr4.Rows[dong]["Master Khách Hàng"] = "Không Có";
                        all_master_error_tr4.Rows[dong]["Master Entry Nhập"] = data_codo_truong4;
                        //allow = false;
                        //break;
                        dong++;
                    }
                    
                }
            }

            all_master_error.Merge(all_master_error_tr4);

            if (all_master_error.Rows.Count > 0)
            {
                gridCheck.Visible = true;
                gridCheck.DataSource = all_master_error;
                gridVCheck.Columns["Dòng"].Width = 70;
                gridVCheck.Columns["Tên Ảnh"].Width = 70;
                gridVCheck.Columns["Trường Sai"].Width = 100;
                gridVCheck.Columns["Chuỗi Số"].Width = 100;
                gridVCheck.Columns["Master Khách Hàng"].Width = 200;
                gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            }
        }

        DataTable all_master_error_tr6;
        private void Run_tr6()
        {
            int dong = 0;
            all_master_error_tr6 = new DataTable();
            //all_master_error = new DataTable();
            all_master_error_tr6.Columns.Add("Dòng");

            all_master_error_tr6.Columns.Add("Tên Ảnh");
            all_master_error_tr6.Columns.Add("Trường Sai");
            all_master_error_tr6.Columns.Add("Chuỗi Số");
            all_master_error_tr6.Columns.Add("Master Khách Hàng");
            all_master_error_tr6.Columns.Add("Master Entry Nhập");
            // Trường số 6
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["摘要"].ToString() != "")
                {
                    if ( i==143)
                    {

                    }
                    int xacnhan = 0;
                    string master_server = "";
                    string data_codo_truong6 = dt.Rows[i]["摘要"].ToString();
                    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                    string tenanh_old = "";
                    if (i > 0)
                    {
                        tenanh_old = dt.Rows[i - 1]["Image"].ToString();
                    }
                    if (tenanh_old != tenanh_lc)
                    {
                        string word = data_codo_truong6;
                        bool containUnicode = false;
                        for (int x = 0; x < word.Length; x++)
                        {
                            if (char.GetUnicodeCategory(word[x]) == UnicodeCategory.OtherLetter)
                            {
                                containUnicode = true;
                                break;
                            }
                        }
                        if (containUnicode)
                        {
                            for (int t = 0; t < dt_Master_Truong6.Rows.Count; t++)
                            {
                                master_server = dt_Master_Truong6.Rows[t]["NoiDung"].ToString();
                                if (data_codo_truong6.Contains(master_server) == true)
                                {
                                    bool sosanh = data_codo_truong6.EndsWith(master_server);
                                    if (sosanh == true)
                                    {
                                        xacnhan = 1;
                                    }
                                }
                            }

                        }
                        if (xacnhan == 0)
                        {
                            byte [] checkbyt = Getbytes(data_codo_truong6);

                            if (containUnicode == true)
                            {
                                all_master_error_tr6.Rows.Add();
                                all_master_error_tr6.Rows[dong]["Dòng"] = (i + 1).ToString();
                                all_master_error_tr6.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                                all_master_error_tr6.Rows[dong]["Trường Sai"] = "摘要";
                                //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                                all_master_error_tr6.Rows[dong]["Master Khách Hàng"] = "Không Có";
                                all_master_error_tr6.Rows[dong]["Master Entry Nhập"] = data_codo_truong6;
                                //allow = false;
                                //break;
                                dong++;
                                //MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 摘要 không đúng với File Master Trường 6 !", "Thông Báo !");
                                //allow = false;
                                //break;
                            }
                        }
                    }
                    //    
                    //DataRow[] data_sosanh = dt_Master_Truong6.Select("MaSoPhu = '" + data_codo_truong6 + "' or MaSoChinh = '" + data_codo_truong6 + "'");

                    //if (data_sosanh.Length < 1)
                    //{
                    //    MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 品目コード không đúng với File Master Trường 4 !", "Thông Báo !");
                    //    allow = false;
                    //    break;
                    //}

                }
            }
            all_master_error.Merge(all_master_error_tr6);
            if (all_master_error.Rows.Count > 0)
            {
                gridCheck.Visible = true;
                gridCheck.DataSource = all_master_error;
                gridVCheck.Columns["Dòng"].Width = 70;
                gridVCheck.Columns["Tên Ảnh"].Width = 70;
                gridVCheck.Columns["Trường Sai"].Width = 100;
                gridVCheck.Columns["Chuỗi Số"].Width = 100;
                gridVCheck.Columns["Master Khách Hàng"].Width = 200;
                gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            }
        }
        private void bgwTr6_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        DataTable all_master_error_tr8;
        private void Run_tr8()
        {
            int dong = 0;
            all_master_error_tr8 = new DataTable();
            all_master_error_tr8.Columns.Add("Dòng");

            all_master_error_tr8.Columns.Add("Tên Ảnh");
            all_master_error_tr8.Columns.Add("Trường Sai");
            all_master_error_tr8.Columns.Add("Chuỗi Số");
            all_master_error_tr8.Columns.Add("Master Khách Hàng");
            all_master_error_tr8.Columns.Add("Master Entry Nhập");
            // Trường số 8
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["備考"].ToString() != "")
                {
                    int xacnhan = 0;
                    string master_server = "";
                    string data_codo_truong8 = dt.Rows[i]["備考"].ToString();
                    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                    if (i == 114)
                    {
                    }
                    string word = data_codo_truong8;
                    bool containUnicode = false;
                    for (int x = 0; x < word.Length; x++)
                    {
                        if (char.GetUnicodeCategory(word[x]) == UnicodeCategory.OtherLetter)
                        {
                            containUnicode = true;
                            break;
                        }
                    }
                    if (containUnicode)
                    {
                        for (int t = 0; t < dt_Master_Truong8.Rows.Count; t++)
                        {
                            master_server = dt_Master_Truong8.Rows[t]["CachNhap"].ToString();
                            if (data_codo_truong8.Contains(master_server) == true && master_server != "")
                            {
                                bool sosanh = data_codo_truong8.EndsWith(master_server);
                                if (sosanh == true)
                                {
                                    xacnhan = 1;
                                    break;
                                }
                            }
                            master_server = dt_Master_Truong8.Rows[t]["NoiDungKanji"].ToString();
                            if (data_codo_truong8.Contains(master_server) == true && master_server != "")
                            {
                                bool sosanh = data_codo_truong8.EndsWith(master_server);
                                if (sosanh == true)
                                {
                                    xacnhan = 1;
                                    break;
                                }
                            }
                        }
                    }
                    if (xacnhan == 0)
                    {
                        byte[] checkbyt = Getbytes(data_codo_truong8);
                        if (containUnicode == true)
                        {
                            all_master_error_tr8.Rows.Add();
                            all_master_error_tr8.Rows[dong]["Dòng"] = (i + 1).ToString();
                            all_master_error_tr8.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                            all_master_error_tr8.Rows[dong]["Trường Sai"] = "備考";
                            //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                            all_master_error_tr8.Rows[dong]["Master Khách Hàng"] = "Không Có";
                            all_master_error_tr8.Rows[dong]["Master Entry Nhập"] = data_codo_truong8;
                            //allow = false;
                            //break;
                            dong++;
                            //MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 摘要 không đúng với File Master Trường 8 !", "Thông Báo !");
                            //allow = false;
                            //break;
                        }
                    }
                }
            }
            all_master_error.Merge(all_master_error_tr8);
            if (all_master_error.Rows.Count > 0)
            {
                gridCheck.Visible = true;
                gridCheck.DataSource = all_master_error;
                gridVCheck.Columns["Dòng"].Width = 70;
                gridVCheck.Columns["Tên Ảnh"].Width = 70;
                gridVCheck.Columns["Trường Sai"].Width = 100;
                gridVCheck.Columns["Chuỗi Số"].Width = 100;
                gridVCheck.Columns["Master Khách Hàng"].Width = 200;
                gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            }
        }

        private void bgwTr8_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        DataTable all_master_error_tr10;

        private void bgwTr10_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        private void Rn_tr10()
        {
            int dong = 0;
            all_master_error_tr10 = new DataTable();
            all_master_error_tr10.Columns.Add("Dòng");

            all_master_error_tr10.Columns.Add("Tên Ảnh");
            all_master_error_tr10.Columns.Add("Trường Sai");
            all_master_error_tr10.Columns.Add("Chuỗi Số");
            all_master_error_tr10.Columns.Add("Master Khách Hàng");
            all_master_error_tr10.Columns.Add("Master Entry Nhập");
            // Trường số 10
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["直送先コード"].ToString() != "")
                {
                    string lc_truong10 = dt.Rows[i]["直送先コード"].ToString();
                    string tenanh_lc = dt.Rows[i]["Image"].ToString();
                    string str_congty = dt.Rows[i]["顧客名"].ToString();
                    DataRow[] data_server_truong10 = dt_Master_Truong10.Select("MaSo_TruongSo10 = '" + lc_truong10 + "'");
                    string tenanh_old = "";
                    if (i > 0)
                    {
                        tenanh_old = dt.Rows[i - 1]["Image"].ToString();
                    }
                    if (tenanh_old != tenanh_lc)
                    {
                        if (data_server_truong10.Length > 0)
                        {
                            //if (str_congty != data_server_truong10[0].ItemArray[2].ToString())
                            //{
                            //    all_master_error.Rows.Add();
                            //    all_master_error.Rows[dong]["Dòng"] = (i + 1).ToString();
                            //    all_master_error.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                            //    all_master_error.Rows[dong]["Trường Sai"] = "直送先コード";
                            //    //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                            //    all_master_error.Rows[dong]["Master Khách Hàng"] = data_server_truong10[0].ItemArray[2];
                            //    all_master_error.Rows[dong]["Master Entry Nhập"] = lc_truong10;
                            //    //allow = false;
                            //    //break;
                            //    dong++;
                            //    //MessageBox.Show("Giá trị hàng " + (i + 1) + " của cột 備考 không đúng với File Master Trường 10 !", "Thông Báo !");
                            //    //allow = false;
                            //}
                        }
                        else
                        {
                            all_master_error_tr10.Rows.Add();
                            all_master_error_tr10.Rows[dong]["Dòng"] = (i + 1).ToString();
                            all_master_error_tr10.Rows[dong]["Tên Ảnh"] = tenanh_lc;
                            all_master_error_tr10.Rows[dong]["Trường Sai"] = "直送先コード";
                            //all_master_error.Rows[dong]["Chuỗi Số"] = data_codo_truong4;
                            all_master_error_tr10.Rows[dong]["Master Khách Hàng"] = "Không Có";
                            all_master_error_tr10.Rows[dong]["Master Entry Nhập"] = lc_truong10;
                            //allow = false;
                            //break;
                            dong++;
                        }
                    }
                }
            }
            all_master_error.Merge(all_master_error_tr10);
            if (all_master_error.Rows.Count > 0)
            {
                gridCheck.Visible = true;
                gridCheck.DataSource = all_master_error;
                gridVCheck.Columns["Dòng"].Width = 70;
                gridVCheck.Columns["Tên Ảnh"].Width = 70;
                gridVCheck.Columns["Trường Sai"].Width = 100;
                gridVCheck.Columns["Chuỗi Số"].Width = 100;
                gridVCheck.Columns["Master Khách Hàng"].Width = 200;
                gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            }
        }

        private void bgwTr10_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            
            
        }

        private void bgwTr1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all_master_error.Merge(all_master_error_tr1);
            if (bgwTr4.IsBusy == true && bgwTr6.IsBusy == true && bgwTr8.IsBusy == true && bgwTr10.IsBusy == true)
            {
                
            }
        }

        private void bgwTr4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all_master_error.Merge(all_master_error_tr4);
            //if (bgwTr1.IsBusy == true && bgwTr6.IsBusy == true && bgwTr8.IsBusy == true && bgwTr10.IsBusy == true)
            //{
            //    if (all_master_error.Rows.Count > 0)
            //    {
            //        gridCheck.Visible = true;
            //        gridCheck.DataSource = all_master_error;
            //        gridVCheck.Columns["Dòng"].Width = 70;
            //        gridVCheck.Columns["Tên Ảnh"].Width = 70;
            //        gridVCheck.Columns["Trường Sai"].Width = 100;
            //        gridVCheck.Columns["Chuỗi Số"].Width = 100;
            //        gridVCheck.Columns["Master Khách Hàng"].Width = 200;
            //        gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            //    }
            //}
        }

        private void bgwTr6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all_master_error.Merge(all_master_error_tr6);
            //if (bgwTr1.IsBusy == true && bgwTr4.IsBusy == true && bgwTr8.IsBusy == true && bgwTr10.IsBusy == true)
            //{
            //    if (all_master_error.Rows.Count > 0)
            //    {
            //        gridCheck.Visible = true;
            //        gridCheck.DataSource = all_master_error;
            //        gridVCheck.Columns["Dòng"].Width = 70;
            //        gridVCheck.Columns["Tên Ảnh"].Width = 70;
            //        gridVCheck.Columns["Trường Sai"].Width = 100;
            //        gridVCheck.Columns["Chuỗi Số"].Width = 100;
            //        gridVCheck.Columns["Master Khách Hàng"].Width = 200;
            //        gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            //    }
            //}
        }

        private void bgwTr8_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all_master_error.Merge(all_master_error_tr8);
            //if (bgwTr1.IsBusy == true && bgwTr4.IsBusy == true && bgwTr6.IsBusy == true && bgwTr10.IsBusy == true)
            //{
            //    if (all_master_error.Rows.Count > 0)
            //    {
            //        gridCheck.Visible = true;
            //        gridCheck.DataSource = all_master_error;
            //        gridVCheck.Columns["Dòng"].Width = 70;
            //        gridVCheck.Columns["Tên Ảnh"].Width = 70;
            //        gridVCheck.Columns["Trường Sai"].Width = 100;
            //        gridVCheck.Columns["Chuỗi Số"].Width = 100;
            //        gridVCheck.Columns["Master Khách Hàng"].Width = 200;
            //        gridVCheck.Columns["Master Entry Nhập"].Width = 200;
            //    }
            //}
        }

        private void btn_truong1_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check 1 !!!! ... Waiting ...");
            all_master_error.Clear();
            dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            //dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
           // dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            //dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            //dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            Run_tr1();
            //Run_tr4();
            //Run_tr6();
            //Run_tr8();
            //Rn_tr10();
            splitContainer1.SplitterDistance = splitContainer1.Width - 300;
            splashScreenManager1.CloseWaitForm();
        }

        private void btn_truong3_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check 2 !!!! ... Waiting ...");
            all_master_error.Clear();
            //dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
            //dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            //dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            //dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            //int dong = 0;

            //Run_tr1();
            Run_tr4();
            //Run_tr6();
            //Run_tr8();
            //Rn_tr10();
            splitContainer1.SplitterDistance = splitContainer1.Width - 300;
            splashScreenManager1.CloseWaitForm();
        }

        private void btn_truong6_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check 6 !!!! ... Waiting ...");
            all_master_error.Clear();
            //dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            //dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
            dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            //dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            //dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            

            //Run_tr1();
            //Run_tr4();
            Run_tr6();
            //Run_tr8();
            //Rn_tr10();
            splitContainer1.SplitterDistance = splitContainer1.Width - 300;
            splashScreenManager1.CloseWaitForm();
        }

        private void btn_truong8_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check 8 !!!! ... Waiting ...");
            all_master_error.Clear();
            //dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            //dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
            //dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            //dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            //int dong = 0;

           // Run_tr1();
           // Run_tr4();
            //Run_tr6();
            Run_tr8();
            //Rn_tr10();
            splitContainer1.SplitterDistance = splitContainer1.Width - 300;
            splashScreenManager1.CloseWaitForm();
        }

        private void btn_truong10_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check 10 !!!! ... Waiting ...");
            all_master_error.Clear();
            //dt_Master_Truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");
            //dt_Master_Truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");
            //dt_Master_Truong6 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong6]");
            //dt_Master_Truong8 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong8]");
            dt_Master_Truong10 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong10]");
            //int dong = 0;

           // Run_tr1();
            //Run_tr4();
            //Run_tr6();
            //Run_tr8();
            Rn_tr10();
            splitContainer1.SplitterDistance = splitContainer1.Width - 300;
            splashScreenManager1.CloseWaitForm();
        }

        private void gridVCheck_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int r = e.FocusedRowHandle;
            if ( r > -1)
            {
                string tenanh = gridVCheck.GetRowCellValue(e.FocusedRowHandle, "Tên Ảnh").ToString();
                string rowofImage = gridVCheck.GetRowCellValue(e.FocusedRowHandle, "Dòng").ToString();
                string Cotsai = gridVCheck.GetRowCellValue(e.FocusedRowHandle, "Trường Sai").ToString();


                grThongkeV.Focus();
                grThongkeV.FocusedRowHandle = Convert.ToInt32(rowofImage) - 1;
                grThongkeV.GetFocusedRowCellValue(Cotsai);

                gridCheck.Focus();
            }
        }

        private void gridVCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (gridVCheck.FocusedRowHandle == gridVCheck.RowCount - 1)
                {
                    gridVCheck.FocusedRowHandle = 0;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (gridVCheck.FocusedRowHandle == 0)
                {
                    gridVCheck.FocusedRowHandle = gridVCheck.RowCount - 1;
                    e.Handled = true;
                }
            }
        }
        bool mau_anhtrung = true;
        string anhtrung = "";
        private void btn_checkFullData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Thực hiện chức năng Check Data cho Lastcheck !!!! ... Waiting ...");
            mau_anhtrung = true;
            DataTable dt_checkData = new DataTable();
            //dt_checkData = workdb.dtLastcheck(dot);
            int quet = 1;
            string contenerrror = "";
            string str_name_Image = "";
            int int_soanhtrung = 2;
            for ( int i = 0; i < dt_checkData.Rows.Count; i ++)
            {
                if ( i == 13 )
                {
                    string name1111 = dt_checkData.Rows[i][0].ToString();
                }
                string str_data1 = dt_checkData.Rows[i][1].ToString();
                string  str_new_data = "";
                for ( int z=0; z < 11; z++)
                {
                    str_new_data = str_new_data + str_data1.Split('|')[z].ToString() + "|";
                }
                str_new_data = str_new_data.Remove(str_new_data.Length - 1);
                for ( int t = quet; t < dt_checkData.Rows.Count; t ++)
                {
                    string str_data2 = dt_checkData.Rows[t][1].ToString();
                    string str_new_data2 = "";
                    for (int z = 0; z < 11; z++)
                    {
                        str_new_data2 = str_new_data2 + str_data2.Split('|')[z].ToString() + "|";
                    }
                    str_new_data2 = str_new_data2.Remove(str_new_data2.Length - 1);
                    if (str_new_data.Trim() == str_new_data2.Trim())
                    {
                        int vitrianh1 = 0;
                        int vitrianh2 = 0;

                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                            if (dt.Rows[z]["Image"].ToString() ==   dt_checkData.Rows[i][0].ToString())
                            {
                                vitrianh1 = z + 1;
                            }
                        }
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                            if (dt.Rows[z]["Image"].ToString() == dt_checkData.Rows[t][0].ToString())
                            {
                                vitrianh2 = z + 1;
                            }
                        }
                        if (str_name_Image.Contains(dt_checkData.Rows[i][0].ToString()) == false )
                        {
                            str_name_Image = str_name_Image + dt_checkData.Rows[i][0].ToString() + "," + dt_checkData.Rows[t][0].ToString() + ",";
                            contenerrror = contenerrror + "\n\nẢnh 1 : " + dt_checkData.Rows[i][0].ToString() + "    Dòng " + vitrianh1 + "  \r\n Ảnh 2 : " + dt_checkData.Rows[t][0].ToString() + "  Dòng " + vitrianh2 + "\r\n";
                        }
                        else if ( str_name_Image.Contains(dt_checkData.Rows[t][0].ToString()) == false)
                        {
                            str_name_Image = str_name_Image  + dt_checkData.Rows[t][0].ToString() + ",";
                            contenerrror = contenerrror + " Ảnh " + int_soanhtrung + " : " + dt_checkData.Rows[t][0].ToString() + "    Dòng " + vitrianh2 + "  \r\n";
                        } 
                        //MessageBox.Show("Xảy ra Trường hợp trùng hoàn toàn Dữ liệu ! \r\n   Ảnh 1 : " + dt_checkData.Rows[i][0].ToString() + "   \r\n   Ảnh 2: " + dt_checkData.Rows[t][0].ToString() + " \n\n  Kiểm tra lại nhé !" );
                        //return;
                        int_soanhtrung++;
                    }
                }
                quet++;
                int_soanhtrung = 2;
                //contenerrror = contenerrror + "\n\n";
            }
            if (contenerrror != "")
            {
                splashScreenManager1.CloseWaitForm();
                mau_anhtrung = false;
                anhtrung = contenerrror;
                MessageBox.Show("Xảy ra Trường hợp trùng hoàn toàn Dữ liệu ! \r\n  " + contenerrror + "   Kiểm tra lại nhé !");
                //grThongkeV_RowCellStyle_1(sender,e);
                grThongkeV.Focus();
            }
            else
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Complete Check Data!");
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}