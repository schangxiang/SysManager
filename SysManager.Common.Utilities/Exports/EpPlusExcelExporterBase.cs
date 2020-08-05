using OfficeOpenXml;
using SysManager.Common.Utilities.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace SysManager.Common.Utilities.Exports
{
    public abstract class EpPlusExcelExporterBase
    {
        protected void CreateExcelPackage(string fileName, Action<ExcelPackage> creator)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                creator(excelPackage);
                this.Save(excelPackage, fileName);
            }
        }
        protected void AddHeader(ExcelWorksheet sheet, params string[] headerTexts)
        {
            if (headerTexts.IsNullOrEmpty<string>())
            {
                return;
            }
            for (int i = 0; i < headerTexts.Length; i++)
            {
                this.AddHeader(sheet, i + 1, headerTexts[i]);
            }
        }
        protected void AddHeader(ExcelWorksheet sheet, int columnIndex, string headerText)
        {
            sheet.Cells[1, columnIndex].Value = headerText;
            sheet.Cells[1, columnIndex].Style.Font.Bold = true;
        }
        protected void AddObjects<T>(ExcelWorksheet sheet, int startRowIndex, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            if (items.IsNullOrEmpty<T>() || propertySelectors.IsNullOrEmpty<Func<T, object>>())
            {
                return;
            }
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < propertySelectors.Length; j++)
                {
                    sheet.Cells[i + startRowIndex, j + 1].Value = propertySelectors[j](items[i]);
                }
            }
        }
        protected void Save(ExcelPackage excelPackage, string filePath)
        {
            excelPackage.SaveAs(new FileInfo(filePath));
        }
    }
}
