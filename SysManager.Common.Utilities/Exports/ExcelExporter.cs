using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities.Exports
{
    /// <summary>
    /// Excel导出帮助类
    /// </summary>
    public class ExcelExporter : EpPlusExcelExporterBase
    {
        /// <summary>
        /// 设定导出盘符路径
        /// </summary>
        /// <returns></returns>
        public string GetDirectoryPath()
        {
            return Path.Combine(new string[]
            {
                "C:\\"
            });
        }
        /// <summary>
        /// 导出数据到Excel文件功能
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="name">展出文件的名称</param>
        /// <param name="columns">列表头名称列表</param>
        /// <param name="items">列表数据</param>
        /// <param name="propertySelectors">与表头对应的数据</param>
        public void ExportToFile<T>(string name, string[] columns, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            string directoryPath = this.GetDirectoryPath();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string text = Path.Combine(directoryPath, "FileDownloads");
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            base.CreateExcelPackage(Path.Combine(text, name + ".xlsx"), delegate (ExcelPackage excelPackage)
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(name);
                excelWorksheet.OutLineApplyStyle = true;
                this.AddHeader(excelWorksheet, columns);
                this.AddObjects<T>(excelWorksheet, 2, items, propertySelectors);
                for (int i = 1; i <= 51; i++)
                {
                    excelWorksheet.Column(i).AutoFit();
                }
            });
        }
    }
}
