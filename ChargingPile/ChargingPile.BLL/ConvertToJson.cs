using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ChargingPile.BLL
{
    public class ConvertToJson
    {
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            var json = new StringBuilder();
            json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    json.Append("{");
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        var sb = new StringBuilder();
                        Escape(dt.Rows[i][j].ToString(), sb);

                        json.Append("\"" + dt.Columns[j].ColumnName + "\":\"" + sb + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]}");
            return json.ToString();
        }

        /// <summary>
        /// datatable转化成json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            var json = new StringBuilder();
            json.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    json.Append("{");
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        var sb = new StringBuilder();
                        Escape(dt.Rows[i][j].ToString(), sb);

                        json.Append("\"" + dt.Columns[j].ColumnName + "\":\"" + sb + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]");
            return json.ToString();
        }

        /// <summary>
        /// 将?string数簓组哩?转羇换?成éjson字?符?串?
        /// </summary>
        /// <param name="tagStrings">json对?象ó数簓组哩?名?称?</param>
        /// <param name="strings">json对?象ó数簓组哩?值μ</param>
        /// <returns></returns>
        public static string StringArrayToJson(string[] tagStrings, string[] strings)
        {
            var json = new StringBuilder();
            json.Append("{");
            for (int i = 0; i < strings.Length; i++)
            {
                json.Append(tagStrings[i]);
                json.Append(":");
                json.Append(strings[i]);
                if (i < strings.Length - 1)
                {
                    json.Append(",");
                }
            }
            json.Append("}");
            return json.ToString();
        }

        public static string ObjectToJson<T>(string jsonName, IList<T> il)
        {
            var json = new StringBuilder();
            json.Append("{\"" + jsonName + "\":[");
            if (il.Count > 0)
            {
                for (int i = 0; i < il.Count; i++)
                {
                    var obj = Activator.CreateInstance<T>();
                    var type = obj.GetType();
                    var pis = type.GetProperties();
                    json.Append("{");
                    for (var j = 0; j < pis.Length; j++)
                    {
                        json.Append("\"" + pis[j].Name + "\":\"" + pis[j].GetValue(il[i], null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (i < il.Count - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]}");
            return json.ToString();
        }


        public static void Escape(string s, StringBuilder sb)
        {
            foreach (var ch in s)
            {
                switch (ch)
                {

                    case '"':
                        sb.Append("\\\"");
                        break;

                    case '\\':

                        sb.Append("\\\\");

                        break;

                    case '\b':

                        sb.Append("\\b");

                        break;

                    case '\f':

                        sb.Append("\\f");

                        break;

                    case '\n':

                        sb.Append("\\n");

                        break;

                    case '\r':

                        sb.Append("\\r");

                        break;

                    case '\t':

                        sb.Append("\\t");

                        break;

                    case '/':

                        sb.Append("\\/");

                        break;

                    default:

                        // Reference: http://www.unicode.org/versions/Unicode5.1.0/

                        if ((ch >= '\u0000' && ch <= '\u001F')

                            || (ch >= '\u007F' && ch <= '\u009F')

                            || (ch >= '\u2000' && ch <= '\u20FF'))
                        {

                            string ss = Convert.ToString(ch, 16);

                            sb.Append("\\u");

                            for (int k = 0; k < 4 - ss.Length; k++)
                            {

                                sb.Append('0');

                            }

                            sb.Append(ss.ToUpper());

                        }
                        else
                        {

                            sb.Append(ch);

                        }

                        break;

                }
            }
        }
    }
}
