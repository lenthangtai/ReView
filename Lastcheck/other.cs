using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;


namespace VCB_TEGAKI
{    
    class other_LC
    {
        //StringBuilder pth = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        string ph = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\xuatloidaiwa.xls";
        public void CreatFileExcel()
        {
            try
            {
                if (System.IO.File.Exists(ph) == false)
                {                   
                    //Byte[] b = VCB_LC.Properties.Resources.FORM_XUAT_LOI;                    
                    //Microsoft.VisualBasic.FileIO.FileSystem.WriteAllBytes(ph, b, false);                   
                }
            }
            catch
            {

            }           
        }
        public void DeleteFileExcel()
        {
            try
            {
                System.IO.File.Delete(ph);              
            }
            catch
            {
            }            
        }
        public static string[] arrHCT(string str)
        {
            List<string> HCT = new List<string>();
            string[] arrTemp = null;

            arrTemp = str.Split('+');
            for (int i = 0; i < arrTemp.Length; i++)
            {
                string[] temp = null;
                temp = arrTemp[i].Split('*');
                if (temp.Length == 2)
                {
                    for (int j = 0; j < int.Parse(temp[1]); j++)
                    {
                        HCT.Add(temp[0]);
                    }
                }
                else
                {
                    HCT.Add(arrTemp[i]);
                }
            }
            
            return HCT.ToArray();
        }
        public static string[] arrHGMN(string str)
        {
            List<string> HCT = new List<string>();
            string[] arrTemp = null;

            arrTemp = str.Split('+');
            for (int i = 0; i < arrTemp.Length; i++)
            {
                string[] temp = null;
                temp = arrTemp[i].Split('*');
                if (temp.Length == 2)
                {
                    string[] temparr = temp[0].Split('.');
                    if (temparr.Length == 1)
                    {
                        for (int j = 0; j < int.Parse(temp[1]); j++)
                        {
                            HCT.Add(temp[0]);
                        }
                    }
                    else
                    {                        
                        for (int j = 0; j < int.Parse(temp[1]); j++)
                        {
                            HCT.Add(temparr[0]);
                        }
                    }
                }
                else
                {
                    string[] temparr = arrTemp[i].Split('.');
                    if (temparr.Length == 1)
                    {
                        HCT.Add(arrTemp[i]);
                    }
                    else
                    {                        
                        HCT.Add(temparr[0]);
                    }
                }
            }

            return HCT.ToArray();
        }
        public static string[] arrHGMTP(string str)
        {
            List<string> HCT = new List<string>();
            string[] arrTemp = null;

            arrTemp = str.Split('+');
            for (int i = 0; i < arrTemp.Length; i++)
            {
                string[] temp = null;
                temp = arrTemp[i].Split('*');
                if (temp.Length == 2)
                {
                    string[] temparr = temp[0].Split('.');
                    if (temparr.Length == 1)
                    {
                        for (int j = 0; j < int.Parse(temp[1]); j++)
                        {
                            HCT.Add("0");
                        }
                    }
                    else
                    {                        
                        for (int j = 0; j < int.Parse(temp[1]); j++)
                        {
                            HCT.Add(temparr[1]);
                        }
                    }
                }
                else
                {
                    string[] temparr = arrTemp[i].Split('.');
                    if (temparr.Length==1)
                    {
                        HCT.Add("0");
                    }
                    else
                    {                     
                        HCT.Add(temparr[1]);
                    }
                }
            }

            return HCT.ToArray();
        }        
        public static bool export(bool ex)
        {
            bool export = ex;
            return export;
        }
    }
}
