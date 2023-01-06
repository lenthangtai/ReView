using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using VCB_Entry;

namespace VCB_TEGAKI
{
    static class Program
    {
        
        public static string server = "", database = "VCB_PLUS_NNC", user = "userai", pass= "userai";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                TcpClient tcp = new TcpClient();
                var result = tcp.BeginConnect("192.168.1.3", 1433, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(500));
                if (success)
                { server = "192.168.1.3"; }
                else
                { server = "117.3.36.41,1437"; }

                //#region Update  
                //try
                //{
                //    DB_Update fc = new DB_Update();
                //    DataTable tenBS = fc.Getten_bosung();
                //    string tenF = fc.getTen();   //lấy tên file mới nhất trên sql  
                //    //string phienban_server = tenF.Substring(tenF.Length - 8, 4));
                //    string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;  //lấy tên chương trình đang chạy
                //    string ten_app = appName.Substring(0, appName.Length - 5);
                //    string link = Directory.GetCurrentDirectory().ToString(); //lấy đường dẫn folder chạy app
                //    //lấy tên các file có trong folder            
                //    string[] lstDLL = Directory.GetFiles(link, "*.dll").Select(Path.GetFileName).ToArray();
                //    string[] lstEXE = Directory.GetFiles(link, "*.exe").Select(Path.GetFileName).Where(x => x.IndexOf("vshost") == -1).ToArray();
                //    bool capnhat = false;
                //    if (tenF == null || tenF == appName + ".exe")
                //        capnhat = true;
                //    for (int i = 0; i < tenBS.Rows.Count; i++)       //tải các tập tin dll còn thiếu về                 
                //        if (lstDLL.Contains(tenBS.Rows[i][0].ToString()))
                //        {
                //            tenBS.Rows.Remove(tenBS.Rows[i]);
                //            i--;
                //        }
                //        else
                //        {
                //            string filePath = link + "\\" + tenBS.Rows[i][0].ToString();
                //            byte[] bt = fc.getFile_bosung(tenBS.Rows[i][0].ToString());
                //            FileStream _FileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                //            _FileStream.Write(bt, 0, bt.Length);
                //            _FileStream.Close();
                //        }
                //    if (capnhat == true)//tải file về và xóa file có phiên bản thấp hơn đi                
                //        for (int i = 0; i < lstEXE.Length; i++)
                //        {
                //            //if (lstEXE[i].IndexOf(ten_app) != -1 && float.Parse(lstEXE[i].Substring(lstEXE[i].Length - 8, 4)) < phienban_server)
                //            if (lstEXE[i].IndexOf(appName + ".exe") != -1 && lstEXE[i] != appName + ".exe")
                //            {
                //                Thread.Sleep(1000);
                //                System.IO.File.Delete(lstEXE[i]);
                //            }
                //        }
                //    else
                //    {
                //        byte[] bt = fc.getFile();
                //        string strfilename = link + "\\" + tenF;
                //        System.IO.FileStream _FileStream = new System.IO.FileStream(link + "\\" + tenF, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //        _FileStream.Write(bt, 0, bt.Length);
                //        _FileStream.Close();
                //        Process.Start(strfilename);
                //        try
                //        {
                //            System.IO.File.Delete(link + "\\" + appName + ".exe");
                //        }
                //        catch
                //        {
                //        }
                //        return;
                //    }
                //}
                //catch { }
                //#endregion
            }
            catch (Exception exceptio)
            {
                MessageBox.Show("Connect error\n" + exceptio.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
    }
}
