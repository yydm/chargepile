using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace ChargingPile.DAL
{
    public class GetPage
    {
        readonly OracleConnection m_oracleConnection = new OracleConnection(ConfigurationSettings.AppSettings["DBConnectionString"]);
        public DataTable GetPageByProcedure(int pageSize, int pageNo, string sqlStr, ref int recordCount)
        {

            var parameters = new OracleParameterCollection();
            OpenOracleConnection();
            var pOracleCmd = new OracleCommand("PK_Pager.GetPager", m_oracleConnection);
            pOracleCmd.CommandType = CommandType.StoredProcedure;

            var p1 = new OracleParameter("p_PageSize", OracleType.Int32, 10);//每页记录数
            var p2 = new OracleParameter("p_PageNo", OracleType.Int32, 10);//当前页码,从 1 开始
            var p3 = new OracleParameter("p_SqlSelect", OracleType.VarChar, 1000);//查询语句,含排序部分
            var p4 = new OracleParameter("p_OutRecordCount", OracleType.Int32, 10);
            var p5 = new OracleParameter("p_OutCursor", OracleType.Cursor);

            //设置参数的输入输出类型,默认为输入
            p1.Direction = ParameterDirection.Input;
            p2.Direction = ParameterDirection.Input;
            p3.Direction = ParameterDirection.Input;
            p4.Direction = ParameterDirection.Output;
            p5.Direction = ParameterDirection.Output;

            pOracleCmd.Parameters.Add(p1);
            pOracleCmd.Parameters.Add(p2);
            pOracleCmd.Parameters.Add(p3);
            pOracleCmd.Parameters.Add(p4);
            pOracleCmd.Parameters.Add(p5);

            p1.Value = pageSize;
            p2.Value = pageNo;
            p3.Value = sqlStr;
            var pOracleDataAdapter = new OracleDataAdapter(pOracleCmd);
            var datatable = new DataTable();
            pOracleDataAdapter.Fill(datatable);
            //在执行结束后,从存储过程输出参数中取得相应的值放入引用参数中以供程序调用
            recordCount = int.Parse(p4.Value.ToString());
            //关闭连接
            CloseOracleConnection();
            return datatable;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        private void CloseOracleConnection()
        {
            if (m_oracleConnection.State == ConnectionState.Open)
            {
                m_oracleConnection.Close();
            }
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        private void OpenOracleConnection()
        {
            if (m_oracleConnection.State == ConnectionState.Closed)
            {
                m_oracleConnection.Open();
            }
        }
    }
}
