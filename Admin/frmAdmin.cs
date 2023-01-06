using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Drawing.Imaging;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.XtraReports.Wizard;
using System.Globalization;
using DevExpress.Export;
using VCB_Entry.Admin;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Base;
using VCB_Entry.ENTRY.ImageForm;
using System.Threading;

namespace VCB_TEGAKI
{
    public partial class frmAdmin : Form
    {
        DataSet ds = new DataSet();

        public Int32 formid, formiduser, formidngay, formidcherker;
        // string cthuc = "";
        System.Data.DataTable dtbatchlc;
        System.Data.DataTable dtp = new System.Data.DataTable();
        System.Data.DataTable dtcp = new System.Data.DataTable();
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtfb = new System.Data.DataTable();
        System.Data.DataTable dtc = new System.Data.DataTable();
        System.Data.DataTable dtlc = new System.Data.DataTable();
        System.Data.DataTable dtlklc = new System.Data.DataTable();
        System.Data.DataTable dtcspd = new System.Data.DataTable();
        System.Data.DataTable dtcsps = new System.Data.DataTable();
        System.Data.DataTable ktcspd = new System.Data.DataTable();
        System.Data.DataTable ktcsps = new System.Data.DataTable();
        System.Data.DataTable dtidPFM = new System.Data.DataTable();
        System.Data.DataTable dtResultsEntry = new System.Data.DataTable();
        string tongsoluong1, tongsoluong2, soluongp1, soluongp2, soluongcp, soluonge1, soluonge2, slcheck, slqc;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\pathCrop.txt";
        string pagesFilePath;
        string[] arrCD;
        string[] arrCS;
        int[] arrIndex;
        int idsop = 0;
        int ttsop = 0;
        string strbatch = "";
        int pagesFilePathLength;
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameters myEncoderParameters;
        EncoderParameter myEncoderParameter;
        //private static string imgLocation = ConfigurationManager.AppSettings["LocalImage"].ToString();
        //Đường dẫn đối tượng excel
        string ph = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\tyleloitrenkytu.xls";

        #region Variable
        // Khởi động chtr Excell
        Microsoft.Office.Interop.Excel.Application exApp;
        // Thêm file temp xls
        Microsoft.Office.Interop.Excel.Workbook oBook;
        // Lấy sheet 1.
        Microsoft.Office.Interop.Excel.Worksheet oSheet;
        //class workDB
        string pathImage = "";
        string listBatch = "";
        WorkDB_Admin workdb = new WorkDB_Admin();
        Io_Entry Io = new Io_Entry();
        System.Data.DataTable dtAllUser;
        System.Data.DataTable dtTemplate; System.Data.DataTable dtbatch;
        System.Data.DataTable dtresult = new System.Data.DataTable();
        System.Data.DataTable dtstatus = new System.Data.DataTable();
        System.Data.DataTable dttemplate = new System.Data.DataTable();
        System.Data.DataTable tableall = new System.Data.DataTable();
        System.Data.DataTable dtPFMP = new System.Data.DataTable();
        System.Data.DataTable dtPFMCP = new System.Data.DataTable();
        System.Data.DataTable dtPFM = new System.Data.DataTable();
        System.Data.DataTable dtPFMCheck = new System.Data.DataTable();
        System.Data.DataTable dtPFMLastCheck = new System.Data.DataTable();
        string sodong;
        string sophieu;
        DataRow[] foundRows;
        string datestring, datestringFB = ""; int idUser = 0;
        string expression;
        int batchId;
        string dotlc;
        string imgname;
        string batchname;
        int trangthai = 0;
        string filename = "";
        bool noncharacter = false;
        double phieu = 0.0;
        // 3 variable temp
        string typeUser = "";
        string typeSearch = "";
        string typeGroup = "";
        public int iddetails;
        string isop;
        //List Batch;
        string lstBatch;
        string lstBatchPFM;
        List<string> listBatchNameArray = new List<string>();
        int row;
        double dong = 0.0;
        int rowExcel;
        int columExcel;
        int idTemplate;
        System.Data.DataTable dtSoPhieu_SoDong;
        string trungtam = "";
        #endregion


        public frmAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
            dtPFMP.Columns.Add("Họ và tên", typeof(string));
            dtPFMP.Columns.Add("Trung tâm", typeof(string));
            dtPFMP.Columns.Add("Tổng ký tự", typeof(double));
            dtPFMP.Columns.Add("Lỗi sai", typeof(double));
            dtPFMP.Columns.Add("Tỷ lệ sai(%)", typeof(double));
            dtPFMP.Columns.Add("Thời gian(phút)", typeof(double));
            dtPFMP.Columns.Add("Tốc độ(ký tự/phút)", typeof(double));
            dtPFMP.Columns.Add("Đảm nhận(%)", typeof(double));
            dtPFMP.Columns.Add("Tổng trường", typeof(double));
            dtPFMP.Columns.Add("Tổng trường notgood", typeof(double));
            dtPFMP.Columns.Add("Tỷ lệ NG", typeof(double));
            //// thêm mới
            dtPFMP.Columns.Add("Tổng Thời gian", typeof(double));
            dtPFMP.Columns.Add("Lỗi sai so với LC (nội dung qua checker)", typeof(int));
            dtPFMP.Columns.Add("Chênh lệch dữ liệu sau khi LC (Nội dung so với QC)", typeof(int));
            ////
            //
            dtPFMCP.Columns.Add("Họ và tên", typeof(string));
            dtPFMCP.Columns.Add("Trung tâm", typeof(string));
            dtPFMCP.Columns.Add("Tổng trường", typeof(double));
            dtPFMCP.Columns.Add("Thời gian", typeof(double));
            dtPFMCP.Columns.Add("Đảm nhận", typeof(double));
            //// new
            dtPFMCP.Columns.Add("Tổng Thời gian", typeof(double));
            //dtPFM.Columns.Add("Tổng ký tự Out", typeof(double));
            dtPFMCP.Columns.Add("Lỗi sai so với LC (nội dung qua checker)", typeof(int));
            dtPFMCP.Columns.Add("Chênh lệch dữ liệu sau khi LC (Nội dung so với QC)", typeof(int));
            //
            dtPFM.Columns.Add("Họ và tên", typeof(string));
            dtPFM.Columns.Add("Level", typeof(string));
            dtPFM.Columns.Add("Trung tâm", typeof(string));
            dtPFM.Columns.Add("Tổng ký tự", typeof(double));
            dtPFM.Columns.Add("Lỗi sai", typeof(double));
            dtPFM.Columns.Add("Tỷ lệ sai(%)", typeof(double));
            dtPFM.Columns.Add("Thời gian(phút)", typeof(double));
            dtPFM.Columns.Add("Tốc độ(ký tự/phút)", typeof(double));
            dtPFM.Columns.Add("Đảm nhận(%)", typeof(double));
            dtPFM.Columns.Add("Tổng trường", typeof(double));
            dtPFM.Columns.Add("Tổng trường notgood", typeof(double));
            dtPFM.Columns.Add("Tỷ lệ NG", typeof(double));
            // Thêm mới
            dtPFM.Columns.Add("Tổng Thời gian", typeof(double));
            dtPFM.Columns.Add("Lỗi sai so với LC (nội dung qua checker)", typeof(int));
            dtPFM.Columns.Add("Chênh lệch dữ liệu sau khi LC (Nội dung so với QC)", typeof(int));
            //
            //
            dtPFMCheck.Columns.Add("Họ và tên", typeof(string));
            dtPFMCheck.Columns.Add("Level", typeof(string));
            dtPFMCheck.Columns.Add("Trung tâm", typeof(string));
            dtPFMCheck.Columns.Add("Tổng trường", typeof(double));
            dtPFMCheck.Columns.Add("Thời gian(phút)", typeof(double));
            dtPFMCheck.Columns.Add("Tốc độ(trường/phút)", typeof(double));
            dtPFMCheck.Columns.Add("Đảm nhận(%)", typeof(double));
            // new
            dtPFMCheck.Columns.Add("Tổng Thời gian", typeof(double));
            //dtPFM.Columns.Add("Tổng ký tự Out", typeof(double));
            dtPFMCheck.Columns.Add("Lỗi sai so với LC (nội dung qua checker)", typeof(int));
            dtPFMCheck.Columns.Add("Chênh lệch dữ liệu sau khi LC (Nội dung so với QC)", typeof(int));
            //
            dtPFMLastCheck.Columns.Add("Họ và tên", typeof(string));
            dtPFMLastCheck.Columns.Add("Trung tâm", typeof(string));
            dtPFMLastCheck.Columns.Add("Tổng phiếu", typeof(double));
            dtPFMLastCheck.Columns.Add("Thời gian(phút)", typeof(double));
            dtPFMLastCheck.Columns.Add("Tốc độ(phiếu/phút)", typeof(double));
            dtPFMLastCheck.Columns.Add("Đảm nhận(%)", typeof(double));
            dtPFMLastCheck.Columns.Add("Tổng Thời gian", typeof(double));
            //status   
            dtResultsEntry.Columns.Add("Id", typeof(int));
            dtResultsEntry.Columns.Add("Tên Ảnh", typeof(String));
            dtResultsEntry.Columns.Add("P1", typeof(Int32));
            dtResultsEntry.Columns.Add("P2", typeof(Int32));
            dtResultsEntry.Columns.Add("CheckP", typeof(string));
            dtResultsEntry.Columns.Add("Entry1", typeof(Int32));
            dtResultsEntry.Columns.Add("Entry2", typeof(Int32));
            dtResultsEntry.Columns.Add("C2", typeof(Int32));
            dtResultsEntry.Columns.Add("QC2", typeof(Int32));
            dtResultsEntry.Columns.Add("LC", typeof(Int32));
            dtResultsEntry.Columns.Add("Exit_Image", typeof(Int32));
        }

