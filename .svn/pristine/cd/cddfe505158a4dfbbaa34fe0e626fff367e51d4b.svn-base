using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace VCB_TEGAKI
{
    public static class Common
    {
        public static Pen PEN_DRAW = new Pen(Color.Red, 2);
        public static Brush BRUSH = new SolidBrush(Color.FromArgb(30, 255, 0, 0));
        public static string BASE_URL = "http://localhost/textmil/index.php/";
        public static byte INSERT_TEMPLATE_STATE = 1;
        public static byte UPDATE_TEMPLATE_STATE = 2;

        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;
        internal const int MF_ENABLED = 0x0;
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);
        [DllImport("user32.dll")]
        public static extern int RemoveMenu(int systemMenu, int itemPosition, int flag);
        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(int systemMenu);
        [DllImport("user32.dll")]
        public static extern int DrawMenuBar(IntPtr currentWindow);
        public static void FormCloseEnabled(Form form, bool enabled)
        {
            MethodInvoker method = delegate
            {
                int disable = 2;
                int enable = 1;
                IntPtr menu;
                int itemCount;
                if (enabled)
                {
                    EnableMenuItem(GetSystemMenu(form.Handle, false), SC_CLOSE, MF_ENABLED);
                    //get the system menu of the application
                    menu = GetSystemMenu(form.Handle, false);
                    //get the count of menu items in the system menu
                    itemCount = GetMenuItemCount(menu.ToInt32());
                    //disable the "Close" command in the menu
                    RemoveMenu(menu.ToInt32(), itemCount - 1, enable);
                    //now draw the menu bar on the application
                    DrawMenuBar(form.Handle);
                }
                else
                {
                    EnableMenuItem(GetSystemMenu(form.Handle, false), SC_CLOSE, MF_GRAYED);
                    //get the system menu of the application
                    menu = GetSystemMenu(form.Handle, false);
                    //get the count of menu items in the system menu
                    itemCount = GetMenuItemCount(menu.ToInt32());
                    //disable the "Close" command in the menu
                    RemoveMenu(menu.ToInt32(), itemCount - 1, disable);
                    //now draw the menu bar on the application
                    DrawMenuBar(form.Handle);
                }
            };

            if (form.InvokeRequired)
                form.BeginInvoke(method);
            else
                method.Invoke();
        }

        public static Bitmap ZoomImage(Bitmap img, double scale)
        {
            int width = Convert.ToInt32(img.Width * scale);
            int height = Convert.ToInt32(img.Height * scale);
            return new Bitmap(img, width, height);
        }

        public static int[] ResizePoint(string[] points, int extraVal, Bitmap bmpPage)
        {
            int[] returnVal = new int[4];
            int x = int.Parse(points[0]);
            int y = int.Parse(points[1]);
            int width = int.Parse(points[2]);
            int height = int.Parse(points[3]);

            int left, right, top, bottom;

            // get left
            if (x > extraVal)
            {
                left = extraVal;
            }
            else
            {
                left = x;
            }

            // get right
            if (x + width + extraVal > bmpPage.Width)
            {
                right = bmpPage.Width - (x + width);
            }
            else
            {
                right = extraVal;
            }

            // get top
            if (y > extraVal)
            {
                top = extraVal;
            }
            else
            {
                top = y;
            }

            // get bottom
            if (y + height + extraVal > bmpPage.Height)
            {
                bottom = bmpPage.Height - (y + height);
            }
            else
            {
                bottom = extraVal;
            }

            // get new point
            returnVal[0] = x - left;
            returnVal[1] = y - top;
            returnVal[2] = left + width + right;
            returnVal[3] = top + height + bottom;

            return returnVal;
        }
        public static string filename(string fileroot)
        {
            string str = "";
            string[] arrstr;

            arrstr = fileroot.Split('\\');

            str = arrstr[arrstr.Length-1];

            return str;
        }
        public static string[] pixcelextraVal(string[] pixcellocation,int extr,Bitmap bm)
        {
            string[] px = new string[4];
            int x = Int32.Parse(pixcellocation[0]);
            int y = Int32.Parse(pixcellocation[1]);
            int width = Int32.Parse(pixcellocation[2]);
            int height = Int32.Parse(pixcellocation[3]);
            int total;
            if (x > extr)
            {
                x = x - extr;
            }
            else
            {
                x = 0;
            }
            if (y > extr)
            {
                y = y - extr;
            }
            else
            {
                y = 0;
            }
            total = x + width + extr * 2;
            if (total < bm.Width)
            {
                width = width + extr*2;
            }
            else
            {
                width = bm.Width - x;
            }
            total = y + height + extr * 2;
            if (total < bm.Height)
            {
                height = height + extr * 2;
            }
            else
            {
                height = bm.Height - y;
            }
            px[0] = x.ToString();px[1] = y.ToString(); px[2] = width.ToString(); px[3] = height.ToString();           

            return px;
        }
        public static void TransfFTP(string filename,string address,string username,string password)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address + Path.GetFileName(filename));

                // This example assumes the FTP site uses anonymous logon.

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;
                FileStream stream = File.OpenRead(filename);
                byte[] buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error! FTP\n" + ex.Message);
            }
        }
        public static Byte[] ConvertToUtf8(string strencode)
        {
            Byte[] by;

            // Create a UTF-8 encoding.
            UTF8Encoding utf8 = new UTF8Encoding();      

            // Encode the string.
            by = utf8.GetBytes(strencode);   

            
            
            return by;
        }
        public static byte[] imageToByteArray(Bitmap imageIn)
        {
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Compression;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)EncoderValue.CompressionCCITT4);
            myEncoderParameters.Param[0] = myEncoderParameter;        
          
            using (var ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms,myImageCodecInfo,myEncoderParameters);
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
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
    }
}
