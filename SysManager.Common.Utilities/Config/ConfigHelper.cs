/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities.Config
 * FileName：ConfigHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/25 14:38:06
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/25 14:38:06 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetValue(string key)
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings[key].ToString().Trim();
            }
            catch (Exception)
            {
                throw new Exception("配置文件中找不到【" + key + "】节点");
            }
            return value;
        }
    }
}
