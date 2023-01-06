﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
namespace VCB_TEGAKI
{
    class WorkDB_LC
    {
        //Chuoi ket noi co sdl
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog="+Program.database+";User Id="+Program.user+ ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        //Lấy User đã nhập
        public DataTable GetUserID(string startdate, string enddate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select DISTINCT(Name),tongphieu=0.0,phieudung=0.0,phieusai=0.0,tyledung=0.0,tylesai=0.0,Userid From DB_owner.[Imagecontent] Join DB_owner.[User] On UserID=[User].ID Where InputDate <= CONVERT(DATETIME2,'" + enddate + " 23:59:59:00') and InputDate >= CONVERT(DATETIME2,'" + startdate + " 01:00:00:00') and Checked=0 ORDER by UserID";
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

        //Đếm số phiếu nhập của từng user
        public int Demphieunhap(int UserID, string startdate, string enddate)
        {
            int count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select COUNT(*) From DB_owner.[Imagecontent] Where InputDate <= CONVERT(DATETIME2,'" + enddate + "') and InputDate >= CONVERT(DATETIME2,'" + startdate + "') and Checked=0 and UserID='" + UserID + "'";
                    con.Open();
                    count = (int)sqlCommand.ExecuteScalar();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return count;
        }

        //Đếm số phiếu nhập sai của từng user
        public int phieunhapsai(int UserID, string startdate, string enddate)
        {
            int count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select COUNT(*) From DB_owner.[Imagecontent] Where CheckedDate <= CONVERT(DATETIME2,'" + enddate + " 23:59:59:00') and CheckedDate >= CONVERT(DATETIME2,'" + startdate + " 01:00:00:00') and UserID='" + UserID + "' and (Checked=1 OR checked=1.5) ";
                    con.Open();
                    count = (int)sqlCommand.ExecuteScalar();
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy Entry\n" + sqlException.Message);
            }
            return count;
        }
        public DataTable dtLastcheck(int dot, string template, int lctong)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (lctong == 0)
                    {
                        sqlCommand.CommandText = "select ImageName,Result,AllImageID,Content1,Content2,Checkresult,ResultP from db_owner.AllImage join db_owner.Imagecontent on AllImage.Id=ImageContent.AllImageId where TurnUp = " + dot + " and Result is not null and UserLC_Keep_Img = 0 and UserLC_Done = 0 and ResultP = N'"+ template + "'";
                    }
                    else
                    {
                        sqlCommand.CommandText = "select ImageName,Result,AllImageID,Content1,Content2,Checkresult,ResultP from db_owner.AllImage join db_owner.Imagecontent on AllImage.Id=ImageContent.AllImageId where TurnUp = " + dot + " and Result is not null and UserLC_Done > 0 ";
                    }
                    
