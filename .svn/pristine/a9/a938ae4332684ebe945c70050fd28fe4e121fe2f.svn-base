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
using PresentationControls;
using System.Reflection;
namespace VCB_TEGAKI
{
    public partial class frmAdmin : Form
    {
        DataSet ds = new DataSet();

        public Int32 formid, formiduser, formidngay, formidcherker;
        // string cthuc = "";
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtc = new System.Data.DataTable();
        System.Data.DataTable dtlc = new System.Data.DataTable();
        //private static string imgLocation = ConfigurationManager.AppSettings["LocalImage"].ToString();
        //Đường dẫn đối tượng excel
        string ph = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\tyleloitrenkytu.xls";
        frmLogIn frmlg = new frmLogIn();
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
        System.Data.DataTable dtAllUser;
        System.Data.DataTable dtfindUser = new System.Data.DataTable();
        System.Data.DataTable dtTemplate; System.Data.DataTable dtbatch;
        System.Data.DataTable dtresult = new System.Data.DataTable();
        System.Data.DataTable dtstatus = new System.Data.DataTable();
        System.Data.DataTable tableall = new System.Data.DataTable();
        System.Data.DataTable dtPFM = new System.Data.DataTable();
        System.Data.DataTable dtPFMCheck = new System.Data.DataTable();
        System.Data.DataTable dtPFMLastCheck = new System.Data.DataTable();
        System.Data.DataTable dtalluser = new System.Data.DataTable();
        System.Data.DataTable dtdetails = new System.Data.DataTable();
        DataRow[] foundRows;
        string datestring, datestringFB = ""; int idUser = 0;
        string expression;
        string sodong;
        string sophieu;
        int batchId;
        int trangthai = 0;
        string batchname;
        string filename = "";
        bool noncharacter = false;
        double phieu = 0.0;
        // 3 variable temp
        string typeUser = "";
        string typeSearch = "";
        string typeGroup = "";
        public int iddetails;
        //List Batch;
        string lstBatch;
        string lstBatchPFM;
        List<string> listBatchArray = new List<string>();
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
            dtPFM.Columns.Add("FullName", typeof(string));
            dtPFM.Columns.Add("Level", typeof(string));
            dtPFM.Columns.Add("Trung tâm", typeof(string));
            dtPFM.Columns.Add("Tổng ký tự", typeof(double));
            dtPFM.Columns.Add("Lỗi sai", typeof(double));
            dtPFM.Columns.Add("Tỉ lệ sai", typeof(double));
            dtPFM.Columns.Add("Thời gian", typeof(double));
            dtPFM.Columns.Add("Tốc độ", typeof(double));
            dtPFM.Columns.Add("Đảm nhận", typeof(double));
            dtPFM.Columns.Add("Tổng trường", typeof(double));
            dtPFM.Columns.Add("Số trường NG", typeof(double));
            //
            dtPFMCheck.Columns.Add("FullName", typeof(string));
            dtPFMCheck.Columns.Add("Level", typeof(string));
            dtPFMCheck.Columns.Add("Trung tâm", typeof(string));
            dtPFMCheck.Columns.Add("Tổng trường", typeof(double));
            dtPFMCheck.Columns.Add("Thời gian", typeof(double));
            dtPFMCheck.Columns.Add("Đảm nhận", typeof(double));
            //
            dtPFMLastCheck.Columns.Add("FullName", typeof(string));
            dtPFMLastCheck.Columns.Add("Trung tâm", typeof(string));
            dtPFMLastCheck.Columns.Add("Tên Batch", typeof(string));
            dtPFMLastCheck.Columns.Add("Tổng phiếu", typeof(double));
            dtPFMLastCheck.Columns.Add("Thời gian", typeof(double));
            dtPFMLastCheck.Columns.Add("Đảm nhận", typeof(double));
        }

