using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCB_TEGAKI
{
    public partial class frmUpdateImage_BK : Form
    {
        int countFinish = 0;
        string[] pagesFilePath;
        int pagesFilePathLength;
        int pageUp = 0;
        int[] arrIndex;
        int getid;
        int iturn = 0;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\path_plus_nnc.txt";
        DBsql dbsql = new DBsql();
        DataTable dt = new DataTable();
        string batchname = "";
        int batchid = 0;
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameters myEncoderParameters;
        EncoderParameter myEncoderParameter;
        public frmUpdateImage_BK()
        {
            InitializeComponent();
            grThongkeV.IndicatorWidth = 50;
        }

        private void btnSourceDirectoryBrow_Click(object sender, EventArgs e)
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
            
            if (rdb_pdf.Checked == true)
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Title = "Browse File",
                    Filter = "All File|*.pdf",
                    Multiselect = false
                };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    var folders = open.FileNames;
                    string currentDirectory = Path.GetDirectoryName(folders[0].ToString());
                    string filename = Path.GetFileName(folders[0].ToString());
                    Directory.CreateDirectory(currentDirectory + "\\" + filename.Split('.')[0].ToString());
                    txtSourceDirectory.Text = currentDirectory + "\\" + filename.Split('.')[0].ToString();
                    PdfiumViewer.PdfDocument document = PdfiumViewer.PdfDocument.Load(folders[0].ToString());
                    int stt_img = 1;
                    //spl_waitform.ShowWaitForm();
                    for (int a = 0; a < document.PageCount; a++)
                    {
                        Image image;
                        //string imagename = filename.Split('.')[0].ToString() + " VBPO-" + stt_img.ToString().PadLeft(4,'0');
                        string imagename = filename.Split('.')[0].ToString() + " VBPO-" + stt_img.ToString().PadLeft(4, '0');
                        if (document.PageSizes[a].Width < 800 && document.PageSizes[a].Height < 1200)
                        {
                            try
                            {
                                int tyle = Convert.ToInt32(1500 / document.PageSizes[a].Width);
                                image = document.Render(a, Convert.ToInt32(document.PageSizes[a].Width * tyle), Convert.ToInt32(document.PageSizes[a].Height * tyle), 1300.0f, 1300.0f, true);

                                image.Save(currentDirectory + "\\" + filename.Split('.')[0].ToString().Trim() + @"\" + imagename + ".jpeg");
                                image.Dispose();
                            }
                            catch (Exception exxx)
                            {
                                int tyle = Convert.ToInt32(1500 / document.PageSizes[a].Width);
                                image = document.Render(a, Convert.ToInt32(document.PageSizes[a].Width * tyle), Convert.ToInt32(document.PageSizes[a].Height * tyle), 600.0f, 600.0f, true);
                                image.Save(currentDirectory + "\\" + filename.Split('.')[0].ToString().Trim() + @"\" + imagename + ".jpeg");
                                image.Dispose();
                            }
                        }
                        else
                        {
                            try
                            {
                                int tyle = Convert.ToInt32(2500 / document.PageSizes[a].Width);
                                image = document.Render(a, Convert.ToInt32(document.PageSizes[a].Width * tyle), Convert.ToInt32(document.PageSizes[a].Height * tyle), 1800.0f, 1800.0f, true);
                                image.Save(currentDirectory + "\\" + filename.Split('.')[0].ToString().Trim() + @"\" + imagename + ".jpeg");
                                image.Dispose();
                            }
                            catch (Exception exxx)
                            {
                                int tyle = Convert.ToInt32(1500 / document.PageSizes[a].Width);
                                image = document.Render(a, Convert.ToInt32(document.PageSizes[a].Width * tyle), Convert.ToInt32(document.PageSizes[a].Height * tyle), 600.0f, 600.0f, true);
                                image.Save(currentDirectory + "\\" + filename.Split('.')[0].ToString().Trim() + @"\" + imagename + ".jpeg");
                                image.Dispose();
                            }
                        }
                        stt_img++;
                    }
                    //spl_waitform.CloseWaitForm();
                }
                else
                {
                    return;
                }
            }
            else
            {
                FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
                fbd.SelectedPath = strPreferenceToRemember;
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    txtSourceDirectory.Text = fbd.SelectedPath;
                    File.WriteAllText(path, txtSourceDirectory.Text);
                    txtSourceDirectory.Text = fbd.SelectedPath;
                }
                else
                {
                    return;
                }
            }
            btnUpImage.Enabled = true;
            lb_time.Text = "Time Up: 00";
            //string[] ext = new string[4] { ".jpg", ".tif", ".png", ".tiff" };
            //pagesFilePath = Directory.GetFiles(txtSourceDirectory.Text,"*.tif",SearchOption.AllDirectories).Where(s => ext.Any(vl => s.EndsWith(vl))).ToArray();
            string[] patterns = new[] { "*.jpeg" };
            //pagesFilePath = Directory.GetFiles(txtSourceDirectory.Text, , SearchOption.AllDirectories);
            pagesFilePath = Directory.GetFiles(txtSourceDirectory.Text, "*.jpeg", SearchOption.AllDirectories);
            int sl = pagesFilePath.Length;
            for (int i = 0; i < sl; i++)
            {
                using (Bitmap img = new Bitmap(pagesFilePath[i]))
                {
                    if (img == null)
                    {
                        MessageBox.Show("Ảnh đang có vấn đề: " + pagesFilePath[i].ToString());
                        btnUpImage.Enabled = false;
                        return;
                    }
                }
                    //try
                    //{
                    //    Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Ảnh đang có vấn đề: " + pagesFilePath[i].ToString());
                    //    btnUpImage.Enabled = false;
                    //    return;
                    //}
                if (dbsql.ktanhtrung(Path.GetFileName(pagesFilePath[i])) > 0)
                {
                    MessageBox.Show("Ảnh" + pagesFilePath[i] + " vị trí thứ " + (i + 1) + " bị trùng!");
                    pagesFilePath = null;
                    btnUpImage.Enabled = false;
                    return;
                }
                // Update thêm chức năng 10/06/2021
            }
            #region close code
            // Bổ sung thêm chức năng check Time ở trong Tên ảnh
            //bool infotime_error = false;
            //string Image_name_Error = "";
            //for( int i = 0; i < sl; i ++)
            //{
            //    string nameFile = Path.GetFileName(pagesFilePath[i]);
            //    string ngaythang = "";// allinfo.Split('_')[1].Substring(0, 8);
            //    string giophut = "";// allinfo.Split('_')[1].Substring(8, 4);
            //    string nameanh_kitu = new string(nameFile.Where(c => !char.IsControl(c)).ToArray());
            //    try
            //    {
            //        string data_datetime = nameanh_kitu.Split('_')[nameanh_kitu.Split('_').Length - 3].ToString();
            //        string image_info = data_datetime.Substring(data_datetime.Length - 14, 14).ToString();
            //        if (image_info.ToString().Length > 10)
            //        {
            //            try
            //            {
            //                ngaythang = image_info.Substring(0, 8);
            //                giophut = image_info.Substring(8, 4);
            //                DateTime dt = DateTime.ParseExact(ngaythang, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            //                DateTime dt_minute = DateTime.ParseExact(giophut, "HHmm", System.Globalization.CultureInfo.InvariantCulture);
            //            }
            //            catch
            //            {
            //                Image_name_Error = Image_name_Error + nameFile + "\r\n";
            //                infotime_error = true;
            //            }
            //        }
            //        else
            //        {
            //            Image_name_Error = Image_name_Error + nameFile + "\r\n";
            //            infotime_error = true;
            //            //MessageBox.Show("Thông tin Ngày Tháng Năm trong tên ảnh đang có vấn đề !!!.. Xác nhận lại với đội dự án \r\n Tên ảnh: " + nameanh_kitu);
            //            return;
            //        }
            //    }
            //    catch
            //    {
            //        Image_name_Error = Image_name_Error + nameFile + "\r\n";
            //        infotime_error = true;
            //    }
            //}
            //if (infotime_error == true)
            //{
            //    MessageBox.Show("Vùi lòng kiểm tra lại thông tin của những ảnh sau :  \r\n" + Image_name_Error, "Thông Báo");
            //    return;
            //}

            //for ( int i = 0; i < sl; i ++)
            //{
            //    string name111 = new string(Path.GetFileName(pagesFilePath[i]).Where(c => !char.IsControl(c)).ToArray()) ; //new string(tenanh.Where(c => !char.IsControl(c)).ToArray());
            //    string[] leng11 = name111.Split('_');
            //    string data_get = name111.Split('_')[name111.Split('_').Length - 3].ToString();
            //    string now123 = data_get.Substring(0, 13).ToString();
            //    string now = data_get.Substring(data_get.Length - 14, 14).ToString();
            //}


            //for ( int i = 0; i < sl; i ++)
            //{
            //    string tenanh = Path.GetFileName(pagesFilePath[i]);
            //    string tenanh_kituchuan = new string(tenanh.Where(c => !char.IsControl(c)).ToArray());

            //    if (tenanh.Length != tenanh_kituchuan.Length || tenanh.Contains(" ") == true)
            //    {
            //        MessageBox.Show("Ảnh:  " + tenanh + " có vấn đề !..Kiểm tra lại nhé");
            //        return;
            //    }
            //}
            #endregion
            Array.Sort(pagesFilePath);
            pagesFilePathLength = pagesFilePath.Length;
            lblPage.Text = pagesFilePathLength.ToString();
            btnUpImage.Enabled = true;
            MessageBox.Show("Complete Check Data Image !!! Countinue -- >");

        }
        public static class CustomDirectoryTools
        {
            public static string[] GetFiles(string path, string[] patterns = null, SearchOption options = SearchOption.TopDirectoryOnly)
            {
                if (patterns == null || patterns.Length == 0)
                    return Directory.GetFiles(path, "*", options);
                if (patterns.Length == 1)
                    return Directory.GetFiles(path, patterns[0], options);
                return patterns.SelectMany(pattern => Directory.GetFiles(path, pattern, options)).Distinct().ToArray();
            }
        }
        #region Turn
        public void Turnup(string ImgName)
        {
            iturn = 0;
            DateTime now = DateTime.Now;
            int ithang = 0;
            int nthang =  0;
            int ingay = 0;
            int nngay = 0;
            int igio = 0;
            int iphut = 0;  
            int igiophut = 0;

            if (ImgName.Split('_')[1].ToString().Length > 10)
            {
                ithang  = Convert.ToInt32(ImgName.Split('_')[1].Substring(4, 2));
                ingay = Convert.ToInt32(ImgName.Split('_')[1].Substring(6, 2));
                igio = Convert.ToInt32(ImgName.Split('_')[1].Substring(8, 2));
                iphut = Convert.ToInt32(ImgName.Split('_')[1].Substring(10, 2));
                igiophut = Convert.ToInt32(ImgName.Split('_')[1].Substring(8, 4));
                nngay = Convert.ToInt32(now.Day);
                nthang = Convert.ToInt32(now.Month);
            }
            else
            {
                ithang = Convert.ToInt32(ImgName.Substring(4, 2));
                ingay = Convert.ToInt32(ImgName.Substring(6, 2));
                igio = Convert.ToInt32(ImgName.Substring(8, 2));
                iphut = Convert.ToInt32(ImgName.Substring(10, 2));
                igiophut = Convert.ToInt32(ImgName.Substring(8, 4));
                nngay = Convert.ToInt32(now.Day);
                nthang = Convert.ToInt32(now.Month);
            }

            if (ithang < nthang)
            {
                iturn = 1;
            }
            else if (ithang == nthang)
            {
                if (ingay < nngay)
                {
                    iturn = 1;
                }
                else if (ingay == nngay)
                {
                    if (igiophut <= 1005 || igiophut >= 1606)
                    {
                        iturn = 1;
                    }
                    else if (igiophut >= 1006  && igiophut <= 1120)
                    {
                        iturn = 2;
                    }
                    else if (igiophut >= 1121 && igiophut <= 1305)
                    {
                        iturn = 3;
                    }
                    else if (igiophut >= 1306 && igiophut <= 1605)
                    {
                        iturn = 4;
                    }
                }
            }
        }
        #endregion
        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            countFinish++;
            if (countFinish > 9)
            {
                bgrImage.RunWorkerAsync();
            }
            else if (pagesFilePath.Length <= 9)
            {
                bgrImage.RunWorkerAsync();
            }
        }

        private void bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            prbUpImage.Value = pageUp;
        }
        string str_CAUp = "";
        bool CA = true;
        DateTime time_start = DateTime.Now;
        private void btnUpImage_Click(object sender, EventArgs e)
        {
            if (pagesFilePath.Length > 0)
            {
                str_CAUp = Path.GetFileName( txtSourceDirectory.Text);

                if(str_CAUp != "CA1")
                {
                    CA = false;
                }
                pageUp = 0;
                countFinish = 0;
                arrIndex = clValue.value(pagesFilePath.Length);
                btnUpImage.Enabled = false;
                btnSourceDirectoryBrow.Enabled = false;
                prbUpImage.Value = 0;
                prbUpImage.Maximum = pagesFilePath.Length;
                iturn = Convert.ToInt32(cbb_ca.Text.ToString());
                //BackgroundWorker worker = sender as BackgroundWorker;
                //bgrImage.RunWorkerAsync();
                time_start = DateTime.Now;
                #region code đang chạy đóng Test
                //for ( int i = 0;i < pagesFilePath.Length; i ++)
                //{
                //    Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                //    dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                //    //pageUp = pageUp + 1;
                //    //prbUpImage.Value = i + 1;
                //    lblUp.Text = (i + 1).ToString();
                //    // report progress.
                //    //worker.ReportProgress(pageUp);
                //    Turnup(Path.GetFileName(btnSourceDirectoryBrow.Text));
                //    dbsql.InsertImage(Path.GetFileName(pagesFilePath[i]), iturn);
                //}
                //lblUp.Text = dbsql.countImage();
                ////btnUpImage.Enabled = true;
                //btnSourceDirectoryBrow.Enabled = true;
                ////prbUpImage.Value = pagesFilePathLength;
                //grThongke.DataSource = null;
                //dt = dbsql.GetImageOnServer();
                //grThongke.DataSource = dt;
                //grThongkeV.Columns[0].Visible = false;
                //MessageBox.Show("Completed!");
                #endregion
                if (pagesFilePath.Length > 9)
                {
                    bgw1.RunWorkerAsync();
                    bgw2.RunWorkerAsync();
                    bgw3.RunWorkerAsync();
                    bgw4.RunWorkerAsync();
                    bgw5.RunWorkerAsync();
                    bgw6.RunWorkerAsync();
                    bgw7.RunWorkerAsync();
                    bgw8.RunWorkerAsync();
                    bgw9.RunWorkerAsync();
                    bgw10.RunWorkerAsync();
                }
                else
                {
                    bgw1.RunWorkerAsync();
                }
            }
            
        }

        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < arrIndex[0]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[0]; i < arrIndex[1]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw3_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[1]; i < arrIndex[2]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw4_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[2]; i < arrIndex[3]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw5_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[3]; i < arrIndex[4]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw6_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[4]; i < arrIndex[5]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw7_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[5]; i < arrIndex[6]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw8_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[6]; i < arrIndex[7]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                //getid = dbsql.GetId_AllImage(Common.filename(pagesFilePath[i].ToString()));
                //dbsql.Insert_ImageContent(getid);
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw9_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[7]; i < arrIndex[8]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void bgw10_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = arrIndex[8]; i < arrIndex[9]; i++)
            {
                Bitmap imagepage = new Bitmap(pagesFilePath[i]);
                dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
                pageUp = pageUp + 1;
                // report progress.
                worker.ReportProgress(pageUp);
            }
        }

        private void grThongkeV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrive it from a configuration file.
            return "Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;";
        }
        private void InsertImageToServer_123(string Name, byte[] image)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    //sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "INSERT INTO dbo.ServerImage (NameImage,BinaryImage,DateCreated) VALUES (@NameImage,@VarImage,GETDATE())";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    //sqlCommand.Parameters.Add("@Iturn", SqlDbType.Int, 30).Value = turn;
                    con.Open();
                }
            }
            catch { }
        }
        private void frmUpdateImage_Load(object sender, EventArgs e)
        {
            //code UP ảnh

            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Compression;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, (long)EncoderValue.CompressionCCITT4);
            myEncoderParameters.Param[0] = myEncoderParameter;
            dt = dbsql.GetImageOnServer();
            grThongke.DataSource = dt;
            grThongkeV.Columns[0].Visible = false;
            btnUpImage.Enabled = false;
            cbb_ca.SelectedIndex = 0;
            lb_time.Text = "Time Up: 00";


            //string str_linkUp = @"D:\TAI LIEU\NNC\anhthieu";
            //pagesFilePath = Directory.GetFiles(str_linkUp, "*.jpeg", SearchOption.AllDirectories);

            //for (int i = 0; i < pagesFilePath.Length; i++)
            //{
            //    using (BackgroundWorker bgw = new BackgroundWorker())
            //    {
            //        Bitmap imagepage = new Bitmap(pagesFilePath[i]);
            //        dbsql.InsertImageToServer(Path.GetFileName(pagesFilePath[i]), imageToByteArray(imagepage));
            //    }
            //}

        }

        private void grThongkeV_MouseUp(object sender, MouseEventArgs e)
        {
            int r = grThongkeV.FocusedRowHandle;
            if (r > -1 )
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {   //click event
                    //MessageBox.Show("you got it!");
                    ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                    MenuItem menuItem = new MenuItem("Delete");
                    menuItem.Click += new EventHandler(DeleteAction);
                    contextMenu.MenuItems.Add(menuItem);
                    grThongke.ContextMenu = contextMenu;
                }
            }            
        }
        void DeleteAction(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa ảnh???","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ColumnView View = (ColumnView)grThongke.FocusedView;
                GridColumn column = View.Columns[grThongkeV.FocusedColumn.FieldName];
                if (grThongkeV.SelectedRowsCount == 0)
                {
                    return;
                }
                else if (grThongkeV.SelectedRowsCount > 1)
                {
                    for (int i = grThongkeV.SelectedRowsCount - 1; i >= 0; i--)
                    {
                        int rw = grThongkeV.GetSelectedRows()[i]; string test = grThongkeV.GetRowCellValue(rw, grThongkeV.Columns["NameImage"]).ToString();
                        string batchName = grThongkeV.GetRowCellValue(rw, grThongkeV.Columns["NameImage"]).ToString();//dt.Rows[rw]["NameImage"].ToString();
                        string id = grThongkeV.GetRowCellValue(rw, grThongkeV.Columns["Id"]).ToString();//dt.Rows[rw]["ID"].ToString();
                        dbsql.DeleteBatch(id, batchName);
                        dt.Rows.RemoveAt(rw);
                    }
                    grThongke.DataSource = null;
                }
                else
                {
                    int rw = grThongkeV.GetSelectedRows()[0];
                    string batchName = grThongkeV.GetRowCellValue(rw, grThongkeV.Columns["NameImage"]).ToString();//dt.Rows[rw]["NameImage"].ToString();
                    string id = grThongkeV.GetRowCellValue(rw, grThongkeV.Columns["Id"]).ToString();//dt.Rows[rw]["ID"].ToString();
                    dbsql.DeleteBatch(id, batchName);
                    dt.Rows.RemoveAt(rw);
                    grThongke.DataSource = null;
                }
                dt.Rows.Clear();
                dt = dbsql.GetImageOnServer();
                grThongke.DataSource = dt;
                grThongkeV.Columns[0].Visible = false;
                MessageBox.Show("Completed!");
            }
            else
            {
                return;
            }
        }

        private void bgrImage_DoWork(object sender, DoWorkEventArgs e)
        {
            //iturn = Convert.ToInt32(cbb_ca.Text.ToString());
            for (int i = 0; i < pagesFilePath.Length; i++)
            {
                //Turnup(Path.GetFileName(pagesFilePath[i]));
                dbsql.InsertImage(Path.GetFileName(pagesFilePath[i]), iturn);
            }
        }

        private void bgrImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblUp.Text = (pageUp).ToString();
            prbUpImage.Value = e.ProgressPercentage;
        }

        private void bgrImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblUp.Text = dbsql.countImage();
            //btnUpImage.Enabled = true;
            btnSourceDirectoryBrow.Enabled = true;
            prbUpImage.Value = pagesFilePathLength;
            grThongke.DataSource = null;
            dt = dbsql.GetImageOnServer();
            grThongke.DataSource = dt;
            grThongkeV.Columns[0].Visible = false;
            MessageBox.Show("Completed!");
            dt = dbsql.GetImageOnServer();
            grThongke.DataSource = dt;
            grThongkeV.Columns[0].Visible = false;
            TimeSpan timespan = DateTime.Now - time_start;
            lb_time.Text = "Time Up: --" + timespan.Hours + " :Hours - " + timespan.Minutes + " :Minutes - " + timespan.Seconds + " :Seconds";
        }

        private void btnDeleteall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hết batch không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbsql.Delete_AllBatch();
            }
            grThongke.DataSource = null;
            dt.Clear();
            dt = dbsql.GetBatch();
            grThongke.DataSource = dt;
            MessageBox.Show("Completed Delete All  !");
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

        private void frmUpdateImage_FormClosing(object sender, FormClosingEventArgs e)
        {

            //// Kiểm tra dữ liệu file Master khách hàng đã có chưa ?
            //string truong1 = dAEntry.GetStringSQL("select Count(Id) from dbo.[Master_Truong1]");

            //int sodong1 = Convert.ToInt32(truong1);
            //if (sodong1 < 1)
            //{
            //    MessageBox.Show("File Master Trường Số 1 chưa có trên Server !");
            //    e.Cancel = true;

            //}
            //string truong4 = dAEntry.GetStringSQL("select Count(Id) from dbo.[Master_Truong4]");
            //int sodong4 = Convert.ToInt32(truong4);
            //if (sodong4 < 1)
            //{
            //    MessageBox.Show("File Master Trường Số 4 chưa có trên Server !");
            //    e.Cancel = true;
            //}

            //if (CA == true)
            //{
            //    if (MessageBox.Show("Bạn chắc chắn đã Up file Master khách hàng chưa ? ", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //    {   // MessageBox.Show("Bạn đã chắc chắn Up file Master khách hàng chưa ? ","Thông Báo ")
            //        e.Cancel = true;
            //    }

            //}
        }
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        private void btn_importMaster_Click(object sender, EventArgs e)
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
            FolderBrowserDialogEx FileMst = new FolderBrowserDialogEx();
            FileMst.SelectedPath = strPreferenceToRemember;
            if (DialogResult.OK == FileMst.ShowDialog())
            {
                DataTable master_Server_truong1 = new DataTable();
                master_Server_truong1 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong1]");

                DataTable master_Server_truong4 = new DataTable();
                master_Server_truong4 = dAEntry.GetDatatableSQL("select * from dbo.[Master_Truong4]");

                //txtSourceDirectory.Text = FileMst.SelectedPath;
                int sl_FileMaster = Directory.GetFiles(FileMst.SelectedPath.ToString(), "*.csv", SearchOption.AllDirectories).Length;
                if ( sl_FileMaster != 2)
                {
                    MessageBox.Show(" Trong Folder chỉ được có 2 File Master CSV khách hàng thôi nhé ! ", " Thông Báo ");
                    return;
                }
                else
                {
                    string[] Mst_Plus = Directory.GetFiles(FileMst.SelectedPath.ToString(), "*.csv", SearchOption.AllDirectories);

                    for (int t = 0; t < 2; t++)
                    {
                        string nameFile = Path.GetFileName(Mst_Plus[t].ToString());
                        if (nameFile.Contains("custmst") == true)
                        {
                            //StreamReader mst_Plus = new StreamReader(Mst_Plus[t].ToString());
                            var Line = File.ReadAllLines(Mst_Plus[t].ToString());
                            string[] data_truong1 = Line;
                            for (int i = 1; i < data_truong1.Length; i++)
                            {
                                string[] data_Add = data_truong1[i].Replace("'", "").Split(',');
                                string add = data_Add[0].Trim();
                                string add2 = data_Add[1].Trim();

                                DataRow[] data_Add_new = master_Server_truong1.Select("Maso = '" + add + "'");
                                if (data_Add_new.Length == 0)
                                {
                                    dAEntry.ExecuteSQL("INSERT INTO dbo.[Master_Truong1] (Maso,Noidung) VALUES (N'" + add + "',N'" + add2 + "')");
                                }
                            }
                        }
                        else if (nameFile.Contains("prodmst") == true)
                        {
                            //StreamReader mst_Plus = new StreamReader(Mst_Plus[t].ToString());
                            var Line = File.ReadAllLines(Mst_Plus[t].ToString());
                            string[] data_truong4 = Line;
                            for (int i = 1; i < data_truong4.Length; i++)
                            {
                                string[] data_Add = data_truong4[i].Replace("'", "").Split(',');
                                string add = data_Add[0].Trim();
                                string add2 = data_Add[1].Trim();
                                string add3 = data_Add[2].Trim();
                                DataRow[] data_Add_new = master_Server_truong4.Select("MaSoPhu = '" + add + "'");
                                if (data_Add_new.Length == 0)
                                {
                                    dAEntry.ExecuteSQL("INSERT INTO dbo.[Master_Truong4] (MaSoPhu,MaSoChinh,NoiDung) VALUES (N'" + add + "',N'" + add2 + "',N'" + add3 + "')");
                                }
                            }
                        }
                    }
                    MessageBox.Show("Hoàn Thành Up File Master Trường 1 và Trường 4 !", "Hoàn thành !");
                }
            }
            else
            {
                return;
            }
        }

        private void grThongkeV_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