                    SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                    sqldataAdapter.SelectCommand = sqlCommand;
                    con.Open();
                    sqldataAdapter.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                throw new System.Exception("Lỗi khi lây du liêu LC\n" + ex.Message);
            }
            return dt;
        }
        public string PathUri(string pathUri, int batchid)
        {
            string returnVal = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Image.pathUri FROM db_owner.[page] Join db_owner.[image] ON pageid= [page].id WHERE [page].PathUri = '" + pathUri + "' AND batchID = " + batchid;
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        returnVal = sqlDataReader["pathUri"].ToString();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy pathUri\n" + sqlException.Message);
            }
            return returnVal;
        }

        public string[] InsertPerformance(int batchId, int userid)
        {

            string[] id = null;
            id = new string[2];
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "InsertPerformanceLastCheck";
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@StartTime", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int, 30).Value = batchId;
                    sqlCommand.Parameters.Add("@UserID", SqlDbType.Int, 10).Value = userid;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    try
                    {
                        id[0] = sqlCommand.Parameters["@ID"].Value.ToString();
                        id[1] = sqlCommand.Parameters["@StartTime"].Value.ToString();
                    }
                    catch
                    {
                        id[0] = "";
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            return id;
        }
        public bool UpdatePerformance(string starttime, int ID)
        {

            bool id = false;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdatePerformanceLastCheck";
                    sqlCommand.Parameters.Add("@Starttime", SqlDbType.DateTime, 30).Value = starttime;
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 10).Value = ID;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    id = true;
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình đọc dữ liệu\n" + sqlException.Message);
            }
            return id;
        }
        /// <summary>
        /// Insert Lastcheck
        /// </summary>       
        public int InsertLastcheck(int userid, byte[] obook)
        {
            int id = 0;
            //Insert Page    
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "INSERT INTO dbo.Lastcheck (userID,FileLC) VALUES (" + userid + ",@obook); Select SCOPE_IDENTITY();";
                    sqlCommand.Parameters.Add(new SqlParameter("@obook", obook));
                    con.Open();
                    id = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                }
                //sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Insert page\n" + sqlException.Message);
            }
            return id;
        }

        //Update Lastcheck
        public void UpdateLastcheck(int batchid, int userid, byte[] obook, int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.Lastcheck SET batchID = " + batchid + ",UserID=" + userid + ",FileLC=@obook WHERE ID = " + id;
                    sqlCommand.Parameters.Add(new SqlParameter("@obook", obook));
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }

        /// <summary>
        /// Check batchid
        /// </summary>
        /// <param name="template"></param>        
        public int CheckBatch(int batchid)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT [ID] FROM dbo.LastCheck WHERE batchID = " + batchid;
                    con.Open();
                    id = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            {
            }
            return id;
        }
        public void RetrieveExcelFromDatabase(int ID, string batchName)
        {
            byte[] excelContents;
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), batchName + ".csv");

            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "SELECT FileLC FROM dbo.Lastcheck WHERE ID = @ID";
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                con.Open();
                excelContents = (byte[])sqlCommand.ExecuteScalar();
            }
            File.WriteAllBytes(path, excelContents);
        }

        //Update số phiếu, số dòng trong Batch 
        public void UpdateBatch(int batchid, int soPhieu, int soDong)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.Batch SET SoPhieu = " + soPhieu + ",SoDong=" + soDong + " WHERE Id = " + batchid;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Batch\n" + sqlException.Message);
            }
        }
        public byte[] getImageOnServer(string Name)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.ServerImage WHERE NameImage = N'" + Name + "'";
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Không có ảnh trên server\n" + sqlException.Message);
            }
            return returnVal;
        }
        public DataTable Dem_LC(int batchid, int userid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select top 1 ID,TimeWork from dbo.PerformanceLastCheck where UserID=" + userid + " and BatchID=" + batchid + "";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public void UpdatePFMLC2(int Id, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE dbo.PerformanceLastCheck set TimeWork = TimeWork + "+time+" where ID="+Id+"";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Update_dataSave(int Id, string result)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent set Result = @result  where Id =" + Id + "";
                    sqlCommand.Parameters.Add("@result", SqlDbType.NVarChar).Value = result;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void DeletePFMLC2(int BatchID,int UserID,int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "delete from dbo.PerformanceLastCheck where UserID="+UserID+" and BatchID="+BatchID+" and ID <> "+Id+"";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
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
        public void Insert_Codedau(string cd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.CSPD (Content) values (N'"+cd+"')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Insert_Codesau(string cs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.CSPS (Content) values (N'" + cs + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
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
        public void Insert_X2(string cs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X2 (Content) values (N'" + cs + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Insert_X3(string cs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X3 (Content) values (N'" + cs + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Insert_X5(string cs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Insert into dbo.X5 (Content) values (N'" + cs + "')";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Save_LC(string content, string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update db_owner.ImageContent set Result = N'" + content + "' where AllImageId ='" + id + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Save_PFM(int dot,string ms, int userid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = " INSERT INTO dbo.Pfmlc (TurnUp, LcId, TimeLC, DateLC) VALUES ('" + dot + "', " + userid + ", N'" + ms + "', GETDATE())";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public void Save_DemDong(int dot, int SoPhieu, int SoDong, int kiemtra, int SoPhieu_TurnUp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    if (kiemtra == 0)
                    {
                        sqlCommand.CommandText = " INSERT INTO dbo.DemDong (CA, SoPhieu, SoDong, Date,SoPhieu_TurnUp ) VALUES ('" + dot + "', " + SoPhieu + ", " + SoDong + ", GETDATE(),"+ SoPhieu_TurnUp + " )";
                    }
                    else
                    {
                        sqlCommand.CommandText = " Update dbo.DemDong set  SoPhieu = " + SoPhieu + ", SoDong =" + SoDong + " , Date = GETDATE(), SoPhieu_TurnUp = "+ SoPhieu_TurnUp + " where CA = " + dot+" ";
                    }
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Lastcheck\n" + sqlException.Message);
            }
        }
        public bool check_sql(string sql)
        {
            bool excute_true = false;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = sql;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    excute_true = true;
                }
            }
            catch (SqlException sqlException)
            {
                excute_true = false;
            }
            return excute_true;
        }
        public void ExecuteSQL(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = sql;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình thực thi câu lệnh\n" + sqlException.Message);
            }
        }
        public  string GetStringSQL(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = sql;
                    con.Open();
                    var res1 = sqlCommand.ExecuteScalar();
                    if (res1 == null)
                        return "";
                    else
                        return res1.ToString();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
            }
        }
        public int Check_Dot(int dot)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select Count(Id)from dbo.[DemDong] where CA = "+ dot + "";
                    con.Open();
                    id = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            {
            }
            return id;
        }
        public int Check_TurnUp(int dot)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select Count(Id)from db_owner.AllImage where TurnUp = " + dot + "";
                    con.Open();
                    id = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            {
            }
            return id;
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
        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

    }
}
