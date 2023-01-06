
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry.Lastcheck
{
    public partial class Up_Master : Form
    {
        public int IdLc;
        public Up_Master()
        {
            InitializeComponent();
        }
        WorkDB_LC workdb = new WorkDB_LC();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_data1.Text != "" || txt_data2.Text != "" || txt_data3.Text != "")
            {
                
                if (cbb_masterTruong.Text == "Master Trường 6")
                {
                    workdb.ExecuteSQL("Insert into dbo.[Master_Truong6] (NoiDung,UserUp) VALUES (N'" + txt_data1.Text.Trim() + "',"+ IdLc + ")");
                    txt_data1.Text = "";
                }
                else if (cbb_masterTruong.Text == "Master Trường 8")
                {
                    workdb.ExecuteSQL("Insert into dbo.[Master_Truong8] (NoiDungKanji,CachNhap,UserUp) VALUES (N'" + txt_data1.Text + "',N'"+txt_data2.Text+"',"+ IdLc + ")");
                    txt_data1.Text = "";
                    txt_data2.Text = "";
                }
                else if (cbb_masterTruong.Text == "Master Trường 10")
                {
                    workdb.ExecuteSQL("Insert into dbo.[Master_Truong10] (SttForm,TenForm,MaSo_TruongSo10,UserUp) VALUES (N'" + txt_data1.Text.Trim() + "',N'" + txt_data2.Text.Trim() + "',N'"+txt_data3.Text.Trim()+"',"+ IdLc + ")");
                    txt_data1.Text = "";
                    txt_data2.Text = "";
                    txt_data3.Text = "";
                }
                MessageBox.Show("Hoàn Thành");
            }
            else
            {
                MessageBox.Show("Bạn phải nhập thông tin Master !", " Thông Báo ");
                return;
            }
        }

        private void cbb_masterTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_masterTruong.Text == "Master Trường 6")
            {
                label1.Text = "Nội Dung :";
                label2.Text = "";
                label3.Text = "";
                txt_data1.Enabled = true;
                txt_data2.Enabled = false;
                txt_data3.Enabled = false;
            }
            else if (cbb_masterTruong.Text == "Master Trường 8")
            {
                label1.Text = "Nội Dung Kanji:";
                label2.Text = "Nội Dung Cách nhập:";
                label3.Text = "";
                txt_data1.Enabled = true;
                txt_data2.Enabled = true;
                txt_data3.Enabled = false;
            }
            else if (cbb_masterTruong.Text == "Master Trường 10")
            {
                label1.Text = "STT Form :";
                label2.Text = "Tên Form :";
                label3.Text = "Mã Số Trường 10 :";
                txt_data1.Enabled = true;
                txt_data2.Enabled = true;
                txt_data3.Enabled = true;
            }
        }

        private void Up_Master_Load(object sender, EventArgs e)
        {
            txt_data1.Enabled = false;
            txt_data2.Enabled = false;
            txt_data3.Enabled = false;
            cbb_masterTruong.SelectedIndex = -1;
        }
        DataTable export = new DataTable();
        private void btn_export_Click(object sender, EventArgs e)
        {
            export.Clear();
            grdExport.DataSource = null;
            grdVExxport.Columns.Clear();
            if (cbb_masterTruong.Text == "Master Trường 6")
            {
                export = workdb.GetDatatableSQL("select NoiDung from dbo.[Master_Truong6]");
            }
            else if (cbb_masterTruong.Text == "Master Trường 8")
            {
                export = workdb.GetDatatableSQL("select NoiDungKanji,CachNhap from dbo.[Master_Truong8]");
            }
            else if (cbb_masterTruong.Text == "Master Trường 10")
            {
                export = workdb.GetDatatableSQL("select SttForm,TenForm,MaSo_TruongSo10 from dbo.[Master_Truong10]");
            }
            if (export.Rows.Count > 0)
            {
                grdExport.DataSource = export;
                if (grdVExxport.Columns.Count > 0)
                {
                    SaveFileDialog svFD = new SaveFileDialog();
                    svFD.RestoreDirectory = true;
                    svFD.Title = "Save to file xlsx";
                    svFD.Filter = "EXCEL | *.xlsx";
                    svFD.FileName = cbb_masterTruong.Text + "_Export.xlsx";
                    
                    if (svFD.ShowDialog() == DialogResult.OK)
                    {
                        grdVExxport.ExportToXlsx(svFD.FileName);
                        MessageBox.Show(" XUẤT DỮ LIỆU THÀNH CÔNG NHÉ !");
                    }

                    //if (svFD.ShowDialog() == DialogResult.OK)
                    //{
                    //    grdVExxport.ExportToXlsx(svFD.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                    //    MessageBox.Show(" XUẤT DỮ LIỆU THÀNH CÔNG NHÉ !");
                    //}
                    //using (SaveFileDialog saveDialog = new SaveFileDialog())
                    //{


                    //    saveDialog.FileName = cbb_masterTruong.Text + "_Export.xlsx";
                    //    saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    //    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    //    {
                    //        grdVExxport.ClearColumnsFilter();
                    //        grdVExxport.ClearSorting();
                    //        grdVExxport.ClearGrouping();
                    //        grdVExxport.ClearSelection();
                    //        grdVExxport.FindFilterText = "";
                    //        string exportFilePath = saveDialog.FileName;
                    //        string fileExtenstion = new System.IO.FileInfo(exportFilePath).Extension;
                    //        //NImageExporter imageExporter = chartControl.ImageExporter;
                    //        grdVExxport.ExportToXlsx(exportFilePath);
                    //        MessageBox.Show("Hoàn Thành !");
                    //    }

                    //}
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Trường Master  !");
                return;
            }
        }
    }
}
