using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using VCB_Entry;
using System.Drawing.Imaging;
using VCB_Entry.Lastcheck;

namespace VCB_TEGAKI
{
    public partial class frmLogIn : Form
    {
        public static bool fn = false;
        public static string path_file_config = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\VCB_Plus_nnc.txt";
        public static string path_image;
        public static string[] arrConfig = new string[7] { "false", "", "", "", "false", "", DateTime.Now.ToString()};
        public string batchname;
        public int batchId;
        public int ImgId;
        public int uID;
        int pair;
        string role = "";
        private string[] usr;
        DAEntry_Entry daEntry;
        DAEntry_Check daCheck;
        private WorkDB_LC wb;
        bool Rpass = false;
        private Io_Entry clUntil = new Io_Entry();
        DataTable dtbatch;
        public frmLogIn()
        {
            InitializeComponent();
            this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            if (File.Exists(path_file_config))
            {
                arrConfig = File.ReadAllLines(path_file_config);
                try { Rpass = Convert.ToBoolean(arrConfig[0]); }
                catch { }
            }
            this.CenterToScreen();
        }
        double tonggiatri;
        private void frmLogIn_Load(object sender, EventArgs e)
        {


            //
            daEntry = new DAEntry_Entry();
            daCheck = new DAEntry_Check();
            wb = new WorkDB_LC();
            DBsql dbsql = new DBsql();
            //string datee_time = daEntry.GetStringSQL("Select CONVERT(nvarchar(8),DateCreated,112) as 'Date' from dbo.[ServerImage] where NameImage = N'FAX転送_20211004111029_00001_1.tiff'");
            lblError.Text = "";
            if (Rpass == true)
            {
                txtPassword.Text = arrConfig[2];
                txtUserId.Text = arrConfig[1];
                chbRememberpasss.Checked = true;
            }
            try { usr = daEntry.usr(arrConfig[1]); }
            catch { }
        }
        //public void InsertImageToServer2(int id, byte[] image)
        //{
        //    string stringconnecttion = String.Format(@"Data Source=192.168.1.3; Initial Catalog=VCB_PLUS_NNC;User Id=entryplus;Password=entryplus;Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");
        //    try
        //    {

        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandType = CommandType.Text;
        //            sqlCommand.CommandText = "Update dbo.[Template] set SopImage = @VarImage where Id = " + id;
        //            sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
        //            //sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
        //            con.Open();
        //            sqlCommand.ExecuteReader();
        //        }
        //    }
        //    catch { }
        //}
        //private byte[] imageToByteArray2(Bitmap imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        try
        //        {
        //            imageIn.Save(ms, ImageFormat.Jpeg);
        //            return ms.ToArray();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}
        ////Button login
        //WorkDB_Admin workdb = new WorkDB_Admin();
        private void butLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //List<string> listbatch = new List<string>();
                usr = daEntry.usr(txtUserId.Text);
                if (usr[0] == "")
                {
                    return;
                }
                lblError.Text = "";
                if (usr[0] != "")
                {
                    if (usr[1] != txtPassword.Text.Trim())
                    {
                        lblError.Text = "Pass is Incorrect";
                        return;
                    }
                    uID = Convert.ToInt32(usr[0]);
                    pair = Convert.ToInt32(usr[2]);
                    role = usr[3];
                    switch (role)
                    {
                        case "ENTRY":
                            bool blLoop = false;
                            do
                            {
                                fn = false;
                                //listbatch.Add(batchId.ToString());
                                using (frmEntry frm = new frmEntry())
                                {
                                    if (pair == 1 || pair == 2)
                                    {
                                        frm.batchId = batchId;
                                        frm.userId = uID;
                                        frm.userName = txtUserId.Text;
                                        frm.batchName = batchname;
                                        frm.pair = pair;
                                        frm.ShowDialog();
                                        //else if (pair == 2)
                                        //{
                                        //    FrmEntry2 frm2 = new FrmEntry2();
                                        //    frm2.batchId = batchId;
                                        //    frm2.userId = uID;
                                        //    frm2.userName = txtUserId.Text;
                                        //    frm2.batchName = batchname;
                                        //    frm2.pair = pair;
                                        //    frm2.ShowDialog();
                                    }
                                    else if (pair == 3 || pair == 4)
                                    {
                                        FrmEntryP frm3 = new FrmEntryP();
                                        frm3.batchId = batchId;
                                        frm3.userId = uID;
                                        frm3.userName = txtUserId.Text;
                                        frm3.batchName = batchname;
                                        frm3.pair = pair;
                                        frm3.ShowDialog();
                                    }
                                    string[] arrbatch = daEntry.GetbatchNew(batchId);
                                    if (arrbatch[0] != "" && fn)
                                    {
                                        var msb = MessageBox.Show(this, "Đã hoàn thành batch " + batchname + "." + Environment.NewLine + "Bạn có muốn nhập tiếp batch " + arrbatch[1] + " ko?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (msb == DialogResult.Yes)
                                        {
                                            batchId = Convert.ToInt32(arrbatch[0]);
                                            batchname = arrbatch[1];
                                            blLoop = true;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            while (blLoop);
                            break;
                        case "CHECK":
                            blLoop = false;
                            do
                            {
                                fn = false;
                                if (txtUserId.Text.Trim().ToUpper().Contains("CP"))
                                {
                                    //using (FrmCheckP frmcp = new FrmCheckP())
                                    //{
                                    FrmCheckP frmcp = new FrmCheckP();
                                    frmcp.batchId = batchId;
                                    frmcp.userId = uID;
                                    frmcp.userName = txtUserId.Text;
                                    frmcp.batchName = batchname;
                                    frmcp.ShowDialog();
                                    break;
                                }
                                else if (txtUserId.Text.Trim().ToUpper().Split('-')[0] == "QC2")
                                {
                                    frmCheck frm = new frmCheck();
                                    frm.batchId = batchId;
                                    frm.userId = uID;
                                    frm.pair = "QC";
                                    frm.userName = txtUserId.Text;
                                    frm.batchName = batchname;
                                    frm.ShowDialog();
                                    break;
                                }
                                else if (txtUserId.Text.Trim().ToUpper().Split('-')[0] == "C2")
                                {
                                    frmCheck frm = new frmCheck();
                                    frm.batchId = batchId;
                                    frm.userId = uID;
                                    frm.pair = "CHECK";
                                    frm.userName = txtUserId.Text;
                                    frm.batchName = batchname;
                                    frm.ShowDialog();
                                    break;
                                }
                            }
                            while (blLoop);
                            break;
                        case "LASTCHECK":
                            using (LC_New_plus_NNC frm = new LC_New_plus_NNC())
                            {
                                LC_New_plus_NNC.batchID = batchId;
                                LC_New_plus_NNC.batchname = batchname;
                                LC_New_plus_NNC.datestring = DateTime.Now.Year.ToString().Substring(2, 2) + String.Format("{0:00}", int.Parse(DateTime.Now.Month.ToString())) + String.Format("{0:00}", int.Parse(DateTime.Now.Day.ToString()));
                                //frm.INFperformance = wb.InsertPerformance(batchId, uID);
                                //if (frm.INFperformance[0] == "")
                                //{
                                //    MessageBox.Show("Error connenct, please reset application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    return;
                                //}
                                LC_New_plus_NNC.batchID = batchId;
                                LC_New_plus_NNC.batchname = batchname;
                                LC_New_plus_NNC.userID = uID;
                                if (txtUserId.Text.ToUpper().Contains("LC1"))
                                { LC_New_plus_NNC.dot = 1; }
                                if (txtUserId.Text.ToUpper().Contains("LC2"))
                                { LC_New_plus_NNC.dot = 2; }
                                if (txtUserId.Text.ToUpper().Contains("LC3"))
                                { LC_New_plus_NNC.dot = 3; }
                                if (txtUserId.Text.ToUpper().Contains("LC4"))
                                { LC_New_plus_NNC.dot = 4; }
                                LC_New_plus_NNC.LCtong = 0;
                                LC_New_plus_NNC.type_tem = cbb_template.Text;
                                if (cbb_template.Text != "")
                                {
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    return;
                                }
                                getTemplate(Convert.ToInt32(txtUserId.Text.Split('-')[0].Substring(2, 1)));
                            }
                            break;
                        case "LASTCHECKTONG":
                            using (LC_New_plus_NNC frm = new LC_New_plus_NNC())
                            {
                                LC_New_plus_NNC.batchID = batchId;
                                LC_New_plus_NNC.batchname = batchname;
                                LC_New_plus_NNC.datestring = DateTime.Now.Year.ToString().Substring(2, 2) + String.Format("{0:00}", int.Parse(DateTime.Now.Month.ToString())) + String.Format("{0:00}", int.Parse(DateTime.Now.Day.ToString()));
                                //frm.INFperformance = wb.InsertPerformance(batchId, uID);
                                //if (frm.INFperformance[0] == "")
                                //{
                                //    MessageBox.Show("Error connenct, please reset application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    return;
                                //}
                                LC_New_plus_NNC.batchID = batchId;
                                LC_New_plus_NNC.batchname = batchname;
                                LC_New_plus_NNC.userID = uID;
                                if (txtUserId.Text.ToUpper().Contains("LCT1"))
                                { LC_New_plus_NNC.dot = 1; }
                                if (txtUserId.Text.ToUpper().Contains("LCT2"))
                                { LC_New_plus_NNC.dot = 2; }
                                if (txtUserId.Text.ToUpper().Contains("LCT3"))
                                { LC_New_plus_NNC.dot = 3; }
                                if (txtUserId.Text.ToUpper().Contains("LCT4"))
                                { LC_New_plus_NNC.dot = 4; }
                                LC_New_plus_NNC.LCtong = 1;
                                frm.ShowDialog();
                            }
                            break;
                        case "CROP":
                            using (frmUpdateImage frmcrop = new frmUpdateImage())
                            {
                                frmcrop.ShowDialog();
                            }
                            break;
                        case "ADMIN":
                            frmAdmin frmAdmin = new frmAdmin();
                            frmAdmin.ShowDialog();
                            break;
                    }
                }
                else
                {
                    lblError.Text = "Username is Incorrect";
                }
            }
            catch (SqlException exp)
            {
                MessageBox.Show("Connect error\n" + exp.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Refresh  
            if (usr[0] != "" && usr[3].ToUpper() != "CROP" && usr[3].ToUpper() != "ADMIN")
            {
                int hitpoint = -1;
                switch (usr[3])
                {
                    case "ENTRY": hitpoint = 0; break;
                    case "CHECK": hitpoint = 1; break;
                    case "LASTCHECK": hitpoint = 2; break;
                    default: hitpoint = -1; break;
                }
            }
        }
        private void chbRememberpasss_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRememberpasss.Checked == false)
            {
                arrConfig[1] = "";
                arrConfig[2] = "";
                arrConfig[0] = false.ToString();
            }
            else if (chbRememberpasss.Checked == true)
            {
                arrConfig[1] = txtUserId.Text;
                arrConfig[2] = txtPassword.Text;
                arrConfig[0] = true.ToString();
            }
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            chbRememberpasss_CheckedChanged(sender, e);
            File.WriteAllLines(path_file_config, arrConfig);
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frmchangepass = new frmChangePassword();
            frmchangepass.ShowDialog();
        }
        DataTable template = new DataTable();
        void getTemplate(int dot)
        {
            template = new DataTable();
            template = daEntry.GetDatatableSQL("select ResultP from db_owner.AllImage join db_owner.Imagecontent on AllImage.Id = ImageContent.AllImageId where TurnUp = " + dot + " and Result is not null and UserLC_Keep_Img = 0 and UserLC_Done = 0 Group by ResultP");
            cbb_template.DataSource = template;
            cbb_template.DisplayMember = "ResultP";
        }
        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                butLogin_Click(sender, e);
            if (e.KeyCode == Keys.F1)
            {
                string pass = Microsoft.VisualBasic.Interaction.InputBox("", "Nhập pass", "");
                if (pass == "123456")
                {
                    UpdateTool up = new UpdateTool();
                    up.ShowDialog();
                }
            }
            if (e.Control)
            {
                var arrTemp = txtUserId.Text.Split('-');
                if (arrTemp.Length == 2)
                {
                    lb_tem.Visible = false; cbb_template.Visible = false;
                    if (e.KeyCode == Keys.NumPad1)
                    {
                        if (arrTemp[0].ToUpper() == "E1")
                            arrTemp[0] = "E2";
                        else if (arrTemp[0].ToUpper() == "E2")
                            arrTemp[0] = "E1";
                        else
                            arrTemp[0] = "E1";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad2)
                    {
                        if (arrTemp[0].ToUpper() == "C2")
                            arrTemp[0] = "QC2";
                        else if (arrTemp[0].ToUpper() == "QC2")
                            arrTemp[0] = "C2";
                        else
                            arrTemp[0] = "C2";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad3)
                    {
                        if (arrTemp[0].ToUpper() == "LC1")
                            arrTemp[0] = "LC2";
                        else if (arrTemp[0].ToUpper() == "LC2")
                            arrTemp[0] = "LC3";
                        else if (arrTemp[0].ToUpper() == "LC3")
                            arrTemp[0] = "LC4";
                        else if (arrTemp[0].ToUpper() == "LC4")
                            arrTemp[0] = "LC1";
                        else
                            arrTemp[0] = "LC1";
                        txtUserId.Text = string.Join("-", arrTemp);
                        if (Convert.ToInt32(arrTemp[0].Substring(2, 1)) > 0)
                        {
                            lb_tem.Visible = true; cbb_template.Visible = true;
                            getTemplate(Convert.ToInt32(arrTemp[0].Substring(2, 1)));
                        }
                    }
                    else if (e.KeyCode == Keys.NumPad4)
                    {
                        arrTemp[0] = "CR";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad5)
                    {
                        arrTemp[0] = "AD";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad7)
                    {
                        if (arrTemp[0].ToUpper() == "P1")
                            arrTemp[0] = "P2";
                        else if (arrTemp[0].ToUpper() == "P2")
                            arrTemp[0] = "P1";
                        else
                            arrTemp[0] = "P1";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad8)
                    {
                        arrTemp[0] = "CP";
                        txtUserId.Text = string.Join("-", arrTemp);
                    }
                    else if (e.KeyCode == Keys.NumPad9)
                    {
                        if (arrTemp[0].ToUpper() == "LCT1")
                            arrTemp[0] = "LCT2";
                        else if (arrTemp[0].ToUpper() == "LCT2")
                            arrTemp[0] = "LCT3";
                        else if (arrTemp[0].ToUpper() == "LCT3")
                            arrTemp[0] = "LCT4";
                        else if (arrTemp[0].ToUpper() == "LCT4")
                            arrTemp[0] = "LCT1";
                        else
                            arrTemp[0] = "LCT1";
                        lb_tem.Visible = false; cbb_template.Visible = false;
                        txtUserId.Text = string.Join("-", arrTemp);
                        //if (Convert.ToInt32(arrTemp[0].Substring(2, 1)) > 0)
                        //{
                        //    lb_tem.Visible = true; cbb_template.Visible = true;
                        //    getTemplate(Convert.ToInt32(arrTemp[0].Substring(2, 1)));
                        //}
                    }
                }
                getbatch();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void serverConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //arrConfig[4] = false.ToString();
            //Application.Restart();
        }

        public System.Net.IPAddress[] dataSource { get; set; }
        private void rbtn1_Click(object sender, EventArgs e)
        {
        }

        private void rbtn2_Click(object sender, EventArgs e)
        {
        }

        private void rbtn3_Click(object sender, EventArgs e)
        {
        }
        public static bool pingServer(string ip)
        {
            bool result = false;
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(ip);
                if (pingReply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }

        private void updateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareInfo si = new SoftwareInfo();
            si.ShowDialog();
        }
        private void getbatch()
        {
            try
            {
                usr = daEntry.usr(txtUserId.Text);
                if (usr[0] != "" && usr[3].ToUpper() != "CROP" && usr[3].ToUpper() != "ADMIN")
                {
                    int hitpoint = -1;
                    switch (usr[3])
                    {
                        case "ENTRY": hitpoint = 0; break;
                        case "CHECK": hitpoint = 1; break;
                        case "LASTCHECK": hitpoint = 2; break;
                        default: hitpoint = -1; break;
                    }
                }
            }
            catch
            { }
        }

        private void txtUserId_Leave(object sender, EventArgs e)
        {
            lb_tem.Visible = false; cbb_template.Visible = false;
            getbatch();
            if (txtUserId.Text.Split('-')[0] == "LC1" || txtUserId.Text.Split('-')[0] == "LC2" || txtUserId.Text.Split('-')[0] == "LC3" || txtUserId.Text.Split('-')[0] == "LC4")
            {
                if (Convert.ToInt32(txtUserId.Text.Split('-')[0].Substring(2, 1)) > 0)
                {
                    lb_tem.Visible = true; cbb_template.Visible = true;
                    getTemplate(Convert.ToInt32(txtUserId.Text.Split('-')[0].Substring(2, 1)));
                }
            }
        }

        private void rbtn1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_viewFb_Click(object sender, EventArgs e)
        {

            FB_NEW_2708 _frm_fb = new FB_NEW_2708() { uID = uID, user_login = txtUserId.Text.ToString() };
            _frm_fb.ShowDialog();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
