using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VCB_TEGAKI;

namespace VCB_Entry
{
    class db_feedback
    {
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog=VCB_YAUA_0516;User Id=useryaua;Password=useryaua;Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        public DataTable get_batchName_userid(string userid,string pair,string tungay, string denngay) //yyyy-mm-dd
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select [Image].BatchName "
                            +"from db_owner.[ImageContent] join db_owner.[Image] on ImageContent.ImageId=[Image].Id "
                            + "where (userid" + pair + "=" + userid + " and loisai" + pair + " >0) and ( inputdate" + pair + " BETWEEN '" + tungay + " 00:00:00.000' AND '"+denngay+" 23:59:59.999') "
                            +"group by [Image].BatchName";
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get batchname user!\n" + sqlException.Message);
            }
            return dt;

        }
        public DataTable get_tb_batchName_userid(string userid, string pair, string tungay, string denngay) //yyyy-mm-dd
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select ImageName,Content" + pair + " as 'ContentEntry',result as 'ContentCheckQC',ResultCheck as 'ContentLC',loisai" + pair + " as'LoiSai',CheckerId,LastCheckId,BinaryImage as 'Image' "
                            + "from ImageContent join AllImage on ImageContent.AllImageId=AllImage.Id join ServerImage on AllImage.ImageName=ServerImage.NameImage  "
                            + "where (userid" + pair + "=" + userid + " and loisai" + pair + " >0) and ( inputdate" + pair + " BETWEEN '" + tungay + " 00:00:00.000' AND '" + denngay + " 23:59:59.999') ";                           
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get batchname user!\n" + sqlException.Message);
            }
            return dt;

        }
        public DataTable get_tb_batchName_userid_QC(string userid, string pair, string tungay, string denngay) //yyyy-mm-dd
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select ImageName,Content" + pair + " as 'ContentEntry',result as 'ContentCheckQC',ResultCheck as 'ContentLC',loisai" + pair + " as'LoiSai',CheckerId,LastCheckId,BinaryImage as 'Image' "
                            + "from ImageContent join AllImage on ImageContent.AllImageId=AllImage.Id join ServerImage on AllImage.ImageName=ServerImage.NameImage  "
                            + "where (userid" + pair + "=" + userid + " and QCID>0) and ( inputdate" + pair + " BETWEEN '" + tungay + " 00:00:00.000' AND '" + denngay + " 23:59:59.999') ";
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get batchname user!\n" + sqlException.Message);
            }
            return dt;

        }
        public DataTable get_tb_batchName_userid_sum(string userid, string pair, string tungay, string denngay) //yyyy-mm-dd
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select [Image].BatchName as 'NameBatch',loisai" + pair + " as 'LoiSai' "
                        + "from db_owner.[ImageContent] join db_owner.[Image] on ImageContent.ImageId=[Image].Id "
                        + "where userid" + pair + "=" + userid + " and loisai" + pair + " >0 and ( inputdate" + pair + " BETWEEN '" + tungay + " 00:00:00.000' AND '" + denngay + " 23:59:59.999') ";                         

                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get batchname user!\n" + sqlException.Message);
            }
            return dt;

        }
        public byte[] get_image(string BatchName, string nameImage)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT BinaryImage FROM ServerImage WHERE NameImage ='" + nameImage + "' and BatchName='" + BatchName + "' ";                    
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { }
            return returnVal;
        }
        public string get_FullNameUser(int userid)
        {
            string returnVal="";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT UserName+'_'+Fullname+'('+Center+')' FROM AllUser WHERE id =" + userid;
                    con.Open();
                    returnVal = (string)sqlCommand.ExecuteScalar();
                }
            }
            catch
            { }
            return returnVal;
        }      
    }
}

