using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry
{
    public partial class UpdateTool : Form
    {
        string file = "";
        OpenFileDialog open;
        DB_Update fc = new DB_Update();
        public UpdateTool()
        {
            InitializeComponent();
        }

        private void UpdateTool_Load(object sender, EventArgs e)
        {
            grdFile.DataSource = fc.getTenFile();
            //grvFile.Columns["FileCapNhat"].Visible = false;
            cbTenFile.DataSource = fc.getTenFile2();
            cbTenFile.ValueMember = "ID";
            cbTenFile.DisplayMember = "Tên File";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.RestoreDirectory = true;
            open.InitialDirectory = System.IO.Directory.GetCurrentDirectory().ToString();
            if (open.ShowDialog() != DialogResult.Cancel)
            {
                file = System.IO.Path.GetFileName(open.FileName);
                lbTenFile.Text = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (file != "")
            {
                Stream fl = open.OpenFile();
                fc.addFile(file, streamtobyte(fl), getStringDateTime());
            }
            else
                MessageBox.Show("Chưa chọn file!");
            MessageBox.Show("Đã xong!");
            grdFile.DataSource = fc.getTenFile();
        }
        public byte[] streamtobyte(Stream file)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public string getStringDateTime()
        {
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            return String.Format("{0:MM/dd/yyyy}", date); // "03/09/2008"
        }
        public void layFile()
        {
            string link = System.IO.Directory.GetCurrentDirectory().ToString();
            string tenF = "123";
            string tenD = ".exe";
            if (tenF != null && tenF != "")
            {
                SaveFileDialog save = new SaveFileDialog();
                string strfilename;
                save.RestoreDirectory = true;
                save.Title = "Export";
                //save.Filter = "Excel 2007 file|*.xlsx";
                save.FileName = tenF + tenD;
                save.OverwritePrompt = true;
                byte[] bt;
                if (!(save.ShowDialog() == DialogResult.Cancel))
                {
                    // progressBarEntry.Visible = true;
                    strfilename = save.FileName;
                    bt = fc.getFile();
                    try
                    {
                        // Open file for reading
                        System.IO.FileStream _FileStream =
                           new System.IO.FileStream(strfilename, System.IO.FileMode.Create,
                                                    System.IO.FileAccess.Write);
                        // Writes a block of bytes to this stream using data from
                        // a byte array.
                        _FileStream.Write(bt, 0, bt.Length);
                        // close file stream
                        _FileStream.Close();
                        MessageBox.Show("Đã lưu");
                    }
                    catch (Exception _Exception)
                    {
                        // Error
                        Console.WriteLine("Exception caught in process: {0}",
                                          _Exception.ToString());
                    }
                }
            }
            else
                MessageBox.Show("Không có file đính kèm");
        }
    }
}
