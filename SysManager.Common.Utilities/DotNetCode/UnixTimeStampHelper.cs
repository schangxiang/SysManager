/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities
 * FileName：UnixTimeStampHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/21 16:45:50
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/21 16:45:50 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// UNIX时间戳帮助类
    /// </summary>
    public class UnixTimeStampHelper
    {
        /// <summary>
        /// 当前时间生成Unix时间戳
        /// </summary>
        /// <param name="timeZoneType">时区类型</param>
        /// <param name="timeSpanPrecisionType">时间戳精度类型</param>
        /// <returns>Unix时间戳</returns>
        public static long GetUnixTimeStamp(TimeZoneType timeZoneType, TimeSpanPrecisionType timeSpanPrecisionType)
        {
            DateTime startTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);//当前的格林威治时间
            if (timeZoneType == TimeZoneType.EasEightArea)
            {
                startTime = TimeZone.CurrentTimeZone.ToLocalTime(startTime);//将当前时间格林威治时间转换成东八区时间
            }
            DateTime nowTime = DateTime.Now;

            double _double = 0;
            if (timeSpanPrecisionType == TimeSpanPrecisionType.Milliseconds)
            {
                _double = (nowTime - startTime).TotalMilliseconds;
            }
            else if (timeSpanPrecisionType == TimeSpanPrecisionType.Seconds)
            {
                _double = (nowTime - startTime).Seconds;
            }

            long unixTime = (long)System.Math.Round(_double, MidpointRounding.AwayFromZero);
            return unixTime;
        }
    }

    /// <summary>
    /// 时间戳精度类型
    /// </summary>
    public enum TimeSpanPrecisionType
    {
        /// <summary>
        /// 毫秒
        /// </summary>
        Milliseconds = 1,
        /// <summary>
        /// 秒
        /// </summary>
        Seconds = 2
    }


    /// <summary>
    /// 时区类型
    /// </summary>
    public enum TimeZoneType
    {
        /// <summary>
        /// 东八区
        /// </summary>
        EasEightArea = 1,
        /// <summary>
        /// 零时区(格林威治时间)
        /// </summary>
        ZeroTimeZone = 2
    }
}
