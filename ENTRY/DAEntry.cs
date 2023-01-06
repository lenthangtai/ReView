using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace VCB_TEGAKI
{
    class DAEntry_Entry
    {
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        public void SetResult(int imageId, string content, int leng, int state)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent SET Result = N'" + content + "',State = " + state + ",Tongkytu=" + leng + " WHERE ImageId = " + imageId;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
            }
        }

        //lấy status image
        public string[] GetbatchNew(int batchid)
        {
            string[] returnValue = new string[] { "", "" };
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Batch.Id,Batch.Name FROM dbo.Batch WHERE Hitpoint=0 and Batch.id >" + batchid;
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        returnValue[0] = sqlDataReader["Id"].ToString().Trim();
                        returnValue[1] = sqlDataReader["Name"].ToString().Trim();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch
            { }
            return returnValue;
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
                    sqlCommand.CommandText = "InsertPerformance";
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
                    sqlCommand.CommandText = "UpdatePerformance";
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
        /// Lấy thông tin số ảnh còn lại
        /// </summary>
        /// <param name="userId">id của user</param>
        /// <returns>level</returns>
        //public int ImageExist(int batchId, int pair)
        //{
        //    int returnVal = 0;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.CommandText = "ImageExist";
        //            sqlCommand.Parameters.Add("@vlout", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int, 30).Value = batchId;
        //            sqlCommand.Parameters.Add("@pair", SqlDbType.Int, 30).Value = pair;
        //            con.Open();
        //            sqlCommand.ExecuteNonQuery();
        //            returnVal = Convert.ToInt32(sqlCommand.Parameters["@vlout"].Value.ToString());
        //        }
        //    }
        //    catch (SqlException sqlException)
        //    {
        //        throw new System.Exception(sqlException.Message);
        //    }
        //    return returnVal;
        //}
        //
        //update password
        //
        //update password
        public int ImageExist(int pair)
        {
            int id = 0;
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint1=0";
                        con.Open();
                        id = (int)sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception(sqlException.Message);
                }
            }
            if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint2=0";
                        con.Open();
                        id = (int)sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception(sqlException.Message);
                }
            }
            return id;
        }
        public int ImageExistEntry(int pair)
        {
            int id = 0;
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint" + pair + "=2";
                        con.Open();
                        id = (int)sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception(sqlException.Message);
                }
            }
            return id;
        }
        public void Updatepassword(string pass, string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.AllUser SET Password = N'" + pass + "' where UPPER(Name) ='" + name + "'";
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
            }
        }
        //Kiểm tra username,pass login
        public string[] usr(string username)
        {
            string[] usr = new string[4] { "", "", "", "" };
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Id,Password,Pair,Role from db_owner.AllUser where UPPER(Name) = N'" + username + "'";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        usr[0] = sqlDataReader["ID"].ToString();
                        usr[1] = sqlDataReader["Password"].ToString();
                        usr[2] = sqlDataReader["Pair"].ToString();
                        usr[3] = sqlDataReader["Role"].ToString();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Login\n" + sqlException.Message);
            }

            return usr;
        }
        public string[] usr_FB(string username)
        {
            string[] usr = new string[5] { "", "", "", "", "" };
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Id,Password,Pair,Role, Fullname from db_owner.AllUser where UPPER(Name) = N'" + username + "'";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        usr[0] = sqlDataReader["ID"].ToString();
                        usr[1] = sqlDataReader["Password"].ToString();
                        usr[2] = sqlDataReader["Pair"].ToString();
                        usr[3] = sqlDataReader["Role"].ToString();
                        usr[4] = sqlDataReader["Fullname"].ToString();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch
            { }

            return usr;
        }
        public string[] usr_FB_2(string username)
        {
            string stringconnecttion3 = String.Format(@"Data Source=192.168.1.3; Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");
            string[] usr = new string[5] { "", "", "", "", "" };
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion3))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Id,Password,Pair,Role, Fullname from db_owner.AllUser where UPPER(Name) = N'" + username + "'";
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        usr[0] = sqlDataReader["ID"].ToString();
                        usr[1] = sqlDataReader["Password"].ToString();
                        usr[2] = sqlDataReader["Pair"].ToString();
                        usr[3] = sqlDataReader["Role"].ToString();
                        usr[4] = sqlDataReader["Fullname"].ToString();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch
            { }

            return usr;
        }
        public string name_checker(string Id_user)
        {
            string name = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"select Fullname from db_owner.AllUser where Id = " + Convert.ToInt32(Id_user);
                    con.Open();
                    name = sqlCommand.ExecuteScalar().ToString();

                    //sqlCommand.Close();
                }
            }
            catch
            { }
            return name;

        }
        //Get table Batch
        public DataTable dtBatch(int hitpoint)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Select Name,ID,Hitpoint from dbo.batch where Hitpoint=" + hitpoint;
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
            }
            return dt;

        }
        public DataTable GetIdImageEntrySecond(int pair)
        {
            DataTable dt = new DataTable();
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select top 1 ImageName, Id from db_owner.AllImage where Hitpoint1 = 0";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
                }
            }
            else if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select top 1 ImageName, Id from db_owner.AllImage where Hitpoint2 = 0";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
                }
            }
            return dt;
        }
        /// <summary>
        /// set hitpoint batch = 1 neu ton tai image chua nhap
        /// </summary>
        /// <param name="batchId"></param>
        public void SetHitpointBatch(int batchId, int pair)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SetHitpointBatch";
                    sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int).Value = batchId;
                    sqlCommand.Parameters.Add("@Pair", SqlDbType.Int).Value = pair;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Lấy đối tượng image để nhập content
        /// </summary>
        /// <param name="imageId">Id của image</param>
        /// <returns>Image</returns>
        //public int GetIDImage(int pair)
        //{
        //    int id = 0;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandText = "SELECT top 1 AllImage.id from db_owner.AllImage join db_owner.ImageContent on AllImage.Id = ImageContent.AllImageId WHERE ResultP is not null and Hitpoint"+pair+" = 2 and InfoP = 0";
        //            con.Open();
        //            id = Convert.ToInt32(sqlCommand.ExecuteScalar());
        //        }
        //    }
        //    catch
        //    {   }           
        //    return id;
        //}
        /// <summary>
        /// Check co ton tai record image content ko
        /// </summary>
        /// <param name="imageId">id cua image</param>
        /// <returns>ton tai hay ko</returns>
        /// 

        //public byte[] getImageOnServer(string Name)
        //{
        //    byte[] returnVal = null;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.ServerImage WHERE NameImage =@NameImage";
        //            sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
        //            con.Open();
        //            returnVal = (byte[])sqlCommand.ExecuteScalar();
        //        }
        //    }
        //    catch
        //    { }
        //    return returnVal;
        //}

        public byte[] getImageOnServer(string Name)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.ServerImage WHERE NameImage =@NameImage";
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { }
            return returnVal;
        }

        //public byte[] getImageOnServerSOP(string Name)
        //{
        //    byte[] returnVal = null;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.ServerImage WHERE NameImage =@NameImage";
        //            //sqlCommand.CommandText = "SELECT dbo.ServerImageSOP_Demo.Binary_Poi_SOP FROM dbo.ServerImageSOP_Demo WHERE TemplateID = (SELECT Id FROM dbo.Template_Demo WHERE TempName = @NameImage)";
        //            sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
        //            con.Open();
        //            returnVal = (byte[])sqlCommand.ExecuteScalar();
        //        }
        //    }
        //    catch
        //    { }
        //    return returnVal;
        //}



        public byte[] getImageOnServer_BK(string Name)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.ServerImage_BACKUP WHERE NameImage =@NameImage";
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { }
            return returnVal;
        }
        public void AddImageContent1(string imgContentImageId, string imgContentContent, string imgContentUserId, string leng, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {

                    //UPDATE db_owner.ImageContent SET Content1 =@imgContentContent, UserP1=@imgContentUserId, DateP1=getdate(), TongkytuP1=1, TimemilionP1 = @time WHERE AllImageId =@imgContentImageId; 
                    //UPDATE db_owner.AllImage SET InfoP = 2 WHERE Id =@imgContentImageId;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentPair1";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@leng", SqlDbType.Int).Value = leng;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void AddImageContent2(string imgContentImageId, string imgContentContent, string imgContentUserId, string leng, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentPair2";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@leng", SqlDbType.Int).Value = leng;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void AddImageContentNG1(string imgContentImageId, string imgContentContent, string imgContentUserId, string leng, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentNGPair1";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@leng", SqlDbType.Int).Value = leng;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch { }
        }
        public void AddImageContentNG2(string imgContentImageId, string imgContentContent, string imgContentUserId, string leng, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentNGPair2";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@leng", SqlDbType.Int).Value = leng;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch { }
        }
        public void ReturnPairANDHitpointEntry(int ImageId, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "returnPairEntry";
                    sqlCommand.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;
                    sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
        public DataTable Get_Image1()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,ImageName where Hitpoint1 = 0";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Get_AllTemplate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,TempName as TemplateName,Colum1_1,Colum1_2,Colum1_3,Poi_Rules_Truong1 from dbo.Template_Demo";
                //sqlCommand.CommandText = @"select Id,CONVERT(varchar(10), Id)+'  '+TempName as TemplateName from dbo.Template";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public DataTable Get_Binary(string ImageName, int id, int pair)
        {
            DataTable dt = new DataTable();
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint1 = 1 where AllImage.Id = " + id + "";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }

                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
                }
            }
            else if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint2 = 1 where AllImage.Id = " + id + "";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }

                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
                }
            }
            return dt;
        }
        public void AddImageContentP1(int imgContentImageId, string imgContentContent, int imgContentUserId, int time, int Loai_form)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentP1";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    sqlCommand.Parameters.Add("@form", SqlDbType.Int).Value = Loai_form;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void AddImageContentP2(int imgContentImageId, string imgContentContent, int imgContentUserId, int time, int Loai_form)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentP2";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentContent", SqlDbType.NVarChar).Value = imgContentContent;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    sqlCommand.Parameters.Add("@form", SqlDbType.Int).Value = Loai_form;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void AddImageContentNGP1(int imgContentImageId, int imgContentUserId, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentNGP1";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void AddImageContentNGP2(int imgContentImageId, int imgContentUserId, int time)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "AddImageContentNGP2";
                    sqlCommand.Parameters.Add("@imgContentImageId", SqlDbType.Int).Value = imgContentImageId;
                    sqlCommand.Parameters.Add("@imgContentUserId", SqlDbType.Int).Value = imgContentUserId;
                    sqlCommand.Parameters.Add("@time", SqlDbType.Int).Value = time;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        public void Return_Hitpoint(int imageId, int pair)
        {
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint1 = 0 where AllImage.Id = " + imageId;
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
                }
            }
            if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint2 = 0 where AllImage.Id = " + imageId;
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
                }
            }
        }
        public DataTable Get_ImageFree(int pair)
        {
            DataTable dt = new DataTable();
            if (pair == 1)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select top 1 ImageName, Id from db_owner.AllImage where Hitpoint1 = 2";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
                }
            }
            else if (pair == 2)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select top 1 ImageName, Id from db_owner.AllImage where Hitpoint2 = 2";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        da.SelectCommand = sqlCommand;
                        da.Fill(dt);
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình update mật khẩu\n" + sqlException.Message);
                }
            }
            return dt;
        }
        public DataTable Get_BinaryEntry(string ImageName, int id, int pair)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint" + pair + " = 3 where AllImage.Id = " + id + "";
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    da.SelectCommand = sqlCommand;
                    da.Fill(dt);
                }

            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
            }
            return dt;
        }
        public void Return_HitpointEntry(int imageId, int pair)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint" + pair + " = 2 where AllImage.Id = " + imageId;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
            }
        }
        public BOImage_Entry GetImage(int imageId, int pair)
        {
            BOImage_Entry img = new BOImage_Entry();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.id as 'imgID',AllImage.ImageName as 'PUrl',Template.Rules as 'Rule', Template.Id as 'TempId', Template.CodeNumber as 'Code' FROM db_owner.AllImage join db_owner.ImageContent on AllImage.Id = ImageContent.AllImageId join dbo.Template_Demo on Template.TempName = ResultP WHERE Template.TempName = ResultP and ResultP is not null and Hitpoint" + pair + " = 2 and AllImage.Id = " + imageId + "";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.PageUrl = sqlDataReader["PUrl"].ToString().Trim();
                            img.Roles = sqlDataReader["Rule"].ToString().Trim();
                            img.Temid = int.Parse(sqlDataReader["TempId"].ToString().Trim());
                            img.Codenumber = sqlDataReader["Code"].ToString().Trim();
                        }
                        sqlDataReader.Close();
                    }
                }
            }
            catch
            {

            }
            return img;
        }
        public BOImage_Entry GetImageDemo(int imageId, int pair)
        {
            BOImage_Entry img = new BOImage_Entry();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.id as 'imgID',AllImage.ImageName as 'PUrl',Template_Demo.Rules as 'Rule', Template_Demo.Id as 'TempId', Template_Demo.CodeNumber as 'Code' FROM db_owner.AllImage join db_owner.ImageContent on AllImage.Id = ImageContent.AllImageId join dbo.Template_Demo on Template_Demo.TempName = ResultP WHERE Template_Demo.TempName = ResultP and ResultP is not null and Hitpoint" + pair + " = 2 and AllImage.Id = " + imageId + "";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.PageUrl = sqlDataReader["PUrl"].ToString().Trim();
                            img.Roles = sqlDataReader["Rule"].ToString().Trim();
                            img.Temid = int.Parse(sqlDataReader["TempId"].ToString().Trim());
                            img.Codenumber = sqlDataReader["Code"].ToString().Trim();
                        }
                        sqlDataReader.Close();
                    }
                }
            }
            catch
            {

            }
            return img;
        }
        public int GetIDImage(int pair)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UserInf";
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@Pair", SqlDbType.Int).Value = pair;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    id = Convert.ToInt32(sqlCommand.Parameters["@ID"].Value.ToString());
                }
            }
            catch
            {

            }
            return id;
        }
        //public int GetIDImageP(int pair)
        //{
        //    int id = 0;
        //    if (pair == 3)
        //    {
        //        try
        //        {
        //            using (SqlConnection con = new SqlConnection(stringconnecttion))
        //            {
        //                SqlCommand sqlCommand = new SqlCommand();
        //                sqlCommand.Connection = con;
        //                sqlCommand.CommandText = "declare @idimage int; Set @idimage= (SELECT top 1 AllImage.id from db_owner.AllImage where Hitpoint1 = 0);Update db_owner.AllImage set Hitpoint1=1 where ID=@idimage;";
        //                sqlCommand.Parameters.Add("@idimage", SqlDbType.Int).Value = ParameterDirection.Output;
        //                con.Open();
        //                id = Convert.ToInt32(sqlCommand.Parameters["@idimage"].Value);
        //            }
        //        }
        //        catch
        //        { }
        //    }
        //    else if (pair == 4)
        //    {
        //        try
        //        {
        //            using (SqlConnection con = new SqlConnection(stringconnecttion))
        //            {
        //                SqlCommand sqlCommand = new SqlCommand();
        //                sqlCommand.Connection = con;
        //                sqlCommand.CommandText = "Set @Id= (SELECT top 1 AllImage.id from db_owner.AllImage where Hitpoint2 = 0);Update db_owner.AllImage set Hitpoint2=1 where ID=@Id;";
        //                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = ParameterDirection.Output;
        //                con.Open();
        //                id = Convert.ToInt32(sqlCommand.Parameters["@ID"].Value);
        //            }
        //        }
        //        catch
        //        { }
        //    }
        //    return id;
        //}
        //public string Get_imgname(int imageId)
        //{
        //    string bb = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandText = "SELECT AllImage.ImageName FROM db_owner.AllImage where AllImage.Id = " + imageId + "";
        //            con.Open();
        //            bb = sqlCommand.ExecuteScalar().ToString();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return bb;
        //}
        public string Get_imgname(int imageId)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.ImageName FROM db_owner.AllImage where AllImage.Id = " + imageId + "";

                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
        public byte[] Get_BinaryP(string ImageName, int id, int pair)
        {
            byte[] returnVal = null;
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint1 = 1 where AllImage.Id = " + id + "";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        returnVal = (byte[])sqlCommand.ExecuteScalar();
                    }

                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
                }
            }
            if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint2 = 1, InfoP = 1 where AllImage.Id = " + id + "";
                        SqlDataAdapter da = new SqlDataAdapter();
                        con.Open();
                        returnVal = (byte[])sqlCommand.ExecuteScalar();
                    }

                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Error! Get table Field\n" + sqlException.Message);
                }
            }
            return returnVal;
        }
        public int ImageExistP(int pair)
        {
            int id = 0;
            if (pair == 3)
            {
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(stringconnecttion))
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = con;
                            sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint1 = 0";
                            con.Open();
                            id = (int)sqlCommand.ExecuteScalar();
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        throw new System.Exception(sqlException.Message);
                    }
                }
            }
            if (pair == 4)
            {
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(stringconnecttion))
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = con;
                            sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint2 = 0";
                            con.Open();
                            id = (int)sqlCommand.ExecuteScalar();
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        throw new System.Exception(sqlException.Message);
                    }
                }
            }
            return id;
        }
        public void Return_HitpointP(int imageId, int pair)
        {
            if (pair == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint1 = 0, InfoP = 0 where AllImage.Id = " + imageId;
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
                }
            }
            if (pair == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint2 = 0, InfoP = 0 where AllImage.Id = " + imageId;
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlException)
                {
                    throw new System.Exception("Có lỗi trong quá trình cập nhật Result\n" + sqlException.Message);
                }
            }
        }
        public string Get_Result(int imageId)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT ResultP FROM db_owner.ImageContent where AllImageId = " + imageId + "";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
        public string Get_Rules(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Rules FROM dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
        public string Get_RulesDemo(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Rules FROM dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }

        public string Get_maso(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT CodeNumber FROM dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }
public string Get_masoDemo(string name)
        {
            string bb = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT CodeNumber FROM dbo.Template_Demo where TempName = N'" + name + "'";
                    con.Open();
                    bb = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch
            {
            }
            return bb;
        }

        public int Get_Temid(string name)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Id FROM dbo.Template_Demo where TempName = N'" + name + "'";
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
        public int Get_TemidDemo(string name)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT Id FROM dbo.Template_Demo where TempName = N'" + name + "'";
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

        public int Get_Type_Image(int imageId)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT STT_ID_PL FROM db_owner.ImageContent where AllImageId = " + imageId + "";
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
        public byte[] Get_imgsop(string Name)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT SopImage FROM dbo.Template_Demo WHERE TempName = N'" + Name + "'";
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { returnVal = null; }
            return returnVal;
        }
       public byte[] Get_imgsoDemo(string Name)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT SopImage FROM dbo.Template_Demo WHERE TempName = N'" + Name + "'";
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { returnVal = null; }
            return returnVal;
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
        //public void ExecuteSQLInsertAll(string sql,byte[] SOP, byte[] SOPPL)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(stringconnecttion))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = con;
        //            sqlCommand.CommandText = sql;
        //            sqlCommand.Parameters.Add("@BinarySOP", SqlDbType.VarBinary).Value = SOP;
        //            sqlCommand.Parameters.Add("@BinarySOP_PL", SqlDbType.VarBinary).Value = SOPPL;

        //            con.Open();
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SqlException sqlException)
        //    {
        //        throw new Exception("Có lỗi trong quá trình thực thi câu lệnh\n" + sqlException.Message);
        //    }
        //}
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
                throw new Exception("Có lỗi trong quá trình thực thi câu lệnh\n" + sqlException.Message);
            }
        }

        public void ExecuteSQL2(string sql,byte[] BinaryImage, byte[] BinaryImagePL)
        {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = sql;
                    sqlCommand.Parameters.Add("@BinarySOP", SqlDbType.VarBinary).Value = BinaryImage;
                    sqlCommand.Parameters.Add("@BinarySOP_PL", SqlDbType.VarBinary).Value = BinaryImagePL;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            
        }
        public void ExecuteSQLPL(string sql, byte[] BinaryImage)
        {
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@BinarySOP_PL", SqlDbType.VarBinary).Value = BinaryImage;
                con.Open();
                sqlCommand.ExecuteNonQuery();
            }

        }
        public string GetStringSQL(string sql)
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
        public int GetIntSQL(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = sql;
                    con.Open();
                    var res = sqlCommand.ExecuteScalar();
                    if (res == null)
                        return -1;
                    else
                        try
                        {
                            return Convert.ToInt32(res.ToString());
                        }
                        catch
                        {
                            return 0;
                        }
                }
            }
            catch (Exception sqlException)
            {
                throw new Exception("Có lỗi trong quá trình lấy int\n" + sqlException.Message);
            }
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

        public string UP_IMAGE_XOAY(byte[] image, string nameImage, int IDanh)
        {
            string anh = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "Update dbo.ServerImage set BinaryImage=@VarImage,DateCreated = getdate() where NameImage =@nameImage ";
                    sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@nameImage", SqlDbType.NVarChar).Value = nameImage;
                    con.Open();
                    sqlCommand.ExecuteReader();
                    //image = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException sqlException)
            {
                throw new Exception("Có lỗi trong quá trình Xoay ảnh \n" + sqlException.Message);
            }
            return anh;
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, ImageFormat.Tiff);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UP_conten1_new(string imgContent, int imgContentUserId, int lng, int ms, int idreturn)
        {
            try
            {
                //string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Update db_owner.ImageContent set Content1 = @imgContent,UserId1 = " + imgContentUserId + ",InputDate1 = getdate(),Tongkytu1 = " + lng + ",TimemilionE1 = " + ms + " where AllImageId = " + idreturn;
                    //sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@imgContent", SqlDbType.NVarChar).Value = imgContent;
                    con.Open();
                    sqlCommand.ExecuteReader();
                }
            }
            catch { }
        }
        public void UP_conten_Result_new(string imgContent, int idreturn)
        {
            try
            {
                //string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Update db_owner.ImageContent set Checkresult = @imgContent, Result = @imgContent  where  Id =" + idreturn;
                    //sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@imgContent", SqlDbType.NVarChar).Value = imgContent;
                    con.Open();
                    sqlCommand.ExecuteReader();
                }
            }
            catch { }
        }
        public void UP_conten2_new(string imgContent, int imgContentUserId, int lng, int ms, int idreturn)
        {
            try
            {
                //string connectionString = GetConnectionString();
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text; //Update db_owner.ImageContent set Content2 = N'" + imgContent.Trim() + "',UserId2 = " + imgContentUserId + ",InputDate2=getdate(),Tongkytu2 =" + lng + ",TimemilionE2 = " + ms + " where AllImageId=" + idreturn

                    sqlCommand.CommandText = "Update db_owner.ImageContent set Content2 = @imgContent,UserId2 = " + imgContentUserId + ",InputDate2 = getdate(),Tongkytu2 = " + lng + ",TimemilionE2 = " + ms + " where AllImageId = " + idreturn;
                    //sqlCommand.Parameters.Add(new SqlParameter("@VarImage", image));
                    sqlCommand.Parameters.Add("@imgContent", SqlDbType.NVarChar).Value = imgContent;
                    con.Open();
                    sqlCommand.ExecuteReader();
                }
            }
            catch { }
        }
        public void Insert_DATA_BACKUP(string NameImage, string conten1, int id1, string conten2, int id2, int checkerID, int QCID, int loisai1, int loisai2, string Result, string ResultCheck, string Time, int idpl1, int idpl2, string rspl, int idpl)
        {
            try
            {
                //string connectionString = stringconnecttion3;
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "INSERT INTO db_owner.[BackUp_ImageContent] (ImageName,Content1,UserId1,Content2,UserId2,CheckerId,QCID,Loisai1,Loisai2,Result,Checkresult,Time,IdPL1,IdPL2,ResultPL,IDType_PL) VALUES (@NameImage ,@conten1, " + id1 + ", @conten2, " + id2 + "," + checkerID + "," + QCID + "," + loisai1 + "," + loisai2 + ", @Result,@ResultCheck,N'" + Time + "'," + idpl1 + "," + idpl2 + ",@ResultPL," + idpl + ")";
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = NameImage;
                    sqlCommand.Parameters.Add("@conten1", SqlDbType.NVarChar).Value = conten1;
                    sqlCommand.Parameters.Add("@conten2", SqlDbType.NVarChar).Value = conten2;
                    sqlCommand.Parameters.Add("@Result", SqlDbType.NVarChar).Value = Result;
                    sqlCommand.Parameters.Add("@ResultCheck", SqlDbType.NVarChar).Value = ResultCheck;
                    //sqlCommand.Parameters.Add("@IdPL1", SqlDbType.NVarChar).Value = idpl1;
                    //sqlCommand.Parameters.Add("@IdPL2", SqlDbType.NVarChar).Value = idpl2;
                    sqlCommand.Parameters.Add("@ResultPL", SqlDbType.NVarChar).Value = rspl;
                    //sqlCommand.Parameters.Add("@IDType_PL", SqlDbType.NVarChar).Value = ResultCheck;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Insert Data lên Backup\n" + sqlException.Message);
            }
        }

        #region code-update-by-tailnt


        public byte[] getImageSOPPL(string TempName)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = con;
                    sqlcmd.CommandText = "SELECT Binary_Poi_SOP_PL FROM dbo.ServerImageSOP_Demo WHERE TemplateID=(Select ID from dbo.Template_Demo Where TempName=@TempName)";
                    sqlcmd.Parameters.Add("@TempName", SqlDbType.VarChar).Value = TempName;
                    con.Open();
                    returnVal = (byte[])sqlcmd.ExecuteScalar();
                }
            }
            catch { }
            return returnVal;
        }
       

        #endregion
    }
}
