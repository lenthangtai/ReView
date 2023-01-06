using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry.Admin
{
    public partial class Form_Crop : Form
    {
        private Graphics graphics;
        Pen PEN_DRAW = new Pen(Color.Red, 2);
        Pen PEN_DRAW_BLUE = new Pen(Color.Blue, 2);
        Brush BRUSH = new SolidBrush(Color.FromArgb(30, 127, 255, 0));
        Pen LineRed = new Pen(Color.Red, 3);
        DAEntry_Entry daentry = new DAEntry_Entry();
        WorkDB_Admin wb_ad = new WorkDB_Admin();
        public Form_Crop()
        {
            InitializeComponent();
        }
        public DataTable dt_template;
        public int index_row;
        int x, y, x1, y1, x2, y2, width, height;
        DataTable role_tem = new DataTable();
        DataTable role_tem_truong1 = new DataTable();
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameters myEncoderParameters;
        EncoderParameter myEncoderParameter;
        private void Form_Crop_Load(object sender, EventArgs e)
        {
            myImageCodecInfo = GetEncoderInfo("image/png");
            role_tem = new DataTable();
            role_tem.Columns.Add("Role");
            role_tem.Columns.Add("Poi");
            role_tem_truong1 = role_tem.Clone();
            cbb_form.DataSource = null;
            cbb_form.DataSource = dt_template;
            cbb_form.DisplayMember = "TempName";
            cbb_form.SelectedIndex = index_row;            
        }
        Bitmap imageSource;
        string[] data_role ;
        int select_form = 0;
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
        private void cbb_form_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (index_row > -1)
            {
                index_row = cbb_form.SelectedIndex;
                string Role = dt_template.Rows[index_row]["Rules"].ToString();
                string poi = dt_template.Rows[index_row]["Poi_Rules"].ToString();
                string poi_truong1 = dt_template.Rows[index_row]["Poi_Rules_Truong1"].ToString();//Poi_Rules_Truong1
                role_tem.Clear();
                for (int i = 0; i < Role.Split(',').Length; i++)
                {
                    if (poi == "")
                    {
                        role_tem.Rows.Add(Role.Split(',')[i].ToString());
                    }
                    else
                    {
                        role_tem.Rows.Add(Role.Split(',')[i].ToString(), poi.Split('|')[i].ToString());
                    }
                }
                cbb_role_img.DataSource = role_tem;
                cbb_role_img.DisplayMember = "Role";
                cbb_Role1.SelectedIndex = 0;
                grd_poi.DataSource = null;
                grd_poi.DataSource = role_tem;
                role_tem_truong1.Clear();
                for (int i = 0; i < 3; i++)
                {
                    if (poi_truong1 == "")
                    {
                        role_tem_truong1.Rows.Add((i+1).ToString());
                    }
                    else
                    {
                        role_tem_truong1.Rows.Add((i + 1).ToString(), poi_truong1.Split('|')[i].ToString());
                    }
                }
                
                grid_1.DataSource = null;
                grid_1.DataSource = role_tem_truong1;
                DataTable img_sourc = new DataTable();
                img_sourc = daentry.GetDatatableSQL("Select Image_Draw from dbo.[Template] where TempName = N'" + cbb_form.Text + "'");
                try
                {
                    imageSource = null;
                    imageSource = new Bitmap(byteArrayToImage((byte[])img_sourc.Rows[0]["Image_Draw"]));
                    pbimg.Image = imageSource;
                    cbb_role_img.Enabled = true; btndeldot.Enabled = true; btnsubmit.Enabled = true; cbb_Role1.Enabled = true;btn_Del_truong1.Enabled = true;
                }
                catch
                {
                    cbb_role_img.Enabled = false; btndeldot.Enabled = false; btnsubmit.Enabled = false; cbb_Role1.Enabled = false; btn_Del_truong1.Enabled = false;
                }
                valuezom = 2; scale = 1;
                data_role = poi.Split('|');
                select_form = 0;
                reopen = true;
            }
        }
        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
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
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        bool reopen = false;
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
                        if (rdo_ROle1.Checked)
                        {
                            if (cbb_Role1.SelectedIndex == role_tem_truong1.Rows.Count - 1)
                            {
                                role_tem_truong1.Rows[cbb_Role1.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString();
                                //role_tem.Rows.Add(((lstalldtve[current][vitrianh].Rows.Count + 1).ToString().PadLeft(2, '0') + "|" + x + "," + y + "," + width + "," + height + "|" + idim.ToString()).Split('|'));
                            }
                            else
                            {
                                role_tem_truong1.Rows[cbb_Role1.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString();
                                //lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex]["Id"] = idim.ToString();
                            }
                            x = 0; y = 0; width = 0; height = 0;
                            try
                            {
                            }
                            catch { }
                            //if (cbodraw.SelectedIndex == lstalldtve[current][vitrianh].Rows.Count - 1)
                            //{ lstalldtve[current][vitrianh].Rows.Add(((lstalldtve[current][vitrianh].Rows.Count + 1).ToString().PadLeft(2, '0') + "|" + x + "," + y + "," + width + "," + height).Split('|')); }
                            //else
                            //{ lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString(); }
                            //x = 0; y = 0; width = 0; height = 0;
                            //cbodraw.SelectedIndex = lstalldtve[current][vitrianh].Rows.Count - 1;
                        }
                        else
                        {
                            //int idim = ClassData.GetIntSQL("Select Id from dbo.Template_Location where Dot = N'" + cbosavetext + "' and TenMon = N'" + cbolangue.Text + "' and ImageName = N'" + lblimage.Text + "'");
                            
                            if (cbb_role_img.SelectedIndex == role_tem.Rows.Count -1)
                            {
                                role_tem.Rows[cbb_role_img.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString();
                                //role_tem.Rows.Add(((lstalldtve[current][vitrianh].Rows.Count + 1).ToString().PadLeft(2, '0') + "|" + x + "," + y + "," + width + "," + height + "|" + idim.ToString()).Split('|'));
                            }
                            else
                            {
                                role_tem.Rows[cbb_role_img.SelectedIndex][1] = (x + "," + y + "," + width + "," + height).ToString();
                                //lstalldtve[current][vitrianh].Rows[cbodraw.SelectedIndex]["Id"] = idim.ToString();
                            }
                            x = 0; y = 0; width = 0; height = 0;
                            try
                            {
                                //cbodraw.SelectedIndex = lstalldtve[current][vitrianh].Rows.Count - 1;
                                //cbb_role_img.SelectedIndex = lstalldtve[current][vitrianh].Rows.Count - 1;
                            }
                            catch { }
                        }
                        drawimage();
                    }
                    //}
                    //catch { }
                }
            }
        }
        private void btndeldot_Click(object sender, EventArgs e)
        {
            if (cbb_role_img.SelectedIndex > -1)
            {
                if (MessageBox.Show("Xóa tọa độ của Role đang chọn ???","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    role_tem.Rows[cbb_role_img.SelectedIndex][1] = "";
                    drawimage();
                }
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            bool data_full = true;
            //for (int i = 0; i < role_tem.Rows.Count; i++)
            //{
            //    if (role_tem.Rows[i][1].ToString() == "")
            //    {
            //        data_full = false;
            //        break;
            //    }
            //}
            if (data_full == false)
            {
                MessageBox.Show("Có tọa độ của Role đang trống ?", "Return");
                return;
            }
            else
            {
                if (MessageBox.Show("Update Tọa độ lên hệ thống ???","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string poi_role = "";
                    for (int i = 0; i < role_tem.Rows.Count; i++)
                    {
                        poi_role += role_tem.Rows[i][1].ToString() + "|";
                    }
                    poi_role = poi_role.Substring(0, poi_role.Length - 1);
                    string poi_role_truong1 = "";
                    for (int i = 0; i < role_tem_truong1.Rows.Count; i++)
                    {
                        poi_role_truong1 += role_tem_truong1.Rows[i][1].ToString() + "|";
                    }
                    poi_role_truong1 = poi_role_truong1.Substring(0, poi_role_truong1.Length - 1);
                    dt_template.Rows[index_row]["Poi_Rules"] = poi_role;
                    dt_template.Rows[index_row]["Poi_Rules_Truong1"] = poi_role_truong1;
                    dt_template.AcceptChanges();
                    //string id_template = dt_template.Rows[cbb_form.SelectedIndex]["Id"].ToString();
                    daentry.ExecuteSQL("Update dbo.[Template] set Poi_Rules = N'" + poi_role + "',Poi_Rules_Truong1 = N'"+ poi_role_truong1 + "' where TempName = N'" + cbb_form.Text + "'");
                    MessageBox.Show("Complete");
                }
                else
                {
                    return;
                }
            }
        }

        private void btn_brow_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse File Image",
                DefaultExt = "tif",
                Filter = "All Graphics Types|*.jpg;*.jpeg;*.png;*.tif;*.tiff",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                var mess_update = MessageBox.Show("Update thông tin File Image lên hệ thống ???", "Messenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mess_update == DialogResult.Yes)
                {
                    Bitmap imagepage = new Bitmap(open.FileName.ToString());
                    wb_ad.Insert_Image_Draw(cbb_form.Text, imageToByteArray_img(imagepage));                    
                    return;
                }
            }
        }
        private byte[] imageToByteArray_img(Bitmap imageIn)
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

        private void rdo_Role_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Role.Checked)
            {
                rdo_ROle1.Checked = false;
            }
        }

        private void rdo_ROle1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_ROle1.Checked)
            {
                rdo_Role.Checked = false;
            }
        }

        private void btn_truong1_Click(object sender, EventArgs e)
        {
            if (cbb_Role1.SelectedIndex > -1)
            {
                if (MessageBox.Show("Xóa tọa độ của Vùng Trường 1 đang chọn ???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    role_tem_truong1.Rows[cbb_Role1.SelectedIndex][1] = "";
                    drawimage();
                }
            }
        }

        private void cbb_Role1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Role1.SelectedIndex > -1)
            {
                grid_1.Focus();
                gridV_1.FocusedRowHandle = cbb_Role1.SelectedIndex;
                grid_1.Focus();
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            try
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch
            {
                return null;
            }
        }
        int valuezom = 9;
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
        bool mouseDown = false; double scale = 1;
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
            DataTable dtv = role_tem;
            //DataTable dtvmsdt = role_tem;
            int _x = 0;
            int _y = 0;
            int wid = 0;
            int hei = 0;
            pbimg.Refresh();
            for (int i = 0; i < dtv.Rows.Count; i++)
            {
                try
                {
                    //dtv.Rows[i][0] = (i + 1).ToString().PadLeft(2, '0');
                    _x = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[0]) * scale);
                    _y = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[1]) * scale);
                    wid = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[2]) * scale);
                    hei = Convert.ToInt32(Convert.ToInt32(dtv.Rows[i][1].ToString().Split(',')[3]) * scale);
                    graphics = pbimg.CreateGraphics();
                    graphics.DrawRectangle(PEN_DRAW, _x, _y, wid, hei);
                    graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
                    //graphics.DrawString((i + 1).ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Red), _x, _y);
                    graphics.DrawString(dtv.Rows[i][0].ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Red), _x, _y);
                }
                catch { }
            }
            DataTable dt_truong1 = role_tem_truong1;
            for (int i = 0; i < dt_truong1.Rows.Count; i++)
            {
                try
                {
                    //dtvmsdt.Rows[0][0] = "01";
                    _x = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[0]) * scale);
                    _y = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[1]) * scale);
                    wid = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[2]) * scale);
                    hei = Convert.ToInt32(Convert.ToInt32(dt_truong1.Rows[i][1].ToString().Split(',')[3]) * scale);
                    graphics = pbimg.CreateGraphics();
                    graphics.DrawRectangle(PEN_DRAW_BLUE, _x, _y, wid, hei);
                    graphics.FillRectangle(BRUSH, _x, _y, wid, hei);
                    graphics.DrawString(dt_truong1.Rows[i][0].ToString().PadLeft(2, '0'), new Font("Arial", 12), new SolidBrush(Color.Blue), _x, _y);
                }
                catch { }
            }
        }
    }
}
