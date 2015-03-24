using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ChargingPile.UI.WEB.WebService
{
    public class JSonHandle
    {
        public static string ToJson(DataTable dt,int intCount,string strFormat)
        {
            System.Text.StringBuilder jsonBuilder = new System.Text.StringBuilder();
            if (dt !=null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jsonBuilder.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            jsonBuilder.Append("\"");
                            jsonBuilder.Append(dt.Columns[j].ColumnName);
                            jsonBuilder.Append("\":");
                            if (dt.Rows[i][j] is DateTime)
                            {
                                jsonBuilder.Append("\"" + ((DateTime)dt.Rows[i][j]).ToString(strFormat) + "\",");
                            }
                            else
                            {
                                if (dt.Rows[i][j] is decimal)
                                {
                                    jsonBuilder.Append(dt.Rows[i][j].ToString() + ",");
                                }
                                else
                                {
                                    jsonBuilder.Append("\"" + System.Web.HttpUtility.HtmlEncode(dt.Rows[i][j].ToString().Replace("\r\n", "<br>").Replace(@"\", @"\\")) + "\",");
                                }
                            }
                        }
                        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        jsonBuilder.Append("},");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                }
            }
            string returnData = string.Empty;
            returnData = "{";                //总共多少页        
            returnData += "\"total\"";
            returnData += ":";
            returnData += "\"";
            returnData += intCount.ToString();
            returnData += "\"";
            returnData += ",";                //datable转换得到的JSON字符串        
            returnData += "\"rows\"";
            returnData += ":[";
            returnData += jsonBuilder.ToString();
            returnData += "]}";

            return returnData;
        }
    }
}