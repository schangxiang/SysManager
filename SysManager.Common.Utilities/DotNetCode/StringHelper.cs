/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities.DotNetCode
 * FileName：StringHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/25 14:33:04
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/25 14:33:04 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// 字符串帮助
    /// </summary>
    public sealed class StringHelper
    {
        /// <summary>
        /// 比较两个字符串是否相等，不区分大小写
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static bool StringCompareWithIgnoreCase(string strA, string strB)
        {
            return String.Compare(strA, strB, true) == 0 ? true : false;
        }

        /// <summary>
        /// Null值转Empty
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string NullToEmpty(string val)
        {
            if (val == null)
                return "";
            return val;
        }
    }
}
