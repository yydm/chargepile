using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ChargingPile.BLL
{
    public class OutExcel
    {
        /// <summary>将内存中的DataTable转成Excel
        /// </summary>
        /// <param name="excelSavePath">Excel保存路径</param>
        /// <param name="sourceTable">内存中的DataTable</param>
        /// <param name="sheetName">在Excel中保存的Sheet名称</param>
        public static void DataTableToExcel(string excelSavePath, DataTable sourceTable, string sheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelSavePath + ";" + "Extended Properties=Excel 8.0;";
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                //检查表单是否已存在
                string[] sheets = GetSheets(conn);
                for (int i = 0; i < sheets.Length; i++)
                {
                    if (sheets[i].Equals(sheetName, StringComparison.OrdinalIgnoreCase))
                    {
                        //如果存在，删除
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = string.Format("DROP TABLE {0} ", sheetName);
                            cmd.ExecuteNonQuery();

                        }
                        break;
                    }
                }
                //创建表单
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("CREATE TABLE {0} ({1})", sheetName, BuildColumnsString(sourceTable));
                    cmd.ExecuteNonQuery();
                }
                using (OleDbDataAdapter da = new OleDbDataAdapter(string.Format("SELECT * FROM {0}", sheetName), conn))
                {
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataTable dataTable = new DataTable(sheetName);
                    //读取表单（空表）
                    da.Fill(dataTable);
                    //为空表写数据
                    foreach (DataRow sRow in sourceTable.Rows)
                    {
                        DataRow nRow = dataTable.NewRow();
                        for (int i = 0; i < sourceTable.Columns.Count; i++)
                        {
                            if (sRow[i] is System.Byte[])
                                nRow[i] = "二进制数据";
                            else
                                nRow[i] = sRow[i];
                        }
                        dataTable.Rows.Add(nRow);
                    }
                    //更新表单
                    da.Update(dataTable);
                }
            }
        }
        /// <summary>获取EXCEL的所有表单
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private static string[] GetSheets(OleDbConnection conn)
        {
            //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
            DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            //包含excel中表名的字符串数组
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k++)
            {
                DataRow row = dtSheetName.Rows[k];
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            }
            return strTableNames;
        }
        /// <summary>将<paramref name="column"/>的DataType转成数据库关键字
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private static string SwitchToSqlType(DataColumn column)
        {
            string TypeFullName = column.DataType.FullName;
            switch (TypeFullName)
            {
                case "System.Int32":return "INTEGER";

                case "System.Int16":return "SMALLINT";

                case "System.String": return "VARCHAR(150)";
                                    
                case "System.Int64":return "NUMERIC";
                                    
                case "System.Double":return "DECIMAL";
                                    
                case "System.Float":return "DECIMAL";
                                    
                case "System.Single":return "REAL";
                                    
                case "System.Numeric":return "NUMERIC";

                case "System.DateTime": return "VARCHAR(150)";//case "System.DateTime":return "DATETIME";
                                    
                case "System.Decimal":return "DECIMAL";
                                    
                default:return "VARCHAR(150)";
         
            }
        }
        /// <summary>从<paramref name="sourceTable"/>构建字段字符串
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <returns></returns>
        private static string BuildColumnsString(DataTable sourceTable)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sourceTable.Columns.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                string colName = sourceTable.Columns[i].ColumnName;
                sb.Append(colName);
                sb.Append(" ");//为了避免系统关键字，将所有字段名后添加下划线
                sb.Append(SwitchToSqlType(sourceTable.Columns[i]));
            }
            return sb.ToString();
        }
    }
}
