using DevExpress.Export;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCB_TEGAKI   
{
    public partial class frmdetails : Form
    {
        public frmdetails()
        {
            InitializeComponent();
        }
        public int iddt;
        WorkDB_Admin workdb = new WorkDB_Admin();
        DAEntry_Entry dAEntry = new DAEntry_Entry();
        System.Data.DataTable dtAlldetails;

        string User_C_QC = "";
        private void frmdetails_Load(object sender, EventArgs e)
        {
            dtAlldetails = workdb.Get_alldetails(iddt);
            txtctcp.Text = dtAlldetails.Rows[0]["ResultP"].ToString();
            txte1.Text = dtAlldetails.Rows[0]["Content1"].ToString();
            txte2.Text = dtAlldetails.Rows[0]["Content2"].ToString();
            txtcheck.Text = dtAlldetails.Rows[0]["Checkresult"].ToString();
            txtuscp.Text = dtAlldetails.Rows[0]["CheckP"].ToString() + " - " + dtAlldetails.Rows[0]["ttcp"].ToString();
            txtuse1.Text = dtAlldetails.Rows[0]["Entry1"].ToString() + " - " + dtAlldetails.Rows[0]["tte1"].ToString();
            txtuse2.Text = dtAlldetails.Rows[0]["Entry2"].ToString() + " - " + dtAlldetails.Rows[0]["tte2"].ToString();
            txtuscheck.Text = dtAlldetails.Rows[0]["Checker"].ToString() + " - " + dtAlldetails.Rows[0]["ttch"].ToString();
            User_C_QC = dtAlldetails.Rows[0]["UserCheck"].ToString();
            //
            txt_checkpl1.Text = dtAlldetails.Rows[0]["ustp1"].ToString() + " - " + dtAlldetails.Rows[0]["ttp1"].ToString();
            txt_checkpl2.Text = dtAlldetails.Rows[0]["ustp2"].ToString() + " - " + dtAlldetails.Rows[0]["ttp2"].ToString();
            txt_user_error.Text = " --- E1 --- \r\n" + dtAlldetails.Rows[0]["User_Exit_Img_E1"].ToString() + "\r\n ---- E2 ---- \r\n" + dtAlldetails.Rows[0]["User_Exit_Img_E2"].ToString();
            btnch.Visible = false; btnqc.Visible = false;
            //update-test-tailnt
            txt_lastCheck.Text = dtAlldetails.Rows[0]["LastCheck"].ToString() + " - " + dtAlldetails.Rows[0]["ttp3"].ToString();

            if (User_C_QC.Split('-')[0] == "C2")
            {
                btnch.Visible = true;
            }
            else if (User_C_QC.Split('-')[0] == "QC2")
            {
                btnqc.Visible = true;
            }            
        }

        private void btnrp_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_Entry_PL(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Content1 = NULL, Content2 = NULL, UserId1 = NULL,  Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnrp2_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_P2(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnrcp_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_CP(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnre1_Click(object sender, EventArgs e)
        {
            try
            {
                string Result_PL = dAEntry.GetStringSQL("Select ResultP from db_owner.[ImageContent] where AllImageId = " + iddt + "");
                if (Result_PL != "")
                {
                    workdb.Return_Entry(iddt);
                    dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set  Content1 = NULL,Content2 = NULL,Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("Dữ liệu Result Phân Loại không có !!! \r\nReturn về Entry PL nhé !!!");
                    return;
                }                
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnre2_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_E2(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnch_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_Check(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }

        private void btnqc_Click(object sender, EventArgs e)
        {
            try
            {
                workdb.Return_QC(iddt);
                dAEntry.ExecuteSQL("Update db_owner.[ImageContent] set Checkresult = NULL,Result = NULL,Color_LC= NULL,Color_Check_QC= NULL where AllImageId = " + iddt + "");
                MessageBox.Show("Ok");
            }
            catch
            {
                MessageBox.Show("Không phải dạng trả về");
            }
        }
        //private void ToExcel(DataTable dtable, string fileName)
        //{
        //    Microsoft.Office.Interop.Excel.Application excel;
        //    Microsoft.Office.Interop.Excel.Workbook workbook;
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet;
        //    try
        //    {
        //        excel = new Microsoft.Office.Interop.Excel.Application();
        //        excel.Visible = false;
        //        excel.DisplayAlerts = false;
        //        workbook = excel.Workbooks.Add(Type.Missing);
        //        worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
        //        worksheet.Name = "Sheet 1";
        //        for (int i = 0; i < dtable.Columns.Count; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = dtable.Columns[i].ColumnName;
        //        }
        //        for (int i = 0; i < dtable.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dtable.Columns.Count; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dtable.Rows[i][j].ToString();
        //            }
        //        }
        //        workbook.SaveAs(fileName);
        //        //đóng workbook
        //        workbook.Close();
        //        excel.Quit();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        workbook = null;
        //        worksheet = null;
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtAlldetails.Columns.Count > 0)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = "Detail_" + dtAlldetails.Rows[0]["ResultP"].ToString() + ".xlsx";
                    saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        //saveDialog.FileName = saveDialog.FileName.Split('_')[0] + "_BANRA" + ".xlsx";                        
                        //grvPerformance.ClearColumnsFilter();
                        //grvPerformance.ClearSorting();
                        //grvPerformance.ClearGrouping();
                        //grvPerformance.ClearSelection();
                        //grvPerformance.FindFilterText = "";                        
                        //grvDetails.ExportToXlsx(saveDialog.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                        //string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        //NImageExporter imageExporter = chartControl.ImageExporter;
                        //grvPerformance.ExportToXlsx(exportFilePath);
                        //NImageExporter imageExporter = chartControl.ImageExporter;

                        //ToExcel(dtAlldetails, saveDialog.FileName);
                    }
                    MessageBox.Show("Hoàn thành Export ");

                }
            }
        }
    }
}
