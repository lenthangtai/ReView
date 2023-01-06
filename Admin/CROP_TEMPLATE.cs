using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_Entry;
using VCB_Entry.CROP;
using VCB_YOBE;

namespace VCB_YOBE
{
    public partial class CROP_TEMPLATE : Form
    {
        public CROP_TEMPLATE()
        {
            InitializeComponent();
        }
        int valuezom = 9;
        double scale = 1;
        Bitmap imageSource;
        string fodersave = "";
        int vitrianh = 0;
        string[] arrimg;
        Pen PEN_DRAW = new Pen(Color.Red, 2);
        Pen PEN_DRAW_BLUE = new Pen(Color.Blue, 2);
        Brush BRUSH = new SolidBrush(Color.FromArgb(30, 127, 255, 0));
        Pen LineRed = new Pen(Color.Red, 3);
        private Graphics graphics;
        private bool mouseDown = false;
        private int x, y, x1, y1, x2, y2, width, height;
        DataTable dtfolder = new DataTable();
        List<List<DataTable>> lstalldtve = new List<List<DataTable>>();
        List<List<DataTable>> lstallmstdt = new List<List<DataTable>>();
        List<DataTable> lstdtve = new List<DataTable>();
        List<DataTable> lstdtvemsdt = new List<DataTable>();
        DataTable dtvediem = new DataTable();
        DataTable dtmsdt = new DataTable();
        string[] arrfile;
        bool reopen = false;
        DataTable dtsave = new DataTable();
        DataTable dtalldot = new DataTable();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Patheven.txt";
        public string GetConnectionString()
        { return "Data Source=192.168.1.3;Initial Catalog=AI_OCR_IN;User Id=sa;Password=Vbpo@#$123;Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;"; }
        private void AI_OCR_Load(object sender, EventArgs e)
        {

            splitContainer1.SplitterDistance = this.Width - cbolangue.Width - 50;
            dtfolder.Columns.Add("folder", typeof(string));
            dtfolder.Columns.Add("Loca", typeof(string));
            dtalldot = ClassData2.GetDatatableSQL("Select distinct(Dot) as 'Dot' from dbo.Template_Location");
            if (dtalldot.Rows.Count > 0)
            {
                cbosave.DataSource = dtalldot;
                cbosave.DisplayMember = "Dot";
            }
        }
        int currentindex = -1;
        string cbosavetext = "";
        private void cbosave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbosave.SelectedIndex > -1)
            {
                if (currentindex != cbosave.SelectedIndex || currentindex == -1)
                {
                    cbosavetext = dtalldot.Rows[cbosave.SelectedIndex][0].ToString();
                    currentindex = cbosave.SelectedIndex;
                    current = -1;
                    lstalldtve = new List<List<DataTable>>();
                    lstallmstdt = new List<List<DataTable>>();
                    lstdtve = new List<DataTable>();
                    lstdtvemsdt = new List<DataTable>();
                    dtfolder.Clear();
                    scale = 1;
                    valuezom = 4;
                    dtsave = new DataTable();
                    dtsave = ClassData2.GetDatatableSQL("select TenMon,ImageName,LocationMsdt ,LocationDiem, Id from dbo.Template_Location where Dot = N'" + cbosavetext + "'");
                    DataView view = new DataView(dtsave);
                    DataTable dtfoldernew = view.ToTable(true, "TenMon");
                    dtfoldernew.Columns.Add("Loca");
                    dtfolder = dtfoldernew.Copy();
                    for (int i = 0; i < dtfolder.Rows.Count; i++)
                    {
                        string tenmonthi = dtfolder.Rows[i][0].ToString();
                        lstdtve = new List<DataTable>();
                        lstdtvemsdt = new List<DataTable>();
                        DataTable dtimg = dtsave.Select("TenMon = '" + tenmonthi + "'").CopyToDataTable();
                        for (int j = 0; j < dtimg.Rows.Count; j++)
                        {
                            dtvediem = new DataTable();
                            dtmsdt = new DataTable();
                            dtvediem.Columns.Add("A", typeof(string));
                            dtvediem.Columns.Add("Loc", typeof(string));
                            dtvediem.Columns.Add("Id", typeof(string));
                            dtmsdt.Columns.Add("A", typeof(string));
                            dtmsdt.Columns.Add("Loca", typeof(string));
                            dtmsdt.Columns.Add("Id", typeof(string));
                            if (dtimg.Rows[j][3].ToString() != "")
                            {
                                string[] arrsave = dtimg.Rows[j][3].ToString().Split('|');
                                for (int k = 0; k < arrsave.Length; k++)
                                { dtvediem.Rows.Add(((k + 1).ToString().PadLeft(2, '0') + "|" + arrsave[k] + "|" + dtimg.Rows[j]["Id"].ToString()).Split('|')); }
                            }
                            if (dtimg.Rows[j][2].ToString() != "")
                            {
                                string[] arrsavemsdt = dtimg.Rows[j][2].ToString().Split('|');
                                for (int k = 0; k < arrsavemsdt.Length; k++)
                                { dtmsdt.Rows.Add(("MSDT|" + arrsavemsdt[k] + "|" + dtimg.Rows[j]["Id"].ToString()).Split('|')); }
                            }
                            //dtvediem.Rows[]
                            lstdtve.Add(dtvediem);
                            lstdtvemsdt.Add(dtmsdt);
                        }
                        lstalldtve.Add(lstdtve);
                        lstallmstdt.Add(lstdtvemsdt);
                    }
                    reopen = true;
                    dtfolder.Columns[0].ColumnName = "folder";
                    cbolangue.DataSource = dtfolder;
                    cbolangue.DisplayMember = "folder";
                }
            }
        }
        private void btndeldot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đợt " + cbosavetext + "", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { ClassData2.ExecuteSQL("Delete from dbo.Template_Location where Dot = N'" + cbosavetext + "'"); }
            if (reopen)
            {
                dtalldot = ClassData2.GetDatatableSQL("Select distinct(Dot) as 'Dot' from dbo.Template_Location");
                if (dtalldot.Rows.Count > 0)
                {
                    currentindex = -1;
                    cbosave.DataSource = dtalldot;
                    cbosave.DisplayMember = "Dot";
                }
                else
                {
                    pbimg.Image = null;
                    pbimg.Refresh();
                    lblimage.Text = ""; txtinput.Text = "0"; lblsoanh.Text = "0";
                    lstalldtve = new List<List<DataTable>>();
                    lstallmstdt = new List<List<DataTable>>();
                    lstdtve = new List<DataTable>();
                    lstdtvemsdt = new List<DataTable>();
                    cbomsdt.DataSource = null;
                    cbodraw.DataSource = null;
                    dtfolder.Clear();
                }
            }
        }
        private void btnselectfolder_Click(object sender, EventArgs e)
        {
            string strPreferenceToRemember = @"C:\";
            if (File.Exists(path))
            { strPreferenceToRemember = File.ReadAllText(path); }
            else
            { File.WriteAllText(path, strPreferenceToRemember); }
            FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            fbd.SelectedPath = strPreferenceToRemember;
            if (DialogResult.OK == fbd.ShowDialog())
            {
                dtfolder.Clear();
                lstalldtve = new List<List<DataTable>>();
                reopen = false;
                File.WriteAllText(path, fbd.SelectedPath);
                arrfile = Directory.GetDirectories(fbd.SelectedPath);
                lstalldtve = new List<List<DataTable>>();
                lstallmstdt = new List<List<DataTable>>();
                lstdtve = new List<DataTable>();
                lstdtvemsdt = new List<DataTable>();
                for (int i = 0; i < arrfile.Length; i++)
                {
                    dtfolder.Rows.Add((Path.GetFileName(arrfile[i]) + "|" + arrfile[i]).Split('|'));
                    string[] arrimgcheck = Directory.GetFiles(arrfile[i], "*.jpg");
                    if (arrimgcheck.Length == 0)
                    {
                        MessageBox.Show("Folder " + arrfile[i] + " không có ảnh!");
                        break;
                    }
                    for (int j = 0; j < arrimgcheck.Length; j++)
                    {
                        dtvediem = new DataTable();
                        dtmsdt = new DataTable();
                        dtvediem.Columns.Add("A", typeof(string));
                        dtvediem.Columns.Add("Loc", typeof(string));
                        dtmsdt.Columns.Add("A", typeof(string));
                        dtmsdt.Columns.Add("Loca", typeof(string));
                        lstdtve.Add(dtvediem);
                        lstdtvemsdt.Add(dtmsdt);
                    }
                    lstalldtve.Add(lstdtve);
                    lstallmstdt.Add(lstdtvemsdt);
                }
                current = -2;
                cbolangue.DataSource = null;
                cbolangue.DataSource = dtfolder;
                cbolangue.DisplayMember = "folder";
                txt_tendot.Text = "";
                txt_tendot.Visible = true;
            }
            else
            { return; }
        }
        int current = -1;
        private void cbolangue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbolangue.SelectedIndex > -1 && cbolangue.SelectedIndex != current)
            {
                current = cbolangue.SelectedIndex;
                if (reopen)
                {
                    arrimg = dtsave.Select("TenMon = '" + dtfolder.Rows[current][0].ToString() + "'").CopyToDataTable().Rows.OfType<DataRow>().Select(r => r[1].ToString()).ToArray();
                    if (arrimg.Length > 0)
                    {
                        vitrianh = 0;
                        imageSource = new Bitmap(Support.byteArrayToImage(ClassData2.getImageOnServer(arrimg[vitrianh], "Template_Location", cbosavetext)));
                        //pbimg.Image = imageSource;
                        lblimage.Text = arrimg[vitrianh];
                        lblsoanh.Text = " / " + arrimg.Length;
                        txtinput.Text = (vitrianh + 1).ToString();
                    }
                }
                else
                {
                    arrimg = Directory.GetFiles(dtfolder.Rows[cbolangue.SelectedIndex][1].ToString(), "*.jpg");
                    if (arrimg.Length > 0)
                    {
                        vitrianh = 0;
                        imageSource = new Bitmap(arrimg[vitrianh]);
                        //pbimg.Image = imageSource;
                        lblimage.Text = Path.GetFileName(arrimg[vitrianh]);
                        lblsoanh.Text = " / " + arrimg.Length;
                        txtinput.Text = (vitrianh + 1).ToString();
                    }
                }
                pbimg.Image = imageSource;
                zoomimage();
                //pbimg.Refresh();
                cbodraw.DataSource = lstalldtve[current][0];
                cbodraw.DisplayMember = "A";
                cbomsdt.DataSource = lstallmstdt[current][0];
                cbomsdt.DisplayMember = "A";
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }



        public Bitmap ZoomImage2(Bitmap img, double scale)
        {
            int width = 0;
            int height = 0;
            try
            {
                width = Convert.ToInt32(img.Width * scale);
                height = Convert.ToInt32(img.Height * scale);
            }
            catch
            { }
            return new Bitmap(img, width, height);
        }
        private void pbimg_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        try
                        {
                            if (valuezom > 2)
                            valuezom--;
                            else
                            { valuezom = 9; }
                        }
                        catch { valuezom = 9; }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        try
                        {
                            if (valuezom < 9)
                                valuezom++;
                            else
                            { valuezom = 1; }
                        }
                        catch { valuezom = 1; }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                    { valuezom = 4; }
                    zoomimage();
                }
                catch { }
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (pbimg.Image != null)
                    {
                        mouseDown = true;
                        x1 = e.X;
                        y1 = e.Y;
                    }
                }
            }
        }
        public void zoomimage()
        {
            if (pbimg.Image != null)
            {
                scale = (double)valuezom / 9;
                //this.Text = valuezom + " - " + scale.ToString();
                pbimg.Image = Common.ZoomImage((Bitmap)imageSource, scale);
                drawimage();
            }
        }

        public void drawimage()
        {
            DataTable dtv = lstalldtve[current][vitrianh].Copy();
            DataTable dtvmsdt = lstallmstdt[current][vitrianh].Copy();
            int _x = 0;
            int _y = 0;
            int wid = 0;
            int hei = 0;
            pbimg.Refresh();
            for (int i = 0; i < dtv.Rows.Count; i++)
            {
                try
                {
                    dtv.Rows[i][0] = (i + 1).ToString().PadLeft(2, '0');
                    _x = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[0]) * scale);
                    _y = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[1]) * scale);
                    wid = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[2]) * scale);
                    hei = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[3]) * scale);
                    graphics = pbimg.CreateGraphics();
                    graphics.DrawRectangle(PEN_DRAW, _x, _y, wid, hei);
                    graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
                    graphics.DrawString((i + 1).ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Red), _x, _y);
                }
                catch { }
            }
            try
            {
                dtvmsdt.Rows[0][0] = "01";
                _x = Convert.ToInt32(Convert.ToInt32(dtvmsdt.Rows[0][1].ToString().Split(',')[0]) * scale);
                _y = Convert.ToInt32(Convert.ToInt32(dtvmsdt.Rows[0][1].ToString().Split(',')[1]) * scale);
                wid = Convert.ToInt32(Convert.ToInt32(dtvmsdt.Rows[0][1].ToString().Split(',')[2]) * scale);
                hei = Convert.ToInt32(Convert.ToInt32(dtvmsdt.Rows[0][1].ToString().Split(',')[3]) * scale);
                graphics = pbimg.CreateGraphics();
                graphics.DrawRectangle(PEN_DRAW_BLUE, _x, _y, wid, hei);
                graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
                graphics.DrawString("MSDT", new Font("Arial", 12), new SolidBrush(Color.Blue), _x, _y);
            }
            catch { }

        }
        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                { return true; }
            }
            catch
            { return false; }
        }

        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }


        private void pbimg_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ModifierKeys.HasFlag(Keys.Control))
            {
                //xcopy = Convert.ToInt32(e.X / scale); ycopy = Convert.ToInt32(e.Y / scale);
                if (pbimg.Image != null)
                {
                    if (mouseDown)
                    {
                        if (e.X < 0)
                        { x2 = 0; }
                        else
                        { x2 = e.X; }

                        if (e.Y < 0)
                        { y2 = 0; }
                        else
                        { y2 = e.Y; }
                        //pnTemplate.AutoScrollPosition = new Point(x2 - pnTemplate.Width, y2 - pnTemplate.Height);
                        System.Threading.Thread.Sleep(50);
                        width = Math.Abs(x2 - x1);
                        height = Math.Abs(y2 - y1);
                        pbimg.Refresh();
                        graphics = pbimg.CreateGraphics();
                        if (x1 < x2 && y1 < y2)
                        {
                            x = x1;
                            y = y1;

                            if (x + width > pbimg.Width)
                            {
                                width = pbimg.Width - x;
                                panel1.AutoScrollPosition = new Point(x2, y2);
                            }
                            if (y + height > pbimg.Height)
                            {
                                height = pbimg.Height - y;
                                panel1.AutoScrollPosition = new Point(x2, y2);
                            }

                            graphics.DrawRectangle(PEN_DRAW, x, y, width, height);
                            graphics.FillRectangle(BRUSH, x, y, width, height);
                        }
                        else if (x1 < x2 && y1 > y2)
                        {
                            x = x1;
                            y = y2;
                            if (x + width > imageSource.Width)
                            {
                                width = imageSource.Width - x;
                                panel1.AutoScrollPosition = new Point(x2, y2);
                            }
                            graphics.DrawRectangle(PEN_DRAW, x, y, width, height);
                            graphics.FillRectangle(BRUSH, x, y, width, height);
                        }
                        else if (x1 > x2 && y1 > y2)
                        {
                            x = x2;
                            y = y2;

                            graphics.DrawRectangle(PEN_DRAW, x, y, width, height);
                            graphics.FillRectangle(BRUSH, x, y, width, height);
                        }
                        else if (x1 > x2 && y1 < y2)
                        {
                            x = x2;
                            y = y1;

                            if (y + height > imageSource.Height)
                            {
                                height = imageSource.Height - y;
                                panel1.AutoScrollPosition = new Point(x2, y2);
                            }

                            graphics.DrawRectangle(PEN_DRAW, x, y, width, height);
                            graphics.FillRectangle(BRUSH, x, y, width, height);
                        }
                        // convert to nomal size
                        //this.Text = x + " - " + y + " - " + width + " - " + height;
                        x = Convert.ToInt32(x / scale);
                        y = Convert.ToInt32(y / scale);
                        width = Convert.ToInt32(width / scale);
                        height = Convert.ToInt32(height / scale);
                        
                    }
                }
            }
        }

        private void pbimg_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ModifierKeys.HasFlag(Keys.Control))
            {
                if (pbimg.Image != null && mouseDown)
                {
                    mouseDown = false;
                    //this.Text = x + " - " + y + " - " + width + " - " + height + " + " + pbimg.Width + " - " + pbimg.Height + " + " + imageSource.Width + " - " + imageSource.Height; 

                    //try
                    // {
                    if (width < 20 || height < 20)
                    {
                        MessageBox.Show("Size too small!");
                        drawimage();
                        return;
                    }
                    else
                    {
                        if (!reopen)
                        {
                            if (rdbdiem.Checked)
                            {
                                if (cbodraw.SelectedIndex == lstalldtve[current][vitrianh].Rows.Count - 1)
                                { lstalldtve[current][vitrianh].Rows.Add(((lstalldtve[current][vitrianh].Rows.Count + 1).ToString().PadLeft(2, '0') + "|" + x + "," + y + "," + width + "," + height).Split('|')); }
                                else
                                { lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString(); }
                                x = 0; y = 0; width = 0; height = 0;
                                cbodraw.SelectedIndex = lstalldtve[current][vitrianh].Rows.Count - 1;
                            }
                            else
                            {
                                if (lstallmstdt[current][vitrianh].Rows.Count == 0)
                                { lstallmstdt[current][vitrianh].Rows.Add(("MSDT|" + x + "," + y + "," + width + "," + height).Split('|')); }
                                else
                                { lstallmstdt[current][vitrianh].Rows[0][1] = (x + "," + y + "," + width + "," + height).ToString(); }
                            }
                        }
                        else
                        {
                            int idim = ClassData.GetIntSQL("Select Id from dbo.Template_Location where Dot = N'" + cbosavetext + "' and TenMon = N'" + cbolangue.Text + "' and ImageName = N'" + lblimage.Text + "'");
                            if (rdbdiem.Checked)
                            {
                                if (cbodraw.SelectedIndex == lstalldtve[current][vitrianh].Rows.Count - 1)
                                { lstalldtve[current][vitrianh].Rows.Add(((lstalldtve[current][vitrianh].Rows.Count + 1).ToString().PadLeft(2, '0') + "|" + x + "," + y + "," + width + "," + height + "|" + idim.ToString()).Split('|')); }
                                else
                                {
                                    lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString();
                                    lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex]["Id"] = idim.ToString();
                                }
                                x = 0; y = 0; width = 0; height = 0;
                                try
                                { cbodraw.SelectedIndex = lstalldtve[current][vitrianh].Rows.Count - 1; }
                                catch { }
                            }
                            else
                            {
                                if (lstallmstdt[current][vitrianh].Rows.Count == 0)
                                { lstallmstdt[current][vitrianh].Rows.Add(("MSDT|" + x + "," + y + "," + width + "," + height + "|" + idim.ToString()).Split('|')); }
                                else
                                {
                                    lstallmstdt[current][vitrianh].Rows[0][1] = (x + "," + y + "," + width + "," + height).ToString();
                                    lstallmstdt[current][vitrianh].Rows[0]["Id"] = idim.ToString();
                                }
                            }
                        }
                        drawimage();
                    }
                    //}
                    //catch { }
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                lstalldtve[current][vitrianh].Rows.RemoveAt(cbodraw.SelectedIndex);
                drawimage();
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { lstalldtve[current][vitrianh].Rows.Clear(); cbodraw.DataSource = lstalldtve[current][vitrianh]; cbodraw.DisplayMember = "A"; drawimage(); }
            catch { }
        }
        static byte[] imageToByteArray(Bitmap imageIn)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!reopen)
            {
                if (txt_tendot.Text.Trim() == "")
                {
                    txt_tendot.Focus();
                    MessageBox.Show("Nhập tên đợt đi bạn");
                    return;
                }
                else
                {
                    if (ClassData2.GetIntSQL("Select Count(Id) from dbo.Template_Location where Dot = N'" + txt_tendot.Text.Trim() + "'") > 0)
                    {
                        txt_tendot.Text = "";
                        txt_tendot.Focus();
                        MessageBox.Show("Tên đợt đã tồn tại! " + Environment.NewLine + "(  Gợi ý: " + txt_tendot.Text.Trim() + "-2  )");
                        return;
                    }
                }
                //ClassData2.ExecuteSQL("Delete from dbo.Template_Location");
                for (int i = 0; i < dtfolder.Rows.Count; i++)
                {
                    string tenmon = dtfolder.Rows[i][0].ToString();
                    string[] arrfileup = Directory.GetFiles(dtfolder.Rows[i][1].ToString(), "*.jpg");
                    for (int j = 0; j < arrfileup.Length; j++)
                    {
                        Bitmap imagepage = new Bitmap(arrfileup[j]);
                        string realsize = imagepage.Width + "," + imagepage.Height;
                        string location = string.Join("|", lstalldtve[i][j].Rows.OfType<DataRow>().Select(r => r[1].ToString()));
                        string locationmsdt = "";
                        if (lstallmstdt[i][j].Rows.Count > 0)
                        { locationmsdt = lstallmstdt[i][j].Rows[0][1].ToString(); }
                        ClassData2.ExecuteSQL_Para("Insert into dbo.Template_Location(BinaryImage,TenMon,ImageName,LocationMsdt,LocationDiem, Dot, RealSize) values (@varimage ,@TenMon,@ImageName,N'" + locationmsdt + "', N'" + location + "', N'" + txt_tendot.Text.Trim() + "', N'" + realsize + "')", Path.GetFileName(arrfileup[j]), tenmon, imageToByteArray(imagepage));
                    }
                }
                dtalldot = new DataTable();
                cbosave.DataSource = null;
                dtalldot = ClassData2.GetDatatableSQL("Select distinct(Dot) as 'Dot' from dbo.Template_Location");
                if (dtalldot.Rows.Count > 0)
                {
                    cbosave.DataSource = dtalldot;
                    cbosave.DisplayMember = "Dot";
                    try
                    {
                        reopen = true;
                        txt_tendot.Text = "";
                        txt_tendot.Visible = false;
                        cbosave.SelectedIndex = dtalldot.Rows.Count - 1;
                    }
                    catch
                    { this.Close(); }
                }
            }
            else
            {
                ClassData2.ExecuteSQL("Update dbo.Template_Location set LocationDiem = '', LocationMsdt = '' where Dot = N'" + cbosavetext + "'");
                int alllstve = lstalldtve.Count;
                for (int i = 0; i < alllstve; i++)
                {
                    int countdtve = lstalldtve[i].Count;
                    for (int j = 0; j < countdtve; j++)
                    {
                        DataTable dtdrawdiem = lstalldtve[i][j].Copy();
                        DataTable dtdrawmsdt = lstallmstdt[i][j].Copy();
                        string idupdate = "0"; string location = "";
                        if (dtdrawdiem.Rows.Count > 0)
                        {
                            idupdate = dtdrawdiem.Rows[0][2].ToString();
                            location = string.Join("|", dtdrawdiem.Rows.OfType<DataRow>().Select(r => r[1].ToString()));
                        }
                        string locationmsdt = "";
                        if (dtdrawmsdt.Rows.Count > 0)
                        { locationmsdt = dtdrawmsdt.Rows[0][1].ToString(); }
                        ClassData.ExecuteSQL("Update dbo.Template_Location set LocationDiem = N'" + location + "', LocationMsdt = N'" + locationmsdt + "' where Id = " + idupdate);
                    }
                }
            }
            MessageBox.Show("Complete!");
        }

        private void AI_OCR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            { rdbdiem.Checked = true; }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            { rdbmsdt.Checked = true; }
            else if (e.KeyCode == Keys.F1)
            { btnsubmit_Click(sender, e); }
            else if (e.KeyCode == Keys.F3)
            {
                if (rdbdiem.Checked)
                { btndelete_Click(sender, e); }
                else
                { button4_Click(sender, e); }
            }
        }

        private void AI_OCR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn tắt chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            { e.Cancel = true; }
        }

        private void cbomsdt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                lstallmstdt[current][vitrianh].Rows.RemoveAt(cbomsdt.SelectedIndex);
                drawimage();
            }
            catch { }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        try
                        { valuezom--; }
                        catch { valuezom = 9; }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        try
                        { valuezom++; }
                        catch { valuezom = 1; }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                    { valuezom = 9; }
                    zoomimage();
                }
                catch { }
            }
        }

        private void btnviewdemo_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Show_Demo frmshow = new Frm_Show_Demo();
                if (lstalldtve[current][vitrianh].Rows.Count > 0)
                {
                    frmshow.dtdraw = lstalldtve[current][vitrianh];
                    frmshow.imgshow = imageSource;
                    frmshow.ShowDialog();
                }
                else
                { MessageBox.Show("Chưa vẽ vùng điểm!"); }
            }
            catch { }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            { lstallmstdt[current][vitrianh].Rows.Clear(); cbodraw.DataSource = lstallmstdt[current][vitrianh]; cbodraw.DisplayMember = "A"; drawimage(); }
            catch { }
        }




        private void btnback_Click(object sender, EventArgs e)
        {
            if (arrimg != null)
            {
                if (vitrianh == 0)
                { vitrianh = arrimg.Length - 1; }
                else
                { vitrianh--; }
                if (arrimg.Length > 0)
                {
                    if (reopen)
                    { imageSource = new Bitmap(Support.byteArrayToImage(ClassData2.getImageOnServer(arrimg[vitrianh], "Template_Location", cbosavetext))); lblimage.Text = arrimg[vitrianh]; }
                    else
                    { imageSource = new Bitmap(arrimg[vitrianh]); lblimage.Text = Path.GetFileName(arrimg[vitrianh]); }
                    pbimg.Image = imageSource;
                    lblsoanh.Text = " / " + arrimg.Length;
                    txtinput.Text = (vitrianh + 1).ToString();
                    //pbimg.Image = ZoomImage2(imageSource, scale);
                    zoomimage();
                    cbodraw.DataSource = lstalldtve[current][vitrianh];
                    cbodraw.DisplayMember = "A";
                    cbomsdt.DataSource = lstallmstdt[current][vitrianh];
                    cbomsdt.DisplayMember = "A";
                    drawimage();
                }
                else
                {
                    pbimg.Image = ZoomImage2(imageSource, scale);
                }
                //lblimage.Text = Path.GetFileName(arrimg[vitrianh]);
                cbodraw.DataSource = lstalldtve[current][vitrianh];
                cbodraw.DisplayMember = "A";
                cbomsdt.DataSource = lstallmstdt[current][vitrianh];
                cbomsdt.DisplayMember = "A";
                drawimage();
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (arrimg != null)
            {
                if (vitrianh == arrimg.Length - 1)
                { vitrianh = 0; }
                else
                { vitrianh++; }


                //arrimg = dtfolder.Rows.OfType<DataRow>().Select(r => r[1].ToString()).ToArray();
                if (arrimg.Length > 0)
                {
                    if (reopen)
                    { imageSource = new Bitmap(Support.byteArrayToImage(ClassData2.getImageOnServer(arrimg[vitrianh], "Template_Location", cbosavetext))); lblimage.Text = arrimg[vitrianh]; }
                    else
                    { imageSource = new Bitmap(arrimg[vitrianh]); lblimage.Text = Path.GetFileName(arrimg[vitrianh]); }
                    //pbimg.Image = imageSource;
                    //this.Text = imageSource.Width + " - " + imageSource.Height;
                    lblsoanh.Text = " / " + arrimg.Length;
                    txtinput.Text = (vitrianh + 1).ToString();
                    //pbimg.Image = ZoomImage2(imageSource, scale);
                    zoomimage();
                    cbodraw.DataSource = lstalldtve[current][vitrianh];
                    cbodraw.DisplayMember = "A";
                    cbomsdt.DataSource = lstallmstdt[current][vitrianh];
                    cbomsdt.DisplayMember = "A";
                    drawimage();
                }
            }
        }
        private void txtinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (arrimg != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int i = 0;
                    if (!int.TryParse(txtinput.Text, out i))
                    { txtinput.Text = (vitrianh + 1).ToString(); }
                    else
                    {
                        int kiemtra = Convert.ToInt32(txtinput.Text);
                        if (kiemtra > 0)
                        {
                            kiemtra--;
                            if (kiemtra > arrimg.Length)
                            { vitrianh = arrimg.Length - 1; }
                            else
                            { vitrianh = kiemtra; }
                        }
                        else
                        { vitrianh = 0; }
                        if (arrimg.Length > 0)
                        {
                            vitrianh = 0;
                            if (reopen)
                            { imageSource = new Bitmap(Support.byteArrayToImage(ClassData2.getImageOnServer(arrimg[vitrianh], "Template_Location", cbosavetext))); lblimage.Text = arrimg[vitrianh]; }
                            else
                            { imageSource = new Bitmap(arrimg[vitrianh]); lblimage.Text = Path.GetFileName(arrimg[vitrianh]); }
                            pbimg.Image = imageSource;
                            lblsoanh.Text = " / " + arrimg.Length;
                            txtinput.Text = (vitrianh + 1).ToString();
                            //pbimg.Image = ZoomImage(imageSource, scale);
                            zoomimage();
                            cbodraw.DataSource = lstalldtve[current][vitrianh];
                            cbodraw.DisplayMember = "A";
                            cbomsdt.DataSource = lstallmstdt[current][vitrianh];
                            cbomsdt.DisplayMember = "A";
                            drawimage();
                        }
                        else
                        { pbimg.Image = ZoomImage2(imageSource, scale); }
                        cbodraw.DataSource = lstalldtve[current][vitrianh];
                        cbodraw.DisplayMember = "A";
                        cbomsdt.DataSource = lstallmstdt[current][vitrianh];
                        cbomsdt.DisplayMember = "A";
                        drawimage();
                    }
                }
            }
        }
    }
}
