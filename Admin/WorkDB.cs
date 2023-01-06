﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace VCB_TEGAKI
{
    class WorkDB_Admin
    {
        //Chuoi ket noi co sdl
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        #region Entry_date
        //Lấy User đã nhập
        public DataTable GetUserID_Date(string startdate, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectUser";
                    sqlCommand.Parameters.Add("@GROUP", SqlDbType.NVarChar, 30).Value = group;
                    sqlCommand.Parameters.Add("@startdate", SqlDbType.NVarChar, 10).Value = startdate;
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    con.Open();
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }

        //Tổng ký tự nhập của từng user1
        public double Tongkytu1_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  SUM(Tongkytu1) as 'tt' From DB_owner.[Imagecontent] left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid1=[User].id Where LEFT(CONVERT(VARCHAR,InputDate1, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng ký tự nhập của từng user2
        public double Tongkytu2_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  SUM(Tongkytu2) as 'tt' From DB_owner.[Imagecontent] left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid2=[User].id Where LEFT(CONVERT(VARCHAR,InputDate2, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng truong của từng user1
        public double TongTruong1_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  Count(1) as 'tt' From DB_owner.[Imagecontent] left  join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid1=[User].id Where LEFT(CONVERT(VARCHAR,InputDate1, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng truong của từng user2
        public double TongTruong2_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  Count(1) as 'tt' From DB_owner.[Imagecontent] Left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid2=[User].id Where LEFT(CONVERT(VARCHAR,InputDate2, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng truong NG của từng user1
        public double TongTruongNG1_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  Count(1) as 'tt' From DB_owner.[Imagecontent] left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId Join db_owner.[User] on NG1=[User].id Where LEFT(CONVERT(VARCHAR,InputDate1, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng truong của từng user2
        public double TongTruongNG2_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  Count(1) as 'tt' From DB_owner.[Imagecontent] Left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId join db_owner.[User] on NG2=[User].id Where LEFT(CONVERT(VARCHAR,InputDate2, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng Loi sai của từng user1    
        public double Loisai1_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  SUM(Loisai1) as 'tt' From DB_owner.[Imagecontent] Left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid1=[User].id Where LEFT(CONVERT(VARCHAR,InputDate1, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy lỗi sai\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng Loi sai của từng user1    
        public double Loisai2_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  SUM(Loisai2) as 'tt' From DB_owner.[Imagecontent] left join db_owner.Image on Image.Id=ImageId join db_owner.Page on page.Id=PageId join dbo.Batch on Batch.Id=BatchId JOIN db_owner.[User] on userid2=[User].id Where LEFT(CONVERT(VARCHAR,InputDate2, 112), 10) ='" + startdate + "' and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " and Batch.Hitpoint =2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng ký tự nhập của từng user1
        public double Tongtime_Date(string MSNV, string startdate, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select  SUM(Timework) as 'tt' From Dbo.[Performance] Join Dbo.Batch on Batchid=Batch.id JOIN db_owner.[User] on Userid=[User].id Where  MSNV='" + MSNV + "' and Lvl=" + lvl + " and LEFT(CONVERT(VARCHAR,Starttime, 112), 10) ='" + startdate + "' and Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        #endregion
        #region Entry_TemplateBatch
        //Lấy User đã nhập
        public DataTable getPerformaceEntry(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"select us1.Email as 'FullName', us1.[Group] as N'Trung Tâm',LoisaiP1 as N'Lỗi sai', TimemilionP1 as N'Thời gian',NGP1 as 'NGP',MSNV from db_owner.AllUser as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserP1 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") union all (select us2.Email as 'FullName', us2.[Group] as N'Trung Tâm',LoisaiP2 as N'Lỗi sai', TimemilionP2 as N'Thời gian',NGP2 as 'NGP',MSNV from db_owner.AllUser as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserP2 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + "))";
                    else
                        sqlCommand.CommandText = @"select us1.Email as 'FullName', us1.[Group] as N'Trung Tâm',LoisaiP1 as N'Lỗi sai', TimemilionP1 as N'Thời gian',NGP1 as 'NGP',MSNV from db_owner.AllUser as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserP1 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") and us1.[Group]=N'" + group + "' union all (select us2.Email as 'FullName', us2.[Group] as N'Trung Tâm',LoisaiP2 as N'Lỗi sai', TimemilionP2 as N'Thời gian',NGP2 as 'NGP',MSNV from db_owner.AllUser as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserP2 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") and us2.[Group]=N'" + group + "')";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }

        //Tổng ký tự nhập của từng user1
        public double Tongkytu1_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(Tongkytu1) as 'tt' from db_owner.[User] as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng ký tự nhập của từng user2
        public double Tongkytu2_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(Tongkytu2) as 'tt' from db_owner.[User] as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng trường của từng user1
        public double TongTruong1_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select  Count(ImageContent.Id) as 'tt' from db_owner.[User] as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng trường nhập của từng user2
        public double TongTruong2_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select  Count(ImageContent.Id) as 'tt' from db_owner.[User] as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng trường not good của từng user1
        public double TongTruongNG1_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "select COUNT(NG1) as 'tt' from db_owner.[User] as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.Image on ImageContent.ImageId=Image.Id join dbo.Batch on Batch.Id=Image.IDBatch where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng trường not good nhập của từng user2
        public double TongTruongNG2_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "select COUNT(NG2) as 'tt' from db_owner.[User] as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.Image on ImageContent.ImageId=Image.Id join dbo.Batch on Batch.Id=Image.IDBatch where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]=" + lvl + " AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng Loi sai của từng user1    
        public double Loisai1_TemplateBatch(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(Loisai1) as 'tt' from db_owner.[User] as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy lỗi sai\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng Loi sai của từng user1    
        public double Loisai2_TemplateBatch(string MSNV, string listBatch, int lvl, int idtemplate)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(Loisai2) as 'tt' from db_owner.[User] as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        break;
                    }
                    sqlDataReader.Close();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        //Tổng ký tự nhập của từng user1
        public double Tongtime_TemplateBatch1(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(TimeMiliseconds1) as 'tt' from db_owner.[User] as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    //else
                    //    sqlCommand.CommandText = "Select  SUM(Timework) as 'tt' From Dbo.[Performance] JOIN db_owner.[User] on Userid=[User].id Where  MSNV='" + MSNV + "' and Lvl=" + lvl + " and Batchid in (" + listBatch + ") Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        try
                        {

                            tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        }
                        catch { }
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        public double Tongtime_TemplateBatch2(string MSNV, string listBatch, int lvl)
        {
            double tkt = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Select SUM(TimeMiliseconds2) as 'tt' from db_owner.[User] as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.Image on Image.Id=ImageContent.ImageId join dbo.Batch on Batch.Id=Image.IDBatch Where IDBatch in (" + listBatch + ") and [MSNV]='" + MSNV + "' and [Lvl]='" + lvl + "' AND Batch.Hitpoint=2 Group by MSNV";
                    //else
                    //    sqlCommand.CommandText = "Select  SUM(Timework) as 'tt' From Dbo.[Performance] JOIN db_owner.[User] on Userid=[User].id Where  MSNV='" + MSNV + "' and Lvl=" + lvl + " and Batchid in (" + listBatch + ") Group by MSNV";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        try
                        {

                            tkt = double.Parse(sqlDataReader["tt"].ToString().Trim());
                        }
                        catch { }
                        break;
                    }
                    sqlDataReader.Close();
                }
                //return tkt;
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return tkt;
        }
        #endregion
        public DataTable dtResult(string imgname)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT db_owner.AllImage.ImageName,Anh='',us1.Fullname,db_owner.ImageContent.Content1,Loisai1,us2.Fullname,db_owner.ImageContent.Content2,Loisai2,us3.Fullname,db_owner.ImageContent.Result FROM db_owner.AllImage Join db_owner.Imagecontent ON AllimageID = Allimage.ID Join db_owner.AllUser as us1 ON [Us1].id=Userid1 Join db_owner.AllUser as us2 ON [us2].id=Userid2 Join db_owner.AllUser as us3 ON [us3].id=Checkerid WHERE db_owner.AllImage.TurnUp in (" + imgname + ") and NG1 = 0 and NG2 = 0";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy table batch\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable dtResultQA(int imgname)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT db_owner.AllImage.ImageName,Anh='',us1.Fullname,db_owner.ImageContent.Content1,us2.Fullname,db_owner.ImageContent.Content2,us3.Fullname,db_owner.ImageContent.Result FROM db_owner.AllImage Join db_owner.Imagecontent ON AllimageID = Allimage.ID Join db_owner.AllUser as us1 ON [Us1].id=Userid1 Join db_owner.AllUser as us2 ON [us2].id=Userid2 Join db_owner.AllUser as us3 ON [us3].id=Checkerid WHERE db_owner.AllImage.ImageName = N'" + imgname + "' and NG1 <> 0 or NG2 <> 0";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy table batch\n" + sqlException.Message);
            }
            return dt;
        }
        #region Check
        public DataTable SelectCheck_Date(string dateString, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SelectCheck_Date";
                    sqlCommand.Parameters.Add("@GROUP", SqlDbType.NVarChar, 30).Value = group;
                    sqlCommand.Parameters.Add("@startdate", SqlDbType.NVarChar, 10).Value = dateString;
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable Tongtime_check(string dateString, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"Select MSNV,Lvl,SUM(timework) From DB_owner.[User] Join dbo.PerformanceCheck on userid=[User].ID Where LEFT(CONVERT(VARCHAR,Starttime, 112), 10) ='" + dateString + "' and timework>0 group by MSNV,lvl order by MSNV";
                    else
                        sqlCommand.CommandText = @"Select MSNV,Lvl,SUM(timework) From DB_owner.[User] Join dbo.PerformanceCheck on userid=[User].ID Where LEFT(CONVERT(VARCHAR,Starttime, 112), 10) ='" + dateString + "' and [Group]='" + group + "' and timework>0  group by MSNV,lvl order by MSNV";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable SelectCheck_TemplateBatch(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"Select Fullname as 'Họ và tên',Lvl as 'Level',[Group] as 'Trung tâm',COUNT(1) as 'Tổng trường','Thời gian(phút)'=0.0,'Tốc độ(trường/phút)'=0.0,'Đảm nhận(%)'=0.0,MSNV From DB_owner.[Imagecontent] join db_owner.Image on Image.Id = ImageId Join DB_owner.[User] On CheckerId=[User].ID Join dbo.Batch ON batch.id=IDBatch  Where IDBatch in (" + listBatch + ") AND Batch.Hitpoint=2 group by Fullname,MSNV,Lvl,[Group] order by MSNV";
                    else
                        sqlCommand.CommandText = "Select Fullname as 'Họ và tên',Lvl as 'Level',[Group] as 'Trung tâm',COUNT(1) as 'Tổng trường','Thời gian(phút)'=0.0,'Tốc độ(trường/phút)'=0.0,'Đảm nhận(%)'=0.0,MSNV From DB_owner.[Imagecontent] join db_owner.Image on Image.Id = ImageId Join DB_owner.[User] On CheckerId=[User].ID Join dbo.Batch ON batch.id=IDBatch  Where IDBatch in (" + listBatch + ") AND Batch.Hitpoint=2 and [Group]=N'" + group + "' group by Fullname,MSNV,Lvl,[Group] order by MSNV";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable All_Check(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"select us3.Fullname,us3.Lvl,us3.[Group] as N'Trung tâm',TimemilionCK as N'Thời gian',MSNV from db_owner.AllUser as us3 join db_owner.ImageContent on us3.Id=ImageContent.CheckerId join db_owner.AllImage on AllImage.Id=ImageContent.AllImageId where AllImageID in (" + listBatch + ")";
                    else
                        sqlCommand.CommandText = @"select us3.Fullname,us3.Lvl,us3.[Group] as N'Trung tâm',TimemilionCK as N'Thời gian',MSNV from db_owner.AllUser as us3 join db_owner.ImageContent on us3.Id=ImageContent.CheckerId join db_owner.AllImage on AllImage.Id=ImageContent.AllImageId where AllImageID in (" + listBatch + ") and us3.[Group] = N'" + group + "'";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable All_CheckP(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"select Fullname,[Group] as N'Trung tâm',TimemilionCP as N'Thời gian',MSNV from db_owner.AllUser join db_owner.ImageContent on AllUser.Id=ImageContent.CheckIDP where AllImageId in (" + listBatch + ")";
                    else
                        sqlCommand.CommandText = @"select Fullname,[Group] as N'Trung tâm',TimemilionCP as N'Thời gian',MSNV from db_owner.AllUser join db_owner.ImageContent on AllUser.Id=ImageContent.CheckIDP where AllImageId in (" + listBatch + ") and AllUser.[Group] = N'" + group + "'";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        #endregion
        #region Lastcheck
        public DataTable All_Lastcheck(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"select us3.Fullname,us3.[Group] as N'Trung tâm',PathUri as 'Tổng phiếu' ,TimeWork as N'Thời gian',Batch.Name as N'Tên Batch',MSNV from db_owner.[User] as us3 join dbo.PerformanceLastCheck on us3.Id=PerformanceLastCheck.UserID join dbo.Batch on PerformanceLastCheck.BatchID=Batch.Id join db_owner.Page on Batch.Id=Page.BatchId where Batch.Id in (" + listBatch + ")";
                    else
                        sqlCommand.CommandText = @"select us3.Fullname,us3.[Group] as N'Trung tâm',PathUri as 'Tổng phiếu' ,TimeWork as N'Thời gian',Batch.Name as N'Tên Batch',MSNV from db_owner.[User] as us3 join dbo.PerformanceLastCheck on us3.Id=PerformanceLastCheck.UserID join dbo.Batch on PerformanceLastCheck.BatchID=Batch.Id join db_owner.Page on Batch.Id=Page.BatchId where Batch.Id in (" + listBatch + ") and us3.[Group] = N'" + group + "'";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable SelectLastCheck_Listbatch(string listbatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    if (group == "ALL")
                        if (listbatch == "-1")
                            sqlCommand.CommandText = @"select Fullname as 'Họ và tên',[Group] as 'Trung tâm','Tổng phiếu'=0.0,Round(Sum(Timework)/60.0,2) as 'Thời gian(phút)','Tốc độ(phiếu/phút)'=0.0,'Đảm nhận(%)'=0.0,Batch.Name,dbo.PerformanceLastCheck.BatchId as 'MSNV'  from dbo.PerformanceLastCheck Join dbo.Batch on Batch.Id=Batchid join db_owner.[User] on userid=[User].id  Where BatchID in (" + listbatch + ") AND Batch.Hitpoint=2 and timework>0 group by Fullname,dbo.PerformanceLastCheck.BatchId,Batch.Name,[Group]";
                        else
                            sqlCommand.CommandText = @"select Fullname as 'Họ và tên',[Group] as 'Trung tâm','Tổng phiếu'=0.0,Round(Sum(Timework)/60.0,2) as 'Thời gian(phút)','Tốc độ(phiếu/phút)'=0.0,'Đảm nhận(%)'=0.0,Batch.Name,dbo.PerformanceLastCheck.BatchId as 'MSNV'  from dbo.PerformanceLastCheck Join dbo.Batch on Batch.Id=Batchid join db_owner.[User] on userid=[User].id  Where BatchID in (" + listbatch + ") and [Group]=N'" + group + "' AND Batch.Hitpoint=2 and timework>0 group by Fullname,dbo.PerformanceLastCheck.BatchId,Batch.Name,[Group]";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error connect SelectLastCheck_Listbatch \n" + sqlException.Message);
            }
            return dt;
        }
        public double Phieu(string batchid)
        {
            double vl = 0.0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Count(page.id) as vl from db_owner.[Page] where batchid = " + batchid;
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vl = double.Parse(sqlDataReader["vl"].ToString());
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error connect\n" + sqlException.Message);
            }
            return vl;
        }
        #endregion
        //Get User
        public DataTable daUser(string username)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,Name,Password,Role from db_owner.[user] Where Upper(name) Like @name ";
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = username.Trim();
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        //Kiểm tra username,pass login
        public string password(string username)
        {
            string pass = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Password from db_owner.[User] where UPPER(Name) = N'" + username + "'";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        pass = sqlDataReader["Password"].ToString().Trim();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình kiem tra password\n" + sqlException.Message);
            }
            return pass;
        }
        //update password
        public void Updatepassword(string pass, string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.[User] SET Password = N'" + pass + "' where UPPER(Name) ='" + name + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        //Create New User
        public void NewUser(string username, string fulname, string lvl, string pair, string group, string email, string role, string MSNV)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "INSERT INTO db_owner.Alluser (Role,Name,Password,lvl,email,Pair,[Group],MSNV,LastChangeDate,LockUser,Fullname) VALUES(N'" + role + "',N'" + username.Trim().ToUpper() + "','123456',N'" + lvl + "',N'" + email + "',N'" + pair + "',N'" + group + "',N'" + MSNV + "',getdate(),N'False',N'" + fulname + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        // reset Passwword
        public void ResetPassWord(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.Alluser Set Password=N'123456' where id=" + id + "";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        //Update User
        public void UpdateUser(int id, string fulname, string lvl, string pair, string group, string email, string role, string MSNV)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.Alluser Set Role=N'" + role + "',lvl=N'" + lvl + "',email=N'" + email + "',Pair=N'" + pair + "',[Group]=N'" + group + "',MSNV=N'" + MSNV + "',Fullname=N'" + fulname + "' where id=" + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        //Get table User
        public DataTable daAllUser()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id, role,Name as 'User',Fullname,[Group],MSNV, Email,Pair,Lvl from db_owner.AllUser";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        //Get table User
        public DataTable daAllFullname()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Distinct(Fullname) from db_owner.[user] order by Fullname";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        //Delete User
        public void DeleteUser(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Delete db_owner.[imagecontent] from db_owner.[imagecontent] join db_owner.AllUser on userid1=AllUser.id where userid1=" + id;
                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Connection = con;
                    sqlCommand1.CommandText = "Delete db_owner.[imagecontent] from db_owner.[imagecontent] join db_owner.AllUser on userid2=AllUser.id where userid2=" + id;
                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Connection = con;
                    sqlCommand2.CommandText = "Delete db_owner.Alluser where id=" + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand1.ExecuteNonQuery();
                    sqlCommand2.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        //Get table User
        public DataTable daTemplate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select id,name from db_owner.[Formtemplate]";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        //Get table User
        public DataTable daBatch()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select AllImage.Id as N'Id', AllImage.ImageName as N'Name' from db_owner.AllImage join db_owner.ImageContent on AllImage.Id = ImageContent.AllImageID";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        public DataTable Get_X2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.X2";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_X3()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.X3";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_X4()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.X4";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_X5()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.X5";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_CSPD()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.CSPD";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_CSPS()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select * from dbo.CSPS";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }

        //get SoPhieu, SoDong in Batch
        public DataTable GetSoPhieu_SoDong(string lstBatchPFM)
        {
            DataTable dt = new DataTable();
            if (!lstBatchPFM.Equals(""))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select Sum(SoPhieu) as N'Số phiếu', Sum(SoDong) as N'Số dòng' from dbo.Batch where Id in (" + lstBatchPFM + ")";
                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                        con.Open();
                        sqldataAdapter.SelectCommand = sqlCommand;
                        sqldataAdapter.Fill(dt);
                    }

                }
                catch (Exception ex)
                {
                    throw new System.Exception("Lỗi khi lây du liêu \n" + ex.Message);
                }
            }
            return dt;
        }
        //get SoPhieu, SoDong in Batch by UploadDate
        public DataTable GetSoPhieu_SoDongByUpdateDate(string date)
        {
            DataTable dt = new DataTable();
            if (!date.Equals(""))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select SoPhieu, SoDong from dbo.Batch where CAST(UploadDate as date) = '" + date + "'";
                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                        con.Open();
                        sqldataAdapter.SelectCommand = sqlCommand;
                        sqldataAdapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new System.Exception("Lỗi khi lây du liêu \n" + ex.Message);
                }
            }
            return dt;
        }
        public DataTable Get_AllBatch()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id,Name from db_owner.AllImage";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_allTemp()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id,TempName as 'TempName',Rules,Colum1_1,Colum1_2,Colum1_3,MaCot1 as '代理店コード',MaCot2 as '直送先コード',MaCot3 as '出荷元 倉庫',Poi_Sop,Poi_Rules,Poi_Rules_Truong1,Form6 from dbo.Template_Demo";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_allTempDemo()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    //sqlCommand.CommandText = "select Id,TempName as 'TempName',Rules,Colum1_1,Colum1_2,Colum1_3,MaCot1 as '代理店コード',MaCot2 as '直送先コード',MaCot3 as '出荷元 倉庫',Poi_Sop,Poi_SOP_PL,Poi_Rules,Poi_Rules_Truong1,[Form 6],Binary_Poi_Sop,Binary_Poi_Sop_PL  from dbo.Template_Demo";

                    sqlCommand.CommandText = "SELECT dbo.Template_Demo.Id,TempName as 'TempName',Rules,Colum1_1,Colum1_2,Colum1_3,MaCot1 as '代理店コード',MaCot2 as '直送先コード',MaCot3 as '出荷元 倉庫',dbo.ServerImageSOP_Demo.Poi_SOP,dbo.ServerImageSOP_Demo.Poi_SOP_PL,Poi_Rules,Poi_Rules_Truong1,[Form 6],dbo.Template_Demo.Poi_SOP AS PoiSop from dbo.Template_Demo LEFT JOIN dbo.ServerImageSOP_Demo ON dbo.Template_Demo.Id = dbo.ServerImageSOP_Demo.TemplateID";
                    SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                    con.Open();
                    sqldataAdapter.SelectCommand = sqlCommand;
                    sqldataAdapter.Fill(dt);
                }
                return dt;
            }
            catch(SqlException sqlex)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlex.Message);
            }
        }
        public DataTable Get_Id_Name_Template()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id,TempName as 'Name' from dbo.Template_Demo";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        #region Demo Template
        public DataTable Get_Id_Name_TemplateDemo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id,TempName as 'Name' from dbo.Template_Demo";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        #endregion
        public DataTable Get_DemDong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select * from dbo.DemDong";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_ALLDATA_DemDong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select  AllImage.Id,AllImage.TurnUp,AllImage.ImageName,TimemilionP1,TimemilionP2,TimemilionE1,TimemilionE2,TimemilionCP,TimemilionCK from db_owner.[ImageContent] left join db_owner.AllImage on db_owner.ImageContent.AllImageId = db_owner.AllImage.Id";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_DataLC_DemDong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select TurnUp, CONVERT(INT, TimeLC) as 'TimeLC' from dbo.[PfmLC] ";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_All_Image_Change()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id,ImageName,TurnUp  from db_owner.AllImage ";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_status(string lstbatch)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select IDbatch, Content1, Content2,Pair1, Pair2, Image.HitPoint, Image.Status,us1.[Group] as g1,us2.[Group] as g2 from db_owner.[Image] left join db_owner.ImageContent on db_owner.ImageContent.ImageId = db_owner.Image.Id left join db_owner.[user] as us1 ON Pair1=us1.id left join db_owner.[user] as us2 on Pair2=us2.id where IdBatch in (" + lstbatch + ")";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_LC1()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id, ImageName, Hitpoint1, Hitpoint2, NG1, NG2, InfoP, InfoE from db_owner.AllImage where TurnUp = 1";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_LC2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id, ImageName, Hitpoint1, Hitpoint2, NG1, NG2, InfoP, InfoE from db_owner.AllImage where TurnUp = 2";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_LC3()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id, ImageName, Hitpoint1, Hitpoint2, NG1, NG2, InfoP, InfoE from db_owner.AllImage where TurnUp = 3";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_LC4()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id, ImageName, Hitpoint1, Hitpoint2, NG1, NG2, InfoP, InfoE from db_owner.AllImage where TurnUp = 4";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_LCAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id, ImageName, Hitpoint1, Hitpoint2, NG1, NG2, InfoP, InfoE from db_owner.AllImage";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        //public DataTable Get_alldetails(int id)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(stringconnecttion))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = con;
        //        sqlCommand.CommandText = "select us1.Email as 'Entry1',Content1,us1.[Group] as 'tte1' ,us2.Email as 'Entry2',Content2, us2.[Group] as 'tte2', us3.Email as 'CheckP', ResultP,Content2, us3.[Group] as 'ttcp',  us4.Email as 'Checker', Checkresult, Content2, us4.[Group] as 'ttch'  from db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id=ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id=ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id=ImageContent.CheckerId where AllImageId = " + id;
        //        SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
        //        con.Open();
        //        sqldataAdapter.SelectCommand = sqlCommand;
        //        sqldataAdapter.Fill(dt);
        //    }
        //    return dt;
        //}
        public DataTable Get_alldetails(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                //sqlCommand.CommandText = "select us1.Email as 'Entry1',Content1,us1.[Group] as 'tte1' ,us2.Email as 'Entry2',Content2, us2.[Group] as 'tte2', us3.Email as 'CheckP', ResultP,Content2, us3.[Group] as 'ttcp',  us4.Email as 'Checker', Checkresult, Content2, us4.[Group] as 'ttch', us5.Email as 'ustp1',us5.[Group] as 'ttp1',us6.Email as 'ustp2',us6.[Group] as 'ttp2',User_Exit_Img_E1,User_Exit_Img_E2,us4.[Name] as 'UserCheck'  from db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id=ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id=ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id=ImageContent.CheckerId left join db_owner.AllUser as us5 on us5.Id=ImageContent.UserP1 left join db_owner.AllUser as us6 on us6.Id=ImageContent.UserP2 where AllImageId = " + id;
                sqlCommand.CommandText = "select us1.Email as 'Entry1',Content1,us1.[Group] as 'tte1' ,us2.Email as 'Entry2',Content2, us2.[Group] as 'tte2', us3.Email as 'CheckP', ResultP,Content2, us3.[Group] as 'ttcp',  us4.Email as 'Checker', Checkresult, Content2, us4.[Group] as 'ttch', us5.Email as 'ustp1',us5.[Group] as 'ttp1',us6.Email as 'ustp2',us6.[Group] as 'ttp2',User_Exit_Img_E1,User_Exit_Img_E2,us4.[Name] as 'UserCheck',us7.Email AS 'LastCheck', us7.[Group] as 'ttp3'   from db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id = ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id = ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id = ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id = ImageContent.CheckerId left join db_owner.AllUser as us5 on us5.Id = ImageContent.UserP1 left join db_owner.AllUser as us6 on us6.Id = ImageContent.UserP2 LEFT JOIN db_owner.AllUser AS us7 ON us7.Id = ImageContent.UserLC_Done  where AllImageId = " + id;
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        #region tailnt
        public DataTable Get_alldetails_Export(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                //sqlCommand.CommandText = "select us1.Email as 'Entry1',Content1,us1.[Group] as 'tte1' ,us2.Email as 'Entry2',Content2, us2.[Group] as 'tte2', us3.Email as 'CheckP', ResultP,Content2, us3.[Group] as 'ttcp',  us4.Email as 'Checker', Checkresult, Content2, us4.[Group] as 'ttch', us5.Email as 'ustp1',us5.[Group] as 'ttp1',us6.Email as 'ustp2',us6.[Group] as 'ttp2',User_Exit_Img_E1,User_Exit_Img_E2,us4.[Name] as 'UserCheck'  from db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id=ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id=ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id=ImageContent.CheckerId left join db_owner.AllUser as us5 on us5.Id=ImageContent.UserP1 left join db_owner.AllUser as us6 on us6.Id=ImageContent.UserP2 where AllImageId = " + id;
                sqlCommand.CommandText = "SELECT ResultP AS 'CP', us1.Email +' - '+ us1.[Group] as 'User Entry1',Content1 AS 'Entry1',us2.Email  +' - '+ us2.[Group] as 'User Entry2',Content2 AS 'Entry2',us3.Email + ' - ' + us3.[Group] AS 'CheckP',us4.Email + ' - ' + us4.[Group] as 'Checker' ,Checkresult,us5.Email +' - '+ us5.[Group] AS 'EntryPL1',us6.Email +' - '+us6.[Group] AS 'EntryPL2',User_Exit_Img_E1 AS 'E1',User_Exit_Img_E2 AS 'E2',us4.[Name] as 'UserCheck',us7.Email+' - '+us7.[Group] AS 'Last Check'  FROM db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id=ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id=ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id=ImageContent.CheckerId left join db_owner.AllUser as us5 on us5.Id=ImageContent.UserP1 left join db_owner.AllUser as us6 on us6.Id=ImageContent.UserP2 LEFT JOIN db_owner.AllUser AS us7 ON us7.Id = ImageContent.UserLC_Done where AllImageId = " + id;
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        #endregion
        public DataTable Get_alldetails_1()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select us5.ImageName,us1.Email as 'Entry1',Content1,us1.[Group] as 'tte1' ,us2.Email as 'Entry2',Content2, us2.[Group] as 'tte2', us3.Email as 'CheckP', ResultP,Content2, us3.[Group] as 'ttcp',  us4.Email as 'Checker', Checkresult, Content2, us4.[Group] as 'ttch',User_Exit_Img_E1 as 'Error_E1',User_Exit_Img_E2 as 'Error_E2'  from db_owner.ImageContent left join db_owner.AllUser as us1 on us1.Id=ImageContent.UserId1 left join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 left join db_owner.AllUser as us3 on us3.Id=ImageContent.CheckIDP left join db_owner.AllUser as us4 on us4.Id=ImageContent.CheckerId left join db_owner.AllImage as us5 on us5.Id=ImageContent.AllImageId";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Ctrl_1(int Id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "Fix_Error_null1";
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    con.Open();
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable Search_All(string ab)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "search_all";
                    sqlCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = ab;
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    con.Open();
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }

        public DataTable Ctrl_2(int Id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "Fix_Result_null2";
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    con.Open();
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }
        public void Ctrl_3(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Delete from dbo.LastCheck where BatchID=" + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public DataTable dttrungtam()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select distinct([Group]) as trungtam from db_owner.AllUser";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy trung tam\n" + sqlException.Message);
            }
            if (dt.Rows.Count > 0)
                dt.Rows.Add("ALL");
            return dt;
        }

        public byte[] GetImageBatch(string imageName)
        {
            byte[] image = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select BinaryImage from dbo.ServerImage join db_owner.AllImage on ServerImage.NameImage = AllImage.ImageName where ImageName = N'" + imageName + "'";
                    con.Open();
                    image = (byte[])sqlCommand.ExecuteScalar();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy image\n" + sqlException.Message);
            }
            return image;
        }
        public byte[] GetImage_BackUP(string imageName)
        {

            byte[] image = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select BinaryImage from dbo.ServerImage  where NameImage = N'" + imageName + "'";
                    con.Open();
                    image = (byte[])sqlCommand.ExecuteScalar();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy image\n" + sqlException.Message);
            }
            return image;
        }
        public byte[] GetImage_BackUP2111(int id)
        {
            string stringconnecttion22 = String.Format(@"Data Source=192.168.1.3; Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");
            byte[] image = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion22))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select SopImage from dbo.Template_Demo  where Id = " + id;
                    con.Open();
                    image = (byte[])sqlCommand.ExecuteScalar();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy image\n" + sqlException.Message);
            }
            return image;
        }
        public DataTable All_User()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "Select Id,[Role],Name,Fullname,[Group] from db_owner.[User]";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        public DataTable All_details(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "Select MSNV,Email,Lvl,Pair from db_owner.[User] where Id = " + id + "";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;

        }
        public int ktuser(string user)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select count(Id) from db_owner.AllUser where Name = N'" + user + "'";
                    con.Open();
                    id = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            { }
            return id;
        }
        public int get_Idanh(string nameImage)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select Id from db_owner.AllImage where ImageName = N'" + nameImage + "'";
                    con.Open();
                    id = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            { }
            return id;
        }
        public void Update_X2(string x2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.X2 SET Content = N'" + x2 + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_X3(string x3)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.X3 SET Content = N'" + x3 + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_X4(string x4)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.X4 SET Content = N'" + x4 + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_X5(string x5)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.X5 SET Content = N'" + x5 + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_Change_Dot(string nameImage, int Id, int TurnUpDot)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.AllImage  SET TurnUp = " + TurnUpDot + " where ImageName = N'" + nameImage + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_CD(string cd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.CSPD SET Content = N'" + cd + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Update_CS(string cs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.CSPS SET Content = N'" + cs + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_X2(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X2 (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_X3(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X3 (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_X4(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X4 (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_X5(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X5 (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_CD(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.CSPD (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Insert_CS(string ct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.CSPS (Content) values (N'" + ct + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public int ktlc(int lc)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "select COUNT(id) from dbo.LastCheck where BatchID = " + lc + "";
                    con.Open();
                    id = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            { }
            return id;
        }
        public void Insert_SOP(int idimg, byte[] image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "InsertSOPDemo";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@IDimage", SqlDbType.Int).Value = idimg;
                    con.Open();
                    using (SqlDataReader vendorReader = sqlCommand.ExecuteReader())
                    { }
                }
            }
            catch { }
        }
        //public void Insert_SOP(int idimg, byte[] image)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.CommandText = "InsertSOP";
        //            sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
        //            sqlCommand.Parameters.Add("@IDimage", SqlDbType.Int).Value = idimg;
        //            con.Open();
        //            using (SqlDataReader vendorReader = sqlCommand.ExecuteReader())
        //            { }
        //        }
        //    }
        //    catch { }
        //}
        public void Return_Entry_PL(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 0,Hitpoint2 = 0,InfoP = 0,InfoE = 0 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_P2(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 0,Hitpoint2 = 0, InfoP = 0 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_CP(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 1, Hitpoint2 = 1,InfoP = 2,InfoE = 0 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_Entry(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 2,Hitpoint2 = 2, InfoP = 0,InfoE = 0 where Id = " + id; //+ "; Update db_owner.ImageContent set Content1 = NULL, UserId1 = NULL,InputDate1 = NULL where Id = " + id ;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_E2(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint2 = 2, InfoP = 0 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_Check(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 3,Hitpoint2 = 3,InfoE = 2 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public void Return_QC(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.AllImage set Hitpoint1 = 3,Hitpoint2 = 3,InfoE = 3 where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        public DataTable Get_PFM(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id from db_owner.AllImage where TurnUp =" + id;
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_PFMAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select Id from db_owner.AllImage";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_PFMEntry(string listBatch, string group)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    if (group == "ALL")
                        sqlCommand.CommandText = @"select us1.Email as 'FullName',us1.Lvl as 'Level', us1.[Group] as N'Trung Tâm',Tongkytu1 as N'Tổng ký tự',Loisai1 as N'Lỗi sai',N'Tỉ lệ sai'=0.0, TimemilionE1 as 'Thời gian',NG1 as 'NG',MSNV from db_owner.AllUser as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") union all (select us2.Email as 'FullName',us2.Lvl as 'Level', us2.[Group] as N'Trung Tâm',Tongkytu2 as N'Tổng ký tự',Loisai2 as N'Lỗi sai',N'Tỉ lệ sai'=0.0, TimemilionE2 as 'Thời gian', NG2 as 'NG',MSNV from db_owner.AllUser as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + "))";
                    else
                        sqlCommand.CommandText = @"select us1.Email as 'FullName',us1.Lvl as 'Level', us1.[Group] as N'Trung Tâm',Tongkytu1 as N'Tổng ký tự',Loisai1 as N'Lỗi sai',N'Tỉ lệ sai'=0.0, TimemilionE1 as 'Thời gian',NG1 as 'NG',MSNV from db_owner.AllUser as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserId1 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") and us1.[Group]=N'" + group + "' union all (select us2.Email as 'FullName',us2.Lvl as 'Level', us2.[Group] as N'Trung Tâm',Tongkytu2 as N'Tổng ký tự',Loisai2 as N'Lỗi sai',N'Tỉ lệ sai'=0.0, TimemilionE2 as 'Thời gian', NG2 as 'NG',MSNV from db_owner.AllUser as us2 join db_owner.ImageContent on us2.Id=ImageContent.UserId2 left join db_owner.AllImage on AllImage.Id = ImageContent.AllImageId where AllImageId in (" + listBatch + ") and us2.[Group]=N'" + group + "')";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return dt;
        }
        public void DeleteTemplate(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Delete dbo.Template_Demo where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public void DeleteTemplateDemo(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Delete dbo.Template_Demo where Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public void Insert_Template(string Tempname, string rule, string code, int rule8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.Template_Demo (TempName,Rules,CodeNumber,set_Rule_8) values (N'" + Tempname + "',N'" + rule + "',N'" + code + "'," + rule8 + ")";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public void Insert_TemplateDemo(string Tempname, string rule, string code, int rule8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.Template_Demo (TempName,Rules,CodeNumber,set_Rule_8) values (N'" + Tempname + "',N'" + rule + "',N'" + code + "'," + rule8 + ")";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public string Get_imgname(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Id from dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
        public string Get_imgnameDemo(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Id from dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
        public void Update_Template(string Tempname, string rule, string code, string id, int Rule8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update dbo.Template_Demo set TempName = N'" + Tempname + "',Rules = N'" + rule + "',set_Rule_8 = " + Rule8 + ",CodeNumber = N'" + code + "' where Id=" + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public void Update_TemplateDemo(string Tempname, string rule, string code, string id, int Rule8)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update dbo.Template_Demo set TempName = N'" + Tempname + "',Rules = N'" + rule + "',set_Rule_8 = " + Rule8 + ",CodeNumber = N'" + code + "' where Id=" + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Connection failed!" + sqlException.Message);
            }
        }
        public DataTable GetAll_LC(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Fullname,[Group] as N'Trung tâm' from db_owner.AllUser where Id ='" + id + "'";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable Get_PFMLC(string listBatch)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Lcid, CONVERT(INT, TimeLC)  as N'Time', TurnUp from dbo.PfmLC where TurnUp in (" + listBatch + ")";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public DataTable Get_PFMLCALL()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Lcid, CONVERT(INT, TimeLC)  as N'Time', TurnUp from dbo.PfmLC";
                    con.Open();
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy tổng ký tự\n" + sqlException.Message);
            }
            return dt;
        }
        public string Get_LcFn(int id)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT FullName from db_owner.AllUser where Id = " + id + "";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            { }
            return bb;
        }
        public string Get_LcGr(int id)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT [Group] from db_owner.AllUser where Id = " + id + "";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            { }
            return bb;
        }
        public string Get_Lcsl(string id)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Count(Id) from db_owner.AllImage where TurnUp = '" + id + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            { }
            return bb;
        }
        public string Get_Lcdn()
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Count(Id) from db_owner.AllImage";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            { }
            return bb;
        }
        public DataTable GetDatatableSQL(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sql;
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;
                    con.Open();
                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new Exception("Có lỗi trong quá trình lấy datatable\n" + sqlException.Message);
            }
            return dt;
        }
        public void Insert_Image_Draw(string NameItem, byte[] image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Update dbo.[Template] set Image_Draw = @Image_Draw where TempName = N'" + NameItem + "'";
                    sqlCommand.Parameters.Add(new SqlParameter("@Image_Draw", image));
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new Exception("Có lỗi trong quá trình thực thi câu lệnh Insert Kain \n" + sqlException.Message);
                //return;
            }
            finally
            {

            }
        }
        public void Insert_Image_DrawDemo(string NameItem, byte[] image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Update dbo.[Template_Demo] set Image_Draw = @Image_Draw where TempName = N'" + NameItem + "'";
                    sqlCommand.Parameters.Add(new SqlParameter("@Image_Draw", image));
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new Exception("Có lỗi trong quá trình thực thi câu lệnh Insert Kain \n" + sqlException.Message);
                //return;
            }
            finally
            {

            }
        }

    }
}