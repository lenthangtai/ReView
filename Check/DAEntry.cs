using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace VCB_TEGAKI
{
    class DAEntry_Check
    {
        private string stringconnecttion = String.Format("Data Source=" + Program.server + ";Initial Catalog=" + Program.database + ";User Id=" + Program.user + ";Password=" + Program.pass + ";Integrated Security=no;MultipleActiveResultSets=True;Packet Size=4096;Pooling=false;");

        /// <summary>
        /// Set status = lock hay free cho record
        /// </summary>
        /// <param name="id">Id của image</param>
        /// <param name="status">lock: không được nhập/ free: được nhập</param>
        public void SetHitPointImage(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.AllImage SET HitPoint1 =3, Hitpoint2 = 3, InfoE = 2  WHERE Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật HitPoint\n" + sqlException.Message);
            }
        }
        public void SetHitPointImage_QC(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.AllImage SET HitPoint1 =3, Hitpoint2 = 3, InfoE = 3  WHERE Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật HitPoint\n" + sqlException.Message);
            }
        }
        public void Set_result_null(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent SET Result = NULL WHERE AllImageID = " + id + ";UPDATE db_owner.AllImage SET InfoE = 2 WHERE Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật HitPoint\n" + sqlException.Message);
            }
        }
        public void Set_result_null_QC(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent SET Result = NULL WHERE AllImageID = " + id + ";UPDATE db_owner.AllImage SET InfoE = 3 WHERE Id = " + id;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật HitPoint\n" + sqlException.Message);
            }
        }

        /// <summary>
        /// Set hitpoint cho batch
        /// </summary>
        /// <param name="batchId">Id của Batch</param>
        /// <param name="hitPoint">0: chua entry het/ 1: da entry het</param>
        public void SetHitPointBatch(int batchId, int hitPoint)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE Batch SET HitPoint = " + hitPoint + " WHERE Id = " + batchId;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật HitPoint cua Batch\n" + sqlException.Message);
            }
        }

        /// <summary>
        /// Update 1 record vào table ImageContent (khi checker chon content1, content2, hay nhap moi result
        /// </summary>
        /// <param name="imgContent">đối tượng ImageContent cần update</param>
        public void UpdateResutlCheck(BOImageContent_Check imgContent, int ms)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent SET CheckerId = " + imgContent.CheckerId + ", CheckedDate = getdate(), Checkresult = @imgContent, Result = @imgContent, Loisai2 = " + imgContent.Loisai2 + ", Loisai1 = " + imgContent.Loisai1 + ", Tongkytu = " + imgContent.Tongkytu + ", TimemilionCK = TimemilionCK + " + ms + " WHERE AllImageId = " + imgContent.Id + " ; UPDATE db_owner.AllImage set Hitpoint1 = 4, Hitpoint2 = 4, InfoE = 0 where AllImage.Id = " + imgContent.Id;
                    sqlCommand.Parameters.Add("@imgContent", SqlDbType.NVarChar).Value = imgContent.Result;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật 1 record imageContent\n" + sqlException.Message);
            }
        }
        public DataTable Get_Hangchitiet(int Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Hangchitiet from db_owner.Imagecontent where Imagecontent.Id=" + Id + "";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }

        //Get number image check
        public int ImageExistCheck()
        {
            int id = 0;
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "SELECT COUNT(Id) FROM db_owner.AllImage where Hitpoint1 = 3 and Hitpoint2 = 3 and InfoE = 2 and NG1 = 0 and NG2 = 0";
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
        public string ImageExistCheckQC(int batchId)
        {
            string returnVal = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT COUNT(1) FROM db_owner.Image join db_owner.Imagecontent on Image.Id = Imagecontent.ImageId WHERE IDbatch = " + batchId + " AND Imagecontent.Result is null AND db_owner.Image.status='1'";
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
        //Get number image check
        public string ImageExistQC(int batchId, int lvl)
        {
            string returnVal = "";
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT COUNT(1) FROM db_owner.Image JOIN db_owner.Page ON db_owner.Image.PageId = db_owner.Page.Id JOIN db_owner.Field ON db_owner.Image.FieldId = db_owner.Field.Id WHERE db_owner.Page.BatchId =" + batchId + " AND db_owner.Image.Status ='1'";
                    con.Open();
                    int numberOfRecord = (int)sqlCommand.ExecuteScalar();
                    returnVal = numberOfRecord.ToString();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception(sqlException.Message);
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
                    sqlCommand.CommandText = "InsertPerformanceCheck";
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
                    sqlCommand.CommandText = "UpdatePerformanceCheck";
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
        //lấy status image
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
                    sqlCommand.CommandText = "SELECT Batch.Id,Batch.Name FROM dbo.Batch WHERE Hitpoint=1 and Batch.id >" + batchid;
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
        public int GetIdCheckP()
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetImageCheck";
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    id = Convert.ToInt32(sqlCommand.Parameters["@ID"].Value.ToString());
                }
            }
            catch
            { }
            return id;
        }
        public int GetCheck()
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetCheck";
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    id = Convert.ToInt32(sqlCommand.Parameters["@ID"].Value.ToString());
                }
            }
            catch
            { }
            return id;
        }
        public int GetkQC()
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetQC";
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    id = int.Parse(sqlCommand.Parameters["@ID"].Value.ToString());
                }
            }
            catch
            { }
            return id;
        }
        public int GetIdImageEntriedFromBatchIdQC(int batchId)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetImageCheckQC";
                    sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int).Value = batchId;
                    con.Open();
                    id = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                }
            }
            catch
            { }
            return id;
        }
        /// <summary>
        /// set hitpoint batch
        /// </summary>
        /// <param name="batchId"></param>
        public void SetHitpointBatch(int batchId)
        {
            // check cheker        
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SetHitpointBatchCheck";
                    sqlCommand.Parameters.Add("@BatchID", SqlDbType.Int).Value = batchId;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// Lấy đối tượng image để nhập content
        /// </summary>
        /// <param name="imageId">Id của image</param>
        /// <returns>Image</returns>
        public BOImage_Check GetImage(int imageId)
        {
            BOImage_Check img = new BOImage_Check();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT image.id as 'imgID',Page.PathUri as 'PUrl',NG1,NG2 FROM db_owner.Image JOIN db_owner.[Page] ON pageid=Page.id WHERE Image.Id = " + imageId;
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.PageName = sqlDataReader["PUrl"].ToString().Trim();
                            img.NG1 = (int)sqlDataReader["NG1"];
                            img.NG2 = (int)sqlDataReader["NG2"];
                            break;
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
        /// <summary>
        /// Check co ton tai record image content ko
        /// </summary>
        /// <param name="imageId">id cua image</param>
        /// <returns>ton tai hay ko</returns>
        public byte[] getImageOnServer(string Name, string nameTable)
        {
            byte[] returnVal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT BinaryImage FROM dbo.[" + nameTable + "] WHERE NameImage = @NameImage";
                    sqlCommand.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = Name;
                    con.Open();
                    returnVal = (byte[])sqlCommand.ExecuteScalar();
                }
            }
            catch
            { }
            return returnVal;
        }
        /// <summary>
        /// Lấy đối tượng imageContent để check content
        /// </summary>
        /// <param name="imageId">Id của image</param>
        /// <returns>ImageContent</returns>
        public BOImageContent_Check GetImageContent(int imageId)
        {
            BOImageContent_Check imgContent = new BOImageContent_Check();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT ImageContent.Id,ImageId,Content1,InputDate1,UserId1,Content2,UserId2,InputDate2,us1.Fullname as f1,us1.[Group] as G1,us2.Fullname as f2,us2.[Group] as G2,Hangchitiet FROM db_owner.ImageContent left join db_owner.[user] as us1 ON userid1=us1.id left join db_owner.[user] as us2 on userid2=us2.id where ImageId = " + imageId;
                    con.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        imgContent.Id = int.Parse(sqlDataReader["Id"].ToString().Trim());
                        imgContent.ImageId = int.Parse(sqlDataReader["ImageId"].ToString().Trim());
                        //Content1            
                        imgContent.Content1 = sqlDataReader["Content1"].ToString().Split('|').ToList<string>();
                        imgContent.UserId1 = int.Parse(sqlDataReader["UserId1"].ToString().Trim());
                        imgContent.InputDate1 = DateTime.Parse(sqlDataReader["InputDate1"].ToString().Trim());
                        imgContent.Name1 = sqlDataReader["f1"].ToString();
                        imgContent.Group1 = sqlDataReader["G1"].ToString();
                        //Content2                
                        imgContent.Content2 = sqlDataReader["Content2"].ToString().Split('|').ToList<string>();
                        imgContent.UserId2 = int.Parse(sqlDataReader["UserId2"].ToString().Trim());
                        imgContent.InputDate2 = DateTime.Parse(sqlDataReader["InputDate2"].ToString().Trim());
                        imgContent.Name2 = sqlDataReader["f2"].ToString();
                        imgContent.Group2 = sqlDataReader["G2"].ToString();
                        //Hangchitiet
                        imgContent.Hangchitiet = sqlDataReader["Hangchitiet"].ToString();
                        break;
                    }
                    sqlDataReader.Close();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Lỗi lấy dư liệu Content1 và Content2\n" + sqlException.Message);
            }
            return imgContent;
        }
        public void SetStatusQC(int imageid, string status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.[Image] SET status = '" + status + "' WHERE Id = " + imageid;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật status cua image\n" + sqlException.Message);
            }
        }
        public int GetIdImageEntrySecond()
        {
            int id = 0;
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "select top 1 Id from db_owner.AllImage where Hitpoint1 = 1 and Hitpoint2 = 1 and InfoP = 2";
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
        public DataTable Get_AllTemplateName()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,RIGHT('000' + CAST(ROW_NUMBER() over (order by (select 1)) as varchar(5)),3)+'  '+TempName as TemplateName,Colum1_1,Colum1_2,Colum1_3 from dbo.Template_Demo";
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
        public void Return_Hitpoint(int imageId)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint1 = 1, Hitpoint2 = 1 where AllImage.Id = " + imageId;
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
        public int ImageExist()
        {
            int id = 0;
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint1 = 1 or Hitpoint2 = 1";
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
        public DataTable Get_AllContent(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select us1.Id as 'User1',us1.Fullname as 'UserName1',us1.MSNV as 'MSNV1',us1.[Group] as N'Trung tâm1',Content1,us2.Id as User2,us2.Fullname as 'UserName2',us2.MSNV as 'MSNV2',us2.[Group] as N'Trung tâm2',Content2 from db_owner.AllUser as us1 join db_owner.ImageContent on us1.Id=ImageContent.UserP1 join db_owner.AllUser as us2 on us2.Id=ImageContent.UserP2 where AllImageId=" + id + "; Update db_owner.AllImage set Hitpoint1 = 2, Hitpoint2 = 2 where AllImage.Id = " + id + "";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public void Insert_ContentP(int imageId, int loisai1, int loisai2, string result, int usid, int ms, int stt_PL)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.ImageContent set Content1 = null, Content2 = null, LoisaiP1 = " + loisai1 + ", LoisaiP2 = " + loisai2 + ", ResultP = N'" + result + "',CheckIDP = " + usid + ",DateCheckP = GETDATE(), TimemilionCP = TimemilionCP + " + ms + ",STT_ID_PL = "+ stt_PL + " where AllImageId = " + imageId + "; Update db_owner.AllImage set Hitpoint1=2,Hitpoint2=2,InfoP=0 where Id =" + imageId;

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
        public DataTable Get_AllTemplate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,TempName as TemplateName,Colum1_1,Colum1_2,Colum1_3,Poi_Rules_Truong1 from dbo.Template_Demo";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public void Insert_ContentNGP(int imageId, int usid)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "Update db_owner.ImageContent set Content1 = null, Content2 = null, CheckIDP = " + usid + ",DateCheckP = Getdate() where AllImageId=" + imageId + "; Update db_owner.AllImage set Hitpoint1 = 10, Hitpoint2 = 10, InfoP = 10 where AllImage.Id = " + imageId + "";
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
        public BOImageContent_Check GetImageCheckP(int imageId)
        {
            BOImageContent_Check img = new BOImageContent_Check();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.id as 'imgID',AllImage.ImageName as 'PUrl',Content1,Content2, us1.Id as 'usp1', us1.MSNV as 'ms1',us1.Fullname as 'fullname1',us1.[Group] as 'tt1', us2.Id as 'usp2', us2.MSNV  as 'ms2',us2.Fullname as 'fullname2',us2.[Group] as 'tt2' from db_owner.AllUser as us1 join db_owner.ImageContent on ImageContent.UserP1 = us1.Id join db_owner.AllUser as us2 on us2.Id=ImageContent.UserP2 join db_owner.AllImage on Imagecontent.AllImageId = AllImage.Id where AllImage.Id = " + imageId + "";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.Uri = sqlDataReader["PUrl"].ToString().Trim();
                            img.Contentp1 = sqlDataReader["Content1"].ToString().Trim();
                            img.Contentp2 = sqlDataReader["Content2"].ToString().Trim();
                            img.UserP1 = int.Parse(sqlDataReader["usp1"].ToString().Trim());
                            img.UserP2 = int.Parse(sqlDataReader["usp2"].ToString().Trim());
                            img.Name1 = sqlDataReader["fullname1"].ToString().Trim();
                            img.Name2 = sqlDataReader["fullname2"].ToString().Trim();
                            img.Group1 = sqlDataReader["tt1"].ToString().Trim();
                            img.Group2 = sqlDataReader["tt2"].ToString().Trim();
                            img.Ms1 = sqlDataReader["ms1"].ToString().Trim();
                            img.Ms2 = sqlDataReader["ms2"].ToString().Trim();

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
        public DataTable Get_BinaryP(string ImageName, int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint1 = 2, Hitpoint2 = 2 where AllImage.Id = " + id + "";
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
        public int ImageExistCP()
        {
            int id = 0;
            {
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(stringconnecttion))
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = con;
                            sqlCommand.CommandText = @"Select Count(Id) from db_owner.AllImage where Hitpoint1 = 1 and Hitpoint2 = 1";
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
        public DataTable Get_AllTemplateName2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(stringconnecttion))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = @"select Id,TempName as TemplateName from dbo.Template_Demo";
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter();
                con.Open();
                sqldataAdapter.SelectCommand = sqlCommand;
                sqldataAdapter.Fill(dt);
            }
            return dt;
        }
        public BOImageContent_Check GetImageCheck(int imageId)
        {
            BOImageContent_Check img = new BOImageContent_Check();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.id as 'imgID',NG1,NG2, AllImage.ImageName as 'PUrl',Content1,Content2, us1.Id as 'us1', us1.MSNV as 'ms1',us1.Fullname as 'fullname1',us1.[Group] as 'tt1', us2.Id as 'us2', us2.MSNV  as 'ms2',us2.Fullname as 'fullname2',us2.[Group] as 'tt2' from db_owner.AllUser as us1 join db_owner.ImageContent on ImageContent.UserId1 = us1.Id join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 join db_owner.AllImage on Imagecontent.AllImageId = AllImage.Id where AllImage.Id = " + imageId + "";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.Uri = sqlDataReader["PUrl"].ToString().Trim();
                            img.Content1 = sqlDataReader["Content1"].ToString().Split('|').ToList<string>();
                            img.Content2 = sqlDataReader["Content2"].ToString().Split('|').ToList<string>();
                            img.UserId1 = int.Parse(sqlDataReader["us1"].ToString().Trim());
                            img.UserId2 = int.Parse(sqlDataReader["us2"].ToString().Trim());
                            img.Name1 = sqlDataReader["fullname1"].ToString().Trim();
                            img.Name2 = sqlDataReader["fullname2"].ToString().Trim();
                            img.Group1 = sqlDataReader["tt1"].ToString().Trim();
                            img.Group2 = sqlDataReader["tt2"].ToString().Trim();
                            img.Ms1 = sqlDataReader["ms1"].ToString().Trim();
                            img.Ms2 = sqlDataReader["ms2"].ToString().Trim();
                            img.Notgood1 = int.Parse(sqlDataReader["NG1"].ToString().Trim());
                            img.Notgood2 = int.Parse(sqlDataReader["NG2"].ToString().Trim());

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
        public BOImageContent_Check GetImageQC(int imageId)
        {
            BOImageContent_Check img = new BOImageContent_Check();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "SELECT AllImage.id as 'imgID',NG1,NG2, AllImage.ImageName as 'PUrl',Content1,Content2, us1.Id as 'us1', us1.MSNV as 'ms1',us1.Fullname as 'fullname1',us1.[Group] as 'tt1', us2.Id as 'us2', us2.MSNV  as 'ms2',us2.Fullname as 'fullname2',us2.[Group] as 'tt2' from db_owner.AllUser as us1 join db_owner.ImageContent on ImageContent.UserId1 = us1.Id join db_owner.AllUser as us2 on us2.Id=ImageContent.UserId2 join db_owner.AllImage on Imagecontent.AllImageId = AllImage.Id where AllImage.Id = " + imageId + "";
                    con.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            img.Id = int.Parse(sqlDataReader["imgID"].ToString().Trim());
                            img.Uri = sqlDataReader["PUrl"].ToString().Trim();
                            img.Content1 = sqlDataReader["Content1"].ToString().Split('|').ToList<string>();
                            img.Content2 = sqlDataReader["Content2"].ToString().Split('|').ToList<string>();
                            img.UserId1 = int.Parse(sqlDataReader["us1"].ToString().Trim());
                            img.UserId2 = int.Parse(sqlDataReader["us2"].ToString().Trim());
                            img.Name1 = sqlDataReader["fullname1"].ToString().Trim();
                            img.Name2 = sqlDataReader["fullname2"].ToString().Trim();
                            img.Group1 = sqlDataReader["tt1"].ToString().Trim();
                            img.Group2 = sqlDataReader["tt2"].ToString().Trim();
                            img.Ms1 = sqlDataReader["ms1"].ToString().Trim();
                            img.Ms2 = sqlDataReader["ms2"].ToString().Trim();
                            img.Notgood1 = int.Parse(sqlDataReader["NG1"].ToString().Trim());
                            img.Notgood2 = int.Parse(sqlDataReader["NG2"].ToString().Trim());

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
        public DataTable Get_BinaryCheck(string ImageName, int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = @"Select BinaryImage from dbo.ServerImage where NameImage = N'" + ImageName + "'; Update db_owner.AllImage set Hitpoint1 = 4, Hitpoint2 = 4 where AllImage.Id = " + id + "";
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
        public void Return_HitpointCheck(int imageId)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint1 = 3, Hitpoint2 = 3 where AllImage.Id = " + imageId;
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
        public void Return_HitpointQC(int imageId)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringconnecttion))
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.CommandText = "UPDATE db_owner.AllImage SET Hitpoint1 = 3, Hitpoint2 = 3 where AllImage.Id = " + imageId;
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
        public int ImageExistQC()
        {
            int id = 0;
            {
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(stringconnecttion))
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = con;
                            sqlCommand.CommandText = "SELECT COUNT(Id) FROM db_owner.AllImage where Hitpoint1 = 3 and Hitpoint2 = 3 and InfoE = 3";
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
        public void UpdateResutlQC(BOImageContent_Check imgContent, int ms, int loisaiE1, int loisaiE2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    sqlCommand.CommandText = "UPDATE db_owner.ImageContent SET CheckerId = " + imgContent.CheckerId + ", CheckedDate = getdate(),Checkresult = @imgContent , Result = @imgContent,Loisai2 = " + loisaiE2 + ", Loisai1 = " + loisaiE1 + ", Tongkytu = " + imgContent.Tongkytu + ",TimemilionCK = TimemilionCK + " + ms + " WHERE AllImageId = " + imgContent.Id + " ; UPDATE db_owner.AllImage set Hitpoint1 = 4, Hitpoint2 = 4, InfoE = 0 where AllImage.Id = " + imgContent.Id;
                    sqlCommand.Parameters.Add("@imgContent", SqlDbType.NVarChar).Value = imgContent.Result;
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình cập nhật 1 record imageContent\n" + sqlException.Message);
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
        public DataTable GetDatatableSQL(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(stringconnecttion))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con;
                    con.Open();
                    sqlCommand.CommandText = sql;
                    //dt.Load(sqlCommand.ExecuteReader());
                    SqlDataAdapter daUser = new SqlDataAdapter();
                    daUser.SelectCommand = sqlCommand;

                    daUser.Fill(dt);
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy datatable\n" + sqlException.Message);
            }
            return dt;
        }
        public  int GetIntSQL(string sql)
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
                        return 0;
                    else
                        return Int32.Parse(res.ToString());
                }
            }
            catch (SqlException sqlException)
            {
                throw new System.Exception("Có lỗi trong quá trình lấy int\n" + sqlException.Message);
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
        //Thực thi câu lệnh
        public  void ExecuteSQL(string sql)
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
    }
}
