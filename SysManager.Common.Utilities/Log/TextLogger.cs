using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities.Log
{
    /// <summary>
    /// 简单日志帮助类
    /// </summary>
    public class TextLogger
    {
        /// <summary>
        /// 直接将记录内容保存到日志文件中
        /// </summary>
        /// <param name="log">记录内容</param>
        public static void WriteLog(string log)
        {
            string text = Path.Combine("C:\\", "Logs");
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            File.AppendAllText(Path.Combine(text, string.Format("debug_log_{0:MM_dd}.txt", DateTime.Now)), string.Format("【{0:yyyy-MM-dd HH:mm:ss}】:{1}\r\n", DateTime.Now, log));
        }
    }
}
