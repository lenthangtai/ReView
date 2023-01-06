using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace VCB_TEGAKI
{
    class DB_Update
    {
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        private SqlConnection sqlConnection = new SqlConnection(String.Format("Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;"));
        /// <summary>
        /// Open connection
        /// </summary>
        private void OpenCnn()
        {
            try
            {
                if (sqlConnection.State.Equals(System.Data.ConnectionState.Closed))
                {
                    sqlConnection.Open();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi kết nối cơ sở dữ liệu\n" + sqlException.Message);
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        private void CloseCnn()
        {
            if (sqlConnection.State.Equals(System.Data.ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }


        public void addFile(string tenFile, byte[] file, string date)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into AutoUpdate(FileCapNhat,TenFile,NgayCN) values(@file,@ten,@date)");
            command.Connection = sqlConnection;
            command.Parameters.Add(new SqlParameter("file", file));
            //doc anh anh thanh cac bit nhi phan           
            command.Parameters.Add(new SqlParameter("ten", tenFile));
            command.Parameters.Add(new SqlParameter("date", date));
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public DataTable getTenFile()
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT top 1 ID,TenFile,NgayCN from dbo.AutoUpdate order by ID desc";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(dt);
                sqlConnection.Close();

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            finally
            {
                CloseCnn();
            }
            return dt;
        }
        public DataTable getTenFile2()
        {
            DataTable dt = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT ID,CONVERT(nvarchar,ID)+'-'+TenFile+'-'+CONVERT(nvarchar,NgayCN) as N'Tên File' from dbo.AutoUpdate order by ID desc";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(dt);
                sqlConnection.Close();

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            finally
            {
                CloseCnn();
            }
            return dt;
        }
        public byte[] getFile()
        {
            byte[] bt;
            try
            {
                //if (frmEntry.selecthitpoint == true)
                //{

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT top 1  FileCapNhat from dbo.AutoUpdate order by ID desc";
                bt = (byte[])sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            return bt;
        }
        public byte[] getFile(string id)
        {
            byte[] bt;
            try
            {
                //if (frmEntry.selecthitpoint == true)
                //{

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT  FileCapNhat from dbo.AutoUpdate where ID='" + id + "'";
                bt = (byte[])sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            return bt;
        }
        public string getTen()
        {
            try
            {
                //if (frmEntry.selecthitpoint == true)
                //{
                sqlConnection.Open();
                //sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT top 1  TenFile from dbo.AutoUpdate order by ID desc";
                string res = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                CloseCnn();
                return res;

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
        }
        public DataTable Getten_bosung()
        {
            DataTable dt = new DataTable();

            try
            {
                //OpenCnn();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select TenFile from dbo.[AutoUpdate] where TenFile not like N'%.exe%'";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(dt);
                CloseCnn();
                //sqlConnection.Close();

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            finally
            {
                CloseCnn();
            }
            return dt;
        }
        public byte[] getFile_bosung(string tenFile)
        {
            byte[] bt;
            try
            {
                //if (frmEntry.selecthitpoint == true)
                //{

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT FileCapNhat from dbo.AutoUpdate where TenFile='" + tenFile + "'";
                bt = (byte[])sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            return bt;
        }
    }
}
