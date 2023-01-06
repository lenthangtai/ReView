using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace VCB_TEGAKI
{
    class clValue
    {     
        public static byte[] imageToByteArray(Bitmap imageIn)
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
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static int[] value(int file)
        {
            int[] temp = null;
            if ((file / 10) >= 1)
            {
                temp = new int[10];
                temp[0] = file / 10;
                temp[1] = file / 5;
                temp[2] = (file * 3) / 10;
                temp[3] = (file * 2) / 5;
                temp[4] = (file / 2);
                temp[5] = (file * 3) / 5;
                temp[6] = (file * 7) / 10;
                temp[7] = (file * 4) / 5;
                temp[8] = (file * 9) / 10;
                temp[9] = file;
            }
            else
            {
                temp = new int[1] { file };
            }
            return temp;
        }
        private static int sodu(int vl)
        {
            int temp = -(vl % 100);


            return temp;
        }
    }
}
