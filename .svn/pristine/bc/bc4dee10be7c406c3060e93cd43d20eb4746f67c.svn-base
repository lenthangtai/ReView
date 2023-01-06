using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace VCB_TEGAKI
{
    class Io_LC
    {
        public static Pen PEN_DRAW = new Pen(Color.Red, 2);
        public static Brush BRUSH = new SolidBrush(Color.FromArgb(30, 255, 0, 0));
        public static Bitmap ZoomImage(Bitmap img, double scale)
        {
            int width = Convert.ToInt32(img.Width * scale);
            int height = Convert.ToInt32(img.Height * scale);
            return new Bitmap(img, width, height);
        }
        private bool rpassconfig;
        public bool Rpass
        {
            get { return rpassconfig; }
        }
        private string passConfig;
        public string Pass
        {
            get { return passConfig; }
        }
        private string userConfig;
        public string User
        {
            get { return userConfig; }
        }
        public  void createFile(string content, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    // Create the file. 
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(content);

                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                //When the Antivirus scaning, we can't write this file, ex: AVG
            }
        }
        public bool ReadConfigFile()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                using (FileStream fs = File.Open(System.IO.Path.Combine(path, "TimeSheetConfig.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {

                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);

                    string str = "";
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        str = temp.GetString(b);
                    }

                    string[] split = str.Split('\n');
                    rpassconfig = Boolean.Parse(split[0].ToString());
                    userConfig = split[1].ToString();
                    passConfig = split[2].ToString();
                }
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public void WriteToFile(bool Rpass, string userConfig, string passConfig)
        {
            try
            {
                string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TimeSheetConfig.txt");
                using (Stream fs = System.IO.File.Open(Path,
                                                         FileMode.OpenOrCreate,
                                                         FileAccess.Write,
                                                         FileShare.ReadWrite)
                      )
                {
                    fs.SetLength(0);
                    fs.Flush();
                    Byte[] info = new UTF8Encoding(true).GetBytes(Rpass + "\n" +
                            userConfig + "\n" +
                            passConfig);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
