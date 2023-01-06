﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
namespace VCB_TEGAKI
{
    class DBsql
    {
        // bool selecthipoint = true;

        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrive it from a configuration file.
            return "Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;";
        }



        /// <summary>
        /// Insert Page
        /// </summary>       
        public int InsertPage(int batchid, string path)
        {
            int id = 0;
            //Insert Page    
            string connectionString = GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "InsertPage";
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int, 30).Value = batchid;
                sqlCommand.Parameters.Add("@path", SqlDbType.NVarChar, 100).Value = path;
                con.Open();
                using (SqlDataReader vendorReader = sqlCommand.ExecuteReader())
                {
                    id = Int32.Parse(sqlCommand.Parameters["@ID"].Value.ToString());
                }
            }
            return id;
        }
        /// <summary>
        /// Insert image
        /// </summary>       
        public void InsertImage(string Name, int turn)
        {

            string connectionString = GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "InsertImage";
                sqlCommand.Parameters.Add("@NameImg", SqlDbType.NVarChar, 200).Value = Name;
                sqlCommand.Parameters.Add("@Iturn", SqlDbType.Int, 30).Value = turn;
                con.Open();
                sqlCommand.ExecuteReader();
            }
        }

        /// <summary>
        /// Insert Batch
        /// </summary>    
        public int InsertBatch(string batchname)
        {
            int id = 0;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "INSERT INTO dbo.Batch (Name,UploadDate,Hitpoint) VALUES (N'" + batchname + "',Getdate(),0); Select SCOPE_IDENTITY();";
                    con.Open();
                    id = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Insert Batch\n" + sqlException.Message);
            }
            return id;
        }

        /// <summary>
        /// Get Id Batch
        /// </summary>
        /// <param name="template"></param>
        public int GetBatchID(string batchname)
        {
            int id = 0;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT ID FROM dbo.Batch WHERE Name = N'" + batchname + "'";
                    con.Open();
                    id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
            }
            catch
            { }
            return id;
        }

        /// <summary>
        /// Get Page id
        /// </summary>
        /// <param name="template"></param>
        public int PageInBatch(int batchid)
        {
            int id = 0;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Count(ID) FROM db_owner.Page WHERE batchid = " + batchid;
                    con.Open();
                    id = (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return id;
        }



        public void DeleteBatch(string Id, string ids)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "delete db_owner.[ImageContent] where AllImageId=" + Id + ";" +
                                             "delete db_owner.[AllImage] where Id=" + Id + ";" +
                                             "delete dbo.ServerImage where NameImage=N'" + ids + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình Delete Batch\n" + sqlException.Message);
            }

        }

        public List<string> GetImageOnServerWithListImage(string listimage, string nametable)
        {
            List<string> list = new List<string>();

            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select NameImage from dbo.[" + nametable + "] where NameImage in (" + listimage + ")";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(sqlDataReader["NameImage"].ToString().Trim());
                        }
                        sqlDataReader.Close();
                    }

                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return list;
        }
        public void InsertImageToServer(string Name, byte[] image)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "InsertImageToServer";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    //sqlCommand.Parameters.Add("@Iturn", SqlDbType.Int, 30).Value = turn;
                    con.Open();
                    using (SqlDataReader vendorReader = sqlCommand.ExecuteReader())
                    {
                    }
                }
            }
            catch { }
        }
        public void InsertImageToServer_123(string Name, byte[] image)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    //sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "INSERT INTO dbo.ServerImage (NameImage,BinaryImage,DateCreated) VALUES (@NameImage,@VarImage,GETDATE())";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    //sqlCommand.Parameters.Add("@Iturn", SqlDbType.Int, 30).Value = turn;
                    con.Open();                    
                }
            }
            catch { }
        }
        public DataTable GetBatch()
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select Id,NameImage as N'ImageName',DateCreated from dbo.ServerImage";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return dt;
        }
        public void Creat_table(string name)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "CREATE TABLE [dbo].[" + name + "](	[Id] [int] IDENTITY(1,1) NOT NULL,	[NameImage] [nvarchar](300) NOT NULL,	[BinaryImage] [varbinary](max) NOT NULL,	[DateCreated] [datetime] NOT NULL, CONSTRAINT [PK_" + name + "] PRIMARY KEY CLUSTERED (	[NameImage] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        //Get number image check
        public string countImage()
        {
            string returnVal = "0";
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select count(Id) from dbo.[ServerImage]";
                    con.Open();
                    returnVal = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return returnVal;
        }
        public int ktbatch(string name)
        {
            int id = 0;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select Count(name) from sys.tables where name = '" + name + "'";
                    con.Open();
                    id = (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return id;
        }
        public void Delete_AllBatch()
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "delete db_owner.[Imagecontent];DBCC CHECKIDENT ('db_owner.[imagecontent]', RESEED, 0)" +
                                             "delete db_owner.[AllImage];DBCC CHECKIDENT ('db_owner.[AllImage]', RESEED, 0)" +
                                             "delete dbo.ServerImage;DBCC CHECKIDENT ('dbo.ServerImage', RESEED, 0)" +
                                             "delete dbo.PfmLC;DBCC CHECKIDENT ('dbo.PfmLC', RESEED, 0)" +
                                             "delete dbo.DemDong;DBCC CHECKIDENT ('dbo.DemDong', RESEED, 0)"+
                                             "delete dbo.save_out;DBCC CHECKIDENT ('dbo.save_out', RESEED, 0)";  

                                            
                    //+"DROP TABLE [" + batchName + "]";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        public void Drop_Table(string batchName)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "DROP TABLE [" + batchName + "]";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        public List<string> GetImageOnServerWithListImage(string listimage)
        {
            List<string> list = new List<string>();
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select NameImage from dbo.ServerImage where NameImage in (" + listimage + ")";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(sqlDataReader["NameImage"].ToString().Trim());
                        }
                        sqlDataReader.Close();
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return list;
        }
        public DataTable GetImageOnServer()
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select AllImage.Id,ServerImage.NameImage, DateCreated,TurnUp from db_owner.AllImage join dbo.ServerImage on ServerImage.NameImage=AllImage.ImageName";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return dt;
        }
        public int GetId_AllImage(string name)
        {
            int id = 0;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select Id from db_owner.AllImage where ImageName = N'" + name + "'";
                    con.Open();
                    id = (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return id;
        }
        public void Insert_ImageContent(int id)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Insert into db_owner.ImageContent (AllImageId) values (" + id + ")";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        public int ktanhtrung(string name)
        {
            int id = -1;
            try
            {
                string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select Count(Id) from db_owner.AllImage where ImageName = N'" + name + "'";
                    con.Open();
                    id = (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
            return id;
        }
    }
}
