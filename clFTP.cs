using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace VCB_TEGAKI
{
    class clFTP
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;
        
        /* Construct Object */
        public void ftp(string hostIP, string userName, string password) 
        { 
            host = hostIP; user = userName; pass = password; 
        }      

        public DateTime getFileCreatedDateTime(string fileName)
        {
            DateTime time_modified=DateTime.Now;
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                time_modified = ftpResponse.LastModified;  
                
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Created Date Time */               
            }
            catch (Exception ex) { time_modified = DateTime.MaxValue; }
            /* Return an Empty string Array if an Exception Occurs */
            return time_modified;
        }
        /* Download File */
        public string download(string remoteFile)
        {
            string inf_update="";
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                ftpStream = ftpResponse.GetResponseStream();
                /* Open a File Stream to Write the Downloaded File */
                //FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                /* Buffer for the Downloaded Data */
                //byte[] byteBuffer = new byte[bufferSize];
                //int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                try
                {
                    //while (bytesRead > 0)
                    //{
                    //    localFileStream.Write(byteBuffer, 0, bytesRead);
                    //    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    //}
                    StreamReader strReader = new StreamReader(ftpStream);
                    inf_update = strReader.ReadToEnd();
                    strReader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                //localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return inf_update;
        }

    }
}
