using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace VCB_TEGAKI
{
    class ExcelDataBaseHelper
    {
        public static DataTable OpenFile(string fileName)
        {
            var fullFileName = fileName;
            if (!File.Exists(fullFileName))
            {
                System.Windows.Forms.MessageBox.Show("File not found");
                return null;
            }
            //Get tablename
            //string[] tablename = GetExcelSheetNames(fileName).ToArray();
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fullFileName);
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Sheet$]", connectionString);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public static IEnumerable<string> GetExcelSheetNames(string excelFile)
        {
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+excelFile+";Extended Properties=Excel 12.0;";
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
                {
                    return (dt ?? new DataTable())
                        .Rows
                        .Cast<DataRow>()
                        .Select(row => row["TABLE_NAME"].ToString());
                }
            }
        }
    }
}
