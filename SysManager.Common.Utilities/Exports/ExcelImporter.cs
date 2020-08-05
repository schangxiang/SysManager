using OfficeOpenXml;
using SysManager.Common.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities.Exports
{
    /// <summary>
	/// Excel导入帮助类
	/// </summary>
	public class ExcelImporter
    {
        /// <summary>
        /// 从Excel导入数据，转换成DataTable待用
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="isSkipFirstRow">是否包含表头</param>
        /// <param name="cols">列数</param>
        /// <param name="workSheet">需要导入的表，默认第1个</param>
        /// <returns>正常返回Datatable,否则返回空</returns>
        public static DataTable ExcelToDataTable(string filePath, bool isSkipFirstRow, int cols, int workSheet = 1)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    for (int i = 0; i < cols; i++)
                    {
                        dataTable.Columns.Add(i.ToString(), Type.GetType("System.String"));
                    }
                    using (Stream stream = new FileStream(filePath, FileMode.Open))
                    {
                        ExcelWorksheet excelWorksheet = new ExcelPackage(stream).Workbook.Worksheets[workSheet];
                        int arg_9A_0 = excelWorksheet.Dimension.Start.Row + (isSkipFirstRow ? 1 : 0);
                        int num = cols;
                        if (num > excelWorksheet.Dimension.End.Column)
                        {
                            num = excelWorksheet.Dimension.End.Column;
                        }
                        for (int j = arg_9A_0; j <= excelWorksheet.Dimension.End.Row; j++)
                        {
                            DataRow dataRow = dataTable.NewRow();
                            for (int k = excelWorksheet.Dimension.Start.Column; k <= num; k++)
                            {
                                if (excelWorksheet.Cells[j, k].Style.Numberformat.Format.IndexOf("yyyy") > -1 && excelWorksheet.Cells[j, k].Value != null)
                                {
                                    dataRow[k - 1] = excelWorksheet.Cells[j, k].GetValue<DateTime>();
                                }
                                else
                                {
                                    dataRow[k - 1] = (excelWorksheet.Cells[j, k].Value ?? DBNull.Value);
                                }
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                    DataTable result = dataTable;
                    return result;
                }
                catch (Exception arg_199_0)
                {
                    TextLogger.WriteLog(arg_199_0.ToString());
                    DataTable result = null;
                    return result;
                }
            }
            return null;
        }
    }
}
