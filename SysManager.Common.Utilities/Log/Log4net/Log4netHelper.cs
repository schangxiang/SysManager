/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities.Log.Log4net
 * FileName：Log4netHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/25 15:20:51
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/25 15:20:51 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// Log4net帮助类
    /// </summary>
    public sealed class Log4netHelper
    {
        /// <summary>
        ///  输出异常日志到Log4Net
        /// </summary>
        /// <param name="t">类型</param>
        /// <param name="msg">错误信息</param>
        /// <param name="ex">异常对象</param>
        public static void WriteErrorLogByLog4Net(Type t, string msg, Exception ex = null)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg, ex);
        }
        /// <summary>
        /// 输出info日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteInfoLogByLog4Net(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }

    }
}
