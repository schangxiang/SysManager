/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.DB.Utilities.ORM_Dapper
 * FileName：SQLServerDapperHelper
 * CurrentYear：2019
 * CurrentTime：2019/8/7 13:21:32
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/8/7 13:21:32 新規作成 (by shaocx)
 */


using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.DB.Utilities
{
    
    /// <summary>
    /// Orcle数据库Dapper操作
    /// </summary>
    public class OracleDapperHelper : DapperDataBase
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string connectionString = DESEncryptHelper.Decrypt(ConfigurationManager.ConnectionStrings["OracleConnString"].ConnectionString);
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public override System.Data.IDbConnection CreateDbConnection()
        {
            var connection = new OracleConnection(connectionString);//连接SQL Server数据库
            connection.Open();
            return connection;
        }
    }
}