        //Get all User
        private void DtAllUser()
        {
            //ThanhNH 140116
            dtAllUser = new System.Data.DataTable();
            dtAllUser = workdb.daAllUser();
            grdUsers.DataSource = null;
            grdUsers.DataSource = dtAllUser;
            grvUsers.RowCellClick += gridView1_RowCellClick;
            grvUsers.Columns[0].Visible = false;

        }
        void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                lblID.Text = grvUsers.GetRowCellValue(e.RowHandle, "Id").ToString();
                txtUsername.Text = grvUsers.GetRowCellValue(e.RowHandle, "User").ToString();
                txtUsername.Enabled = false;
                txtFullname.Text = grvUsers.GetRowCellValue(e.RowHandle, "Fullname").ToString();
                txtMSNV.Text = grvUsers.GetRowCellValue(e.RowHandle, "MSNV").ToString();
                txtEmail.Text = grvUsers.GetRowCellValue(e.RowHandle, "Email").ToString();
                cboGroup.Text = grvUsers.GetRowCellValue(e.RowHandle, "Group").ToString(); ;
                cboRole.Text = grvUsers.GetRowCellValue(e.RowHandle, "role").ToString();
                cboPair.Text = grvUsers.GetRowCellValue(e.RowHandle, "Pair").ToString();
                cboLevel.Text = grvUsers.GetRowCellValue(e.RowHandle, "Lvl").ToString();
                PExitNewUser();
            }
            if (e.Clicks == 2)
            {
                txtUsername.Text = grvUsers.GetRowCellValue(e.RowHandle, "User").ToString();
                if (MessageBox.Show("Bạn muốn Reset Password User: " + txtUsername.Text + " về lại mặc định ( 123456 ) ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    workdb.ResetPassWord(Convert.ToInt32(lblID.Text));
                    MessageBox.Show("Reset Password Thành Công !");
                }
            }
        }
        void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    txtsoptem.Enabled = false;
                    txtsoprule.Enabled = false;
                    txt_Ma11.Enabled = false;
                    isop = grTempV.GetRowCellValue(e.RowHandle, "Id").ToString();
                    txtsoptem.Text = grTempV.GetRowCellValue(e.RowHandle, "TempName").ToString();
                    txtsoprule.Text = grTempV.GetRowCellValue(e.RowHandle, "Rules").ToString();
                    txt_Ma11.Text = grTempV.GetRowCellValue(e.RowHandle, "Colum1_1").ToString();
                    txt_Ma12.Text = grTempV.GetRowCellValue(e.RowHandle, "Colum1_2").ToString();
                    txt_Ma13.Text = grTempV.GetRowCellValue(e.RowHandle, "Colum1_3").ToString();
                    txt_macot1.Text = grTempV.GetRowCellValue(e.RowHandle, "代理店コード").ToString();
                    txt_macot2.Text = grTempV.GetRowCellValue(e.RowHandle, "直送先コード").ToString();
                    txt_macot3.Text = grTempV.GetRowCellValue(e.RowHandle, "出荷元 倉庫").ToString();
                    txt_colum6.Text = grTempV.GetRowCellValue(e.RowHandle, "Form 6").ToString();
                    txtSOP.Text = "";
                    ttsop = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void VCB_Admin_Load(object sender, EventArgs e)
        {
            //CreatFileExcel();
            DtAllUser();
            rdbeP.Checked = true;
            myImageCodecInfo = GetEncoderInfo("image/png");
            myEncoder = System.Drawing.Imaging.Encoder.Compression;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, (long)EncoderValue.CompressionCCITT4);
            myEncoderParameters.Param[0] = myEncoderParameter;
            datestringFB = DateTime.Now.Year.ToString().Substring(2, 2) + String.Format("{0:00}", int.Parse(DateTime.Now.Month.ToString())) + String.Format("{0:00}", int.Parse(DateTime.Now.Day.ToString()));
            cboTrungTam.DataSource = workdb.dttrungtam();
            //dtbatch = workdb.daBatch();
            //cboBatchPFM.Properties.DisplayMember = "Name";
            //cboBatchPFM.Properties.ValueMember = "ID";
            //cboBatchPFM.Properties.DataSource = dtbatch;
            //cboBatchStatus.Properties.DisplayMember = "Name";
            //cboBatchStatus.Properties.ValueMember = "ID";
            //cboBatchStatus.Properties.DataSource = dtbatch;
            //cboBatchFB.Properties.DisplayMember = "Name";
            //cboBatchFB.Properties.ValueMember = "ID";
            //cboBatchFB.Properties.DataSource = dtbatch;
        }

        private void VCB_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                System.IO.File.Delete(ph);
            }
            catch
            {
            }
            return;
        }


        public static Image byteArrayToImage(byte[] byteArrayIn)
        {

            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtUsername.Text.Trim() == "")
            { lblError.Text = "Username is empty"; return; }
            if (txtMSNV.Text.Trim() == "")
            { lblError.Text = "MSNV is empty"; return; }
            if (txtFullname.Text.Trim() == "")
            { lblError.Text = "Fullname is empty"; return; }
            if (txtEmail.Text.Trim() == "")
            { lblError.Text = "Email is empty"; return; }
            if (cboRole.SelectedIndex == -1)
            { lblError.Text = "Role is incorrect"; return; }
            if (trangthai == 1)
            {
                int ktus = workdb.ktuser(txtUsername.Text.Trim());
                if (ktus == 1)
                {
                    lblTitle.Text = "User already exists";
                }
                else
                {
                    //New User
                    workdb.NewUser(txtUsername.Text.Trim(), txtFullname.Text.Trim(), cboLevel.Text, cboPair.Text, cboGroup.Text, txtEmail.Text.Trim(), cboRole.Text, txtMSNV.Text.Trim());
                    lblTitle.Text = "Success!!!";
                }
            }
            else if (trangthai == 2)
            {

                workdb.UpdateUser(Convert.ToInt32(lblID.Text), txtFullname.Text.Trim(), cboLevel.Text, cboPair.Text, cboGroup.Text, txtEmail.Text.Trim(), cboRole.Text, txtMSNV.Text.Trim());
                lblTitle.Text = "Success!!!";
            }
            DtAllUser();
            PExitNewUser();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            { DtAllUser(); txtUsername.Text = ""; }
            //set properties
            PExitNewUser();
        }

        //set properties when exit new user
        private void PExitNewUser()
        {
            btnOk.Visible = false; btnCancel.Visible = false; txtEmail.Enabled = false;
            txtFullname.Enabled = false; txtMSNV.Enabled = false; txtUsername.Enabled = false;
            cboLevel.Enabled = false; cboPair.Enabled = false; cboRole.Enabled = false; cboGroup.Enabled = false;
        }
        //set properties when click New user or Edit user
        private void PNewUserAndEditUser()
        {
            btnOk.Visible = true; btnCancel.Visible = true;
            txtFullname.Enabled = true; txtMSNV.Enabled = true; txtEmail.Enabled = true;
            cboLevel.Enabled = true; cboPair.Enabled = true; cboRole.Enabled = true; cboGroup.Enabled = true;
        }

        private void cboRole_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {

                txtUsername.Text = ""; cboPair.Text = ""; cboLevel.Text = ""; cboGroup.Text = "";

                expression = "Role = '" + cboRole.Text + "'";
            }
        }

        private void cboLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {
                txtUsername.Text = ""; cboPair.Text = ""; cboRole.Text = ""; cboGroup.Text = "";
                expression = "Lvl = '" + cboLevel.Text + "'";
            }
        }

        private void cboPair_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {
                txtUsername.Text = ""; cboLevel.Text = ""; cboRole.Text = ""; cboGroup.Text = "";
                expression = "Pair = '" + cboPair.Text + "'";
            }
        }

        private void cboGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {
                txtUsername.Text = ""; cboPair.Text = ""; cboRole.Text = ""; cboLevel.Text = "";
                expression = "Group = '" + cboGroup.Text + "'";
            }
        }
        System.Data.DataTable tb_DemDong;
        private void tabControlAdmin_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabPerformance.Name == Status.SelectedTab.Name || tabFeedback.Name == Status.SelectedTab.Name || tabstatus.Name == Status.SelectedTab.Name || tabInsert.Name == Status.SelectedTab.Name)
            {
                dttemplate = workdb.Get_allTempDemo();
                //dttemplate.Columns.Add("TempName11"); dttemplate.Columns.Add("TempName12"); dttemplate.Columns.Add("TempName13");
                grTemp.DataSource = dttemplate;
                grTempV.Columns[0].Visible = false;
                grTempV.Columns["Poi_Rules"].Visible = false;
                grTempV.Columns["PoiSop"].Visible = false;
                grTempV.Columns["Poi_Rules_Truong1"].Visible = false;//Poi_Rules_Truong1
                //grTempV.Columns["TempName"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;                
                grTempV.RowCellClick += gridView2_RowCellClick;
                typeUser = "ENTRYP";
                dtfb = workdb.daBatch();
                cboBatchFB.Properties.DisplayMember = "Name";
                cboBatchFB.Properties.ValueMember = "ID";
                cboBatchFB.Properties.DataSource = dtfb;
            }
            else if (tabDemDong.Name == Status.SelectedTab.Name)
            {
                tb_DemDong = new System.Data.DataTable();
                tb_DemDong.Columns.Add("CA");
                tb_DemDong.Columns.Add("Tổng phiếu");
                tb_DemDong.Columns.Add("Số phiếu loại");
                tb_DemDong.Columns.Add("Số phiếu còn lại");
                tb_DemDong.Columns.Add("Số dòng");
                tb_DemDong.Columns.Add("Phân loại (phút)");
                tb_DemDong.Columns.Add("Check phân loại (phút)");
                tb_DemDong.Columns.Add("Entry (phút)");
                tb_DemDong.Columns.Add("Check entry (phút)");
                tb_DemDong.Columns.Add("Lastcheck (phút)");
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows[0][0] = "1";
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows[1][0] = "2";
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows[2][0] = "3";
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows[3][0] = "4";
                System.Data.DataTable data_DemDong = new System.Data.DataTable();
                System.Data.DataTable data_ALL = new System.Data.DataTable();
                System.Data.DataTable data_LCALL = new System.Data.DataTable();
                data_DemDong = workdb.Get_DemDong();
                data_ALL = workdb.Get_ALLDATA_DemDong();
                data_LCALL = workdb.Get_DataLC_DemDong();
                // Thông Tin dòng 1
                System.Data.DataRow[] check_dot1 = data_DemDong.Select("CA = 1");
                if (check_dot1.Length > 0)
                {

                    tb_DemDong.Rows[0]["Tổng phiếu"] = check_dot1[0].ItemArray[5];
                    tb_DemDong.Rows[0]["Số phiếu loại"] = Convert.ToInt32(check_dot1[0].ItemArray[5]) - Convert.ToInt32(check_dot1[0].ItemArray[3]);
                    tb_DemDong.Rows[0]["Số phiếu còn lại"] = check_dot1[0].ItemArray[3];
                    tb_DemDong.Rows[0]["Số dòng"] = check_dot1[0].ItemArray[4];
                    try
                    {
                        double PL1 = double.Parse(data_ALL.Compute("Sum ([TimemilionP1])", "[TurnUp] = 1 ").ToString());
                        double PL2 = double.Parse(data_ALL.Compute("Sum ([TimemilionP2])", "[TurnUp] = 1 ").ToString());
                        tb_DemDong.Rows[0]["Phân loại (phút)"] = Math.Round((PL1 + PL2) / 60000, 2);
                        double CPL = double.Parse(data_ALL.Compute("Sum ([TimemilionCP])", "[TurnUp] = 1 ").ToString());
                        tb_DemDong.Rows[0]["Check phân loại (phút)"] = Math.Round(CPL / 60000, 2);
                        double Entry1 = double.Parse(data_ALL.Compute("Sum ([TimemilionE1])", "[TurnUp] = 1 ").ToString());
                        double Entry2 = double.Parse(data_ALL.Compute("Sum ([TimemilionE2])", "[TurnUp] = 1 ").ToString());
                        tb_DemDong.Rows[0]["Entry (phút)"] = Math.Round((Entry1 + Entry2) / 60000, 2);
                        double CEntry = double.Parse(data_ALL.Compute("Sum ([TimemilionCK])", "[TurnUp] = 1 ").ToString());
                        tb_DemDong.Rows[0]["Check entry (phút)"] = Math.Round(CEntry / 60000, 2);
                    }
                    catch { }
                    try
                    {
                        double LC = double.Parse(data_LCALL.Compute("Sum ([TimeLC])", "[TurnUp] = 1 ").ToString());
                        tb_DemDong.Rows[0]["Lastcheck (phút)"] = Math.Round(LC / 60000, 2);
                    }
                    catch { }
                    //newRow8[10] = Math.Round((tongngdn / tongtruongdn) * 100, 2);

                }

                // Thông tin Dòng 2
                System.Data.DataRow[] check_dot2 = data_DemDong.Select("CA = 2");
                if (check_dot2.Length > 0)
                {
                    tb_DemDong.Rows[1]["Tổng phiếu"] = check_dot2[0].ItemArray[5];
                    tb_DemDong.Rows[1]["Số phiếu loại"] = Convert.ToInt32(check_dot2[0].ItemArray[5]) - Convert.ToInt32(check_dot2[0].ItemArray[3]);
                    tb_DemDong.Rows[1]["Số phiếu còn lại"] = check_dot2[0].ItemArray[3];
                    tb_DemDong.Rows[1]["Số dòng"] = check_dot2[0].ItemArray[4];
                    try
                    {
                        double PL1 = double.Parse(data_ALL.Compute("Sum ([TimemilionP1])", "[TurnUp] = 2 ").ToString());
                        double PL2 = double.Parse(data_ALL.Compute("Sum ([TimemilionP2])", "[TurnUp] = 2 ").ToString());
                        tb_DemDong.Rows[1]["Phân loại (phút)"] = Math.Round((PL1 + PL2) / 60000, 2);
                        double CPL = double.Parse(data_ALL.Compute("Sum ([TimemilionCP])", "[TurnUp] = 2 ").ToString());
                        tb_DemDong.Rows[1]["Check phân loại (phút)"] = Math.Round(CPL / 60000, 2);
                        double Entry1 = double.Parse(data_ALL.Compute("Sum ([TimemilionE1])", "[TurnUp] = 2 ").ToString());
                        double Entry2 = double.Parse(data_ALL.Compute("Sum ([TimemilionE2])", "[TurnUp] = 2 ").ToString());
                        tb_DemDong.Rows[1]["Entry (phút)"] = Math.Round((Entry1 + Entry2) / 60000, 2);
                        double CEntry = double.Parse(data_ALL.Compute("Sum ([TimemilionCK])", "[TurnUp] = 2 ").ToString());
                        tb_DemDong.Rows[1]["Check entry (phút)"] = Math.Round(CEntry / 60000, 2);
                    }
                    catch { }
                    try
                    {
                        double LC = double.Parse(data_LCALL.Compute("Sum ([TimeLC])", "[TurnUp] = 2 ").ToString());
                        tb_DemDong.Rows[1]["Lastcheck (phút)"] = Math.Round(LC / 60000, 2);

                    }
                    catch { }
                }

                // Thông tin dòng 3
                System.Data.DataRow[] check_dot3 = data_DemDong.Select("CA = 3");
                if (check_dot3.Length > 0)
                {
                    tb_DemDong.Rows[2]["Tổng phiếu"] = check_dot3[0].ItemArray[5];
                    tb_DemDong.Rows[2]["Số phiếu loại"] = Convert.ToInt32(check_dot3[0].ItemArray[5]) - Convert.ToInt32(check_dot3[0].ItemArray[3]);
                    tb_DemDong.Rows[2]["Số phiếu còn lại"] = check_dot3[0].ItemArray[3];
                    tb_DemDong.Rows[2]["Số dòng"] = check_dot3[0].ItemArray[4];
                    try
                    {
                        double PL1 = double.Parse(data_ALL.Compute("Sum ([TimemilionP1])", "[TurnUp] = 3 ").ToString());
                        double PL2 = double.Parse(data_ALL.Compute("Sum ([TimemilionP2])", "[TurnUp] = 3 ").ToString());
                        tb_DemDong.Rows[2]["Phân loại (phút)"] = Math.Round((PL1 + PL2) / 60000, 2);
                        double CPL = double.Parse(data_ALL.Compute("Sum ([TimemilionCP])", "[TurnUp] = 3 ").ToString());
                        tb_DemDong.Rows[2]["Check phân loại (phút)"] = Math.Round(CPL / 60000, 2);
                        double Entry1 = double.Parse(data_ALL.Compute("Sum ([TimemilionE1])", "[TurnUp] = 3 ").ToString());
                        double Entry2 = double.Parse(data_ALL.Compute("Sum ([TimemilionE2])", "[TurnUp] = 3 ").ToString());
                        tb_DemDong.Rows[2]["Entry (phút)"] = Math.Round((Entry1 + Entry2) / 60000, 2);
                        double CEntry = double.Parse(data_ALL.Compute("Sum ([TimemilionCK])", "[TurnUp] = 3 ").ToString());
                        tb_DemDong.Rows[2]["Check entry (phút)"] = Math.Round(CEntry / 60000, 2);
                    }
                    catch { }
                    try
                    {
                        double LC = double.Parse(data_LCALL.Compute("Sum ([TimeLC])", "[TurnUp] = 3 ").ToString());
                        tb_DemDong.Rows[2]["Lastcheck (phút)"] = Math.Round(LC / 60000, 2);
                    }
                    catch { }
                }
                // Thông tin dòng 4
                System.Data.DataRow[] check_dot4 = data_DemDong.Select("CA = 4");
                if (check_dot4.Length > 0)
                {
                    tb_DemDong.Rows[3]["Tổng phiếu"] = check_dot4[0].ItemArray[5];
                    tb_DemDong.Rows[3]["Số phiếu loại"] = Convert.ToInt32(check_dot4[0].ItemArray[5]) - Convert.ToInt32(check_dot4[0].ItemArray[3]);
                    tb_DemDong.Rows[3]["Số phiếu còn lại"] = check_dot4[0].ItemArray[3];
                    tb_DemDong.Rows[3]["Số dòng"] = check_dot4[0].ItemArray[4];
                    try
                    {
                        double PL1 = double.Parse(data_ALL.Compute("Sum ([TimemilionP1])", "[TurnUp] = 4 ").ToString());
                        double PL2 = double.Parse(data_ALL.Compute("Sum ([TimemilionP2])", "[TurnUp] = 4 ").ToString());
                        tb_DemDong.Rows[3]["Phân loại (phút)"] = Math.Round((PL1 + PL2) / 60000, 2);
                        double CPL = double.Parse(data_ALL.Compute("Sum ([TimemilionCP])", "[TurnUp] = 4 ").ToString());
                        tb_DemDong.Rows[3]["Check phân loại (phút)"] = Math.Round(CPL / 60000, 2);
                        double Entry1 = double.Parse(data_ALL.Compute("Sum ([TimemilionE1])", "[TurnUp] = 4 ").ToString());
                        double Entry2 = double.Parse(data_ALL.Compute("Sum ([TimemilionE2])", "[TurnUp] = 4 ").ToString());
                        tb_DemDong.Rows[3]["Entry (phút)"] = Math.Round((Entry1 + Entry2) / 60000, 2);
                        double CEntry = double.Parse(data_ALL.Compute("Sum ([TimemilionCK])", "[TurnUp] = 4 ").ToString());
                        tb_DemDong.Rows[3]["Check entry (phút)"] = Math.Round(CEntry / 60000, 2);
                    }
                    catch { }
                    try
                    {
                        double LC = double.Parse(data_LCALL.Compute("Sum ([TimeLC])", "[TurnUp] = 4 ").ToString());
                        tb_DemDong.Rows[3]["Lastcheck (phút)"] = Math.Round(LC / 60000, 2);
                    }
                    catch { }
                }
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows.Add();
                tb_DemDong.Rows.Add();

                tb_DemDong.Rows[5][0] = "Tổng Phiếu";
                int tongphieu = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i][1].ToString() == "")
                    {
                        tongphieu = tongphieu + 0;
                    }
                    else
                    {
                        tongphieu = tongphieu + Convert.ToInt32(tb_DemDong.Rows[i]["Tổng phiếu"]);
                    }
                }
                tb_DemDong.Rows[5]["Tổng phiếu"] = tongphieu.ToString();
                //tb_DemDong.Rows[5]["Tổng phiếu"] = (Convert.ToInt32(tb_DemDong.Rows[0]["Tổng phiếu"]) + Convert.ToInt32(tb_DemDong.Rows[1]["Tổng phiếu"]) + Convert.ToInt32(tb_DemDong.Rows[2]["Tổng phiếu"]) + Convert.ToInt32(tb_DemDong.Rows[3]["Tổng phiếu"])).ToString();
                int sophieuloai = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Số phiếu loại"].ToString() == "")
                    {
                        sophieuloai = sophieuloai + 0;
                    }
                    else
                    {
                        sophieuloai = sophieuloai + Convert.ToInt32(tb_DemDong.Rows[i]["Số phiếu loại"]);
                    }
                }
                tb_DemDong.Rows[5]["Số phiếu loại"] = sophieuloai.ToString();

                //tb_DemDong.Rows[5]["Số phiếu loại"] = (Convert.ToInt32(tb_DemDong.Rows[0]["Số phiếu loại"]) + Convert.ToInt32(tb_DemDong.Rows[1]["Số phiếu loại"]) + Convert.ToInt32(tb_DemDong.Rows[2]["Số phiếu loại"]) + Convert.ToInt32(tb_DemDong.Rows[3]["Số phiếu loại"])).ToString();
                int sophieuconlai = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Số phiếu còn lại"].ToString() == "")
                    {
                        sophieuconlai = sophieuconlai + 0;
                    }
                    else
                    {
                        sophieuconlai = sophieuconlai + Convert.ToInt32(tb_DemDong.Rows[i]["Số phiếu còn lại"]);
                    }
                }
                tb_DemDong.Rows[5]["Số phiếu còn lại"] = sophieuconlai.ToString();
                //tb_DemDong.Rows[5]["Số phiếu còn lại"] = (Convert.ToInt32(tb_DemDong.Rows[0]["Số phiếu còn lại"]) + Convert.ToInt32(tb_DemDong.Rows[1]["Số phiếu còn lại"]) + Convert.ToInt32(tb_DemDong.Rows[2]["Số phiếu còn lại"]) + Convert.ToInt32(tb_DemDong.Rows[3]["Số phiếu còn lại"])).ToString();
                int sodong = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Số dòng"].ToString() == "")
                    {
                        sodong = sodong + 0;
                    }
                    else
                    {
                        sodong = sodong + Convert.ToInt32(tb_DemDong.Rows[i]["Số dòng"]);
                    }
                }
                tb_DemDong.Rows[5]["Số dòng"] = sodong.ToString();
                //tb_DemDong.Rows[5]["Số dòng"] = (Convert.ToInt32(tb_DemDong.Rows[0]["Số dòng"]) + Convert.ToInt32(tb_DemDong.Rows[1]["Số dòng"]) + Convert.ToInt32(tb_DemDong.Rows[2]["Số dòng"]) + Convert.ToInt32(tb_DemDong.Rows[3]["Số dòng"])).ToString();

                double pl_phut = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Phân loại (phút)"].ToString() == "")
                    {
                        pl_phut = pl_phut + 0;
                    }
                    else
                    {
                        pl_phut = pl_phut + Convert.ToDouble(tb_DemDong.Rows[i]["Phân loại (phút)"]);
                    }
                }
                tb_DemDong.Rows[5]["Phân loại (phút)"] = pl_phut.ToString();
                //tb_DemDong.Rows[5]["Phân loại (phút)"] = (Convert.ToDouble(tb_DemDong.Rows[0]["Phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[1]["Phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[2]["Phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[3]["Phân loại (phút)"])).ToString();

                double cpl_phut = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Check phân loại (phút)"].ToString() == "")
                    {
                        cpl_phut = cpl_phut + 0;
                    }
                    else
                    {
                        cpl_phut = cpl_phut + Convert.ToDouble(tb_DemDong.Rows[i]["Check phân loại (phút)"]);
                    }
                }
                tb_DemDong.Rows[5]["Check phân loại (phút)"] = cpl_phut.ToString();
                //tb_DemDong.Rows[5]["Check phân loại (phút)"] = (Convert.ToDouble(tb_DemDong.Rows[0]["Check phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[1]["Check phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[2]["Check phân loại (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[3]["Check phân loại (phút)"])).ToString();
                double entry_phut = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Entry (phút)"].ToString() == "")
                    {
                        entry_phut = entry_phut + 0;
                    }
                    else
                    {
                        entry_phut = entry_phut + Convert.ToDouble(tb_DemDong.Rows[i]["Entry (phút)"]);
                    }
                }
                tb_DemDong.Rows[5]["Entry (phút)"] = entry_phut.ToString();
                //tb_DemDong.Rows[5]["Entry (phút)"] = (Convert.ToDouble(tb_DemDong.Rows[0]["Entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[1]["Entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[2]["Entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[3]["Entry (phút)"])).ToString();

                double Check_entry_phut = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Check entry (phút)"].ToString() == "")
                    {
                        Check_entry_phut = Check_entry_phut + 0;
                    }
                    else
                    {
                        Check_entry_phut = Check_entry_phut + Convert.ToDouble(tb_DemDong.Rows[i]["Check entry (phút)"]);
                    }
                }
                tb_DemDong.Rows[5]["Check entry (phút)"] = Check_entry_phut.ToString();
                //tb_DemDong.Rows[5]["Check entry (phút)"] = (Convert.ToDouble(tb_DemDong.Rows[0]["Check entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[1]["Check entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[2]["Check entry (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[3]["Check entry (phút)"])).ToString();


                double LC_phut = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (tb_DemDong.Rows[i]["Lastcheck (phút)"].ToString() == "")
                    {
                        LC_phut = LC_phut + 0;
                    }
                    else
                    {
                        LC_phut = LC_phut + Convert.ToDouble(tb_DemDong.Rows[i]["Lastcheck (phút)"]);
                    }
                }
                tb_DemDong.Rows[5]["Lastcheck (phút)"] = LC_phut.ToString();
                //tb_DemDong.Rows[5]["Lastcheck (phút)"] = (Convert.ToDouble(tb_DemDong.Rows[0]["Lastcheck (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[1]["Lastcheck (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[2]["Lastcheck (phút)"]) + Convert.ToDouble(tb_DemDong.Rows[3]["Lastcheck (phút)"])).ToString();

                gridDemDong.DataSource = tb_DemDong;
            }
            else if (tabChangeDot.Name == Status.SelectedTab.Name)
            {
                tb_DotThayDoi = new System.Data.DataTable();
                tb_DotThayDoi = workdb.Get_All_Image_Change();
                grd_ChangeDot.DataSource = tb_DotThayDoi;
                grV_ChangeDot.BestFitColumns();
                cbb_TenAnh_Dot.DisplayMember = "ImageName";
                cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
                //cbb_allBatch.DisplayMember = "Name";
                //cbb_allBatch.DataSource = dt_allBatch;
            }
            else if (MSOP.Name == Status.SelectedTab.Name)
            {
                cboreturnLCT.SelectedIndex = 0;
                tb_MultiSOP = new System.Data.DataTable();
                tb_MultiSOP = workdb.Get_Id_Name_Template();
                chkcombo.Properties.DataSource = tb_MultiSOP;
                chkcombo.Properties.ValueMember = "Id";
                chkcombo.Properties.DisplayMember = "Name";
            }
        }
        System.Data.DataTable tb_MultiSOP = new System.Data.DataTable();
        System.Data.DataTable tb_DotThayDoi = new System.Data.DataTable();
        private void btnExportCheck_Click(object sender, EventArgs e)
        {
            lblInformation.Text = "";
            if (cboDot.Text != "")
            {
                SaveFileDialog svFD = new SaveFileDialog();
                svFD.RestoreDirectory = true;
                svFD.Title = "Save to file excel";
                svFD.Filter = "Excel 2007 file|*.xlsx";
                svFD.FileName = cboDot.Text.Replace(" ", "") + "_C";
                if (svFD.ShowDialog() == DialogResult.OK)
                {
                    btnExportCheck.Enabled = false;
                    btnExportQC.Enabled = false;
                    filename = svFD.FileName;
                    if (!bwExportExcel.IsBusy)
                    {
                        strbatch = cboDot.Text;
                        prgExcel.Value = 0;
                        prgExcel.Visible = true;
                        bwExportExcel.RunWorkerAsync();
                    }
                }
            }
        }

        private void bwExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            dtresult = new System.Data.DataTable();
            dtresult = workdb.dtResult(strbatch);
            int progress1 = 0;
            int row = dtresult.Rows.Count;
            BackgroundWorker worker = sender as BackgroundWorker;
            //try
            //{
            if (dtresult.Rows.Count > 0)
            {
                string imagString;
                // Khởi động chtr Excell
                exApp = new Microsoft.Office.Interop.Excel.Application();
                // Thêm file temp xls
                oBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                // Lấy sheet 1.
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[1];
                oSheet.Cells[1, 1].Font.Size = 24;
                oSheet.Range["A1:I1"].Merge();
                oSheet.Cells[3, 1].Value2 = "STT";
                oSheet.Columns["A", Type.Missing].ColumnWidth = 5;
                oSheet.Cells[3, 2].Value2 = "Tên ảnh";
                oSheet.Columns["B", Type.Missing].ColumnWidth = 10;
                oSheet.Cells[3, 3].Value2 = "Ảnh";
                oSheet.Columns["C", Type.Missing].ColumnWidth = 100;
                oSheet.Cells[3, 4].Value2 = "Entry1";
                oSheet.Columns["D", Type.Missing].ColumnWidth = 20;
                oSheet.Columns["E", Type.Missing].Font.Color = Color.Red;
                oSheet.Cells[3, 5].Value2 = "Nội dung nhập 1";
                oSheet.Cells[3, 5].Font.Color = Color.Black;
                oSheet.Columns["E", Type.Missing].ColumnWidth = 60;
                oSheet.Cells[3, 6].Value2 = "Lỗi sai 1";
                oSheet.Columns["F", Type.Missing].ColumnWidth = 10;
                oSheet.Cells[3, 7].Value2 = "Entry2";
                oSheet.Columns["G", Type.Missing].ColumnWidth = 20;
                oSheet.Columns["H", Type.Missing].Font.Color = Color.Red;
                oSheet.Cells[3, 8].Value2 = "Nội dung nhập 2";
                oSheet.Cells[3, 8].Font.Color = Color.Black;
                oSheet.Columns["H", Type.Missing].ColumnWidth = 60;
                oSheet.Cells[3, 9].Value2 = "Lỗi sai 2";
                oSheet.Columns["I", Type.Missing].ColumnWidth = 10;
                oSheet.Cells[3, 10].Value2 = "Checker";
                oSheet.Columns["J", Type.Missing].ColumnWidth = 20;
                oSheet.Cells[3, 11].Value2 = "Nội dung chọn";
                oSheet.Columns["K", Type.Missing].ColumnWidth = 60;
                oSheet.Range["A3:K3"].Font.Bold = true;

                string rwcow = Convert.ToString(row + 3);
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:K" + rwcow].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.Range["A3:K" + rwcow].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                oSheet.Range["A3:K" + rwcow].WrapText = true;
                oSheet.Range["A3:K" + rwcow].Font.Size = 13;
                string content1 = "";
                string content2 = "";
                string check = "";
                int rl = dtresult.Rows.Count;
                int cl = dtresult.Columns.Count;
                for (int i = 0; i < rl; i++)
                {
                    content1 = ""; content2 = ""; check = ""; rowExcel = i;
                    oSheet.Cells[i + 4, 1].Value2 = i + 1;
                    for (int j = 0; j < cl; j++)
                    {
                        if (j != 3 || j != 6 || j != 9 || j != 1)
                        {
                            oSheet.Cells[i + 4, j + 2].Value2 = dtresult.Rows[i][j].ToString().Replace("|", Environment.NewLine);
                        }
                        if (j == 3)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            content1 = all1 + all2;
                            oSheet.Cells[i + 4, j + 2].Value2 = content1;
                        }
                        if (j == 6)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            content2 = all1 + all2;
                            oSheet.Cells[i + 4, j + 2].Value2 = content2;
                        }
                        if (j == 9)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            check = all1 + all2;
                            oSheet.Cells[i + 4, j + 2].Value2 = check;
                            columExcel = 5;
                            c = null;
                            c = new int[content1.Length + 1, check.Length + 1];
                            LCS(content1, check);
                            BackTrack(content1, check, content1.Length, check.Length);
                            columExcel = 8;
                            c = null;
                            c = new int[content2.Length + 1, check.Length + 1];
                            LCS(content2, check);
                            BackTrack(content2, check, content2.Length, check.Length);
                        }
                        if (j == 1)
                        {
                            imagString = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "ImageCheck.jpg";
                            byte[] img = null;
                            img = workdb.GetImageBatch(dtresult.Rows[i][j - 1].ToString().Trim());
                            Bitmap bm = new Bitmap(Io_Entry.byteArrayToImage(img));
                            bm.Save(imagString, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Range oRange = (Range)oSheet.Cells[i + 4, j + 2];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            float ImageSize1 = 880f;
                            float ImageSize2 = 1196f;
                            oSheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize1 / 2, ImageSize2 / 3);
                            oRange.RowHeight = 408;
                        }
                    }
                    progress1 = progress1 + 1;
                    worker.ReportProgress(progress1 * 100 / row);
                }
            }
            exApp.Visible = false;
            // Save file
            oBook.Application.DisplayAlerts = false;
            filename = Path.GetDirectoryName(filename) + @"\" + strbatch.Replace(" ", "") + "_C" + ".xlsx";
            oBook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing);
            oBook.Close(false, false, false);
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void bwExportExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgExcel.Value = e.ProgressPercentage;
        }

        private void bwExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                prgExcel.Value = 0;
                prgExcel.Visible = false;
                lblInformation.Text = "Error!, " + e.Error.Message.ToString();
            }
            else
            {
                lblInformation.Text = "Completed!";
                prgExcel.Value = prgExcel.Maximum;
                prgExcel.Visible = false;
            }
            btnExportCheck.Enabled = true;
            btnExportQC.Enabled = true;
        }

        private void cbobatchF_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbobatchF.SelectedIndex != -1)
            //{
            //    lblInformation.Text = "";
            //    batchId = int.Parse(dtbatch.Rows[cbobatchF.SelectedIndex]["id"].ToString());
            //    batchname = dtbatch.Rows[cbobatchF.SelectedIndex]["name"].ToString();
            //    btnExportCheck.Enabled = true; btnExportQC.Enabled = true;
            //}
        }

        private void btnExportQC_Click(object sender, EventArgs e)
        {
            btnExportCheck.Enabled = false;
            btnExportQC.Enabled = false;
            SaveFileDialog svFD = new SaveFileDialog();
            svFD.RestoreDirectory = true;
            svFD.Title = "Save to file excel";
            svFD.Filter = "Excel 2007 file|*.xlsx";
            svFD.FileName = cboDot.Text.Replace(" ", "") + "_QC";
            if (svFD.ShowDialog() == DialogResult.OK)
            {
                filename = svFD.FileName;
                if (!bwExportExcelQC.IsBusy)
                {
                    strbatch = cboDot.Text;
                    prgExcel.Value = 0;
                    prgExcel.Visible = true;
                    bwExportExcelQC.RunWorkerAsync();
                }

            }
        }

        private void bwExportExcelQC_DoWork(object sender, DoWorkEventArgs e)
        {
            dtresult = new System.Data.DataTable();
            dtresult = workdb.dtResultQA(batchId);
            int progress1 = 0;
            int row = dtresult.Rows.Count;
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                string imagString;

                // Khởi động chtr Excell
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                // Thêm file temp xls
                Microsoft.Office.Interop.Excel.Workbook oBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                // Lấy sheet 1.
                Microsoft.Office.Interop.Excel.Worksheet oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[1];

                oSheet.Cells[1, 1].Font.Size = 24;
                oSheet.Range["A1:I1"].Merge();
                oSheet.Cells[3, 1].Value2 = "STT";
                oSheet.Columns["A", Type.Missing].ColumnWidth = 5;
                oSheet.Cells[3, 2].Value2 = "Tên ảnh";
                oSheet.Columns["B", Type.Missing].ColumnWidth = 25;
                oSheet.Cells[3, 3].Value2 = "Ảnh";
                oSheet.Columns["C", Type.Missing].ColumnWidth = 100;
                oSheet.Cells[3, 4].Value2 = "Entry1";
                oSheet.Columns["D", Type.Missing].ColumnWidth = 20;
                oSheet.Cells[3, 5].Value2 = "Nội dung nhập 1";
                oSheet.Columns["E", Type.Missing].ColumnWidth = 60;
                oSheet.Cells[3, 6].Value2 = "Entry2";
                oSheet.Columns["F", Type.Missing].ColumnWidth = 20;
                oSheet.Cells[3, 7].Value2 = "Nội dung nhập 2";
                oSheet.Columns["G", Type.Missing].ColumnWidth = 60;
                oSheet.Cells[3, 8].Value2 = "Checker";
                oSheet.Columns["H", Type.Missing].ColumnWidth = 20;
                oSheet.Cells[3, 9].Value2 = "Nội dung chọn";
                oSheet.Columns["I", Type.Missing].ColumnWidth = 60;
                oSheet.Range["A3:I3"].Font.Bold = true;

                string rwcow = Convert.ToString(row + 3);
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                oSheet.Range["A3:I" + rwcow].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.Range["A3:I" + rwcow].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                oSheet.Range["A3:I" + rwcow].WrapText = true;
                oSheet.Range["A3:I" + rwcow].Font.Size = 13;
                int rl = dtresult.Rows.Count;
                int cl = dtresult.Columns.Count;
                string content1 = "";
                string content2 = "";
                string check = "";
                for (int i = 0; i < rl; i++)
                {
                    content1 = ""; content2 = ""; check = ""; rowExcel = i;
                    oSheet.Cells[i + 4, 1].Value2 = i + 1;
                    for (int j = 0; j < cl; j++)
                    {
                        if (j != 3 || j != 5 || j != 7 || j != 1)
                        {
                            oSheet.Cells[i + 4, j + 2].Value2 = dtresult.Rows[i][j].ToString().Replace("|", Environment.NewLine);
                        }
                        if (j == 3)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + "- " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            content1 = all1 + all2;
                            content1 = content1.Replace("\r", "");
                            oSheet.Cells[i + 4, j + 2].Value2 = content1;
                        }
                        if (j == 5)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + "- " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            content2 = all1 + all2;
                            content2 = content2.Replace("\r", "");
                            oSheet.Cells[i + 4, j + 2].Value2 = content2;
                        }
                        if (j == 7)
                        {
                            string[] conten1 = null;
                            string[] conten2 = null;
                            string[] conten3 = null;
                            string[] conten4 = null;
                            string[] conten = null;
                            conten = dtresult.Rows[i][j].ToString().Replace(Environment.NewLine, "").Split('|').ToArray();
                            conten1 = conten[1].Split('\n').ToArray();
                            conten2 = conten[2].Split('\n').ToArray();
                            conten3 = conten[3].Split('\n').ToArray();
                            conten4 = conten[7].Split('\n').ToArray();
                            int index = conten1.Length - conten4.Length;
                            if (index > 0)
                            {
                                for (int m = conten4.Length; m <= conten1.Length; m++)
                                { conten[7] = conten[7] + "\n"; }
                            }
                            conten4 = null;
                            conten4 = conten[7].Split('\n').ToArray();
                            string ct3 = conten[3].ToString();
                            int index2 = conten1.Length - conten3.Length;
                            if (index2 > 0)
                            {
                                for (int m = conten3.Length; m <= conten1.Length; m++)
                                { ct3 = ct3 + "\n"; }
                            }
                            conten3 = null;
                            conten3 = ct3.Split('\n').ToArray();
                            string all1 = "";
                            string all2 = "";
                            all1 = conten[0] + Environment.NewLine + conten[5] + Environment.NewLine + conten[6];
                            if (conten3[0] == "" && conten3.Length == 1 && conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + " - " + Environment.NewLine;
                                }
                            }
                            else if (conten3[0] == "" && conten3.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + "- " + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            else if (conten4[0] == "" && conten4.Length == 1)
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < conten1.Length; k++)
                                {
                                    all2 = all2 + Environment.NewLine + conten1[k].ToString() + " - " + conten2[k].ToString() + " - " + conten3[k].ToString() + " - " + conten4[k].ToString() + Environment.NewLine;
                                }
                            }
                            check = all1 + all2;
                            check = check.Replace("\r", "");
                            oSheet.Cells[i + 4, j + 2].Value2 = check;
                            //columExcel = 5;
                            //c = null;
                            //c = new int[content1.Length + 1, check.Length + 1];
                            //LCS(content1, check);
                            //BackTrack(content1, check, content1.Length, check.Length);
                            //columExcel = 8;
                            //c = null;
                            //c = new int[content2.Length + 1, check.Length + 1];
                            //LCS(content2, check);
                            //BackTrack(content2, check, content2.Length, check.Length);
                        }
                        if (j == 1)
                        {
                            imagString = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "ImageQC.jpg";
                            byte[] img = null;
                            img = workdb.GetImageBatch(dtresult.Rows[i][j - 1].ToString().Trim());
                            Bitmap bm = new Bitmap(Io_Entry.byteArrayToImage(img));
                            bm.Save(imagString, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Range oRange = (Range)oSheet.Cells[i + 4, j + 2];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            float ImageSize1 = 880f;
                            float ImageSize2 = 1196f;
                            oSheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize1 / 2, ImageSize2 / 3);
                            oRange.RowHeight = 408;
                        }
                    }
                    progress1 = progress1 + 1;
                    worker.ReportProgress(progress1 * 100 / row);
                }
                exApp.Visible = false;
                // Save file
                oBook.Application.DisplayAlerts = false;
                filename = Path.GetDirectoryName(filename) + @"\" + strbatch.Replace(" ", "") + "_QC" + ".xlsx";
                oBook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing);
                oBook.Close(false, false, false);
                exApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            //noncharacter = false;
            //var aa = (char)e.KeyCode;
            //if (e. && e.KeyValue != 8)
            //    noncharacter = true;
        }

        private void txtPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter)(e.KeyChar))
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvPerformance.Columns.Count > 0)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = "PFM_" + typeUser + ".xlsx";
                    saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        //saveDialog.FileName = saveDialog.FileName.Split('_')[0] + "_BANRA" + ".xlsx";                        
                        //grvPerformance.ClearColumnsFilter();
                        //grvPerformance.ClearSorting();
                        //grvPerformance.ClearGrouping();
                        //grvPerformance.ClearSelection();
                        //grvPerformance.FindFilterText = "";                        
                        grvPerformance.ExportToXlsx(saveDialog.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                        //string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        //NImageExporter imageExporter = chartControl.ImageExporter;
                        //grvPerformance.ExportToXlsx(exportFilePath);
                    }
                    MessageBox.Show("Hoàn thành Export ");

                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dtPFMP.Clear();
            dtPFMCP.Clear();
            dtPFM.Clear();
            dtPFMCheck.Clear();
            dtPFMLastCheck.Clear();
            dtidPFM.Rows.Clear();
            if (cboBatchPFM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Đợt");
                return;
            }
            lstBatchPFM = "";
            if (!bgwXem.IsBusy)
            {
                prgbExcel.Value = 0;
                prgbExcel.Visible = true;
                dt = new System.Data.DataTable();
                grcPerformance.DataSource = null;
                grvPerformance.Columns.Clear();
                dtidPFM = new System.Data.DataTable();
                int id = 0;
                if (cboBatchPFM.Text == "1")
                { id = 1; }
                else if (cboBatchPFM.Text == "2")
                { id = 2; }
                else if (cboBatchPFM.Text == "3")
                { id = 3; }
                else if (cboBatchPFM.Text == "4")
                { id = 4; }
                if (id != 0)
                { dtidPFM = workdb.Get_PFM(id); }
                else
                {
                    if (cboBatchPFM.Text == "All")
                    { dtidPFM = workdb.Get_PFMAll(); }
                }
                dotlc = cboBatchPFM.Text.Trim();
                if (dtidPFM.Rows.Count > 0)
                {
                    for (int i = 0; i < dtidPFM.Rows.Count; i++)
                    { lstBatchPFM = lstBatchPFM + dtidPFM.Rows[i][0] + " "; }
                    lstBatchPFM = lstBatchPFM.Trim().Replace(' ', ',');
                    trungtam = cboTrungTam.Text;
                }
                if (lstBatchPFM != "")
                { bgwXem.RunWorkerAsync(); }
                else
                { prgbExcel.Visible = false; }
            }
            dotlc = cboBatchPFM.Text;
        }
        #region Loại User
        private void rdbEntry_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntry.Checked == true)
            {
                cboTrungTam.Visible = true;
                lbltrungtam.Visible = true;
                typeUser = "ENTRY";
            }
        }

        private void rdbCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCheck.Checked == true)
            {
                cboTrungTam.Visible = true;
                lbltrungtam.Visible = true;
                typeUser = "CHECK";
            }
        }

        private void rdbLastCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLastCheck.Checked == true)
            {
                cboTrungTam.Visible = false;
                lbltrungtam.Visible = false;
                typeUser = "LASTCHECK";
            }
        }

        private void rdbeP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbeP.Checked == true)
            {
                cboTrungTam.Visible = true;
                lbltrungtam.Visible = true;
                typeUser = "ENTRYP";
            }
        }

        private void rdbcheckp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbcheckp.Checked == true)
            {
                cboTrungTam.Visible = true;
                lbltrungtam.Visible = true;
                typeUser = "CHECKP";
            }
        }
        #endregion
        private void bgwXem_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Data.DataTable dtout = new System.Data.DataTable();
            #region ENTRYP
            if (typeUser == "ENTRYP")
            {
                dtp.Clear();
                dtp = workdb.getPerformaceEntry(lstBatchPFM, trungtam);
                dtout = workdb.GetDatatableSQL("select * from dbo.[save_out] join db_owner.[AllUser] as us1 on UserId=us1.Id where  TypeOut = 1 ");
                if (dtp.Rows.Count > 0)
                {
                    var results = from status in dtp.AsEnumerable()
                                  group status by (status.Field<string>("MSNV")) into status
                                  select new
                                  {
                                      Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                      Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                      Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count(),
                                      Loisai = status.Select(x => x.Field<int>("Lỗi sai")).Sum(),
                                      Thoigian = ((status.Select(x => x.Field<int>("Thời gian")).Sum()) / 1000.0) / 60,
                                      NotGood = status.Select(x => x.Field<int>("NGP")).Where(x => x != 0).Count(),
                                  };
                    double tongall = results.Sum(x => x.Tongtruong);
                    double tongls = results.Sum(x => x.Loisai);
                    double tongtg = Math.Round(results.Sum(x => x.Thoigian), 2);
                    double tongtruong = results.Sum(x => x.Tongtruong);
                    double tongng = results.Sum(x => x.NotGood);
                    prgbExcel.Invoke((System.Action)(() =>
                    {
                        prgbExcel.Maximum = results.Count();
                    }));
                    foreach (var element in results)
                    {
                        var rowindex = dtPFMP.NewRow();
                        rowindex["Họ và tên"] = element.Fullname;
                        rowindex["Trung tâm"] = element.Trungtam;
                        rowindex["Tổng ký tự"] = element.Tongtruong;
                        rowindex["Lỗi sai"] = element.Loisai;
                        rowindex["Tỷ lệ sai(%)"] = Math.Round((element.Loisai / Convert.ToDouble(element.Tongtruong)) * 100, 2);
                        rowindex["Thời gian(phút)"] = Math.Round(element.Thoigian, 2);
                        rowindex["Tốc độ(ký tự/phút)"] = Math.Round(Convert.ToDouble(element.Tongtruong) / element.Thoigian, 2);
                        rowindex["Đảm nhận(%)"] = Math.Round((element.Tongtruong / tongtruong) * 100, 2);
                        rowindex["Tổng trường"] = element.Tongtruong;
                        rowindex["Tổng trường notgood"] = element.Tongtruong;
                        rowindex["Tỷ lệ NG"] = element.NotGood;
                        //// Làm thêm:
                        System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                        try
                        {
                            dtsum = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 0 and Name like 'P%'").CopyToDataTable();

                            //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                            rowindex["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round(element.Thoigian, 2));
                        }
                        catch
                        { rowindex["Tổng Thời gian"] = Math.Round(element.Thoigian, 2); }
                        try { dtsumcheck = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 1 and LevelLC = 1 and Name like 'P%' ").CopyToDataTable(); rowindex["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                        catch { rowindex["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                        //// Hết thêm
                        dtPFMP.Rows.Add(rowindex);
                    }
                    DataRow newRow = dtPFMP.NewRow();
                    DataRow newRow1 = dtPFMP.NewRow();
                    DataRow newRow2 = dtPFMP.NewRow();
                    DataRow newRow3 = dtPFMP.NewRow();
                    DataRow newRow4 = dtPFMP.NewRow();
                    //Max,Min,average 
                    newRow1[1] = "Cao nhất";
                    newRow1[2] = dtPFMP.Compute("Max ([Tổng ký tự])", "");
                    newRow1[3] = dtPFMP.Compute("Max ([Lỗi sai])", "");
                    newRow1[4] = dtPFMP.Compute("Max ([Tỷ lệ sai(%)])", "");
                    newRow1[5] = dtPFMP.Compute("Max ([Thời gian(phút)])", "");
                    newRow1[6] = dtPFMP.Compute("Max ([Tốc độ(ký tự/phút)])", "");
                    newRow1[7] = dtPFMP.Compute("Max ([Đảm nhận(%)])", "");
                    newRow1[8] = dtPFMP.Compute("Max ([Tổng trường])", "");
                    newRow1[9] = dtPFMP.Compute("Max ([Tổng trường notgood])", "");
                    newRow1[10] = dtPFMP.Compute("Max ([Tỷ lệ NG])", "");
                    newRow2[1] = "Thấp nhất";
                    newRow2[2] = dtPFMP.Compute("Min ([Tổng ký tự])", "");
                    newRow2[3] = dtPFMP.Compute("Min ([Lỗi sai])", "");
                    newRow2[4] = dtPFMP.Compute("Min ([Tỷ lệ sai(%)])", "");
                    newRow2[5] = dtPFMP.Compute("Min ([Thời gian(phút)])", "");
                    newRow2[6] = dtPFMP.Compute("Min ([Tốc độ(ký tự/phút)])", "");
                    newRow2[7] = dtPFMP.Compute("Min ([Đảm nhận(%)])", "");
                    newRow2[8] = dtPFMP.Compute("Min ([Tổng trường])", "");
                    newRow2[9] = dtPFMP.Compute("Min ([Tổng trường notgood])", "");
                    newRow2[10] = dtPFMP.Compute("Min ([Tỷ lệ NG])", "");
                    try
                    {
                        newRow3[1] = "Trung bình";
                        newRow3[2] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tổng ký tự])", "").ToString()), 0);
                        newRow3[3] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Lỗi sai])", "").ToString()), 0);
                        newRow3[4] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tỷ lệ sai(%)])", "").ToString()), 2);
                        newRow3[5] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Thời gian(phút)])", "").ToString()), 0);
                        newRow3[6] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tốc độ(ký tự/phút)])", "").ToString()), 0);
                        newRow3[7] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Đảm nhận(%)])", "").ToString()), 0);
                        newRow3[8] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tổng trường])", "").ToString()), 0);
                        newRow3[9] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tổng trường notgood])", "").ToString()), 0);
                        newRow3[10] = Math.Round(double.Parse(dtPFMP.Compute("Avg ([Tỷ lệ NG])", "").ToString()), 0);
                    }
                    catch
                    {
                    }
                    dtPFMP.Rows.Add(newRow);
                    dtPFMP.Rows.Add(newRow1);
                    dtPFMP.Rows.Add(newRow2);
                    dtPFMP.Rows.Add(newRow3);
                    if (trungtam == "ALL")
                    {
                        DataRow newRow5 = dtPFMP.NewRow();
                        DataRow newRow7 = dtPFMP.NewRow();
                        DataRow newRow8 = dtPFMP.NewRow();
                        dtPFMP.Rows.Add(newRow5);
                        newRow7[1] = "ALL";
                        newRow7[2] = tongtruong;
                        newRow7[3] = tongls;
                        newRow7[4] = Math.Round(tongls / tongtg, 2);
                        newRow7[5] = tongtg;
                        newRow7[6] = Math.Round(tongtruong / tongtg, 2);
                        newRow7[7] = Math.Round((tongtruong / tongall) * 100, 2);
                        newRow7[8] = tongtruong;
                        newRow7[9] = tongng;
                        newRow7[10] = Math.Round((tongng / tongtruong) * 100, 2);
                        dtPFMP.Rows.Add(newRow7);
                        string tkuGroup = dtPFMP.Compute("COUNT ([Trung tâm])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFMP.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DN'").ToString();
                            double tlsGroup = double.Parse(dtPFMP.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DN'").ToString());
                            double tongtruongdn = double.Parse(dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString());
                            double tongngdn = double.Parse(dtPFMP.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'DN'").ToString());
                            newRow8[1] = "DN";
                            newRow8[2] = tkuGroup;
                            newRow8[3] = tlsGroup;
                            newRow8[4] = Math.Round(tlsGroup / Convert.ToDouble(tkuGroup), 2);
                            newRow8[5] = timeGroup;
                            newRow8[6] = Math.Round(Convert.ToDouble(tkuGroup) / Convert.ToDouble(timeGroup), 2);
                            newRow8[7] = Math.Round(Convert.ToDouble(tkuGroup) / tongall, 2);
                            newRow8[8] = tongtruongdn;
                            newRow8[9] = tongngdn;
                            newRow8[10] = Math.Round((tongngdn / tongtruongdn) * 100, 2);
                            dtPFMP.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFMP.NewRow();
                            string timeGroup = dtPFMP.Compute("Sum ([Thời gian(phút))", "[Trung tâm] = 'HUE'").ToString();
                            double tlsGroup = double.Parse(dtPFMP.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'HUE'").ToString());
                            double tongtruonghue = double.Parse(dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString());
                            double tongnghue = double.Parse(dtPFMP.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'HUE'").ToString());
                            newRow8[1] = "HUE";
                            newRow8[2] = tkuGroup;
                            newRow8[3] = tlsGroup;
                            newRow8[4] = Math.Round(tlsGroup / Convert.ToDouble(tkuGroup), 2);
                            newRow8[5] = timeGroup;
                            newRow8[6] = Math.Round(Convert.ToDouble(tkuGroup) / Convert.ToDouble(timeGroup), 2);
                            newRow8[7] = Math.Round(Convert.ToDouble(tkuGroup) / tongall, 2);
                            newRow8[8] = tongtruonghue;
                            newRow8[9] = tongnghue;
                            newRow8[10] = Math.Round((tongtruonghue / tongnghue) * 100, 2);
                            dtPFMP.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFMP.NewRow();
                            string timeGroup = dtPFMP.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'PY'").ToString();
                            double tlsGroup = double.Parse(dtPFMP.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'PY'").ToString());
                            double tongtruongpy = double.Parse(dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString());
                            double tongngpy = double.Parse(dtPFMP.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'PY'").ToString());
                            newRow8[1] = "PY";
                            newRow8[2] = tkuGroup;
                            newRow8[3] = tlsGroup;
                            newRow8[4] = Math.Round(tlsGroup / Convert.ToDouble(tkuGroup), 2);
                            newRow8[5] = timeGroup;
                            newRow8[6] = Math.Round(Convert.ToDouble(tkuGroup) / Convert.ToDouble(timeGroup), 2);
                            newRow8[7] = Math.Round(Convert.ToDouble(tkuGroup) / tongall, 2);
                            newRow8[8] = tongtruongpy;
                            newRow8[9] = tongngpy;
                            newRow8[10] = Math.Round((tongtruongpy / tongngpy) * 100, 2);
                            dtPFMP.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFMP.NewRow();
                            string timeGroup = dtPFMP.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DL'").ToString();
                            double tlsGroup = double.Parse(dtPFMP.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DL'").ToString());
                            double tongtruongdl = double.Parse(dtPFMP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString());
                            double tongngdl = double.Parse(dtPFMP.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'DL'").ToString());
                            newRow8[1] = "DL";
                            newRow8[2] = tkuGroup;
                            newRow8[3] = tlsGroup;
                            newRow8[4] = Math.Round(tlsGroup / Convert.ToDouble(tkuGroup), 2);
                            newRow8[5] = timeGroup;
                            newRow8[6] = Math.Round(Convert.ToDouble(tkuGroup) / Convert.ToDouble(timeGroup), 2);
                            newRow8[7] = Math.Round(Convert.ToDouble(tkuGroup) / tongall, 2);
                            newRow8[8] = tongtruongdl;
                            newRow8[9] = tongngdl;
                            newRow8[10] = Math.Round((tongtruongdl / tongngdl) * 100, 2);
                            dtPFMP.Rows.Add(newRow8);
                        }
                    }
                    else
                    {
                        DataRow newRow5 = dtPFMP.NewRow();
                        DataRow newRow6 = dtPFMP.NewRow();
                        DataRow newRow7 = dtPFMP.NewRow();
                        dtPFMP.Rows.Add(newRow5);
                        dtPFMP.Rows.Add(newRow6);
                        newRow7[1] = trungtam;
                        newRow7[2] = tongtruong;
                        newRow7[3] = tongls;
                        newRow7[5] = tongtg;
                        newRow7[8] = tongtruong;
                        newRow7[9] = tongng;
                        dtPFMP.Rows.Add(newRow7);
                    }
                    worker.ReportProgress(dtPFMP.Rows.Count);
                }
            }
            #endregion
            #region CHECKP
            if (typeUser == "CHECKP")
            {
                dtcp.Clear();
                dtcp = workdb.All_CheckP(lstBatchPFM, trungtam);
                dtout = workdb.GetDatatableSQL("select * from dbo.[save_out] join db_owner.[AllUser] as us1 on UserId=us1.Id where  TypeOut = 2 ");
                if (dtcp.Rows.Count > 0)
                {
                    var results = from status in dtcp.AsEnumerable()
                                  group status by (status.Field<string>("MSNV")) into status
                                  select new
                                  {
                                      Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                      Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                      Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count() / 1.0,
                                      Thoigian = (status.Select(x => x.Field<int>("Thời gian")).Sum() / 1000.0) / 60,
                                  };
                    double tt = results.Sum(x => x.Tongtruong);
                    double tp = results.Sum(x => x.Thoigian);
                    prgbExcel.Invoke((System.Action)(() =>
                    {
                        prgbExcel.Maximum = results.Count();
                    }));
                    foreach (var element in results)
                    {
                        var rowcheck1 = dtPFMCP.NewRow();
                        rowcheck1["Họ và tên"] = element.Fullname;
                        rowcheck1["Trung tâm"] = element.Trungtam;
                        rowcheck1["Tổng trường"] = element.Tongtruong;
                        rowcheck1["Thời gian"] = element.Thoigian;
                        rowcheck1["Đảm nhận"] = Math.Round(element.Tongtruong / tt * 100, 2);
                        //// Làm thêm:
                        System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                        try
                        {
                            dtsum = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 0 and Name like '%CP%'").CopyToDataTable();

                            //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                            rowcheck1["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round(element.Thoigian, 2));
                        }
                        catch
                        { rowcheck1["Tổng Thời gian"] = Math.Round(element.Thoigian, 2); }
                        try { dtsumcheck = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 1 and LevelLC = 1 and Name like '%CP%'").CopyToDataTable(); rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                        catch { rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                        //// Hết thêm
                        dtPFMCP.Rows.Add(rowcheck1);
                    }
                    DataRow newRowCheck = dtPFMCP.NewRow();
                    DataRow newRowCheck1 = dtPFMCP.NewRow();
                    DataRow newRowCheck2 = dtPFMCP.NewRow();
                    DataRow newRowCheck3 = dtPFMCP.NewRow();
                    DataRow newRowCheck4 = dtPFMCP.NewRow();
                    //Max,Min,average 
                    newRowCheck1[1] = "Cao nhất";
                    newRowCheck1[2] = dtPFMCP.Compute("Max ([Tổng trường])", "");
                    newRowCheck1[3] = dtPFMCP.Compute("Max ([Thời gian])", "");
                    newRowCheck1[4] = dtPFMCP.Compute("Max ([Đảm nhận])", "");
                    newRowCheck2[1] = "Thấp nhất";
                    newRowCheck2[2] = dtPFMCP.Compute("Min ([Tổng trường])", "");
                    newRowCheck2[3] = dtPFMCP.Compute("Min ([Thời gian])", "");
                    newRowCheck2[4] = dtPFMCP.Compute("Min ([Đảm nhận])", "");
                    try
                    {
                        newRowCheck3[1] = "Trung bình";
                        newRowCheck3[2] = Math.Round(double.Parse(dtPFMCP.Compute("Avg ([Tổng trường])", "").ToString()), 2);
                        newRowCheck3[3] = Math.Round(double.Parse(dtPFMCP.Compute("Avg ([Thời gian])", "").ToString()), 2);
                        newRowCheck3[4] = Math.Round(double.Parse(dtPFMCP.Compute("Avg ([Đảm nhận])", "").ToString()), 2);
                    }
                    catch
                    {
                    }
                    dtPFMCP.Rows.Add(newRowCheck);
                    dtPFMCP.Rows.Add(newRowCheck1);
                    dtPFMCP.Rows.Add(newRowCheck2);
                    dtPFMCP.Rows.Add(newRowCheck3);
                    if (trungtam == "ALL")
                    {
                        DataRow newRowCheck5 = dtPFMCP.NewRow();
                        DataRow newRowCheck7 = dtPFMCP.NewRow();
                        DataRow newRowCheck8 = dtPFMCP.NewRow();
                        dtPFMCP.Rows.Add(newRowCheck5);
                        newRowCheck7[1] = "ALL";
                        newRowCheck7[2] = tt;
                        newRowCheck7[3] = tp;
                        newRowCheck7[4] = "100";
                        dtPFMCP.Rows.Add(newRowCheck7);
                        string tkuGroup = dtPFMCP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString();
                            double ttgGroup = double.Parse(dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString());
                            double tdnGroup = double.Parse(dtPFMCP.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DN'").ToString());

                            newRowCheck8[1] = "DN";
                            newRowCheck8[2] = tkuGroup;
                            newRowCheck8[3] = ttgGroup;
                            newRowCheck8[4] = tdnGroup;
                            dtPFMCP.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCP.NewRow();
                            string timeGroup = dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString();
                            double ttgGroup = double.Parse(dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString());
                            double tdnGroup = double.Parse(dtPFMCP.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'HUE'").ToString());

                            newRowCheck8[1] = "HUE";
                            newRowCheck8[2] = tkuGroup;
                            newRowCheck8[3] = ttgGroup;
                            newRowCheck8[4] = tdnGroup;
                            dtPFMCP.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCP.NewRow();
                            string timeGroup = dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString();
                            double ttgGroup = double.Parse(dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString());
                            double tdnGroup = double.Parse(dtPFMCP.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'PY'").ToString());

                            newRowCheck8[1] = "PY";
                            newRowCheck8[2] = tkuGroup;
                            newRowCheck8[3] = ttgGroup;
                            newRowCheck8[4] = tdnGroup;
                            dtPFMCP.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCP.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCP.NewRow();
                            string timeGroup = dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString();
                            double ttgGroup = double.Parse(dtPFMCP.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString());
                            double tdnGroup = double.Parse(dtPFMCP.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DL'").ToString());

                            newRowCheck8[1] = "DL";
                            newRowCheck8[2] = tkuGroup;
                            newRowCheck8[3] = ttgGroup;
                            newRowCheck8[4] = tdnGroup;
                            dtPFMCP.Rows.Add(newRowCheck8);
                        }
                    }
                    else
                    {
                        DataRow newRowCheck5 = dtPFMCP.NewRow();
                        DataRow newRowCheck7 = dtPFMCP.NewRow();
                        dtPFMCP.Rows.Add(newRowCheck5);
                        newRowCheck7[1] = typeGroup;
                        newRowCheck7[2] = tt;
                        newRowCheck7[3] = tp;
                        newRowCheck7[4] = "100";
                        dtPFMCP.Rows.Add(newRowCheck7);
                    }
                    worker.ReportProgress(dtPFMCP.Rows.Count);
                }
            }
            #endregion
            #region ENTRY
            if (typeUser == "ENTRY")
            {
                dt.Clear();
                dt = workdb.Get_PFMEntry(lstBatchPFM, trungtam);
                dtout = workdb.GetDatatableSQL("select * from dbo.[save_out] join db_owner.[AllUser] as us1 on UserId=us1.Id where  TypeOut = 1 ");
                if (dt.Rows.Count > 0)
                {
                    var results = from status in dt.AsEnumerable()
                                  group status by (status.Field<string>("MSNV")) into status
                                  select new
                                  {
                                      Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                      Level = status.Select(x => x.Field<int>("Level")).FirstOrDefault(),
                                      Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                      Tongkytu = status.Select(x => x.Field<int>("Tổng ký tự")).Sum() / 1.0,
                                      Loisai = status.Select(x => x.Field<int>("Lỗi sai")).Sum(),
                                      Thoigian = ((status.Select(x => x.Field<int>("Thời gian")).Sum()) / 1000.0) / 60.0,
                                      Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count(),
                                      NotGood = status.Select(x => x.Field<int>("NG")).Where(x => x != 0).Count(),
                                  };
                    double tongkt = results.Sum(x => x.Tongkytu);
                    double tongls = results.Sum(x => x.Loisai);
                    double tongtg = Math.Round(results.Sum(x => x.Thoigian), 2);
                    double tongtruong = results.Sum(x => x.Tongtruong);
                    double TLNG = results.Sum(x => x.NotGood);
                    prgbExcel.Invoke((System.Action)(() =>
                    {
                        prgbExcel.Maximum = results.Count();
                    }));
                    foreach (var element in results)
                    {
                        var rowindex = dtPFM.NewRow();
                        rowindex["Họ và tên"] = element.Fullname;
                        rowindex["Level"] = element.Level;
                        rowindex["Trung tâm"] = element.Trungtam;
                        rowindex["Tổng ký tự"] = element.Tongkytu;
                        rowindex["Lỗi sai"] = element.Loisai;
                        rowindex["Tỷ lệ sai(%)"] = Math.Round((Convert.ToDouble(element.Loisai) / Convert.ToDouble(element.Tongkytu)) * 100.0, 2);
                        rowindex["Thời gian(phút)"] = Math.Round(element.Thoigian, 2);
                        rowindex["Tốc độ(ký tự/phút)"] = Math.Round(element.Tongkytu / element.Thoigian, 2);
                        rowindex["Đảm nhận(%)"] = Math.Round((element.Tongkytu / tongkt) * 100, 2);
                        rowindex["Tổng trường"] = element.Tongtruong;
                        rowindex["Tổng trường notgood"] = element.NotGood;
                        rowindex["Tỷ lệ NG"] = Math.Round((element.NotGood * 100) / (double)element.Tongtruong, 2);
                        // Làm thêm:
                        System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                        try
                        {
                            dtsum = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 0 and Name like 'E%' ").CopyToDataTable();

                            //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                            rowindex["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round(element.Thoigian, 2));
                        }
                        catch
                        { rowindex["Tổng Thời gian"] = Math.Round(element.Thoigian, 2); }
                        try { dtsumcheck = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 1 and LevelLC = 1 and Name like 'E%'").CopyToDataTable(); rowindex["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                        catch { rowindex["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                        // Hết thêm
                        dtPFM.Rows.Add(rowindex);
                    }
                    DataRow newRow = dtPFM.NewRow();
                    DataRow newRow1 = dtPFM.NewRow();
                    DataRow newRow2 = dtPFM.NewRow();
                    DataRow newRow3 = dtPFM.NewRow();
                    DataRow newRow4 = dtPFM.NewRow();
                    //Max,Min,average 
                    newRow1[2] = "Cao nhất";
                    newRow1[3] = dtPFM.Compute("Max ([Tổng ký tự])", "");
                    newRow1[4] = dtPFM.Compute("Max ([Lỗi sai])", "");
                    newRow1[5] = dtPFM.Compute("Max ([Tỷ lệ sai(%)])", "");
                    newRow1[6] = dtPFM.Compute("Max ([Thời gian(phút)])", "");
                    newRow1[7] = dtPFM.Compute("Max ([Tốc độ(ký tự/phút)])", "");
                    newRow1[8] = dtPFM.Compute("Max ([Đảm nhận(%)])", "");
                    newRow1[9] = dtPFM.Compute("Max ([Tổng trường])", "");
                    newRow1[10] = dtPFM.Compute("Max ([Tổng trường notgood])", "");
                    newRow1[11] = dtPFM.Compute("Max ([Tỷ lệ NG])", "");
                    newRow2[2] = "Thấp nhất";
                    newRow2[3] = dtPFM.Compute("Min ([Tổng ký tự])", "");
                    newRow2[4] = dtPFM.Compute("Min ([Lỗi sai])", "");
                    newRow2[5] = dtPFM.Compute("Min ([Tỷ lệ sai(%)])", "");
                    newRow2[6] = dtPFM.Compute("Min ([Thời gian(phút)])", "");
                    newRow2[7] = dtPFM.Compute("Min ([Tốc độ(ký tự/phút)])", "");
                    newRow2[8] = dtPFM.Compute("Min ([Đảm nhận(%)])", "");
                    newRow2[9] = dtPFM.Compute("Min ([Tổng trường])", "");
                    newRow2[10] = dtPFM.Compute("Min ([Tổng trường notgood])", "");
                    newRow2[11] = dtPFM.Compute("Max ([Tỷ lệ NG])", "");
                    try
                    {
                        newRow3[2] = "Trung bình";
                        newRow3[3] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tổng ký tự])", "").ToString()), 0);
                        newRow3[4] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Lỗi sai])", "").ToString()), 0);
                        newRow3[5] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tỷ lệ sai(%)])", "").ToString()), 2);
                        newRow3[6] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Thời gian(phút)])", "").ToString()), 0);
                        newRow3[7] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tốc độ(ký tự/phút)])", "").ToString()), 0);
                        newRow3[8] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Đảm nhận(%)])", "").ToString()), 0);
                        newRow3[9] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tổng trường])", "").ToString()), 0);
                        newRow3[10] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tổng trường notgood])", "").ToString()), 0);
                        newRow3[11] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tỷ lệ NG])", "").ToString()), 0);
                    }
                    catch
                    {
                    }
                    dtPFM.Rows.Add(newRow);
                    dtPFM.Rows.Add(newRow1);
                    dtPFM.Rows.Add(newRow2);
                    dtPFM.Rows.Add(newRow3);
                    if (trungtam == "ALL")
                    {
                        DataRow newRow5 = dtPFM.NewRow();
                        DataRow newRow7 = dtPFM.NewRow();
                        DataRow newRow8 = dtPFM.NewRow();
                        dtPFM.Rows.Add(newRow5);
                        newRow7[2] = "ALL";
                        newRow7[3] = tongkt;
                        newRow7[4] = tongls;
                        newRow7[5] = tongkt - tongls;
                        newRow7[6] = tongtg;
                        newRow7[7] = "100";
                        newRow7[8] = Math.Round((Convert.ToDouble(newRow7[5]) * 100.0 / tongkt), 2);
                        newRow7[9] = tongtruong;
                        newRow7[10] = dtPFM.Compute("Sum ([Tổng trường notgood])", "level>0");
                        newRow7[11] = "100";
                        dtPFM.Rows.Add(newRow7);
                        string tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DN'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DN'").ToString());
                            double tongtruongdn = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString());

                            newRow8[2] = "DN";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[7] = 0;
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongdn;
                            newRow8[10] = dtPFM.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'DN'");
                            newRow8[11] = 0;
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'HUE'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'HUE'").ToString());
                            double tongtruonghue = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString());
                            newRow8[2] = "HUE";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = Math.Round(double.Parse(tkuGroup) - tlsGroup, 2);
                            newRow8[6] = timeGroup;
                            newRow8[7] = 0;
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruonghue;
                            newRow8[10] = dtPFM.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'HUE'");
                            newRow8[11] = 0;
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'PY'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'PY'").ToString());
                            double tongtruongpy = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString());
                            newRow8[2] = "PY";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongpy;
                            newRow8[10] = dtPFM.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'PY'");
                            newRow8[11] = 0;
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DL'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DL'").ToString());
                            double tongtruongdl = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString());
                            newRow8[2] = "DL";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongdl;
                            newRow8[10] = dtPFM.Compute("SUM ([Tổng trường notgood])", "[Trung tâm] = 'DL'");
                            newRow8[11] = 0;
                            dtPFM.Rows.Add(newRow8);
                        }
                    }
                    else
                    {
                        DataRow newRow5 = dtPFM.NewRow();
                        DataRow newRow6 = dtPFM.NewRow();
                        DataRow newRow7 = dtPFM.NewRow();
                        dtPFM.Rows.Add(newRow5);
                        dtPFM.Rows.Add(newRow6);
                        newRow7[2] = typeGroup;
                        newRow7[3] = tongkt;
                        newRow7[4] = tongls;
                        newRow7[5] = tongkt - tongls;
                        newRow7[6] = tongtg;
                        newRow7[9] = dtPFM.Compute("SUM ([Tổng trường])", "level>0");
                        newRow7[10] = dtPFM.Compute("SUM ([Tổng trường notgood])", "level>0");
                        newRow7[11] = 0;
                        dtPFM.Rows.Add(newRow7);
                    }
                    worker.ReportProgress(dtPFM.Rows.Count);
                }
            }
            #endregion
            #region CHECK
            if (typeUser == "CHECK")
            {
                dtc.Clear();
                dtc = workdb.All_Check(lstBatchPFM, trungtam);
                dtout = workdb.GetDatatableSQL("select * from dbo.[save_out] join db_owner.[AllUser] as us1 on UserId=us1.Id where  TypeOut = 2 ");
                if (dtc.Rows.Count > 0)
                {
                    var results = from status in dtc.AsEnumerable()
                                  group status by (status.Field<string>("MSNV")) into status
                                  select new
                                  {
                                      Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                      Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                      Level = status.Select(x => x.Field<int>("Lvl")).FirstOrDefault(),
                                      Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count() / 1.0,
                                      Thoigian = status.Select(x => x.Field<int>("Thời gian")).Sum()
                                  };
                    double tt = results.Sum(x => x.Tongtruong);
                    double tp = Math.Round(results.Sum(x => x.Thoigian) / 60000.0);
                    prgbExcel.Invoke((System.Action)(() =>
                    {
                        prgbExcel.Maximum = results.Count();
                    }));
                    foreach (var element in results)
                    {
                        var rowcheck1 = dtPFMCheck.NewRow();
                        rowcheck1["Họ và tên"] = element.Fullname;
                        rowcheck1["Level"] = element.Level;
                        rowcheck1["Trung tâm"] = element.Trungtam;
                        rowcheck1["Tổng trường"] = element.Tongtruong;
                        rowcheck1["Thời gian(phút)"] = Math.Round(element.Thoigian / 60000.0, 2);
                        rowcheck1["Tốc độ(trường/phút)"] = Math.Round(element.Tongtruong / (element.Thoigian / 60000.0), 2);
                        rowcheck1["Đảm nhận(%)"] = Math.Round(element.Tongtruong / tt * 100, 2);
                        // Làm thêm:
                        System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                        try
                        {
                            dtsum = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 0 and (Name like 'C2%' or Name like 'QC2%') ").CopyToDataTable();

                            //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                            rowcheck1["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round((double)element.Thoigian / 60000.0, 2));
                        }
                        catch
                        { rowcheck1["Tổng Thời gian"] = Math.Round((double)element.Thoigian / 60000.0, 2); }
                        try { dtsumcheck = dtout.Select("Fullname = '" + element.Fullname + "' and Lvl = 1 and LevelLC = 1 and (Name like 'C2%' or Name like 'QC2%')").CopyToDataTable(); rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                        catch { rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                        // Hết thêm
                        dtPFMCheck.Rows.Add(rowcheck1);
                    }
                    DataRow newRowCheck = dtPFMCheck.NewRow();
                    DataRow newRowCheck1 = dtPFMCheck.NewRow();
                    DataRow newRowCheck2 = dtPFMCheck.NewRow();
                    DataRow newRowCheck3 = dtPFMCheck.NewRow();
                    DataRow newRowCheck4 = dtPFMCheck.NewRow();
                    //Max,Min,average 
                    newRowCheck1[2] = "Cao nhất";
                    newRowCheck1[3] = dtPFMCheck.Compute("Max ([Tổng trường])", "");
                    newRowCheck1[4] = dtPFMCheck.Compute("Max ([Thời gian(phút)])", "");
                    newRowCheck1[5] = dtPFMCheck.Compute("Max ([Tốc độ(trường/phút)])", "");
                    newRowCheck1[6] = dtPFMCheck.Compute("Max ([Đảm nhận(%)])", "");

                    newRowCheck2[2] = "Thấp nhất";
                    newRowCheck2[3] = dtPFMCheck.Compute("Min ([Tổng trường])", "");
                    newRowCheck2[4] = dtPFMCheck.Compute("Min ([Thời gian(phút)])", "");
                    newRowCheck1[5] = dtPFMCheck.Compute("Max ([Tốc độ(trường/phút)])", "");
                    newRowCheck2[6] = dtPFMCheck.Compute("Min ([Đảm nhận(%)])", "");
                    try
                    {
                        newRowCheck3[2] = "Trung bình";
                        newRowCheck3[3] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Tổng trường])", "").ToString()), 2);
                        newRowCheck3[4] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Thời gian(phút)])", "").ToString()), 2);
                        newRowCheck3[5] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Tốc độ(trường/phút)])", "").ToString()), 2);
                        newRowCheck3[6] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Đảm nhận(%)])", "").ToString()), 2);
                    }
                    catch
                    {
                    }
                    dtPFMCheck.Rows.Add(newRowCheck);
                    dtPFMCheck.Rows.Add(newRowCheck1);
                    dtPFMCheck.Rows.Add(newRowCheck2);
                    dtPFMCheck.Rows.Add(newRowCheck3);
                    if (trungtam == "ALL")
                    {
                        DataRow newRowCheck5 = dtPFMCheck.NewRow();
                        DataRow newRowCheck7 = dtPFMCheck.NewRow();
                        DataRow newRowCheck8 = dtPFMCheck.NewRow();
                        dtPFMCheck.Rows.Add(newRowCheck5);
                        newRowCheck7[2] = "ALL";
                        newRowCheck7[3] = tt;
                        newRowCheck7[4] = tp;
                        newRowCheck7[6] = "100";
                        dtPFMCheck.Rows.Add(newRowCheck7);
                        string tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DN'").ToString();
                            double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DN'").ToString());
                            double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận(%)])", "[Trung tâm] = 'DN'").ToString());

                            newRowCheck8[2] = "DN";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[6] = tdnGroup;
                            dtPFMCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCheck.NewRow();
                            string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'HUE'").ToString();
                            double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'HUE'").ToString());
                            double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận(%)])", "[Trung tâm] = 'HUE'").ToString());

                            newRowCheck8[2] = "HUE";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[6] = tdnGroup;
                            dtPFMCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCheck.NewRow();
                            string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'PY'").ToString();
                            double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'PY'").ToString());
                            double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận(%)])", "[Trung tâm] = 'PY'").ToString());

                            newRowCheck8[2] = "PY";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[6] = tdnGroup;
                            dtPFMCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMCheck.NewRow();
                            string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DL'").ToString();
                            double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian(phút)])", "[Trung tâm] = 'DL'").ToString());
                            double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận(%)])", "[Trung tâm] = 'DL'").ToString());

                            newRowCheck8[2] = "DL";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[6] = tdnGroup;
                            dtPFMCheck.Rows.Add(newRowCheck8);
                        }
                    }
                    else
                    {
                        DataRow newRowCheck5 = dtPFMCheck.NewRow();
                        DataRow newRowCheck7 = dtPFMCheck.NewRow();
                        dtPFMCheck.Rows.Add(newRowCheck5);
                        newRowCheck7[2] = typeGroup;
                        newRowCheck7[3] = tt;
                        newRowCheck7[4] = tp;
                        newRowCheck7[6] = "100";
                        dtPFMCheck.Rows.Add(newRowCheck7);
                    }
                    worker.ReportProgress(dtPFMCheck.Rows.Count);
                }
            }
            #endregion
            #region LASTCHECK
            else
            {
                if (typeUser == "LASTCHECK")
                {
                    dtlklc.Clear();
                    if (dotlc != "All")
                    { dtlklc = workdb.Get_PFMLC(dotlc); }
                    else
                    { dtlklc = workdb.Get_PFMLCALL(); }
                    dtout = workdb.GetDatatableSQL("select * from dbo.[save_out] join db_owner.[AllUser] as us1 on UserId=us1.Id where  TypeOut = 3 ");
                    if (dtlklc.Rows.Count > 0)
                    {
                        var results = from status in dtlklc.AsEnumerable()
                                      group status by (status.Field<int>("Lcid")) into status
                                      select new
                                      {
                                          LCID = status.Select(x => x.Field<int>("Lcid")).FirstOrDefault(),
                                          DotLC = status.Select(x => x.Field<string>("TurnUp")).FirstOrDefault(),
                                          Thoigian = status.Select(x => x.Field<int>("Time")).Sum()
                                      };
                        //prgbExcel.Invoke((System.Action)(() =>
                        //{
                        //    prgbExcel.Maximum = results.Count();
                        //}));
                        foreach (var element in results)
                        {
                            var rowcheck1 = dtPFMLastCheck.NewRow();
                            rowcheck1["Họ và tên"] = workdb.Get_LcFn(element.LCID);
                            rowcheck1["Trung tâm"] = workdb.Get_LcGr(element.LCID);
                            rowcheck1["Tổng phiếu"] = workdb.Get_Lcsl(element.DotLC);
                            rowcheck1["Thời gian(phút)"] = Math.Round(Convert.ToDouble(element.Thoigian) / 60000.0, 2);
                            rowcheck1["Tốc độ(phiếu/phút)"] = Math.Round(Convert.ToDouble(workdb.Get_Lcsl(element.DotLC)) / (Convert.ToDouble(element.Thoigian) / 60000), 2);
                            rowcheck1["Đảm nhận(%)"] = Math.Round((Convert.ToDouble(workdb.Get_Lcsl(element.DotLC)) / Convert.ToDouble(workdb.Get_Lcdn()) * 100), 2);
                            // Làm thêm:
                            System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                            try
                            {
                                dtsum = dtout.Select("UserId = '" + element.LCID + "'").CopyToDataTable();

                                //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                                rowcheck1["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round(Convert.ToDouble(element.Thoigian) / 60000.0, 2));
                            }
                            catch
                            { rowcheck1["Tổng Thời gian"] = Math.Round(Convert.ToDouble(element.Thoigian) / 60000, 2); }
                            //try { dtsumcheck = dtout.Select("UserId = '" + element.LCID + "'").CopyToDataTable(); rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                            //catch { rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                            // Hết thêm
                            dtPFMLastCheck.Rows.Add(rowcheck1);
                        }

                        // Thêm Update yêu cầu 16032021
                        //dtPFMLastCheck.Columns.Add("Họ và tên", typeof(string));
                        //dtPFMLastCheck.Columns.Add("Trung tâm", typeof(string));
                        //dtPFMLastCheck.Columns.Add("Tổng phiếu", typeof(double));
                        //dtPFMLastCheck.Columns.Add("Thời gian(phút)", typeof(double));
                        //dtPFMLastCheck.Columns.Add("Tốc độ(phiếu/phút)", typeof(double));
                        //dtPFMLastCheck.Columns.Add("Đảm nhận(%)", typeof(double));
                        //dtPFMLastCheck.Columns.Add("Tổng Thời gian", typeof(double));
                        System.Data.DataTable dt_grop_user = new System.Data.DataTable();
                        dt_grop_user = dtPFMLastCheck.Copy();
                        dt_grop_user.Clear();
                        var results1 = from status1 in dtPFMLastCheck.AsEnumerable()
                                       group status1 by (status1.Field<string>("Họ và tên")) into status1
                                       select new
                                       {
                                           //LCID = status.Select(x => x.Field<int>("Lcid")).FirstOrDefault(),
                                           name_user = status1.Select(x => x.Field<string>("Họ và tên")).FirstOrDefault(),
                                           tongphieu = status1.Select(x => x.Field<double>("Tổng phiếu")).Sum(),
                                           Thoigian = status1.Select(x => x.Field<double>("Thời gian(phút)")).Sum(),
                                           trungtam = status1.Select(x => x.Field<string>("Trung tâm")).FirstOrDefault(),
                                           timetong_user = status1.Select(x => x.Field<double>("Tổng Thời gian")).Sum(),
                                       };
                        double Tongphieu = results1.Sum(x => x.tongphieu);
                        double tongtime = results1.Sum(x => x.Thoigian);
                        foreach (var element in results1)
                        {
                            var rowcheck1 = dt_grop_user.NewRow();
                            rowcheck1["Họ và tên"] = element.name_user;
                            rowcheck1["Trung tâm"] = element.trungtam;
                            rowcheck1["Tổng phiếu"] = element.tongphieu;
                            rowcheck1["Thời gian(phút)"] = element.Thoigian;
                            rowcheck1["Tốc độ(phiếu/phút)"] = Math.Round((Convert.ToDouble(element.tongphieu) / Convert.ToDouble(element.Thoigian)), 2);
                            rowcheck1["Đảm nhận(%)"] = Math.Round((Convert.ToDouble(element.tongphieu) / Tongphieu * 100), 2);
                            rowcheck1["Tổng Thời gian"] = element.timetong_user;
                            //// Làm thêm:
                            //System.Data.DataTable dtsum = new System.Data.DataTable(); System.Data.DataTable dtsumcheck = new System.Data.DataTable(); System.Data.DataTable dtsumqc = new System.Data.DataTable();
                            //try
                            //{
                            //    dtsum = dtout.Select("UserId = '" + element.LCID + "'").CopyToDataTable();

                            //    //sumObject = dtsum.Compute("Sum(Timeout)", string.Empty);ErrorLc
                            //    rowcheck1["Tổng Thời gian"] = Convert.ToDouble(Math.Round(Convert.ToInt32(dtsum.Compute("Sum ([Timeout])", "").ToString()) / 60000.0, 2).ToString()) + Convert.ToDouble(Math.Round(Convert.ToDouble(element.Thoigian) / 60000.0, 2));
                            //}
                            //catch
                            //{ rowcheck1["Tổng Thời gian"] = Math.Round(Convert.ToDouble(element.Thoigian) / 60000, 2); }
                            //try { dtsumcheck = dtout.Select("UserId = '" + element.LCID + "'").CopyToDataTable(); rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = dtsumcheck.Compute("Sum ([ErrorLc])", "").ToString(); }
                            //catch { rowcheck1["Lỗi sai so với LC (nội dung qua checker)"] = "0"; }
                            // Hết thêm
                            dt_grop_user.Rows.Add(rowcheck1);
                        }
                        dtPFMLastCheck.Clear();
                        dtPFMLastCheck = dt_grop_user.Copy();
                    }
                }
            }
            #endregion
        }
        private void bgwXem_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                prgbExcel.Value = e.ProgressPercentage;
            }
            catch
            {
            }
        }

        private void bgwXem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grcPerformance.DataSource = null;
            prgbExcel.Value = prgbExcel.Maximum;
            prgbExcel.Visible = false;
            if (typeUser == "ENTRYP")
            {
                grcPerformance.DataSource = dtPFMP;
            }
            else if (typeUser == "CHECKP")
            {
                grcPerformance.DataSource = dtPFMCP;
            }
            else if (typeUser == "ENTRY")
            {
                grcPerformance.DataSource = dtPFM;
            }
            else if (typeUser == "CHECK")
            {
                grcPerformance.DataSource = dtPFMCheck;
            }
            else if (typeUser == "LASTCHECK")
            {
                grcPerformance.DataSource = dtPFMLastCheck;
            }
        }

        private void frmAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnOk.Visible == true)
                btnOk_Click(sender, e);
        }
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
                oSheet.Cells[rowExcel + 4, columExcel].Characters(i, 1).Font.color = Color.Black;
                return BackTrack(s1, s2, i - 1, j - 1) + s1[i - 1];
            }
            else if (c[i - 1, j] > c[i, j - 1])
                return BackTrack(s1, s2, i - 1, j);
            else
                return BackTrack(s1, s2, i, j - 1);

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

        private void txtDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter)(e.KeyChar))
                e.Handled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "New user"; lblError.Text = "";
            txtFullname.Text = ""; txtMSNV.Text = ""; txtUsername.Text = ""; txtEmail.Text = ""; txtUsername.Enabled = true;
            cboLevel.SelectedIndex = -1; cboPair.SelectedIndex = -1; cboRole.SelectedIndex = -1; cboGroup.SelectedIndex = -1;
            trangthai = 1;
            PNewUserAndEditUser();
            txtUsername.Focus();

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
                if (MessageBox.Show("Delete this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    workdb.DeleteUser(Convert.ToInt32(lblID.Text));
                    DtAllUser();
                }
            trangthai = 3;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            PNewUserAndEditUser();
            trangthai = 2;
        }
        System.Data.DataTable dt_Result_now;
        private void btnviewstt_Click(object sender, EventArgs e)
        {
            dt_Result_now = new System.Data.DataTable();
            dt_Result_now = workdb.Get_alldetails_1();
            dtResultsEntry.Rows.Clear();
            grdstatus.DataSource = null;
            dtbatchlc = new System.Data.DataTable();
            if (cbosttus.Text == "Đợt 1")
            {
                dtbatchlc = workdb.Get_LC1();
            }
            else if (cbosttus.Text == "Đợt 2")
            {
                dtbatchlc = workdb.Get_LC2();
            }
            else if (cbosttus.Text == "Đợt 3")
            {
                dtbatchlc = workdb.Get_LC3();
            }
            else if (cbosttus.Text == "Đợt 4")
            {
                dtbatchlc = workdb.Get_LC4();
            }
            else if (cbosttus.Text == "All")
            {
                dtbatchlc = workdb.Get_LCAll();
            }
            //lstBatch = lstBatch.Trim().Replace(' ', ',');                                           
            if (dtbatchlc.Rows.Count > 0)
            {
                var results = from status in dtbatchlc.AsEnumerable()
                              group status by status.Field<int>("Id") into status
                              select new
                              {
                                  Id = status.Select(x => x.Field<int>("Id")).FirstOrDefault(),
                                  Count = status.Count(),
                                  P1 = status.Count(x => x.Field<int>("Hitpoint1") == 0),
                                  P2 = status.Count(x => x.Field<int>("Hitpoint2") == 0),
                                  CP = status.Count(x => x.Field<int>("Hitpoint1") == 1 && x.Field<int>("Hitpoint2") == 1 && x.Field<int>("InfoP") == 2),
                                  Entry1 = status.Count(x => (x.Field<int>("Hitpoint1") == 2 && x.Field<int>("InfoP") == 0)),
                                  Entry2 = status.Count(x => (x.Field<int>("Hitpoint2") == 2 && x.Field<int>("InfoP") == 0)),
                                  Check = status.Count(x => x.Field<int>("HitPoint1") == 3 && x.Field<int>("HitPoint2") == 3 && x.Field<int>("InfoE") == 2),
                                  QC = status.Count(x => x.Field<int>("HitPoint1") == 3 && x.Field<int>("HitPoint2") == 3 && x.Field<int>("InfoE") == 3),
                                  LC = status.Count(x => x.Field<int>("HitPoint1") == 4 && x.Field<int>("HitPoint2") == 4 && x.Field<int>("InfoE") == 0),
                              };

                foreach (var element in results)
                {
                    var row = dtResultsEntry.NewRow();
                    row["Id"] = dtbatchlc.Select("Id = " + element.Id)[0][0];
                    row["Tên Ảnh"] = dtbatchlc.Select("Id = " + element.Id)[0][1];
                    row["P1"] = element.P1;
                    row["P2"] = element.P2;
                    row["CheckP"] = element.CP;
                    row["Entry1"] = element.Entry1;
                    row["Entry2"] = element.Entry2;
                    row["C2"] = element.Check;
                    row["QC2"] = element.QC;
                    row["LC"] = element.LC;
                    row["Exit_Image"] = 0;
                    dtResultsEntry.Rows.Add(row);
                }
                grdstatus.DataSource = dtResultsEntry;
                grvstatus.Columns["Tên Ảnh"].Summary.Clear();
                grvstatus.Columns["P1"].Summary.Clear();
                grvstatus.Columns["P2"].Summary.Clear();
                grvstatus.Columns["CheckP"].Summary.Clear();
                grvstatus.Columns["Entry1"].Summary.Clear();
                grvstatus.Columns["Entry2"].Summary.Clear();
                grvstatus.Columns["C2"].Summary.Clear();
                grvstatus.Columns["QC2"].Summary.Clear();
                int tongSL = Convert.ToInt32(dtbatchlc.Rows.Count);
                grvstatus.Columns["Tên Ảnh"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Tổng trường");
                grvstatus.Columns["Tên Ảnh"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Tổng nhập");
                grvstatus.Columns["Tên Ảnh"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Còn lại");
                int tongP1 = Convert.ToInt32(dtResultsEntry.Select("P1 = 0").Length);
                grvstatus.Columns["P1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "P1", tongSL.ToString());
                grvstatus.Columns["P1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "P1", tongP1.ToString());
                grvstatus.Columns["P1"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "P1", (tongSL - tongP1).ToString());
                int tongP2 = Convert.ToInt32(dtResultsEntry.Select("P2 = 0").Length);
                grvstatus.Columns["P2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "P2", tongSL.ToString());
                grvstatus.Columns["P2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "P2", tongP2.ToString());
                grvstatus.Columns["P2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "P2", (tongSL - tongP2).ToString());
                //int tongcheckPL = Convert.ToInt32(dtResultsEntry.Select("CheckP = 1").Length);
                //grvstatus.Columns["CheckP"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "CheckP", tongSL.ToString());
                //grvstatus.Columns["CheckP"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "CheckP","0");
                //grvstatus.Columns["CheckP"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CheckP", tongcheckPL.ToString());
                //int tongE1 = Convert.ToInt32(dtResultsEntry.Select("Entry1 = 0").Length);
                //grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry1", tongSL.ToString());
                //grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry1", tongE1.ToString());
                //grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry1", (tongSL - tongE1).ToString());
                //int tongE2 = Convert.ToInt32(dtResultsEntry.Select("Entry2 = 0").Length);
                //grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry2", tongSL.ToString());
                //grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry2", tongE2.ToString());
                //grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry2", (tongSL - tongE2).ToString());
                //int C2 = Convert.ToInt32(dtResultsEntry.Select("C2 = 1").Length);
                //grvstatus.Columns["C2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "C2", tongSL.ToString());
                //grvstatus.Columns["C2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "C2", "0");
                //grvstatus.Columns["C2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "C2", C2.ToString());
                //int QC2 = Convert.ToInt32(dtResultsEntry.Select("QC2 = 1").Length);
                //grvstatus.Columns["QC2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "QC2", tongSL.ToString());
                //grvstatus.Columns["QC2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "QC2", "0");
                //grvstatus.Columns["QC2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QC2", QC2.ToString());
            }
            try
            {
                grvstatus.Columns[0].Visible = false;
            }
            catch
            {
            }
        }

        private void grvstatus_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                frmdetails frmdta = new frmdetails();
                frmdta.iddt = Convert.ToInt32(grvstatus.GetRowCellValue(e.RowHandle, "Id"));
                frmdta.ShowDialog();
                btnviewstt_Click(sender, e);
            }
        }

        private void grvUsers_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grdUsers_MouseHover(object sender, EventArgs e)
        {
            grvUsers.Focus();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            grvUsers.FindFilterText = txtsearch.Text;
            //dtAllUser = workdb.Search_All(txtsearch.Text);
            //grdUsers.DataSource = dtAllUser;

        }
        string entry1stt, entry2stt, checkPL;
        string nameAnh = "";
        private void grvstatus_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            var cl = e.Column;
            string vl = e.CellValue.ToString();

            if (r > -1)
            {
                if (cl.FieldName == "Tên Ảnh")
                {
                    nameAnh = e.CellValue.ToString();
                }
                if (cl.FieldName == "P1")
                {
                    tongsoluong1 = vl;
                    if (vl == "0")
                        e.Appearance.BackColor = Color.YellowGreen;
                    //if ( vl == "1")
                    //{
                    //    e.Appearance.BackColor = Color.Orange;
                    //}
                }
                if (cl.FieldName == "P2")
                {
                    tongsoluong2 = vl;
                    if (vl == "0")
                        e.Appearance.BackColor = Color.YellowGreen;

                    //if (vl == "1")
                    //{
                    //    e.Appearance.BackColor = Color.Orange;
                    //}
                }

                if (cl.FieldName == "Entry1")
                {
                    entry1stt = vl;
                    DataRow[] conten1 = null;
                    try
                    {
                        conten1 = dt_Result_now.Select("ImageName = '" + nameAnh + "'");
                    }
                    catch { }
                    if (tongsoluong1 == "1")
                    {
                        vl = "1";
                        soluonge1 = "1";
                    }
                    if (vl == "0" && checkPL == "0")
                    { e.Appearance.BackColor = Color.YellowGreen; }

                    if (tongsoluong1 == "1" || tongsoluong2 == "1" || checkPL == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    if (conten1[0].ItemArray[2].ToString() == "")
                    {

                        e.Appearance.BackColor = Color.White;
                    }
                }
                if (cl.FieldName == "Entry2")
                {
                    entry2stt = vl;
                    DataRow[] conten2 = null;
                    try
                    {
                        conten2 = dt_Result_now.Select("ImageName = '" + nameAnh + "'");
                    }
                    catch { }
                    if (tongsoluong2 == "1")
                    {
                        vl = "1";
                        soluonge2 = "1";
                    }
                    if (vl == "0" && checkPL == "0")
                    { e.Appearance.BackColor = Color.YellowGreen; }
                    if (tongsoluong1 == "1" || tongsoluong2 == "1" || checkPL == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    if (conten2[0].ItemArray[5].ToString() == "")
                    {

                        e.Appearance.BackColor = Color.White;
                    }
                }

                if (cl.FieldName == "LC")
                {
                    if (vl == "1")
                        e.Appearance.BackColor = Color.YellowGreen;
                }

                if (cl.FieldName == "CheckP")
                {
                    checkPL = vl;
                    if (vl == "1")
                    {
                        //vl = "1";
                        //soluonge1 = "1";
                        e.Appearance.BackColor = Color.OrangeRed;
                    }
                    if (vl == "0")
                    { e.Appearance.BackColor = Color.YellowGreen; }
                    if (tongsoluong1 == "1" || tongsoluong2 == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                }
                if (cl.FieldName == "C2")
                {
                    if (vl == "1")
                    {
                        //vl = "1";
                        e.Appearance.BackColor = Color.OrangeRed;
                        //soluonge2 = "1";
                    }
                    if (vl == "0")
                    { e.Appearance.BackColor = Color.YellowGreen; }
                    if (entry1stt == "1" || entry2stt == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    if (tongsoluong1 == "1" || tongsoluong2 == "1" || checkPL == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                }
                if (cl.FieldName == "QC2")
                {
                    if (vl == "1")
                    {
                        //vl = "1";
                        e.Appearance.BackColor = Color.OrangeRed;
                        //soluonge2 = "1";
                    }
                    if (vl == "0")
                    { e.Appearance.BackColor = Color.YellowGreen; }
                    if (entry1stt == "1" || entry2stt == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    if (tongsoluong1 == "1" || tongsoluong2 == "1" || checkPL == "1")
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                }
                if (cl.FieldName == "Exit_Image")
                {
                    DataRow[] User_Exit = null;
                    try
                    {
                        User_Exit = dt_Result_now.Select("ImageName = '" + nameAnh + "'");
                        if (User_Exit[0].ItemArray[15].ToString() != "" || User_Exit[0].ItemArray[16].ToString() != "")
                        {
                            e.Appearance.BackColor = Color.OrangeRed;
                        }
                    }
                    catch { }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region
            //string strPreferenceToRemember = @"C:\";
            //if (File.Exists(path))
            //{
            //    strPreferenceToRemember = File.ReadAllText(path);
            //}
            //else
            //{
            //    File.WriteAllText(path, strPreferenceToRemember);
            //}

            //FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            //fbd.SelectedPath = strPreferenceToRemember;
            //if (DialogResult.OK == fbd.ShowDialog())
            //{
            //    txtSOP.Text = fbd.SelectedPath;
            //    File.WriteAllText(path, txtSOP.Text);
            //}
            //else
            //{
            //    return;
            //}
            //txtSOP.Text = fbd.SelectedPath;
            ////string[] ext = new string[4] { ".jpg", ".tif", ".png", ".tiff" };
            ////pagesFilePath = Directory.GetFiles(txtSourceDirectory.Text,"*.tif",SearchOption.AllDirectories).Where(s => ext.Any(vl => s.EndsWith(vl))).ToArray();
            //pagesFilePath = Directory.GetFiles(txtSOP.Text, "*.png", System.IO.SearchOption.AllDirectories);
            //Array.Sort(pagesFilePath);
            //pagesFilePathLength = pagesFilePath.Length;
            #endregion
            string strPreferenceToRemember = @"C:\";
            if (File.Exists(path))
            {
                strPreferenceToRemember = File.ReadAllText(path);
            }
            else
            {
                File.WriteAllText(path, strPreferenceToRemember);
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "png files (*.png)|*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string[] ext = new string[4] { ".jpg", ".tif", ".png", ".tiff" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtSOP.Text = openFileDialog1.FileName;
                    File.WriteAllText(path, txtSOP.Text);
                }
                catch (Exception ex)
                {

                }
            }
        }
        private byte[] imageToByteArray(Bitmap imageIn)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms, myImageCodecInfo, myEncoderParameters);
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void cboTemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTemName.SelectedIndex > -1)
            //{
            //    idsop = Convert.ToInt32(dttemplate.Rows[cboTemName.SelectedIndex]["Id"]);
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (gridVDemDong.Columns.Count > 0)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = "";
                    saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        gridVDemDong.ClearColumnsFilter();
                        gridVDemDong.ClearSorting();
                        gridVDemDong.ClearGrouping();
                        gridVDemDong.ClearSelection();
                        gridVDemDong.FindFilterText = "";
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        //NImageExporter imageExporter = chartControl.ImageExporter;
                        gridVDemDong.ExportToXlsx(exportFilePath);
                    }
                }
            }
        }
        private System.Data.DataTable ALL_DATA_DAY()
        {
            string stringconnecttion = String.Format(@"Data Source=192.168.1.3;Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select us1.ImageName,Content1,UserId1,Content2,UserId2,isnull(CheckerId,0),isnull(QCID,0),isnull(Loisai1,0),isnull(Loisai2,0),Result,Checkresult,UserP1,UserP2,ResultP,STT_ID_PL from db_owner.ImageContent join db_owner.AllImage as us1 on AllImageId=us1.Id ";
                SqlDataAdapter da = new SqlDataAdapter();
                con.Open();
                da.SelectCommand = sqlCommand;
                da.Fill(dt);
            }
            return dt;

        }

        public void InsertImageToServer(string Name, byte[] image, string day)
        {
            string stringconnecttion22 = String.Format(@"Data Source=192.168.1.3; Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");
            try
            {

                using (SqlConnection con = new SqlConnection(stringconnecttion22))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Insert into dbo.[ServerImage_BACKUP] (NameImage,BinaryImage,DateCreated) VALUES (@NameImage,@VarImage,N'" + day + "')";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    con.Open();
                    sqlCommand.ExecuteReader();
                }
            }
            catch { }
        }
        DAEntry_Entry daEntry = new DAEntry_Entry();

        private void btn_Change_DotAnh_Click(object sender, EventArgs e)
        {
            if (cbb_DotThaydoi.Text != "" && cbb_TenAnh_Dot.Text != "")
            {
                if (MessageBox.Show("Bạn muốn thay đổi Đợt CA của ảnh hiện tại ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id_Image = workdb.get_Idanh(cbb_TenAnh_Dot.Text);
                    workdb.Update_Change_Dot(cbb_TenAnh_Dot.Text, Id_Image, Convert.ToInt32(cbb_DotThaydoi.Text));
                    tb_DotThayDoi = new System.Data.DataTable();
                    tb_DotThayDoi = workdb.Get_All_Image_Change();
                    grd_ChangeDot.DataSource = tb_DotThayDoi;
                    grV_ChangeDot.BestFitColumns();
                    cbb_TenAnh_Dot.DisplayMember = "ImageName";
                    cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
                    MessageBox.Show("Hoàn thành thay đổi Đợt Up !");
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin Thay đổi ? ");
            }
        }

        private void grTempV_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void grTempV_DoubleClick(object sender, EventArgs e)
        {
            //int r = grTempV.FocusedRowHandle;
            //if (r > -1)
            //{
            //    string id_tem = grTempV.GetRowCellValue(r, grTempV.Columns["Id"]).ToString();
            //    Form_Crop frm = new Form_Crop();
            //    frm.dt_template = dttemplate;
            //    frm.index_row = r;
            //    frm.ShowDialog();
            //    dttemplate = workdb.Get_allTemp();
            //    grTemp.DataSource = dttemplate;
            //    grTempV.Columns[0].Visible = false;
            //    grTempV.Columns["Poi_Rules"].Visible = false;
            //    grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            //}
        }

        private void btn_backUp_Click_2(object sender, EventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            System.Data.DataTable AllData_Daynow = new System.Data.DataTable();
            DateTime test = DateTime.Now;
            //DateTime test2 = DateTime.Parse(AllData_Daynow.Rows[i][6].ToString());
            string date_bk = test.ToString("yyyy-MM-dd");

            System.Data.DataTable check_date = new System.Data.DataTable();
            check_date = daEntry.GetDatatableSQL("Select * from db_owner.[BackUp_ImageContent] where Time = N'" + date_bk + "'");
            if (check_date.Rows.Count > 0)
            {
                //splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Bạn đã thực hiện BackUp !");
                btn_backUp.Enabled = false;
                return;
            }

            // Lấy Toàn bộ dữ liệu trong ngày
            AllData_Daynow = ALL_DATA_DAY();
            //CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime resultdate1;
            DateTime resultdate2;
            if (AllData_Daynow.Rows.Count > 0)
            {
                string format = "yyyy-MM-dd HH:mm:ss.fff";

                for (int i = 0; i < AllData_Daynow.Rows.Count; i++)
                {
                    string test111 = AllData_Daynow.Rows[i][10].ToString();
                    if (test111.Length > 0)
                    {
                        daEntry.Insert_DATA_BACKUP(AllData_Daynow.Rows[i][0].ToString(), AllData_Daynow.Rows[i][1].ToString(), Convert.ToInt32(AllData_Daynow.Rows[i][2].ToString()), AllData_Daynow.Rows[i][3].ToString(), Convert.ToInt32(AllData_Daynow.Rows[i][4].ToString()), Convert.ToInt32(AllData_Daynow.Rows[i][5].ToString()), Convert.ToInt32(AllData_Daynow.Rows[i][6].ToString()), Convert.ToInt32(AllData_Daynow.Rows[i][7].ToString()), Convert.ToInt32(AllData_Daynow.Rows[i][8].ToString()), AllData_Daynow.Rows[i][9].ToString(), AllData_Daynow.Rows[i][10].ToString(), date_bk, Convert.ToInt32(AllData_Daynow.Rows[i][11].ToString()), Convert.ToInt32(AllData_Daynow.Rows[i][12].ToString()), AllData_Daynow.Rows[i][13].ToString(), Convert.ToInt32(AllData_Daynow.Rows[i][14].ToString()));
                    }
                }
                // Add dữ liệu Binary Ảnh
                for (int i = 0; i < AllData_Daynow.Rows.Count; i++)
                {
                    try
                    {
                        //DateTime test = DateTime.Now;
                        //DateTime test2 = DateTime.Parse(AllData_Daynow.Rows[i][6].ToString());
                        //string eeeeeeeeee = test.ToString("yyyy-MM-dd");
                        string name_Image = AllData_Daynow.Rows[i][0].ToString();
                        //System.Data.DataTable tb_binary = daEntry.GetDatatableSQL2("Select * from dbo.[ServerImage] ");
                        byte[] img_backup = null;
                        img_backup = workdb.GetImage_BackUP(name_Image.Trim());
                        Bitmap bm = new Bitmap(Io_Entry.byteArrayToImage(img_backup));
                        //Bitmap imageSource = new Bitmap(Io_Entry.byteArrayToImage(tbImage.getImageOnServer(anhexport, tableimage)));
                        InsertImageToServer(name_Image, imageToByteArray(bm), date_bk);
                    }
                    catch
                    {
                    }
                }
                //MessageBox.Show("Hoàn Thành Back Up Dữ Liệu !");
                btn_backUp.Enabled = false;
            }
            //splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Hoàn Thành Back Up Dữ Liệu !");
        }

        private void txt_macot1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclearsop_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(isop) > 0)
            {
                if (MessageBox.Show("Delete Image SOP in Template_Demo " + txtsoptem.Text.Trim() + "???", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    daEntry.ExecuteSQL("Update dbo.[Template_Demo] set SopImage = NULL,Poi_Sop = 0 where Id = " + isop + "");
                    MessageBox.Show("Delete Image SOP Success!!");
                }
                dttemplate = workdb.Get_allTempDemo();
                grTemp.DataSource = dttemplate;
                grTempV.Columns[0].Visible = false;
                grTempV.Columns["Poi_Rules"].Visible = false;
                grTempV.Columns["PoiSop"].Visible = false;

                grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            }
        }
        System.Data.DataTable dt_dtCheck = new System.Data.DataTable();

        private void grTempV_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            if (r > -1)
            {

                if (grTempV.GetRowCellValue(e.RowHandle, grTempV.Columns["PoiSop"]).ToString() == "0")
                {
                    e.Appearance.BackColor = Color.Orange;
                }
                else
                {
                    //if (grTempV.GetRowCellValue(e.RowHandle, grTempV.Columns["Binary_Poi_SOP"]) == DBNull.Value)
                    //{
                    //    if (e.Column.FieldName == "TempName" || e.Column.FieldName == "Poi_SOP")
                    //    {
                    //        e.Appearance.BackColor = Color.Orange;
                    //    }
                    //}
                    //else if (grTempV.GetRowCellValue(e.RowHandle, grTempV.Columns["Binary_Poi_SOP_PL"]) == DBNull.Value)
                    //{
                    //    if (e.Column.FieldName == "TempName" || e.Column.FieldName == "Poi_SOP_PL")
                    //    {
                    //        e.Appearance.BackColor = Color.Orange;
                    //    }
                    //}
                }



                //if (grTempV.GetRowCellValue(e.RowHandle, grTempV.Columns["Binary_Poi_Sop"]) == DBNull.Value)
                //{
                //    e.Appearance.BackColor = Color.Orange;

                //}
                //if (grTempV.GetRowCellValue(e.RowHandle, grTempV.Columns["Binary_Poi_Sop_PL"]) == DBNull.Value)
                //{
                //    e.Appearance.BackColor = Color.Orange;
                //}
            }

        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all Template?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                daEntry.ExecuteSQL("Delete dbo.[Template_Demo];DBCC CHECKIDENT ('dbo.Template_Demo', RESEED, 1)");
                MessageBox.Show("Delete Success!!");
                dttemplate = workdb.Get_allTempDemo();
                grTemp.DataSource = dttemplate;
                grTempV.Columns[0].Visible = false;
                grTempV.Columns["Poi_Rules"].Visible = false;
                grTempV.Columns["PoiSop"].Visible = false;

                grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            }
            btnclearsop.Visible = false;
        }
        int index_row_change = 0;
        private void grTempV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int r = e.FocusedRowHandle;
            if (r > -1)
            {
                index_row_change = r;
            }
        }

        private void grV_ChangeDot_MouseUp(object sender, MouseEventArgs e)
        {
            int r = grV_ChangeDot.FocusedRowHandle;
            if (r > -1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                    System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem("Loại 1");
                    menuItem.Click += new EventHandler(Change_Style1);
                    System.Windows.Forms.MenuItem menuItem2 = new System.Windows.Forms.MenuItem("Loại 2");
                    menuItem2.Click += new EventHandler(Change_Style2);
                    System.Windows.Forms.MenuItem menuItem3 = new System.Windows.Forms.MenuItem("Loại 3");
                    menuItem3.Click += new EventHandler(Change_Style3);
                    System.Windows.Forms.MenuItem menuItem4 = new System.Windows.Forms.MenuItem("Loại 4");
                    menuItem4.Click += new EventHandler(Change_Style4);
                    contextMenu.MenuItems.Add(menuItem);
                    contextMenu.MenuItems.Add(menuItem2);
                    contextMenu.MenuItems.Add(menuItem3);
                    contextMenu.MenuItems.Add(menuItem4);
                    grd_ChangeDot.ContextMenu = contextMenu;
                }
            }
        }

        void Change_Style1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển qua Đợt 1 ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ColumnView View = (ColumnView)grd_ChangeDot.FocusedView;
                GridColumn column = View.Columns[grV_ChangeDot.FocusedColumn.FieldName];
                if (grV_ChangeDot.SelectedRowsCount == 0)
                {
                    return;
                }
                else if (grV_ChangeDot.SelectedRowsCount > 0)
                {
                    string chuoiID = "";
                    for (int i = 0; i < grV_ChangeDot.SelectedRowsCount; i++)
                    {
                        chuoiID += grV_ChangeDot.GetRowCellValue(grV_ChangeDot.GetSelectedRows()[i], grV_ChangeDot.Columns["Id"]).ToString() + ",";
                    }
                    chuoiID = chuoiID.Substring(0, chuoiID.Length - 1);
                    daEntry.ExecuteSQL("Update db_owner.[AllImage] set TurnUp = 1 where Id in (" + chuoiID + ")");
                    MessageBox.Show("Chuyển đổi Đợt thàng công qua Đợt 1");
                }
                tb_DotThayDoi = new System.Data.DataTable();
                tb_DotThayDoi = workdb.Get_All_Image_Change();
                grd_ChangeDot.DataSource = tb_DotThayDoi;
                grV_ChangeDot.BestFitColumns();
                cbb_TenAnh_Dot.DisplayMember = "ImageName";
                cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
            }
        }
        void Change_Style2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển qua Đợt 2 ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ColumnView View = (ColumnView)grd_ChangeDot.FocusedView;
                GridColumn column = View.Columns[grV_ChangeDot.FocusedColumn.FieldName];
                if (grV_ChangeDot.SelectedRowsCount == 0)
                {
                    return;
                }
                else if (grV_ChangeDot.SelectedRowsCount > 0)
                {
                    string chuoiID = "";
                    for (int i = 0; i < grV_ChangeDot.SelectedRowsCount; i++)
                    {
                        chuoiID += grV_ChangeDot.GetRowCellValue(grV_ChangeDot.GetSelectedRows()[i], grV_ChangeDot.Columns["Id"]).ToString() + ",";
                    }
                    chuoiID = chuoiID.Substring(0, chuoiID.Length - 1);
                    daEntry.ExecuteSQL("Update db_owner.[AllImage] set TurnUp = 2 where Id in (" + chuoiID + ")");
                    MessageBox.Show("Chuyển đổi Đợt thàng công qua Đợt 2");
                }
                tb_DotThayDoi = new System.Data.DataTable();
                tb_DotThayDoi = workdb.Get_All_Image_Change();
                grd_ChangeDot.DataSource = tb_DotThayDoi;
                grV_ChangeDot.BestFitColumns();
                cbb_TenAnh_Dot.DisplayMember = "ImageName";
                cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
            }
        }
        void Change_Style3(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển qua Đợt 3 ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ColumnView View = (ColumnView)grd_ChangeDot.FocusedView;
                GridColumn column = View.Columns[grV_ChangeDot.FocusedColumn.FieldName];
                if (grV_ChangeDot.SelectedRowsCount == 0)
                {
                    return;
                }
                else if (grV_ChangeDot.SelectedRowsCount > 0)
                {
                    string chuoiID = "";
                    for (int i = 0; i < grV_ChangeDot.SelectedRowsCount; i++)
                    {
                        chuoiID += grV_ChangeDot.GetRowCellValue(grV_ChangeDot.GetSelectedRows()[i], grV_ChangeDot.Columns["Id"]).ToString() + ",";
                    }
                    chuoiID = chuoiID.Substring(0, chuoiID.Length - 1);
                    daEntry.ExecuteSQL("Update db_owner.[AllImage] set TurnUp = 3 where Id in (" + chuoiID + ")");
                    MessageBox.Show("Chuyển đổi Đợt thàng công qua Đợt 3");
                }
                tb_DotThayDoi = new System.Data.DataTable();
                tb_DotThayDoi = workdb.Get_All_Image_Change();
                grd_ChangeDot.DataSource = tb_DotThayDoi;
                grV_ChangeDot.BestFitColumns();
                cbb_TenAnh_Dot.DisplayMember = "ImageName";
                cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
            }
        }
        void Change_Style4(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển qua Đợt 4 ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ColumnView View = (ColumnView)grd_ChangeDot.FocusedView;
                GridColumn column = View.Columns[grV_ChangeDot.FocusedColumn.FieldName];
                if (grV_ChangeDot.SelectedRowsCount == 0)
                {
                    return;
                }
                else if (grV_ChangeDot.SelectedRowsCount > 0)
                {
                    string chuoiID = "";
                    for (int i = 0; i < grV_ChangeDot.SelectedRowsCount; i++)
                    {
                        chuoiID += grV_ChangeDot.GetRowCellValue(grV_ChangeDot.GetSelectedRows()[i], grV_ChangeDot.Columns["Id"]).ToString() + ",";
                    }
                    chuoiID = chuoiID.Substring(0, chuoiID.Length - 1);
                    daEntry.ExecuteSQL("Update db_owner.[AllImage] set TurnUp = 4 where Id in (" + chuoiID + ")");
                    MessageBox.Show("Chuyển đổi Đợt thàng công qua Đợt 4");
                }
                tb_DotThayDoi = new System.Data.DataTable();
                tb_DotThayDoi = workdb.Get_All_Image_Change();
                grd_ChangeDot.DataSource = tb_DotThayDoi;
                grV_ChangeDot.BestFitColumns();
                cbb_TenAnh_Dot.DisplayMember = "ImageName";
                cbb_TenAnh_Dot.DataSource = tb_DotThayDoi;
            }
        }

        private void grV_ChangeDot_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thay đổi đường dẫn Folder chứa các File Excel của Dự án ???", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                daEntry.ExecuteSQL("Update dbo.[LinkExport] set Link_Export = N'" + txt_linkSave + "' where Id = 1");
                MessageBox.Show("Update Complete !!!");
                return;
            }
        }

        private byte[] imageToByteArray2(Bitmap imageIn)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        List<string> BinarySOP = new List<string>();
        List<string> BinarySOP_PL = new List<string>();

        public static byte[] imageConversion(string imageName)
        {
            //Initialize a file stream to read the image file
            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
            //Initialize a byte array with size of stream
            byte[] imgByteArr = new byte[fs.Length];
            //Read data from the file stream and put into the byte array
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
            //Close a file stream
            fs.Close();
            return imgByteArr;
        }

        System.Data.DataTable dt_dataall = new System.Data.DataTable();
        private void btnistemp_Click(object sender, EventArgs e)
        {

            #region Update-Code-TaiLNT
            string pathSOP = @"\\192.168.1.5\Project\DE-CHORUS-NNC\Document\TAI LIEU DU AN\SOP\SOP\";
            string pathSOP_PL = @"\\192.168.1.5\Project\DE-CHORUS-NNC\Document\TAI LIEU DU AN\SOP\SOP_PL\";
            BinarySOP = Directory.GetFiles(pathSOP, "*.png", System.IO.SearchOption.TopDirectoryOnly).ToList();
            BinarySOP_PL = Directory.GetFiles(pathSOP_PL, "*.png", System.IO.SearchOption.TopDirectoryOnly).ToList();
            #endregion
            #region code cũ
            //txtsoptem.Text = "";
            //txtsoprule.Text = "";
            //txtCodeNumber.Text = "";
            //txtsoptem.Enabled = true;
            //txtsoprule.Enabled = true;
            //txtCodeNumber.Enabled = true;
            //ttsop = 1;
            //txtsoptem.Focus();
            #endregion
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Excels Files",
                DefaultExt = "xlsx",
                Filter = "Excel files (*.xlsx)|*.xlsx",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                dt_dataall = new System.Data.DataTable();
                string Contrs1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + open.FileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                OleDbConnection con1 = new OleDbConnection(Contrs1);
                OleDbCommand cmd1 = new OleDbCommand("Select * from [Sheet1$]", con1);
                con1.Open();
                dt_dataall.Load(cmd1.ExecuteReader());
                con1.Close();
                if (dt_dataall.Rows.Count <= 0)
                {
                    MessageBox.Show("File dữ liệu trống !!!");
                }
                var mess_update = MessageBox.Show("Update thông tin File Excel lên hệ thống ???", "Messenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mess_update == DialogResult.Yes)
                {
                    for (int i = 0; i < dt_dataall.Rows.Count; i++)
                    {
                        if (dt_dataall.Rows[i][1].ToString() != "")
                        {
                            if (daEntry.GetIntSQL("Select Id from dbo.Template_Demo where TempName = N'" + dt_dataall.Rows[i][1].ToString().Trim() + "'") < 1)
                            {
                                #region update-code-tailnt
                                if (String.IsNullOrEmpty(dt_dataall.Rows[i]["Poi_SOP"].ToString()) || String.IsNullOrEmpty(dt_dataall.Rows[i]["Poi_SOP_PL"].ToString()) || !File.Exists(pathSOP + dt_dataall.Rows[i]["Poi_SOP"].ToString().Trim() + ".png") || !File.Exists(pathSOP_PL + dt_dataall.Rows[i]["Poi_SOP_PL"].ToString().Trim() + ".png"))
                                {
                                    MessageBox.Show("Không tìm thấy ảnh SOP or SOP PL ");
                                    break;
                                }
                                else
                                {
                                    foreach (string files in BinarySOP)
                                    {
                                        foreach (string filesPL in BinarySOP_PL)
                                        {
                                            if (Path.GetFileName(files).ToString().Split('.')[0] == dt_dataall.Rows[i]["Poi_SOP"].ToString().Trim())
                                            {
                                                if (Path.GetFileName(filesPL).ToString().Split('.')[0] == dt_dataall.Rows[i]["Poi_SOP_PL"].ToString().Trim())
                                                {
                                                    daEntry.ExecuteSQL2("INSERT INTO dbo.Template_Demo(TempName,Rules,Colum1_1,Colum1_2,Colum1_3,MaCot1,MaCot2,Poi_Sop,MaCot3,[Form 6],SopImage)VALUES(N'" + dt_dataall.Rows[i][1] + "',N'" + dt_dataall.Rows[i][5] + "',N'" + dt_dataall.Rows[i][2] + "',N'" + dt_dataall.Rows[i][3] + "', N'" + dt_dataall.Rows[i][4] + "',N'" + dt_dataall.Rows[i][6] + "',N'" + dt_dataall.Rows[i][7] + "',1,N'" + dt_dataall.Rows[i][8] + "', N'" + dt_dataall.Rows[i]["Form 6"] + "',@BinarySOP) " + " INSERT INTO dbo.ServerImageSOP_Demo(TemplateID, Poi_SOP, Poi_SOP_PL,Binary_Poi_SOP_PL)VALUES((SELECT Id FROM dbo.Template_Demo WHERE TempName = N'" + dt_dataall.Rows[i][1] + "'), N'" + dt_dataall.Rows[i]["Poi_SOP"] + "', N'" + dt_dataall.Rows[i]["Poi_SOP_PL"] + "', @BinarySOP_PL)", imageConversion(files), imageConversion(filesPL));
                                                }
                                            }
                                        }
                                    }
                                    Thread.Sleep(75);
                                }
                                #endregion
                            }

                        }
                    }

                    MessageBox.Show("Complete Update Info Sop!!!");
                }
                btnclearsop.Visible = false;
                dttemplate = workdb.Get_allTempDemo();
                grTemp.DataSource = null;
                grTemp.DataSource = dttemplate;
                grTempV.Columns[0].Visible = false;
                grTempV.Columns["Poi_Rules"].Visible = false;
                grTempV.Columns["PoiSop"].Visible = false;
                grTempV.Columns["Poi_Rules_Truong1"].Visible = false;//Poi_Rules_Truong1
                grTempV.RowCellClick += gridView2_RowCellClick;
            }
        }


        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        Bitmap imageSource;

        private void grTempV_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btneditsop_Click(object sender, EventArgs e)
        {
            txtsoptem.Enabled = true;
            txtsoprule.Enabled = true;
            txt_Ma11.Enabled = true; txt_Ma12.Enabled = true; txt_Ma13.Enabled = true; txt_macot1.Enabled = true; txt_macot2.Enabled = true; txt_macot3.Enabled = true; txt_colum6.Enabled = true;
            ttsop = 2;
            txtsoptem.Focus();
            btnclearsop.Visible = true;
        }

        private void btndelsop_Click(object sender, EventArgs e)
        {
            if (isop != "")
                if (MessageBox.Show("Delete this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    workdb.DeleteTemplate(Convert.ToInt32(isop));
                    MessageBox.Show("Delete Success!!");
                }
            dttemplate = workdb.Get_allTempDemo();
            grTemp.DataSource = dttemplate;
            grTempV.Columns[0].Visible = false;
            grTempV.Columns["Poi_Rules"].Visible = false;
            grTempV.Columns["PoiSop"].Visible = false;

            grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
            trangthai = 3;
            btnclearsop.Visible = false;
        }

        private void btnUpsop_Click(object sender, EventArgs e)
        {
            if (txtsoptem.Text == "" || txtsoprule.Text == "")
            {
                MessageBox.Show("Có trường trống");
                return;
            }
            else
            {
                //int Rule8 = 0;                
                //if(cbb_rule8.Text.Trim() == "YES")
                //{
                //    Rule8 = 1;
                //}
                //else
                //{
                //    Rule8 = 0;
                //}
                //if (ttsop == 1)
                //{
                //    workdb.Insert_Template(txtsoptem.Text.Trim(), txtsoprule.Text.Trim(), txt_Ma11.Text.Trim(), Rule8);
                //    string id = workdb.Get_imgname(txtsoptem.Text.Trim());
                //    Bitmap imagepage = new Bitmap(txtSOP.Text);
                //    workdb.Insert_SOP(Convert.ToInt32(id), imageToByteArray(imagepage));
                //    MessageBox.Show("Insert Success!!");
                //}
                if (ttsop == 2)
                {
                    if (txt_colum6.Text != "")
                    {
                        string[] data_check_form6 = txt_colum6.Text.Split('|');
                        for (int i = 0; i < data_check_form6.Length; i++)
                        {
                            try
                            {
                                if (Convert.ToInt32(data_check_form6[i].ToString().Substring(0, 1).ToString()) < 1)
                                {
                                    MessageBox.Show("Số bắt đầu không đúng quy định ???");
                                    return;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Kí tự bắt đầu không phải là số ???");
                                return;
                            }

                            try
                            {
                                if (data_check_form6[i].Contains("‡") == false || data_check_form6[i].Split('‡').Length != 2)
                                {
                                    MessageBox.Show("Sai quy định trong chú thích " + (i + 1) + "???");
                                    return;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Sai quy định trong chú thích " + (i + 1) + "???");
                                return;
                            }
                        }
                    }
                    daEntry.ExecuteSQL("Update dbo.[Template_Demo] set TempName = N'" + txtsoptem.Text.Trim() + "',Rules = N'" + txtsoprule.Text.Trim() + "',Colum1_1 = N'" + txt_Ma11.Text.Trim() + "',Colum1_2 = N'" + txt_Ma12.Text.Trim() + "',Colum1_3 = N'" + txt_Ma13.Text.Trim() + "',MaCot1 = N'" + txt_macot1.Text.Trim() + "',MaCot2 = N'" + txt_macot2.Text.Trim() + "', MaCot3 = N'" + txt_macot3.Text.Trim() + "',[Form 6] = N'" + txt_colum6.Text + "' where Id = " + isop + "");
                    //workdb.Update_Template(txtsoptem.Text.Trim(), txtsoprule.Text.Trim(), txt_Ma11.Text.Trim(), isop.ToString(), Rule8);

                    if (txtSOP.Text != "")
                    {
                        Bitmap imagepage = new Bitmap(txtSOP.Text);
                        workdb.Insert_SOP(Convert.ToInt32(isop), imageToByteArray(imagepage));
                        daEntry.ExecuteSQL("Update dbo.[Template_Demo] set Poi_Sop = 1 where Id = " + isop + "");
                    }
                    MessageBox.Show("Edit Success!!");
                }
                //dttemplate = workdb.Get_allTemp();
                //grTemp.DataSource = dttemplate;
                //grTempV.Columns[0].Visible = false;
                //grTempV.Columns["Poi_Rules"].Visible = false;
                //grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
                int row = index_row_change;
                txtsoptem.Enabled = false;
                txtsoprule.Enabled = false;
                txt_Ma11.Enabled = false;
                txt_Ma12.Enabled = false; txt_Ma13.Enabled = false; txt_macot1.Enabled = false; txt_macot2.Enabled = false; txt_macot3.Enabled = false; txt_colum6.Enabled = false;
                ttsop = 0;
                dttemplate = workdb.Get_allTempDemo();
                grTemp.DataSource = dttemplate;
                grTempV.Columns[0].Visible = false;
                grTempV.Columns["Poi_Rules"].Visible = false;
                grTempV.Columns["PoiSop"].Visible = false;

                grTempV.Columns["Poi_Rules_Truong1"].Visible = false;
                grTemp.Focus();
                grTempV.FocusedRowHandle = row;
                ColumnView View = (ColumnView)grTemp.FocusedView;
                GridColumn column = View.Columns[1];
                grTempV.FocusedColumn = column;
                grTemp.Focus();
            }
        }

        private void grTempV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvUsers_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grTemp_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grTempV.PostEditor();
                grTempV.UpdateCurrentRow();
                grTempV.FocusedRowHandle = GridControl.NewItemRowHandle;
            }
        }

        private void grTemp_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    grTempV.AddNewRow();
            //    grTempV.FocusedColumn = grTempV.Columns[0];
            //}
            //if (e.KeyCode == Keys.Add)
            //{
            //        GridColumn col = new GridColumn();
            //        col = grTempV.Columns.AddVisible("Cột mới", string.Empty);
            //        grTempV.Columns.Add(col);
            //}
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains("P1-"))
            {
                cboLevel.Text = "1";
                cboPair.Text = "3";
                cboRole.Text = "ENTRY";
            }
            else if (txtUsername.Text.Contains("P2-"))
            {
                cboLevel.Text = "1";
                cboPair.Text = "4";
                cboRole.Text = "ENTRY";
            }
            else if (txtUsername.Text.Contains("E1-"))
            {
                cboLevel.Text = "1";
                cboPair.Text = "1";
                cboRole.Text = "ENTRY";
            }
            else if (txtUsername.Text.Contains("E2-"))
            {
                cboLevel.Text = "1";
                cboPair.Text = "2";
                cboRole.Text = "ENTRY";
            }
            else if (txtUsername.Text.Contains("C2-"))
            {
                cboLevel.Text = "0";
                cboPair.Text = "0";
                cboRole.Text = "CHECK";
            }
            else if (txtUsername.Text.Contains("QC2-"))
            {
                cboLevel.Text = "0";
                cboPair.Text = "0";
                cboRole.Text = "CHECK";
            }
            else if (txtUsername.Text.Contains("LC-"))
            {
                cboLevel.Text = "0";
                cboPair.Text = "0";
                cboRole.Text = "LASTCHECK";
            }
        }

        private void txtSOP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strPreferenceToRemember = @"C:\";
            if (File.Exists(path))
            {
                strPreferenceToRemember = File.ReadAllText(path);
            }
            else
            {
                File.WriteAllText(path, strPreferenceToRemember);
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "png files (*.png)|*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string[] ext = new string[4] { ".jpg", ".tif", ".png", ".tiff" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtmultisop.Text = openFileDialog1.FileName;
                    File.WriteAllText(path, txtmultisop.Text);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnsavemulti_Click(object sender, EventArgs e)
        {
            if (txtmultisop.Text.Trim() != "")
            {
                try
                {
                    Bitmap imagepage = new Bitmap(txtmultisop.Text);
                    for (int i = 0; i < chkcombo.Properties.Items.Count(); i++)
                    {
                        if (chkcombo.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            string idsop = tb_MultiSOP.Rows[i][0].ToString();
                            workdb.Insert_SOP(Convert.ToInt32(idsop), imageToByteArray(imagepage));
                            daEntry.ExecuteSQL("Update dbo.[Template_Demo] set Poi_Sop = 1 where Id = " + idsop + "");
                        }
                    }
                    tb_MultiSOP = new System.Data.DataTable();
                    tb_MultiSOP = workdb.Get_Id_Name_TemplateDemo();
                    chkcombo.Properties.DataSource = tb_MultiSOP;
                    chkcombo.Properties.ValueMember = "Id";
                    chkcombo.Properties.DisplayMember = "Name";
                    MessageBox.Show("Complete");
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Error: " + exx.ToString());
                }
            }
        }

        private void btndeletemulti_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa các Template đã chọn?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < chkcombo.Properties.Items.Count(); i++)
                    {
                        if (chkcombo.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            string idsop = tb_MultiSOP.Rows[i][0].ToString();
                            daEntry.ExecuteSQL("Delete dbo.[Template_Demo] where Id = " + idsop + "");
                        }
                    }
                    tb_MultiSOP = new System.Data.DataTable();
                    tb_MultiSOP = workdb.Get_Id_Name_TemplateDemo();
                    chkcombo.Properties.DataSource = tb_MultiSOP;
                    chkcombo.Properties.ValueMember = "Id";
                    chkcombo.Properties.DisplayMember = "Name";
                    MessageBox.Show("Complete");
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Error: " + exx.ToString());
                }
            }
        }

        private void btnreturnLCT_Click(object sender, EventArgs e)
        {
            string strCa = cboreturnLCT.Text;
            txtimgreturn.Text = "";
            System.Data.DataTable dtid = new System.Data.DataTable();
            if (strCa != "ALL")
            { dtid = daEntry.GetDatatableSQL("Select tb2.Id, tb1.ImageName as 'Name' from db_owner.[AllImage] as tb1 join db_owner.[ImageContent] as tb2 on tb1.Id = tb2.AllImageId where tb1.TurnUp = " + strCa + " and tb2.Result is not null and tb2.UserLC_Done = 0"); }
            else
            { dtid = daEntry.GetDatatableSQL("Select tb2.Id, tb1.ImageName as 'Name' from db_owner.[AllImage] as tb1 join db_owner.[ImageContent] as tb2 on tb1.Id = tb2.AllImageId where tb2.Result is not null and tb2.UserLC_Done = 0"); }
            string strId = "";
            for (int i = 0; i < dtid.Rows.Count; i++)
            {
                strId += dtid.Rows[i]["Id"].ToString() + ",";
                txtimgreturn.Text = txtimgreturn.Text + dtid.Rows[i]["Name"].ToString() + Environment.NewLine + Environment.NewLine;
            }
            if (strId.Length > 0)
            { strId = strId.Substring(0, strId.Length - 1); }
            bool check_complete = daEntry.check_sql("Update db_owner.[ImageContent] set UserLC_Done = 9999999 where Id in (" + strId + ")");
            MessageBox.Show("Complete");
        }
    }
    #region add button to statusTrip
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                       ToolStripItemDesignerAvailability.ContextMenuStrip |
                                       ToolStripItemDesignerAvailability.StatusStrip)]
    public class ButtonStripItem : ToolStripControlHost
    {
        private System.Windows.Forms.Button button;

        public ButtonStripItem()
            : base(new System.Windows.Forms.Button())
        {
            this.button = this.Control as System.Windows.Forms.Button;
        }

        // Add properties, events etc. you want to expose...
    }
    #endregion
}