        //Get all User
        private void DtAllUser()
        {
            dtalluser = workdb.All_User();
            grduser.DataSource = dtalluser;
            grvuser.OptionsBehavior.Editable = false;
            grvuser.RowCellClick += gridView1_RowCellClick;
            grvuser.Columns[0].Visible = false;
            btnedit.Enabled = false;
            btndel.Enabled = false;
        }
        void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            lblId.Text = grvuser.GetRowCellValue(e.RowHandle, "Id").ToString();           
            txtUsername.Text = grvuser.GetRowCellValue(e.RowHandle, "Name").ToString();
            txtFullname.Text = grvuser.GetRowCellValue(e.RowHandle, "Fullname").ToString();
            cboRole.Text = grvuser.GetRowCellValue(e.RowHandle, "Role").ToString();
            cboGroup.Text = grvuser.GetRowCellValue(e.RowHandle, "Group").ToString();
            dtdetails = workdb.All_details(Convert.ToInt32(lblId.Text));
            txtMSNV.Text = Convert.ToString(dtdetails.Rows[0][0]);
            txtEmail.Text = Convert.ToString(dtdetails.Rows[0][1]);
            cboLevel.Text = Convert.ToString(dtdetails.Rows[0][2]);
            cboPair.Text = Convert.ToString(dtdetails.Rows[0][3]);
            txtUsername.Enabled = false;
            btnedit.Enabled = true;
            btndel.Enabled = true;
            trangthai = 0;
        }
        private void VCB_Admin_Load(object sender, EventArgs e)
        {
            DtAllUser();
            rdbEntry.Checked = true;
            datestringFB = DateTime.Now.Year.ToString().Substring(2, 2) + String.Format("{0:00}", int.Parse(DateTime.Now.Month.ToString())) + String.Format("{0:00}", int.Parse(DateTime.Now.Day.ToString()));
            cboTrungTam.DataSource = workdb.dttrungtam();
            dtbatch = workdb.daBatch();
            cboBatchPFM.Properties.DisplayMember = "Name";
            cboBatchPFM.Properties.ValueMember = "ID";
            cboBatchPFM.Properties.DataSource = dtbatch;
            cboBatchStatus.Properties.DataSource = dtbatch;
            cboBatchStatus.Properties.DisplayMember = "Name";
            cboBatchStatus.Properties.ValueMember = "ID";            
            cboBatchFB.Properties.DisplayMember = "Name";
            cboBatchFB.Properties.ValueMember = "ID";
            cboBatchFB.Properties.DataSource = dtbatch;
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
            if (trangthai != 0)
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
                if (cboGroup.Text == "")
                { lblError.Text = "Group is empty"; return; }
                if (trangthai == 1)
                {
                    int ktuser = workdb.ktuser(lblId.Text);
                    if (ktuser == 0)
                    {
                        workdb.NewUser(txtUsername.Text.Trim(), txtFullname.Text.Trim(), cboLevel.Text, cboPair.Text, cboGroup.Text, txtEmail.Text.Trim(), cboRole.Text, txtMSNV.Text.Trim());
                        dtalluser = workdb.All_User();
                        grduser.DataSource = dtalluser;
                        PExitNewUser();
                        trangthai = 0;
                    }
                    else
                    { lblError.Text = "User allready Exits"; }
                }
                if (trangthai == 2)
                {
                    workdb.UpdateUser(Convert.ToInt32(lblId.Text), txtFullname.Text.Trim(), cboLevel.Text, cboPair.Text, cboGroup.Text, txtEmail.Text.Trim(), cboRole.Text, txtMSNV.Text.Trim());
                    dtalluser = workdb.All_User();
                    grduser.DataSource = dtalluser;
                    PExitNewUser();
                    trangthai = 0;
                }
                if (trangthai == 3)
                {
                    workdb.DeleteUser(Convert.ToInt32(lblId.Text));
                    dtalluser = workdb.All_User();
                    grduser.DataSource = dtalluser;
                    PExitNewUser();
                    trangthai = 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (lblTitle.Text == "Find user")
            //{ DtAllUser(); txtUsername.Text = ""; dtfindUser = new System.Data.DataTable(); }
            ////set properties          
            trangthai = 0;
            lblTitle.Text = "";
            lblError.Text = "";
            PExitNewUser();
        }

        //set properties when exit new user
        private void PExitNewUser()
        {
            txtUsername.Text = ""; txtMSNV.Text = ""; txtFullname.Text = ""; txtEmail.Text = ""; cboRole.Text = ""; cboGroup.Text = ""; cboLevel.Text = ""; cboPair.Text = "";
            txtEmail.Enabled = false;
            txtFullname.Enabled = false; txtMSNV.Enabled = false; txtUsername.Enabled = false;
            cboLevel.Enabled = false; cboPair.Enabled = false; cboRole.Enabled = false; cboGroup.Enabled = false;
        }
        //set properties when click New user or Edit user
        private void PNewUserAndEditUser()
        {
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
                txtUsername.Text = ""; cboPair.Text = "";cboRole.Text = ""; cboGroup.Text = "";
                expression = "Lvl = '" + cboLevel.Text + "'";
            }
        }

        private void cboPair_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {
                txtUsername.Text = ""; cboLevel.Text = "";cboRole.Text = ""; cboGroup.Text = "";
                expression = "Pair = '" + cboPair.Text + "'";
            }
        }

        private void cboGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Find user")
            {
                txtUsername.Text = ""; cboPair.Text = "";cboRole.Text = ""; cboLevel.Text = "";
                expression = "Group = '" + cboGroup.Text + "'";
            }
        }

        private void tabControlAdmin_Selecting(object sender, TabControlCancelEventArgs e)
        {
            trangthai = 0;
            if (tabPerformance.Name == Status.SelectedTab.Name || tabFeedback.Name == Status.SelectedTab.Name || tabstatus.Name == Status.SelectedTab.Name)
            {
                lblInformation.Text = "";
                dtTemplate = new System.Data.DataTable();
                dtbatch = new System.Data.DataTable();
                dtstatus = new System.Data.DataTable();
                dtstatus = workdb.Get_AllBatchtoday();
                dtbatch = workdb.daBatch();
                cboBatchPFM.Properties.DisplayMember = "Name";
                cboBatchPFM.Properties.ValueMember = "ID";
                cboBatchPFM.Properties.DataSource = dtbatch;
                cboBatchStatus.Properties.DataSource = dtstatus;
                cboBatchStatus.Properties.DisplayMember = "Name";
                cboBatchStatus.Properties.ValueMember = "ID";               
                cboBatchFB.Properties.DisplayMember = "Name";
                cboBatchFB.Properties.ValueMember = "ID";
                cboBatchFB.Properties.DataSource = dtbatch;

            }
        }

        private void btnExportCheck_Click(object sender, EventArgs e)
        {
            if (cboBatchFB.Text == "")
            {
                MessageBox.Show("Batch is Empty");
                return;
            }
            else
            {
                SaveFileDialog svFD = new SaveFileDialog();
                svFD.RestoreDirectory = true;
                svFD.Title = "Save to file excel";
                svFD.Filter = "Excel 2007 file|*.xlsx";
                svFD.FileName = "C";
                if (svFD.ShowDialog() == DialogResult.OK)
                {

                    filename = svFD.FileName;
                    if (!bwExportExcel.IsBusy)
                    {
                        listBatchArray = new List<string>();
                        listBatchNameArray = new List<string>();
                        for (int i = 0; i < cboBatchPFM.Properties.Items.Count; i++)
                        {
                            if (cboBatchPFM.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                listBatchArray.Add(dtbatch.Rows[i][0].ToString());
                                listBatchNameArray.Add(dtbatch.Rows[i]["Name"].ToString());
                            }
                        }
                        prgExcel.Value = 0;
                        prgExcel.Visible = true;
                        bwExportExcel.RunWorkerAsync();
                    }

                }
            }
        }

        private void bwExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress1 = 0;
            int row = listBatchNameArray.Count;
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int a = 0; a < listBatchArray.Count; a++)
            {
                try
                {
                    dtresult = new System.Data.DataTable();
                    batchId = Convert.ToInt32(listBatchArray[a]);
                    batchname = listBatchNameArray[a];
                    dtresult = workdb.dtResult(batchId);

                    string imagString;

                    // Khởi động chtr Excell
                    exApp = new Microsoft.Office.Interop.Excel.Application();
                    // Thêm file temp xls
                    oBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    // Lấy sheet 1.
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[1];

                    oSheet.Cells[1, 1].Value2 = "Batch : " + batchId;
                    oSheet.Cells[1, 1].Font.Size = 24;
                    oSheet.Range["A1:I1"].Merge();
                    oSheet.Cells[3, 1].Value2 = "STT";
                    oSheet.Columns["A", Type.Missing].ColumnWidth = 5;
                    oSheet.Cells[3, 2].Value2 = "Tên ảnh";
                    oSheet.Columns["B", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 3].Value2 = "Ảnh";
                    oSheet.Columns["C", Type.Missing].ColumnWidth = 42;
                    oSheet.Cells[3, 4].Value2 = "Entry1";
                    oSheet.Columns["D", Type.Missing].ColumnWidth = 10;
                    oSheet.Columns["E", Type.Missing].Font.Color = Color.Red;
                    oSheet.Cells[3, 5].Value2 = "Nội dung nhập 1";
                    oSheet.Cells[3, 5].Font.Color = Color.Black;
                    oSheet.Columns["E", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 6].Value2 = "Lỗi sai 1";
                    oSheet.Columns["F", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 7].Value2 = "Entry2";
                    oSheet.Columns["G", Type.Missing].ColumnWidth = 10;
                    oSheet.Columns["H", Type.Missing].Font.Color = Color.Red;
                    oSheet.Cells[3, 8].Value2 = "Nội dung nhập 2";
                    oSheet.Cells[3, 8].Font.Color = Color.Black;
                    oSheet.Columns["H", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 9].Value2 = "Lỗi sai 2";
                    oSheet.Columns["I", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 10].Value2 = "Checker";
                    oSheet.Columns["J", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 11].Value2 = "Nội dung chọn";
                    oSheet.Columns["K", Type.Missing].ColumnWidth = 20;
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
                    for (int i = 0; i < dtresult.Rows.Count; i++)
                    {
                        content1 = ""; content2 = ""; check = ""; rowExcel = i;
                        oSheet.Cells[i + 4, 1].Value2 = i + 1;
                        for (int j = 0; j < dtresult.Columns.Count; j++)
                        {
                            oSheet.Cells[i + 4, j + 2].Value2 = dtresult.Rows[i][j].ToString().Replace("|", Environment.NewLine);
                            if (j == 3)
                            {
                                content1 = oSheet.Cells[i + 4, j + 2].Value2;
                            }
                            if (j == 6)
                            {
                                content2 = oSheet.Cells[i + 4, j + 2].Value2;
                            }
                            if (j == 9)
                            {
                                check = oSheet.Cells[i + 4, j + 2].Value2;
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
                                imagString = pathImage + @"\" + batchname + @"\" + dtresult.Rows[i][j - 1].ToString();
                                Bitmap bm = new Bitmap(imagString);
                                Range oRange = (Range)oSheet.Cells[i + 4, j + 2];
                                float Left = (float)((double)oRange.Left);
                                float Top = (float)((double)oRange.Top);
                                float ImageSize1 = float.Parse((bm.Width / 3).ToString());
                                float ImageSize2 = float.Parse((bm.Height / 3).ToString());
                                oSheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize1 / 2, ImageSize2 / 2);
                                try
                                {
                                    oRange.RowHeight = ImageSize2 / 2;
                                }
                                catch
                                {
                                    oRange.RowHeight = 408;
                                }
                            }
                        }
                    }
                    exApp.Visible = false;
                    // Save file
                    oBook.Application.DisplayAlerts = false;
                    filename = Path.GetDirectoryName(filename) + @"\" + batchname;
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
                progress1 = progress1 + 1;
                worker.ReportProgress(progress1 * 100 / row);
            }

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
            if (cboBatchFB.Text == "")
            {
                MessageBox.Show("Batch is Empty");
                return;
            }
            else
            {
                SaveFileDialog svFD = new SaveFileDialog();
                svFD.RestoreDirectory = true;
                svFD.Title = "Save to file excel";
                svFD.Filter = "Excel 2007 file|*.xlsx";
                svFD.FileName = batchname + "_QC";
                if (svFD.ShowDialog() == DialogResult.OK)
                {

                    filename = svFD.FileName;
                    if (!bwExportExcelQC.IsBusy)
                    {
                        listBatchArray = new List<string>();
                        listBatchNameArray = new List<string>();
                        for (int i = 0; i < cboBatchPFM.Properties.Items.Count; i++)
                        {
                            if (cboBatchPFM.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                listBatchArray.Add(dtbatch.Rows[i][0].ToString());
                                listBatchNameArray.Add(dtbatch.Rows[i]["Name"].ToString());
                            }
                        }
                        prgExcel.Value = 0;
                        prgExcel.Visible = true;
                        bwExportExcelQC.RunWorkerAsync();
                    }
                }
            }

        }

        private void bwExportExcelQC_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress1 = 0;
            int row = listBatchNameArray.Count;
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int a = 0; a < listBatchArray.Count; a++)
            {
                try
                {
                    dtresult = new System.Data.DataTable();
                    batchId = Convert.ToInt32(listBatchArray[a]);
                    batchname = listBatchNameArray[a];
                    dtresult = workdb.dtResultQA(batchId);

                    string imagString;

                    // Khởi động chtr Excell
                    Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                    // Thêm file temp xls
                    Microsoft.Office.Interop.Excel.Workbook oBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    // Lấy sheet 1.
                    Microsoft.Office.Interop.Excel.Worksheet oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[1];

                    oSheet.Cells[1, 1].Value2 = "Batch : " + batchId;
                    oSheet.Cells[1, 1].Font.Size = 24;
                    oSheet.Range["A1:I1"].Merge();
                    oSheet.Cells[3, 1].Value2 = "STT";
                    oSheet.Columns["A", Type.Missing].ColumnWidth = 5;
                    oSheet.Cells[3, 2].Value2 = "Tên ảnh";
                    oSheet.Columns["B", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 3].Value2 = "Ảnh";
                    oSheet.Columns["C", Type.Missing].ColumnWidth = 42;
                    oSheet.Cells[3, 4].Value2 = "Entry1";
                    oSheet.Columns["D", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 5].Value2 = "Nội dung nhập 1";
                    oSheet.Columns["E", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 6].Value2 = "Entry2";
                    oSheet.Columns["F", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 7].Value2 = "Nội dung nhập 2";
                    oSheet.Columns["G", Type.Missing].ColumnWidth = 20;
                    oSheet.Cells[3, 8].Value2 = "Checker";
                    oSheet.Columns["H", Type.Missing].ColumnWidth = 10;
                    oSheet.Cells[3, 9].Value2 = "Nội dung chọn";
                    oSheet.Columns["I", Type.Missing].ColumnWidth = 20;
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

                    for (int i = 0; i < dtresult.Rows.Count; i++)
                    {

                        oSheet.Cells[i + 4, 1].Value2 = i + 1;
                        for (int j = 0; j < dtresult.Columns.Count; j++)
                        {
                            oSheet.Cells[i + 4, j + 2].Value2 = dtresult.Rows[i][j].ToString().Replace("|", Environment.NewLine);

                            if (j == 1)
                            {
                                imagString = pathImage + @"\" + batchname + @"\" + dtresult.Rows[i][j - 1].ToString();
                                Bitmap bm = new Bitmap(imagString);
                                Range oRange = (Range)oSheet.Cells[i + 4, j + 2];
                                float Left = (float)((double)oRange.Left);
                                float Top = (float)((double)oRange.Top);
                                float ImageSize1 = float.Parse((bm.Width / 3).ToString());
                                float ImageSize2 = float.Parse((bm.Height / 3).ToString());
                                oSheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize1 / 2, ImageSize2 / 2);
                                try
                                {
                                    oRange.RowHeight = ImageSize2 / 2;
                                }
                                catch { oRange.RowHeight = 408; }

                            }
                        }
                    }
                    exApp.Visible = false;
                    // Save file
                    oBook.Application.DisplayAlerts = false;
                    filename = Path.GetDirectoryName(filename) + @"\" + batchname;
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
                progress1 = progress1 + 1;
                worker.ReportProgress(progress1 * 100 / row);
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
                    saveDialog.FileName = "";
                    saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        grvPerformance.ClearColumnsFilter();
                        grvPerformance.ClearSorting();
                        grvPerformance.ClearGrouping();
                        grvPerformance.ClearSelection();
                        grvPerformance.FindFilterText = "";
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        //NImageExporter imageExporter = chartControl.ImageExporter;
                        grvPerformance.ExportToXlsx(exportFilePath);
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dtPFM.Clear();
            dtPFMCheck.Clear();
            dtPFMLastCheck.Clear();
            //try
            //{
            //    phieu = double.Parse(txtPhieu.Text);
            //    dong = double.Parse(txtDong.Text);
            //}
            //catch { phieu = 0.0; }
            if (cboBatchPFM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Batch");
                return;
            }
            lstBatchPFM = "";
            if (!bgwXem.IsBusy)
            {
                dtPFM.Rows.Clear();
                prgbExcel.Value = 0;
                prgbExcel.Visible = true;
                dt = new System.Data.DataTable();
                grcPerformance.DataSource = null;
                grvPerformance.Columns.Clear();

               
                for (int i = 0; i < cboBatchPFM.Properties.Items.Count; i++)
                {
                    if (cboBatchPFM.Properties.Items[i].CheckState == CheckState.Checked)
                        lstBatchPFM = lstBatchPFM + dtbatch.Rows[i][0] + " ";
                }
                lstBatchPFM = lstBatchPFM.Trim().Replace(' ', ',');
                trungtam = cboTrungTam.Text;
                if (lstBatchPFM != "")
                {
                    bgwXem.RunWorkerAsync();
                }              
               
            }
        }
        #region Loại User
        private void rdbEntry_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntry.Checked == true)
            { typeUser = "ENTRY"; lblPhieu.Visible = true; label1.Visible = true; }
        }

        private void rdbCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCheck.Checked == true)
            { typeUser = "CHECK"; lblPhieu.Visible = false; label1.Visible = false; }
        }

        private void rdbLastCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLastCheck.Checked == true)
            { typeUser = "LASTCHECK";  lblPhieu.Visible = false; label1.Visible = false; }
        }
        #endregion

        private void bgwXem_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int progress1 = 0;
            #region ENTRY
            if (typeUser == "ENTRY")
            {
                dt.Clear();
                dt = workdb.getPerformaceEntry(lstBatchPFM, trungtam);
                dtSoPhieu_SoDong = new System.Data.DataTable();
                dtSoPhieu_SoDong = workdb.GetSoPhieu_SoDong(lstBatchPFM);
                sophieu = Convert.ToString(dtSoPhieu_SoDong.Rows[0][0]);
                sodong = Convert.ToString(dtSoPhieu_SoDong.Rows[0][1]);
                var results = from status in dt.AsEnumerable()
                              group status by (status.Field<string>("MSNV")) into status
                              select new
                              {
                                  Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                  Level = status.Select(x => x.Field<int>("Level")).FirstOrDefault(),
                                  Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                  Tongkytu = status.Select(x => x.Field<int>("Tổng ký tự")).Sum() / 1.0,
                                  Loisai = status.Select(x => x.Field<int>("Lỗi sai")).Sum(),
                                  Thoigian = ((status.Select(x => x.Field<int>("Thời gian")).Sum()) / 1000.0)/60,
                                 // Maxtilesai = Math.Round((status.Select(x => x.Field<int>("Lỗi sai")).Sum() / status.Select(x => x.Field<int>("Tổng ký tự")).Sum() / 1.0),2),
                                  //Tocdo = ((status.Select(x => x.Field<int>("Tổng ký tự")).Sum())) / status.Select(x => x.Field<int>("Thời gian")).Sum() / 1000.0,
                                  Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count(),
                                  NotGood = status.Select(x => x.Field<int>("NG")).Where(x => x != 0).Count(),
                              };
                double tongkt = results.Sum(x => x.Tongkytu);
                double tongls = results.Sum(x => x.Loisai);
                double tongtg = Math.Round(results.Sum(x => x.Thoigian),2);
                //double maxtkt = results.Max(x => x.Tongkytu); double mintkt = results.Min(x => x.Tongkytu); double avetkt = (maxtkt + mintkt) / 2;
                //double maxls = results.Max(x => x.Loisai); double minls = results.Min(x => x.Loisai); double avels = (maxls + minls) / 2;
                //double maxthoigian = Math.Round(results.Min(x => x.Thoigian),2); double minthoigian = Math.Round(results.Max(x => x.Thoigian),2);
                //double avethoigian = Math.Round((maxthoigian + minthoigian) / 2,2);
                //double maxtongtruong = results.Max(x => x.Tongtruong); double mintongtruong = results.Min(x => x.Tongtruong); double avetongtruong = (maxtongtruong + mintongtruong) / 2;
                //double maxNG = results.Max(x => x.NotGood); double minNG = results.Min(x => x.NotGood); double aveNG = (maxNG + minNG) / 2;
                double tongtruong = results.Sum(x => x.Tongtruong);
                prgbExcel.Invoke((System.Action)(() =>
                {
                    prgbExcel.Maximum = results.Count();
                }));
                foreach (var element in results)
                {
                    var rowindex = dtPFM.NewRow();
                    rowindex["FullName"] = element.Fullname;
                    rowindex["Level"] = element.Level;
                    rowindex["Trung tâm"] = element.Trungtam;
                    rowindex["Tổng ký tự"] = element.Tongkytu;
                    rowindex["Lỗi sai"] = element.Loisai;
                    rowindex["Tỉ lệ sai"] = Math.Round((Convert.ToDouble(element.Loisai) / Convert.ToDouble(element.Tongkytu)) * 100.0, 2);
                    rowindex["Thời gian"] = Math.Round(element.Thoigian, 2);
                    rowindex["Tốc độ"] = Math.Round(element.Tongkytu / element.Thoigian, 2);
                    rowindex["Đảm nhận"] = Math.Round((element.Tongkytu / tongkt) * 100, 2);
                    rowindex["Tổng trường"] = element.Tongtruong;
                    rowindex["Số trường NG"] = element.NotGood;
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
                    newRow1[5] = dtPFM.Compute("Max ([Tỉ lệ sai])", "");
                    newRow1[6] = dtPFM.Compute("Max ([Thời gian])", "");
                    newRow1[7] = dtPFM.Compute("Max ([Tốc độ])", "");
                    newRow1[8] = dtPFM.Compute("Max ([Đảm nhận])", "");
                    newRow1[9] = dtPFM.Compute("Max ([Tổng trường])", "");
                    newRow1[10] = dtPFM.Compute("Max ([Số trường NG])", "");
                    newRow2[2] = "Thấp nhất";
                    newRow2[3] = dtPFM.Compute("Min ([Tổng ký tự])", "");
                    newRow2[4] = dtPFM.Compute("Min ([Lỗi sai])", "");
                    newRow2[5] = dtPFM.Compute("Min ([Tỉ lệ sai])", "");
                    newRow2[6] = dtPFM.Compute("Min ([Thời gian])", "");
                    newRow2[7] = dtPFM.Compute("Min ([Tốc độ])", "");
                    newRow2[8] = dtPFM.Compute("Min ([Đảm nhận])", "");
                    newRow2[9] = dtPFM.Compute("Min ([Tổng trường])", "");
                    newRow2[10] = dtPFM.Compute("Min ([Số trường NG])", "");
                    try
                    {
                        newRow3[2] = "Trung bình";
                        newRow3[3] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tổng ký tự])", "").ToString()), 0);
                        newRow3[4] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Lỗi sai])", "").ToString()), 0);
                        newRow3[5] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tỉ lệ sai])", "").ToString()), 2);
                        newRow3[6] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Thời gian])", "").ToString()), 0);
                        newRow3[7] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tốc độ])", "").ToString()), 0);
                        newRow3[8] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Đảm nhận])", "").ToString()), 0);
                        newRow3[9] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Tổng trường])", "").ToString()), 0);
                        newRow3[10] = Math.Round(double.Parse(dtPFM.Compute("Avg ([Số trường NG])", "").ToString()), 0);
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
                        newRow7[0] = "Phiếu";
                        newRow7[1] = "Dòng";
                        newRow7[2] = "ALL";
                        newRow7[3] = tongkt;
                        newRow7[4] = tongls;
                        newRow7[5] = tongkt - tongls;
                        newRow7[6] = tongtg;
                        newRow7[7] = "100";
                        newRow7[8] = Math.Round((Convert.ToDouble(newRow7[5]) * 100.0 / tongkt), 2);
                        newRow7[9] = tongtruong;
                        newRow7[10] = dtPFM.Compute("Sum ([Số trường NG])", "level>0");
                        dtPFM.Rows.Add(newRow7);
                        string tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DN'").ToString());
                            double tongtruongdn = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString());

                            newRow8[2] = "DN";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[0] = Math.Round(Convert.ToInt32(sophieu) * double.Parse(tkuGroup) / tongkt);
                            newRow8[1] = Math.Round(Convert.ToInt32(sodong) * double.Parse(newRow8[0].ToString()) / Convert.ToInt32(sophieu));
                            newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongdn;
                            newRow8[10] = dtPFM.Compute("SUM ([Số trường NG])", "[Trung tâm] = 'DN'");
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'HUE'").ToString());
                            double tongtruonghue = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString());
                            newRow8[2] = "HUE";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = Math.Round(double.Parse(tkuGroup) - tlsGroup,2);
                            newRow8[6] = timeGroup;
                                newRow8[0] = Math.Round(Convert.ToInt32(sophieu) * double.Parse(tkuGroup) / tongkt);
                                newRow8[1] = Math.Round(Convert.ToInt32(sodong) * double.Parse(newRow8[0].ToString()) / Convert.ToInt32(sophieu));
                                newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                                newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                                newRow8[9] = tongtruonghue;
                            newRow8[10] = dtPFM.Compute("SUM ([Số trường NG])", "[Trung tâm] = 'HUE'");
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'PY'").ToString());
                            double tongtruongpy = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString());
                            newRow8[2] = "PY";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[0] = Math.Round(Convert.ToInt32(sophieu) * double.Parse(tkuGroup) / tongkt);
                            newRow8[1] = Math.Round(Convert.ToInt32(sodong) * double.Parse(newRow8[0].ToString()) / Convert.ToInt32(sophieu));
                            newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongpy;
                            newRow8[10] = dtPFM.Compute("SUM ([Số trường NG])", "[Trung tâm] = 'PY'");
                            dtPFM.Rows.Add(newRow8);
                        }
                        tkuGroup = dtPFM.Compute("Sum ([Tổng ký tự])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRow8 = dtPFM.NewRow();
                            string timeGroup = dtPFM.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString();
                            double tlsGroup = double.Parse(dtPFM.Compute("Sum ([Lỗi sai])", "[Trung tâm] = 'DL'").ToString());
                            double tongtruongdl = double.Parse(dtPFM.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString());
                            newRow8[2] = "DL";
                            newRow8[3] = tkuGroup;
                            newRow8[4] = tlsGroup;
                            newRow8[5] = double.Parse(tkuGroup) - tlsGroup;
                            newRow8[6] = timeGroup;
                            newRow8[0] = Math.Round(Convert.ToInt32(sophieu) * double.Parse(tkuGroup) / tongkt);
                            newRow8[1] = Math.Round(Convert.ToInt32(sodong) * double.Parse(newRow8[0].ToString()) / Convert.ToInt32(sophieu));
                            newRow8[7] = Math.Round((Convert.ToDouble(newRow8[0]) * 100.0 / Convert.ToInt32(sophieu)), 2);
                            newRow8[8] = Math.Round((Convert.ToDouble(newRow8[5]) * 100.0 / (Convert.ToDouble(newRow8[3]))), 2);
                            newRow8[9] = tongtruongdl;
                            newRow8[10] = dtPFM.Compute("SUM ([Số trường NG])", "[Trung tâm] = 'DL'");
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
                        newRow7[10] = dtPFM.Compute("SUM ([Số trường NG])", "level>0");
                        dtPFM.Rows.Add(newRow7);
                    }               
                worker.ReportProgress(dtPFM.Rows.Count);
            }
            #endregion
            #region CHECK
            if (typeUser == "CHECK")
            {
                dtc.Clear();
                dtc = workdb.All_Check(lstBatchPFM, trungtam);
                var results = from status in dtc.AsEnumerable()
                              group status by (status.Field<string>("MSNV")) into status
                              select new
                              {
                                  Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                  Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                  Level = status.Select(x => x.Field<int>("Lvl")).FirstOrDefault(),
                                  Tongtruong = status.Select(x => x.Field<string>("MSNV")).Count() / 1.0,
                                  Thoigian = (status.Select(x => x.Field<int>("Thời gian")).Sum()),
                              };
                double tt = results.Sum(x => x.Tongtruong);
                double tp = results.Sum(x => x.Thoigian);
                prgbExcel.Invoke((System.Action)(() =>
                {
                    prgbExcel.Maximum = results.Count();
                }));
                foreach (var element in results)
                {
                    var rowcheck1 = dtPFMCheck.NewRow();
                    rowcheck1["FullName"] = element.Fullname;
                    rowcheck1["Level"] = element.Level;
                    rowcheck1["Trung tâm"] = element.Trungtam;
                    rowcheck1["Tổng trường"] = element.Tongtruong;
                    rowcheck1["Thời gian"] = element.Thoigian;
                    rowcheck1["Đảm nhận"] = Math.Round(element.Tongtruong / tt * 100, 2);
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
                newRowCheck1[4] = dtPFMCheck.Compute("Max ([Thời gian])", "");
                newRowCheck1[5] = dtPFMCheck.Compute("Max ([Đảm nhận])", "");
                newRowCheck2[2] = "Thấp nhất";
                newRowCheck2[3] = dtPFMCheck.Compute("Min ([Tổng trường])", "");
                newRowCheck2[4] = dtPFMCheck.Compute("Min ([Thời gian])", "");
                newRowCheck2[5] = dtPFMCheck.Compute("Min ([Đảm nhận])", "");
                try
                {
                    newRowCheck3[2] = "Trung bình";
                    newRowCheck3[3] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Tổng trường])", "").ToString()), 2);
                    newRowCheck3[4] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Thời gian])", "").ToString()), 2);
                    newRowCheck3[5] = Math.Round(double.Parse(dtPFMCheck.Compute("Avg ([Đảm nhận])", "").ToString()), 2);
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
                    newRowCheck7[5] = "100";
                    dtPFMCheck.Rows.Add(newRowCheck7);
                    string tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DN'").ToString();
                    if (tkuGroup != "0" && tkuGroup != "")
                    {
                        string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString();
                        double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString());
                        double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DN'").ToString());

                        newRowCheck8[2] = "DN";
                        newRowCheck8[3] = tkuGroup;
                        newRowCheck8[4] = ttgGroup;
                        newRowCheck8[5] = tdnGroup;
                        dtPFMCheck.Rows.Add(newRowCheck8);
                    }
                    tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'HUE'").ToString();
                    if (tkuGroup != "0" && tkuGroup != "")
                    {
                        newRowCheck8 = dtPFMCheck.NewRow();
                        string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString();
                        double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString());
                        double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'HUE'").ToString());

                        newRowCheck8[2] = "HUE";
                        newRowCheck8[3] = tkuGroup;
                        newRowCheck8[4] = ttgGroup;
                        newRowCheck8[5] = tdnGroup;
                        dtPFMCheck.Rows.Add(newRowCheck8);
                    }
                    tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'PY'").ToString();
                    if (tkuGroup != "0" && tkuGroup != "")
                    {
                        newRowCheck8 = dtPFMCheck.NewRow();
                        string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString();
                        double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString());
                        double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'PY'").ToString());

                        newRowCheck8[2] = "PY";
                        newRowCheck8[3] = tkuGroup;
                        newRowCheck8[4] = ttgGroup;
                        newRowCheck8[5] = tdnGroup;
                        dtPFMCheck.Rows.Add(newRowCheck8);
                    }
                    tkuGroup = dtPFMCheck.Compute("Sum ([Tổng trường])", "[Trung tâm] = 'DL'").ToString();
                    if (tkuGroup != "0" && tkuGroup != "")
                    {
                        newRowCheck8 = dtPFMCheck.NewRow();
                        string timeGroup = dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString();
                        double ttgGroup = double.Parse(dtPFMCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString());
                        double tdnGroup = double.Parse(dtPFMCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DL'").ToString());

                        newRowCheck8[2] = "DL";
                        newRowCheck8[3] = tkuGroup;
                        newRowCheck8[4] = ttgGroup;
                        newRowCheck8[5] = tdnGroup;
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
                    newRowCheck7[5] = "100";
                    dtPFMCheck.Rows.Add(newRowCheck7);
                }
                worker.ReportProgress(dtPFMCheck.Rows.Count);
            }
            #endregion
            #region LASTCHECK
            else
            {
                if (typeUser == "LASTCHECK")
                {
                    dtlc.Clear();
                    dtlc = workdb.All_Lastcheck(lstBatchPFM, trungtam);
                    var results = from status in dtlc.AsEnumerable()
                                  group status by (status.Field<string>("MSNV")) into status
                                  select new
                                  {
                                      Fullname = status.Select(x => x.Field<string>("FullName")).FirstOrDefault(),
                                      Trungtam = status.Select(x => x.Field<string>("Trung Tâm")).FirstOrDefault(),
                                      Tenbatch = status.Select(x => x.Field<string>("Tên Batch")).FirstOrDefault(),
                                      Tongtruong = status.Select(x => x.Field<string>("Tổng phiếu")).Count(),
                                      Thoigian = status.Select(x => x.Field<int>("Thời gian")).FirstOrDefault(),
                                  };
                    double tt = results.Sum(x => x.Tongtruong);
                    double tp = results.Sum(x => x.Thoigian);
                    prgbExcel.Invoke((System.Action)(() =>
                    {
                        prgbExcel.Maximum = results.Count();
                    }));
                    foreach (var element in results)
                    {
                        var rowcheck1 = dtPFMLastCheck.NewRow();
                        rowcheck1["FullName"] = element.Fullname;
                        rowcheck1["Trung tâm"] = element.Trungtam;
                        rowcheck1["Tổng Phiếu"] = element.Tongtruong;
                        rowcheck1["Thời gian"] = element.Thoigian;
                        rowcheck1["Tên Batch"] = element.Tenbatch;
                        rowcheck1["Đảm nhận"] = Math.Round(element.Tongtruong / tt * 100, 2);
                        dtPFMLastCheck.Rows.Add(rowcheck1);
                    }
                    DataRow newRowCheck = dtPFMLastCheck.NewRow();
                    DataRow newRowCheck1 = dtPFMLastCheck.NewRow();
                    DataRow newRowCheck2 = dtPFMLastCheck.NewRow();
                    DataRow newRowCheck3 = dtPFMLastCheck.NewRow();
                    DataRow newRowCheck4 = dtPFMLastCheck.NewRow();
                    //Max,Min,average 
                    newRowCheck1[2] = "Cao nhất";
                    newRowCheck1[3] = dtPFMLastCheck.Compute("Max ([Tổng Phiếu])", "");
                    newRowCheck1[4] = dtPFMLastCheck.Compute("Max ([Thời gian])", "");
                    newRowCheck1[5] = dtPFMLastCheck.Compute("Max ([Đảm nhận])", "");
                    newRowCheck2[2] = "Thấp nhất";
                    newRowCheck2[3] = dtPFMLastCheck.Compute("Min ([Tổng Phiếu])", "");
                    newRowCheck2[4] = dtPFMLastCheck.Compute("Min ([Thời gian])", "");
                    newRowCheck2[5] = dtPFMLastCheck.Compute("Min ([Đảm nhận])", "");
                    try
                    {
                        newRowCheck3[2] = "Trung bình";
                        newRowCheck3[3] = Math.Round(double.Parse(dtPFMLastCheck.Compute("Avg ([Tổng Phiếu])", "").ToString()), 2);
                        newRowCheck3[4] = Math.Round(double.Parse(dtPFMLastCheck.Compute("Avg ([Thời gian])", "").ToString()), 2);
                        newRowCheck3[5] = Math.Round(double.Parse(dtPFMLastCheck.Compute("Avg ([Đảm nhận])", "").ToString()), 2);
                    }
                    catch
                    {
                    }
                    dtPFMLastCheck.Rows.Add(newRowCheck);
                    dtPFMLastCheck.Rows.Add(newRowCheck1);
                    dtPFMLastCheck.Rows.Add(newRowCheck2);
                    dtPFMLastCheck.Rows.Add(newRowCheck3);
                    if (trungtam == "ALL")
                    {
                        DataRow newRowCheck5 = dtPFMLastCheck.NewRow();
                        DataRow newRowCheck7 = dtPFMLastCheck.NewRow();
                        DataRow newRowCheck8 = dtPFMLastCheck.NewRow();
                        dtPFMLastCheck.Rows.Add(newRowCheck5);
                        newRowCheck7[2] = "ALL";
                        newRowCheck7[3] = tt;
                        newRowCheck7[4] = tp;
                        newRowCheck7[5] = "100";
                        dtPFMLastCheck.Rows.Add(newRowCheck7);
                        string tkuGroup = dtPFMLastCheck.Compute("Sum ([Tổng Phiếu])", "[Trung tâm] = 'DN'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            string timeGroup = dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString();
                            double ttgGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DN'").ToString());
                            double tdnGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DN'").ToString());

                            newRowCheck8[2] = "DN";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[5] = tdnGroup;
                            dtPFMLastCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMLastCheck.Compute("Sum ([Tổng Phiếu])", "[Trung tâm] = 'HUE'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMLastCheck.NewRow();
                            string timeGroup = dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString();
                            double ttgGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'HUE'").ToString());
                            double tdnGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'HUE'").ToString());

                            newRowCheck8[2] = "HUE";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[5] = tdnGroup;
                            dtPFMLastCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMLastCheck.Compute("Sum ([Tổng Phiếu])", "[Trung tâm] = 'PY'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMLastCheck.NewRow();
                            string timeGroup = dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString();
                            double ttgGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'PY'").ToString());
                            double tdnGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'PY'").ToString());

                            newRowCheck8[2] = "PY";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[5] = tdnGroup;
                            dtPFMLastCheck.Rows.Add(newRowCheck8);
                        }
                        tkuGroup = dtPFMLastCheck.Compute("Sum ([Tổng Phiếu])", "[Trung tâm] = 'DL'").ToString();
                        if (tkuGroup != "0" && tkuGroup != "")
                        {
                            newRowCheck8 = dtPFMLastCheck.NewRow();
                            string timeGroup = dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString();
                            double ttgGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Thời gian])", "[Trung tâm] = 'DL'").ToString());
                            double tdnGroup = double.Parse(dtPFMLastCheck.Compute("Sum ([Đảm nhận])", "[Trung tâm] = 'DL'").ToString());

                            newRowCheck8[2] = "DL";
                            newRowCheck8[3] = tkuGroup;
                            newRowCheck8[4] = ttgGroup;
                            newRowCheck8[5] = tdnGroup;
                            dtPFMLastCheck.Rows.Add(newRowCheck8);
                        }
                    }
                    else
                    {
                        DataRow newRowCheck5 = dtPFMLastCheck.NewRow();
                        DataRow newRowCheck7 = dtPFMLastCheck.NewRow();
                        dtPFMLastCheck.Rows.Add(newRowCheck5);
                        newRowCheck7[2] = typeGroup;
                        newRowCheck7[3] = tt;
                        newRowCheck7[4] = tp;
                        newRowCheck7[5] = "100";
                        dtPFMLastCheck.Rows.Add(newRowCheck7);
                    }
                    worker.ReportProgress(dtPFMLastCheck.Rows.Count);
                }
            #endregion
            }
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
            if (typeUser == "ENTRY")
            {
                grcPerformance.DataSource = dtPFM;
                txtsophieu.Text = sophieu;
                txtsodong.Text = sodong;
            }
            else if (typeUser == "CHECK")
            {
                grcPerformance.DataSource = dtPFMCheck;
                txtsophieu.Text = "";
                txtsodong.Text = "";
            }
            else if (typeUser == "LASTCHECK")
            {
                grcPerformance.DataSource = dtPFMLastCheck;
                txtsophieu.Text = "";
                txtsodong.Text = "";
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
            lblTitle.Text = "New user"; lblError.Text = ""; trangthai = 1; 
            txtFullname.Text = ""; txtMSNV.Text = ""; txtUsername.Text = ""; txtEmail.Text = ""; txtUsername.Enabled = true;
            cboLevel.SelectedIndex = -1; cboPair.SelectedIndex = -1; cboRole.SelectedIndex = -1; cboGroup.SelectedIndex = -1;
            PNewUserAndEditUser();
            txtUsername.Focus();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            trangthai = 3;
            if (idUser != 0)
                if (MessageBox.Show("Delete this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    workdb.DeleteUser(idUser);
                    DtAllUser();
                    dtfindUser = new System.Data.DataTable();
                }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Edit user";         
            trangthai = 2;
            //Set properties
            PNewUserAndEditUser();
            txtMSNV.Focus();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Find user";
            cboLevel.Enabled = true; cboPair.Enabled = true; cboRole.Enabled = true; cboGroup.Enabled = true;
            txtUsername.Enabled = true; txtFullname.Text = ""; txtMSNV.Text = ""; txtUsername.Text = ""; txtEmail.Text = "";
            cboLevel.SelectedIndex = -1; cboPair.SelectedIndex = -1; cboRole.SelectedIndex = -1; cboGroup.SelectedIndex = -1;
        }

        private void btnviewstt_Click(object sender, EventArgs e)
        {
            grdstatus.DataSource = null;
            lstBatch = "";

            for (int i = 0; i < cboBatchStatus.Properties.Items.Count; i++)
            {
                if (cboBatchStatus.Properties.Items[i].CheckState == CheckState.Checked)
                    lstBatch = lstBatch + dtstatus.Rows[i][0] + " ";

            }
            lstBatch = lstBatch.Trim().Replace(' ', ',');
            if (lstBatch != "")
            {
                tableall = workdb.Get_status(lstBatch);
                var results = from status in tableall.AsEnumerable()
                              group status by status.Field<int>("IDBatch") into status
                              select new
                              {
                                  Id = status.Select(x => x.Field<int>("IDBatch")).FirstOrDefault(),
                                  Name = status.Select(x => x.Field<string>("Name")).FirstOrDefault(),
                                  Count = status.Count(),
                                  Entry1 = status.Count(x => x.Field<int?>("UserId1") != null),
                                  Entry2 = status.Count(x => x.Field<int?>("UserId2") != null),
                                  Check = status.Count(x => x.Field<int>("HitPoint") == 2 && x.Field<string>("Status") == "entry     "),
                                  QC = status.Count(x => x.Field<int>("HitPoint") == 2 && x.Field<string>("Status") == "1         "),
                                  LC = status.Count()
                              };
                System.Data.DataTable dtDataTegaki = new System.Data.DataTable();
                dtDataTegaki = LinqQueryToDataTable(results);
                grdstatus.DataSource = dtDataTegaki;

                grvstatus.Columns["Count"].Summary.Clear();
                grvstatus.Columns["Entry1"].Summary.Clear();
                grvstatus.Columns["Entry2"].Summary.Clear();
                int tongSL = Convert.ToInt32(dtDataTegaki.Compute("SUM ([Count])", ""));
                grvstatus.Columns["Count"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Tổng trường");
                grvstatus.Columns["Count"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Tổng nhập");
                grvstatus.Columns["Count"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Count", "Còn lại");
                grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Count", "{0}");
                grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Entry1", "{0}");
                int tongEntry1Nhap = Convert.ToInt32(dtDataTegaki.Compute("SUM ([Entry1])", ""));
                grvstatus.Columns["Entry1"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry1", (tongSL - tongEntry1Nhap).ToString());
                grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Count", "{0}");
                grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Entry2", "{0}");
                int tongEntry2Nhap = Convert.ToInt32(dtDataTegaki.Compute("SUM ([Entry2])", ""));
                grvstatus.Columns["Entry2"].Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Entry2", (tongSL - tongEntry2Nhap).ToString());
            }
            grvstatus.Columns[0].Visible = false;
        }
        private System.Data.DataTable LinqQueryToDataTable(IEnumerable<dynamic> v)
        {
            var firstRecord = v.FirstOrDefault();
            if (firstRecord == null)
                return null;

            PropertyInfo[] infos = firstRecord.GetType().GetProperties();
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("Batch", typeof(string));
            table.Columns.Add("LastcheckID", typeof(string));
            foreach (var info in infos)
            {
                Type propType = info.PropertyType;
                if (propType.IsGenericType
                    && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    table.Columns.Add(info.Name, Nullable.GetUnderlyingType(propType));
                }
                else
                {
                    table.Columns.Add(info.Name, info.PropertyType);
                }
            }

            DataRow row;
            foreach (var record in v)
            {

                row = table.NewRow();
                var vlbatchid = infos[0].GetValue(record, null);
                if (tabstatus.Name == Status.SelectedTab.Name)
                {
                    row[0] = dtstatus.Select("Id = " + vlbatchid)[0][1];
                    row[1] = tableall.Select("IDBatch = " + vlbatchid)[0][1];
                }
                for (int i = 2; i < table.Columns.Count; i++)
                {
                    row[i] = infos[i - 2].GetValue(record, null) != null ? infos[i - 2].GetValue(record, null) : DBNull.Value;
                }
                table.Rows.Add(row);
            }

            table.AcceptChanges();
            return table;
        }
        private void grvstatus_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                frmdetails frmdta = new frmdetails();
                frmdta.iddt = Convert.ToInt32(grvstatus.GetRowCellValue(e.RowHandle, "Id"));
                frmdta.ShowDialog();
            }
        }

        private void grduser_MouseHover(object sender, EventArgs e)
        {
            grvuser.Focus();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtalluser = workdb.Search_All(txtsearch.Text);
            grduser.DataSource = dtalluser;
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

