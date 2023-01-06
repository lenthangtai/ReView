using DevExpress.Export;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VCB_Entry;


namespace VCB_TEGAKI
{
    public partial class LC_Level : Form
    {
        public string username;
        public string formname;
        public string dotup;
        public int userid;
        public int formid;
        public int batchid;
        public int pair;
        public int lvl;
        DateTime dtimeBefore = new DateTime();
        public LC_Level()
        {
            InitializeComponent();
        }
        bool changed = false;
        float currentzoom;
        private void LC_Level_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    ImgV.CurrentZoom = currentzoom;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    try
                    {
                        ImgV.RotateImage("270");
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
                        ImgV.RotateImage("90");
                    }
                    catch
                    {
                    }

                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Add)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom <= 0.1f ? 0.1f : ImgV.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom + 0.1f;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    ImgV.CurrentZoom = ImgV.CurrentZoom <= 0.1f ? 0.1f : ImgV.CurrentZoom - 0.1f;
                    e.Handled = true;
                }
            }
        }
        WorkDB_LC workdb = new WorkDB_LC();
        DataTable dt_img_batch = new DataTable(), datasave = new DataTable();
        string table_img = "", table_content = "";
        int id_index_img = 0, index_focus = 0;
        string grid_content = "", grid_content_E3 = "", poi_check1lv = "", poicheck2lv="", poi_lc_1lv = "", poi_lc_2lv = "";
        string grid_content_old = "", grid_content_old3 = "";
        private void gridV_Img_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index_focus = e.FocusedRowHandle;
            string tenanh = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ImageName").ToString();
            id_index_img = Convert.ToInt32(gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Id").ToString());
            
            if (lvl == 1)
            {
                grid_content = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "RsNow").ToString();
                grid_content_old = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ResultCheck").ToString();
                poi_check1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_1_Check").ToString();
                poi_lc_1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_1_LC").ToString();
                //Content_old_1 = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_1_LC").ToString();
                show_data_img(grid_content,"", grid_content_old,"");
            }
            else if (lvl == 3)
            {
                grid_content = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "RsNow").ToString();
                grid_content_old = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ResultCheckE3").ToString();
                poi_check1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_3_Check").ToString();
                poi_lc_1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_3_LC").ToString();
                show_data_img(grid_content, "", grid_content_old, "");
            }
            else if (lvl == 0)
            {
                grid_content = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "RsNow").ToString();
                grid_content_E3 = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "RsNow3").ToString();
                //grid_content_old3
                grid_content_old = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ResultCheck").ToString();
                grid_content_old3 = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ResultCheckE3").ToString();

                poi_check1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_1_Check").ToString();
                poicheck2lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_3_Check").ToString();
                poi_lc_1lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_1_LC").ToString();
                poi_lc_2lv = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Poi_3_LC").ToString();
                show_data_img(grid_content, grid_content_E3, grid_content_old, grid_content_old3);
            }
            
            if (tenanh != "")
            {
                ImgV.Dispose();
                try
                {
                    Bitmap imgSource = new Bitmap(byteArrayToImage(workdb.getImageOnServer(tenanh)));
                    ImgV.Image = imgSource;
                }
                catch
                {
                    MessageBox.Show("Ảnh có vấn đề ");
                    return;
                }
            }
            
        }

        private void gridV_Img_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridV_data_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        DataTable dt_change_data = new DataTable();
        private void gridV_data_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            if (e.RowHandle > -1)
            {
                if (lvl == 0)
                {
                    if (cl > 1)
                    {
                        dt_change_data.Rows.Add(r.ToString(), cl.ToString(), "3");
                    }
                    else
                    {
                        dt_change_data.Rows.Add(r.ToString(), cl.ToString(), "1");
                    }
                }
                else
                {
                    dt_change_data.Rows.Add(r.ToString(), cl.ToString(),"");
                }
                
            }
        }

        private void grid_data_EditorKeyDown(object sender, KeyEventArgs e)
        {
            ColumnView View = (ColumnView)grid_data.FocusedView;
            GridColumn column = View.Columns[gridV_data.FocusedColumn.FieldName];
            int row = gridV_data.FocusedRowHandle;
            if (e.Control && e.KeyCode == Keys.Subtract)
            {
                if (row != 0)
                {
                    DeleteSelectedRows(gridV_data);
                    View.FocusedRowHandle = row - 1;
                    View.FocusedColumn = gridV_data.VisibleColumns[1];
                }
                else
                {
                    MessageBox.Show("Không thể xóa");
                    return;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (row < 0)
                {
                    row = 1;
                }
                if (row == gridV_data.RowCount - 1)
                {
                    View.FocusedRowHandle = row + 1;
                    View.FocusedColumn = column;
                    gridV_data.AddNewRow();
                    View.FocusedRowHandle = row + 1;
                    View.FocusedColumn = gridV_data.VisibleColumns[0];
                }
                else
                {
                    View.FocusedRowHandle = row + 1;
                    View.FocusedColumn = column;
                }
            }
            else if (e.Control && e.KeyCode == Keys.Add)
            {
                DataRow dtr = dt_data_content.NewRow();
                dt_data_content.Rows.InsertAt(dtr, row + 1);
                //dtcopy.Rows.Add();
                //dtcopy.AcceptChanges();
                grid_data.DataSource = null;
                grid_data.DataSource = dt_data_content;
                grid_data.Focus();
                View.FocusedRowHandle = row + 1;
                View.FocusedColumn = column;
                SendKeys.Send("{F2}");
                SendKeys.Send("{END}");
            }
        }
        private void DeleteSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            if (view == null || view.SelectedRowsCount == 0) return;
            DataRow[] rows = new DataRow[view.SelectedRowsCount];
            for (int i = 0; i < view.SelectedRowsCount; i++)
                rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);
            view.BeginSort();
            try
            {
                foreach (DataRow row in rows)
                    row.Delete();
            }
            finally
            {
                view.EndSort();
            }
        }
        
        private void grid_data_Leave(object sender, EventArgs e)
        {
            spl_wait.ShowWaitForm();
            DataTable dt_img = new DataTable();
            if (lvl == 1 || lvl == 3)
            {
                #region
                string ContentOld = grid_content;
                if (dt_change_data.Rows.Count > 0)
                {
                    // Check dữ liệu khi thay đổi xong
                    string Datanew = "";
                    for (int i = 0; i < dt_data_content.Rows.Count; i++)
                    {
                        string vlrow = "";
                        for (int j = 0; j < dt_data_content.Columns.Count; j++)
                        { vlrow = vlrow + "†" + dt_data_content.Rows[i][j].ToString(); }
                        //if (vlrow.Replace("†", "").Trim() != "")
                        Datanew = Datanew + vlrow.Substring(1) + "‡";
                    }
                    if (Datanew.Length > 0)
                    { Datanew = Datanew.Substring(0, Datanew.Length - 1); }

                    if (ContentOld != Datanew)
                    {
                        for (int i = 0; i < dt_change_data.Rows.Count; i++)
                        {
                            datasave.Rows.Add(dt_change_data.Rows[i][0], dt_change_data.Rows[i][1], dt_change_data.Rows[i][2], id_index_img.ToString());
                        }
                        dt_img_batch.Rows[index_focus]["RsNow"] = Datanew;
                        dt_img_batch.AcceptChanges();
                    }
                }
                #endregion
            }
            else
            {
                #region
                string ContentOld = grid_content;
                string ContentOld_3 = grid_content_E3;
                string Datanew = "";
                for (int i = 0; i < dt_data_content.Rows.Count; i++)
                {
                    string vlrow = "";
                    for (int j = 0; j < dt_data_content.Columns.Count; j++)
                    { vlrow = vlrow + "†" + dt_data_content.Rows[i][j].ToString(); }
                    //if (vlrow.Replace("†", "").Trim() != "")
                    Datanew = Datanew + vlrow.Substring(1) + "‡";
                }
                if (Datanew.Length > 0)
                { Datanew = Datanew.Substring(0, Datanew.Length - 1); }

                string Datanew3 = "";
                for (int i = 0; i < dt_data_content.Rows.Count; i++)
                {
                    string vlrow = "";
                    for (int j = 2; j < dt_data_content.Columns.Count; j++)
                    { vlrow = vlrow + "†" + dt_data_content.Rows[i][j].ToString(); }
                    //if (vlrow.Replace("†", "").Trim() != "")
                    Datanew3 = Datanew3 + vlrow.Substring(1) + "‡";
                }
                if (Datanew3.Length > 0)
                { Datanew3 = Datanew3.Substring(0, Datanew3.Length - 1); }

                if (ContentOld != Datanew || ContentOld_3 != Datanew3)
                {
                    for (int i = 0; i < dt_change_data.Rows.Count; i++)
                    {
                        datasave.Rows.Add(dt_change_data.Rows[i][0], dt_change_data.Rows[i][1], dt_change_data.Rows[i][2], id_index_img.ToString());
                    }
                    dt_img_batch.Rows[index_focus]["RsNow"] = Datanew;
                    dt_img_batch.Rows[index_focus]["RsNow3"] = Datanew3;
                    dt_img_batch.AcceptChanges();
                }
                #endregion
            }
            dt_change_data.Clear();
            spl_wait.CloseWaitForm();
        }
        private void LC_Level_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datasave.Rows.Count > 0)
            {
                var mes = MessageBox.Show("Dữ liệu có thay đổi...Bạn có muốn lưu không ????", "Messenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mes == DialogResult.Yes)
                {
                    btn_save_Click(sender, e);                                        
                    return;
                }
                else if (mes == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            TimeSpan span = DateTime.Now - dtimeBefore;
            int ms = (int)span.TotalMilliseconds;
            //string centerid = ClassData.Get_Center(userid);
            //ClassData.Update_TimeLC(batchid, userid, ms, 1, centerid, lvl, dt_img_batch.Rows.Count);
        }
        void Export()
        {
            if (dt_img_batch.Rows.Count > 0)
            {
                #region Tạo bảng export
                DataTable dt_export = new DataTable();
                dt_export.Columns.Add("Image");
                dt_export.Columns.Add("①管理番号");
                dt_export.Columns.Add("②郵便番号");
                dt_export.Columns.Add("③住所");
                dt_export.Columns.Add("④氏名");
                dt_export.Columns.Add("⑤氏名（カナ）");
                #endregion
                #region Phân tích dữ liệu export
                for (int t = 0; t < dt_img_batch.Rows.Count; t++)
                {
                    string nameImgae = dt_img_batch.Rows[t]["ImageName"].ToString();
                    string data_id_1 = dt_img_batch.Rows[t]["RsNow"].ToString();
                    string data_id_3 = dt_img_batch.Rows[t]["RsNow3"].ToString();
                    string[] arrgrid = data_id_1.Split('‡');
                    string[] arrgrid3 = data_id_3.Split('‡');
                    int sodong = 0;
                    if (arrgrid.Length >= arrgrid3.Length)
                    {
                        sodong = arrgrid.Length;
                        if (arrgrid.Length == arrgrid3.Length)
                        {
                            for (int i = 0; i < sodong; i++)
                            {
                                dt_export.Rows.Add(nameImgae, arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < sodong; i++)
                            {
                                if (i >= arrgrid3.Length)
                                {
                                    dt_export.Rows.Add(nameImgae, arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], "", "", "");
                                }
                                else
                                {
                                    dt_export.Rows.Add(nameImgae, arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                                }
                            }
                        }
                    }
                    else
                    {
                        sodong = arrgrid3.Length;
                        for (int i = 0; i < sodong; i++)
                        {
                            if (i >= arrgrid.Length)
                            {
                                dt_export.Rows.Add(nameImgae, "", "", arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                            }
                            else
                            {
                                dt_export.Rows.Add(nameImgae, arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                            }
                        }
                    }
                }
                gridExport.DataSource = null;
                gridExport.DataSource = dt_export;
                #endregion
            }
            else
            {
                MessageBox.Show("Dữ liệu trống ???");
                this.Close();
                return;
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (datasave.Rows.Count > 0)
            {
                MessageBox.Show("Có dữ liệu thay đổi. Vui lòng thực hiện Lưu trước khi Export !!!");
                return;
            }
            #region thực hiện Export dữ liệu
            Export();            
            SaveFileDialog svFD = new SaveFileDialog();
            svFD.RestoreDirectory = true;
            svFD.Title = "Save to file xlsx";
            svFD.Filter = "EXCEL | *.xlsx";
            svFD.FileName = "SPOT" + table_content+ ".xlsx";
            if (svFD.ShowDialog() == DialogResult.OK)
            {
                gridV_Export.ExportToXlsx(svFD.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                MessageBox.Show("Complete Export!");
            }
            #endregion
        }

        //DataTable tb_data_img_change = new DataTable();
        private void gridV_data_MouseLeave(object sender, EventArgs e)
        {
            
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void gridV_Img_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            if (r > -1)
            {
                if (lvl != 3)
                {
                    if (gridV_Img.GetRowCellValue(e.RowHandle, gridV_Img.Columns["CheckerId"]).ToString() != "")
                    {
                        if (e.Column.FieldName == "ImageName")
                        {
                            e.Appearance.BackColor = Color.Orange;
                        }
                    }
                }
                if (lvl != 1)
                {
                    if ( gridV_Img.GetRowCellValue(e.RowHandle, gridV_Img.Columns["CheckerId3"]).ToString() != "")
                    {
                        if (e.Column.FieldName == "ImageName")
                        {
                            e.Appearance.BackColor = Color.Orange;
                        }
                    }
                }
            }
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (datasave.Rows.Count > 0)
            {
                if (lvl == 1 || lvl ==3)
                {
                    for (int i = 0; i < datasave.Rows.Count; i++)
                    {
                        int id = Convert.ToInt32(datasave.Rows[i]["Id_img"].ToString());
                        DataTable dt_datanew = dt_img_batch.Select("Id = '" + id + "'").CopyToDataTable();
                        string datanew = dt_datanew.Rows[0]["RsNow"].ToString();
                        //ClassData.Update_Content_0709_LC(id, table_content, datanew, lvl, "");
                    }
                }
                else
                {
                    for (int i = 0; i < datasave.Rows.Count; i++)
                    {
                        int id = Convert.ToInt32(datasave.Rows[i]["Id_img"].ToString());
                        DataTable dt_datanew = dt_img_batch.Select("Id = '" + id + "'").CopyToDataTable();
                        string datanew = dt_datanew.Rows[0]["RsNow"].ToString();
                        string datanewE3 = dt_datanew.Rows[0]["RsNow3"].ToString();
                        int level_data = Convert.ToInt32(datasave.Rows[i]["Level"].ToString());
                        if (level_data == 1)
                        {
                            //ClassData.Update_Content_0709_LC(id, table_content, datanew, level_data, "");                            
                        }
                        else
                        {
                            //ClassData.Update_Content_0709_LC(id, table_content, datanewE3, level_data, "");                            
                        }
                        
                    }
                }
                datasave.Clear();
            }
        }

        private void gridV_data_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            if (r > -1)
            {
                if (lvl == 1 || lvl == 3)
                {
                    #region Bôi màu cho check và LC
                    if (poi_check1lv != "")
                    {
                        string[] get_Color = poi_check1lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    if (poi_lc_1lv != "")
                    {
                        string[] get_Color = poi_lc_1lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    try
                    {
                        if (dt_data_content.Rows[r][cl].ToString() != dt_data_Goc.Rows[r][cl].ToString())
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    catch
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    
                    #endregion
                }
                else
                {
                    #region Bôi màu cho check và LC
                    if (poi_check1lv != "")
                    {
                        string[] get_Color = poi_check1lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    if (poicheck2lv != "")
                    {
                        string[] get_Color = poicheck2lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot + 2)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    if (poi_lc_1lv != "")
                    {
                        string[] get_Color = poi_lc_1lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    if (poi_lc_2lv != "")
                    {
                        string[] get_Color = poi_lc_2lv.Split('‡');
                        for (int i = 0; i < get_Color.Length; i++)
                        {
                            if (get_Color[i] != "")
                            {
                                int cot = Convert.ToInt32(get_Color[i].Split(',')[1].ToString());
                                int dong = Convert.ToInt32(get_Color[i].Split(',')[0].ToString());
                                if (e.Column.ColumnHandle == cot + 2)
                                {
                                    if (dong == r)
                                    {
                                        e.Appearance.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                    try
                    {
                        if (dt_data_content.Rows[r][cl].ToString() != dt_data_Goc.Rows[r][cl].ToString())
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    catch
                    {
                        e.Appearance.BackColor = Color.Red;
                    }

                    #endregion
                }
            }
            #region code từ plus đóng
            //if (color != "")
            //{
            //    string tenanh_dong = dtTemp.Rows[x][0].ToString();
            //    string[] get_Color_LC = color.Split('‡');
            //    for (int i = 0; i < get_Color_LC.Length; i++)
            //    {
            //        if (get_Color_LC[i] != "")
            //        {
            //            int cot = Convert.ToInt32(get_Color_LC[i].Split(',')[1].ToString());
            //            int dong = Convert.ToInt32(get_Color_LC[i].Split(',')[0].ToString());
            //            if (grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["Image"]).ToString() == tenanh_dong)
            //            {
            //                if (e.Column.ColumnHandle == cot)
            //                {
            //                    if (dong == Convert.ToInt32(grThongkeV.GetRowCellValue(e.RowHandle, grThongkeV.Columns["STT_Dong_Image"]).ToString()))
            //                    {
            //                        e.Appearance.BackColor = Color.LightPink;
            //                    }
            //                }
            //            }
            //            //int cot1 = Convert.ToInt32(get_Color_LC[i].Split(',')[1].ToString());
            //            //int dong1 = Convert.ToInt32(get_Color_LC[i].Split(',')[0].ToString());
            //            //if (e.RowHandle == dong)
            //            //{
            //            //    if (e.Column.ColumnHandle == cot)
            //            //    {
            //            //        e.Appearance.BackColor = Color.LightPink;
            //            //    }
            //            //}
            //        }
            //    }
            //}
            #endregion
        }
        DataTable dt_data_content = new DataTable();
        DataTable dt_data_Goc = new DataTable();
        void show_data_img(string Result, string Result_E3, string Result_Old, string Result_E3_Old)
        {
            dt_data_content.Clear();
            dt_data_Goc.Clear();
            if (lvl == 1 || lvl ==3)
            {
                #region
                string[] arrgrid = Result.Split('‡');
                for (int i = 0; i < arrgrid.Length; i++)
                {
                    dt_data_content.Rows.Add(arrgrid[i].Split('†'));
                }
                grid_data.DataSource = null;
                grid_data.DataSource = dt_data_content;

                string[] arrgrid_old = Result_Old.Split('‡');
                for (int i = 0; i < arrgrid_old.Length; i++)
                {
                    dt_data_Goc.Rows.Add(arrgrid_old[i].Split('†'));
                }
                #endregion
            }
            else if (lvl == 0)
            {
                #region Dữ liệu hiện tại
                int sodong = 0;
                string[] arrgrid = Result.Split('‡');
                string[] arrgrid3 = Result_E3.Split('‡');
                if (arrgrid.Length >= arrgrid3.Length)
                {
                    sodong = arrgrid.Length;
                    if (arrgrid.Length == arrgrid3.Length)
                    {
                        for (int i = 0; i < sodong; i++)
                        {
                            dt_data_content.Rows.Add(arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < sodong; i++)
                        {
                            if (i >= arrgrid3.Length)
                            {
                                dt_data_content.Rows.Add(arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], "","","");
                            }
                            else
                            {
                                dt_data_content.Rows.Add(arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                            }
                        }
                    }
                }
                else
                {
                    sodong = arrgrid3.Length;
                    for (int i = 0; i < sodong; i++)
                    {
                        if (i>= arrgrid.Length)
                        {
                            dt_data_content.Rows.Add("","" , arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                        }
                        else
                        {
                            dt_data_content.Rows.Add(arrgrid[i].Split('†')[0], arrgrid[i].Split('†')[1], arrgrid3[i].Split('†')[0], arrgrid3[i].Split('†')[1], arrgrid3[i].Split('†')[2]);
                        }
                    }
                }
                grid_data.DataSource = null;
                grid_data.DataSource = dt_data_content;
                #endregion
                #region Dữ liệu qua Check
                string[] arrgrid_old = Result_Old.Split('‡');
                string[] arrgrid3_old = Result_E3_Old.Split('‡');
                if (arrgrid_old.Length >= arrgrid3_old.Length)
                {
                    sodong = arrgrid_old.Length;
                    if (arrgrid_old.Length == arrgrid3_old.Length)
                    {
                        for (int i = 0; i < sodong; i++)
                        {
                            dt_data_Goc.Rows.Add(arrgrid_old[i].Split('†')[0], arrgrid_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[0], arrgrid3_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[2]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < sodong; i++)
                        {
                            if (i >= arrgrid3_old.Length)
                            {
                                dt_data_Goc.Rows.Add(arrgrid_old[i].Split('†')[0], arrgrid_old[i].Split('†')[1], "", "", "");
                            }
                            else
                            {
                                dt_data_Goc.Rows.Add(arrgrid_old[i].Split('†')[0], arrgrid_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[0], arrgrid3_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[2]);
                            }
                        }
                    }
                }
                else
                {
                    sodong = arrgrid3_old.Length;
                    for (int i = 0; i < sodong; i++)
                    {
                        if (i >= arrgrid_old.Length)
                        {
                            dt_data_Goc.Rows.Add("", "", arrgrid3_old[i].Split('†')[0], arrgrid3_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[2]);
                        }
                        else
                        {
                            dt_data_Goc.Rows.Add(arrgrid_old[i].Split('†')[0], arrgrid_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[0], arrgrid3_old[i].Split('†')[1], arrgrid3_old[i].Split('†')[2]);
                        }
                    }
                }
                #endregion
            }
        }
        
        private void LC_Level_Load(object sender, EventArgs e)
        {
            table_img = formname + "--" + batchid;
            table_content = batchid + "--" + formname;
            spl_wait.ShowWaitForm();
            // Thực hiện lấy dữ liệu của từng 
            dt_img_batch = new DataTable();
            dt_data_content = new DataTable();
            if (lvl ==1)
            {
                //dt_img_batch = ClassData.GetDatatableSQL("Select Id,ImageName,ResultCheck,CheckerId,Poi_1_Check,Poi_1_LC,Result as 'RsNow' from dbo.[" + table_content+"]");
                dt_data_content.Columns.Add("①管理番号"); dt_data_content.Columns.Add("②郵便番号");
            }
            else if (lvl == 3)
            {
                //dt_img_batch = ClassData.GetDatatableSQL("Select Id,ImageName,ResultCheckE3,CheckerId3,Poi_3_Check,Poi_3_LC,ResultE3 as 'RsNow' from dbo.[" + table_content + "] ");
                dt_data_content.Columns.Add("③住所"); dt_data_content.Columns.Add("④氏名"); dt_data_content.Columns.Add("⑤氏名（カナ）");
            }
            else if (lvl == 0)
            {
                btn_export.Visible = true;
                //dt_img_batch = ClassData.GetDatatableSQL("Select Id,ImageName,ResultCheck,CheckerId,Poi_1_Check,Poi_1_LC,ResultCheckE3,CheckerId3,Poi_3_Check,Poi_3_LC,Result as 'RsNow',ResultE3 as 'RsNow3' from dbo.[" + table_content + "] ");
                dt_data_content.Columns.Add("①管理番号"); dt_data_content.Columns.Add("②郵便番号"); dt_data_content.Columns.Add("③住所"); dt_data_content.Columns.Add("④氏名"); dt_data_content.Columns.Add("⑤氏名（カナ）");
            }
            dt_data_Goc = dt_data_content.Clone();
            datasave = new DataTable();
            datasave.Columns.Add("Dong");
            datasave.Columns.Add("Cot");
            datasave.Columns.Add("Level");
            datasave.Columns.Add("Id_img");
            dt_change_data = new DataTable();
            dt_change_data.Columns.Add("Dong");
            dt_change_data.Columns.Add("Cot");
            dt_change_data.Columns.Add("Level");
            grid_img.DataSource = null;
            grid_img.DataSource = dt_img_batch;
            #region ẩn cột
            gridV_Img.Columns["Id"].Visible = false;
            if (lvl == 1)
            {
                gridV_Img.Columns["ResultCheck"].Visible = false;
                gridV_Img.Columns["CheckerId"].Visible = false;
                gridV_Img.Columns["Poi_1_Check"].Visible = false;
                gridV_Img.Columns["Poi_1_LC"].Visible = false;
                //gridV_Img.Columns["Result"].Visible = false;
            }
            else if (lvl == 3)
            {
                gridV_Img.Columns["ResultCheckE3"].Visible = false;
                gridV_Img.Columns["CheckerId3"].Visible = false;
                gridV_Img.Columns["Poi_3_Check"].Visible = false;
                gridV_Img.Columns["Poi_3_LC"].Visible = false;
                //gridV_Img.Columns["Result"].Visible = false;
            }
            else 
            {
                gridV_Img.Columns["ResultCheck"].Visible = false;
                gridV_Img.Columns["CheckerId"].Visible = false;
                gridV_Img.Columns["Poi_1_Check"].Visible = false;
                gridV_Img.Columns["Poi_1_LC"].Visible = false;
                //gridV_Img.Columns["Result"].Visible = false;
                gridV_Img.Columns["ResultCheckE3"].Visible = false;
                gridV_Img.Columns["CheckerId3"].Visible = false;
                gridV_Img.Columns["Poi_3_Check"].Visible = false;
                gridV_Img.Columns["Poi_3_LC"].Visible = false;
                //gridV_Img.Columns["Result"].Visible = false;
            }
            #endregion
            //gridV_Img.Columns["Id"].Visible = false;
            spl_wait.CloseWaitForm();
            dtimeBefore = DateTime.Now;
        }
    }
}
