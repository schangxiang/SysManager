/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities
 * FileName：DateTimeHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/21 16:43:27
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/21 16:43:27 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// 日期帮助类
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNow()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 格式化当前日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化当前日期成字符串(到毫秒的小数精度为七位。其余数字被截断。)
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTimeWithF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTime(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyy-MM-dd HH:mm:ss:fff)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTimePreciseToFFF(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyyMMdd hh:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTimeToyyyyMMdd(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyyMMdd hh:mm:ss");
        }

    }
}
