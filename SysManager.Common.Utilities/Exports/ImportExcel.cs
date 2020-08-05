
using OfficeOpenXml;
using SysManager.Common.Utilities.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace SysManager.Common.Utilities.Exports
{
    /// <summary>
    /// Execl导入公共类，适用于
    /// </summary>
    public class ImportExcel
    {
        /*
        public static List<Excel> importexc(int sheet)
        {
            List<Excel> list = new List<Excel>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? flag = openFileDialog.ShowDialog();
            bool flag2 = true;
            if (flag.GetValueOrDefault() == flag2 & flag.HasValue)
            {
                string fileName = openFileDialog.FileName;
                Path.GetFileNameWithoutExtension(openFileDialog.FileName).ToString();
                string text = Path.GetExtension(fileName).ToString();
                string[] array = new string[]
                {
                    ".xls",
                    ".xlsx",
                    ".XLS",
                    ".XLSX"
                };
                if (!text.Equals(array[0]) && !text.Equals(array[1]) && !text.Equals(array[2]) && !text.Equals(array[3]))
                {
                    throw new Exception("不是EXCEL文件!");
                }
                Missing arg_C1_0 = Missing.Value;
                using (Stream stream = new FileStream(fileName, FileMode.Open))
                {
                    try
                    {
                        ExcelWorksheet expr_E3 = new ExcelPackage(stream).Workbook.Worksheets[sheet];
                        int row = expr_E3.Dimension.End.Row;
                        int arg_108_0 = expr_E3.Dimension.End.Column;
                        ExcelRange excelRange = expr_E3.Cells["A1:A" + row];
                        ExcelRange excelRange2 = expr_E3.Cells["B1:B" + row];
                        ExcelRange excelRange3 = expr_E3.Cells["C1:C" + row];
                        ExcelRange excelRange4 = expr_E3.Cells["D1:D" + row];
                        ExcelRange excelRange5 = expr_E3.Cells["E1:E" + row];
                        ExcelRange excelRange6 = expr_E3.Cells["F1:F" + row];
                        ExcelRange excelRange7 = expr_E3.Cells["G1:G" + row];
                        ExcelRange excelRange8 = expr_E3.Cells["H1:H" + row];
                        ExcelRange excelRange9 = expr_E3.Cells["I1:I" + row];
                        ExcelRange excelRange10 = expr_E3.Cells["J1:J" + row];
                        ExcelRange excelRange11 = expr_E3.Cells["K1:K" + row];
                        ExcelRange excelRange12 = expr_E3.Cells["L1:L" + row];
                        ExcelRange excelRange13 = expr_E3.Cells["M1:M" + row];
                        ExcelRange excelRange14 = expr_E3.Cells["N1:N" + row];
                        ExcelRange excelRange15 = expr_E3.Cells["O1:O" + row];
                        ExcelRange excelRange16 = expr_E3.Cells["P1:P" + row];
                        ExcelRange excelRange17 = expr_E3.Cells["Q1:Q" + row];
                        ExcelRange excelRange18 = expr_E3.Cells["R1:R" + row];
                        ExcelRange excelRange19 = expr_E3.Cells["S1:S" + row];
                        ExcelRange excelRange20 = expr_E3.Cells["T1:T" + row];
                        ExcelRange excelRange21 = expr_E3.Cells["U1:U" + row];
                        ExcelRange excelRange22 = expr_E3.Cells["V1:V" + row];
                        ExcelRange excelRange23 = expr_E3.Cells["W1:W" + row];
                        ExcelRange excelRange24 = expr_E3.Cells["X1:X" + row];
                        ExcelRange excelRange25 = expr_E3.Cells["Y1:Y" + row];
                        ExcelRange excelRange26 = expr_E3.Cells["Z1:Z" + row];
                        ExcelRange excelRange27 = expr_E3.Cells["AA1:AA" + row];
                        ExcelRange excelRange28 = expr_E3.Cells["AB1:AB" + row];
                        ExcelRange excelRange29 = expr_E3.Cells["AC1:AC" + row];
                        ExcelRange excelRange30 = expr_E3.Cells["AD1:AD" + row];
                        ExcelRange excelRange31 = expr_E3.Cells["AE1:AE" + row];
                        ExcelRange excelRange32 = expr_E3.Cells["AF1:AF" + row];
                        ExcelRange excelRange33 = expr_E3.Cells["AG1:AG" + row];
                        ExcelRange excelRange34 = expr_E3.Cells["AH1:AH" + row];
                        ExcelRange excelRange35 = expr_E3.Cells["AI1:AI" + row];
                        ExcelRange excelRange36 = expr_E3.Cells["AJ1:AJ" + row];
                        ExcelRange excelRange37 = expr_E3.Cells["AK1:AK" + row];
                        ExcelRange excelRange38 = expr_E3.Cells["AL1:AL" + row];
                        ExcelRange excelRange39 = expr_E3.Cells["AM1:AM" + row];
                        ExcelRange excelRange40 = expr_E3.Cells["AN1:AN" + row];
                        ExcelRange excelRange41 = expr_E3.Cells["AO1:AO" + row];
                        ExcelRange excelRange42 = expr_E3.Cells["AP1:AP" + row];
                        ExcelRange excelRange43 = expr_E3.Cells["AQ1:AQ" + row];
                        ExcelRange excelRange44 = expr_E3.Cells["AR1:AR" + row];
                        ExcelRange excelRange45 = expr_E3.Cells["AS1:AS" + row];
                        ExcelRange excelRange46 = expr_E3.Cells["AT1:AT" + row];
                        ExcelRange excelRange47 = expr_E3.Cells["AU1:AU" + row];
                        ExcelRange excelRange48 = expr_E3.Cells["AV1:AV" + row];
                        ExcelRange excelRange49 = expr_E3.Cells["AW1:AW" + row];
                        ExcelRange excelRange50 = expr_E3.Cells["AX1:AX" + row];
                        ExcelRange excelRange51 = expr_E3.Cells["AY1:AY" + row];
                        ExcelRange excelRange52 = expr_E3.Cells["AZ1:AZ" + row];
                        ExcelRange excelRange53 = expr_E3.Cells["BA1:BA" + row];
                        ExcelRange excelRange54 = expr_E3.Cells["BB1:BB" + row];
                        ExcelRange excelRange55 = expr_E3.Cells["BC1:BC" + row];
                        ExcelRange excelRange56 = expr_E3.Cells["BD1:BD" + row];
                        ExcelRange excelRange57 = expr_E3.Cells["BE1:BE" + row];
                        ExcelRange excelRange58 = expr_E3.Cells["BF1:BF" + row];
                        ExcelRange excelRange59 = expr_E3.Cells["BG1:BG" + row];
                        ExcelRange excelRange60 = expr_E3.Cells["BH1:BH" + row];
                        ExcelRange excelRange61 = expr_E3.Cells["BI1:BI" + row];
                        ExcelRange excelRange62 = expr_E3.Cells["BJ1:BJ" + row];
                        ExcelRange excelRange63 = expr_E3.Cells["BK1:BK" + row];
                        ExcelRange excelRange64 = expr_E3.Cells["BL1:BL" + row];
                        ExcelRange excelRange65 = expr_E3.Cells["BM1:BM" + row];
                        ExcelRange excelRange66 = expr_E3.Cells["BN1:BN" + row];
                        ExcelRange excelRange67 = expr_E3.Cells["BO1:BO" + row];
                        ExcelRange excelRange68 = expr_E3.Cells["BP1:BP" + row];
                        ExcelRange excelRange69 = expr_E3.Cells["BQ1:BQ" + row];
                        ExcelRangeBase arg_D00_0 = expr_E3.Cells["BR1:BR" + row];
                        object[,] array2 = (object[,])excelRange.Value;
                        object[,] array3 = (object[,])excelRange2.Value;
                        object[,] array4 = (object[,])excelRange3.Value;
                        object[,] array5 = (object[,])excelRange4.Value;
                        object[,] array6 = (object[,])excelRange5.Value;
                        object[,] array7 = (object[,])excelRange6.Value;
                        object[,] array8 = (object[,])excelRange7.Value;
                        object[,] array9 = (object[,])excelRange8.Value;
                        object[,] array10 = (object[,])excelRange9.Value;
                        object[,] array11 = (object[,])excelRange10.Value;
                        object[,] array12 = (object[,])excelRange11.Value;
                        object[,] array13 = (object[,])excelRange12.Value;
                        object[,] array14 = (object[,])excelRange13.Value;
                        object[,] array15 = (object[,])excelRange14.Value;
                        object[,] array16 = (object[,])excelRange15.Value;
                        object[,] array17 = (object[,])excelRange16.Value;
                        object[,] array18 = (object[,])excelRange17.Value;
                        object[,] array19 = (object[,])excelRange18.Value;
                        object[,] array20 = (object[,])excelRange19.Value;
                        object[,] array21 = (object[,])excelRange20.Value;
                        object[,] array22 = (object[,])excelRange21.Value;
                        object[,] array23 = (object[,])excelRange22.Value;
                        object[,] array24 = (object[,])excelRange23.Value;
                        object[,] array25 = (object[,])excelRange24.Value;
                        object[,] array26 = (object[,])excelRange25.Value;
                        object[,] array27 = (object[,])excelRange26.Value;
                        object[,] array28 = (object[,])excelRange27.Value;
                        object[,] array29 = (object[,])excelRange28.Value;
                        object[,] array30 = (object[,])excelRange29.Value;
                        object[,] array31 = (object[,])excelRange30.Value;
                        object[,] array32 = (object[,])excelRange31.Value;
                        object[,] array33 = (object[,])excelRange32.Value;
                        object[,] array34 = (object[,])excelRange33.Value;
                        object[,] array35 = (object[,])excelRange34.Value;
                        object[,] array36 = (object[,])excelRange35.Value;
                        object[,] array37 = (object[,])excelRange36.Value;
                        object[,] array38 = (object[,])excelRange37.Value;
                        object[,] array39 = (object[,])excelRange38.Value;
                        object[,] array40 = (object[,])excelRange39.Value;
                        object[,] array41 = (object[,])excelRange40.Value;
                        object[,] array42 = (object[,])excelRange41.Value;
                        object[,] array43 = (object[,])excelRange42.Value;
                        object[,] array44 = (object[,])excelRange43.Value;
                        object[,] array45 = (object[,])excelRange44.Value;
                        object[,] array46 = (object[,])excelRange45.Value;
                        object[,] array47 = (object[,])excelRange46.Value;
                        object[,] array48 = (object[,])excelRange47.Value;
                        object[,] array49 = (object[,])excelRange48.Value;
                        object[,] array50 = (object[,])excelRange49.Value;
                        object[,] array51 = (object[,])excelRange50.Value;
                        object[,] array52 = (object[,])excelRange51.Value;
                        object[,] array53 = (object[,])excelRange52.Value;
                        object[,] array54 = (object[,])excelRange53.Value;
                        object[,] array55 = (object[,])excelRange54.Value;
                        object[,] array56 = (object[,])excelRange55.Value;
                        object[,] array57 = (object[,])excelRange56.Value;
                        object[,] array58 = (object[,])excelRange57.Value;
                        object[,] array59 = (object[,])excelRange58.Value;
                        object[,] array60 = (object[,])excelRange59.Value;
                        object[,] array61 = (object[,])excelRange60.Value;
                        object[,] array62 = (object[,])excelRange61.Value;
                        object[,] array63 = (object[,])excelRange62.Value;
                        object[,] array64 = (object[,])excelRange63.Value;
                        object[,] array65 = (object[,])excelRange64.Value;
                        object[,] array66 = (object[,])excelRange65.Value;
                        object[,] array67 = (object[,])excelRange66.Value;
                        object[,] array68 = (object[,])excelRange67.Value;
                        object[,] array69 = (object[,])excelRange68.Value;
                        object[,] array70 = (object[,])excelRange69.Value;
                        object[,] array71 = (object[,])arg_D00_0.Value;
                        for (int i = 0; i < row; i++)
                        {
                            Excel excel = new Excel();
                            excel.excelvalue[0] = ((array2 != null && array2[i, 0] != null) ? array2[i, 0].ToString() : "");
                            excel.excelvalue[1] = ((array3 != null && array3[i, 0] != null) ? array3[i, 0].ToString() : "");
                            excel.excelvalue[2] = ((array4 != null && array4[i, 0] != null) ? array4[i, 0].ToString() : "");
                            excel.excelvalue[3] = ((array5 != null && array5[i, 0] != null) ? array5[i, 0].ToString() : "");
                            excel.excelvalue[4] = ((array6 != null && array6[i, 0] != null) ? array6[i, 0].ToString() : "");
                            excel.excelvalue[5] = ((array7 != null && array7[i, 0] != null) ? array7[i, 0].ToString() : "");
                            excel.excelvalue[6] = ((array8 != null && array8[i, 0] != null) ? array8[i, 0].ToString() : "");
                            excel.excelvalue[7] = ((array9 != null && array9[i, 0] != null) ? array9[i, 0].ToString() : "");
                            excel.excelvalue[8] = ((array10 != null && array10[i, 0] != null) ? array10[i, 0].ToString() : "");
                            excel.excelvalue[9] = ((array11 != null && array11[i, 0] != null) ? array11[i, 0].ToString() : "");
                            excel.excelvalue[10] = ((array12 != null && array12[i, 0] != null) ? array12[i, 0].ToString() : "");
                            excel.excelvalue[11] = ((array13 != null && array13[i, 0] != null) ? array13[i, 0].ToString() : "");
                            excel.excelvalue[12] = ((array14 != null && array14[i, 0] != null) ? array14[i, 0].ToString() : "");
                            excel.excelvalue[13] = ((array15 != null && array15[i, 0] != null) ? array15[i, 0].ToString() : "");
                            excel.excelvalue[14] = ((array16 != null && array16[i, 0] != null) ? array16[i, 0].ToString() : "");
                            excel.excelvalue[15] = ((array17 != null && array17[i, 0] != null) ? array17[i, 0].ToString() : "");
                            excel.excelvalue[16] = ((array18 != null && array18[i, 0] != null) ? array18[i, 0].ToString() : "");
                            excel.excelvalue[17] = ((array19 != null && array19[i, 0] != null) ? array19[i, 0].ToString() : "");
                            excel.excelvalue[18] = ((array20 != null && array20[i, 0] != null) ? array20[i, 0].ToString() : "");
                            excel.excelvalue[19] = ((array21 != null && array21[i, 0] != null) ? array21[i, 0].ToString() : "");
                            excel.excelvalue[20] = ((array22 != null && array22[i, 0] != null) ? array22[i, 0].ToString() : "");
                            excel.excelvalue[21] = ((array23 != null && array23[i, 0] != null) ? array23[i, 0].ToString() : "");
                            excel.excelvalue[22] = ((array24 != null && array24[i, 0] != null) ? array24[i, 0].ToString() : "");
                            excel.excelvalue[23] = ((array25 != null && array25[i, 0] != null) ? array25[i, 0].ToString() : "");
                            excel.excelvalue[24] = ((array26 != null && array26[i, 0] != null) ? array26[i, 0].ToString() : "");
                            excel.excelvalue[25] = ((array27 != null && array27[i, 0] != null) ? array27[i, 0].ToString() : "");
                            excel.excelvalue[26] = ((array28 != null && array28[i, 0] != null) ? array28[i, 0].ToString() : "");
                            excel.excelvalue[27] = ((array29 != null && array29[i, 0] != null) ? array29[i, 0].ToString() : "");
                            excel.excelvalue[28] = ((array30 != null && array30[i, 0] != null) ? array30[i, 0].ToString() : "");
                            excel.excelvalue[29] = ((array31 != null && array31[i, 0] != null) ? array31[i, 0].ToString() : "");
                            excel.excelvalue[30] = ((array32 != null && array32[i, 0] != null) ? array32[i, 0].ToString() : "");
                            excel.excelvalue[31] = ((array33 != null && array33[i, 0] != null) ? array33[i, 0].ToString() : "");
                            excel.excelvalue[32] = ((array34 != null && array34[i, 0] != null) ? array34[i, 0].ToString() : "");
                            excel.excelvalue[33] = ((array35 != null && array35[i, 0] != null) ? array35[i, 0].ToString() : "");
                            excel.excelvalue[34] = ((array36 != null && array36[i, 0] != null) ? array36[i, 0].ToString() : "");
                            excel.excelvalue[35] = ((array37 != null && array37[i, 0] != null) ? array37[i, 0].ToString() : "");
                            excel.excelvalue[36] = ((array38 != null && array38[i, 0] != null) ? array38[i, 0].ToString() : "");
                            excel.excelvalue[37] = ((array39 != null && array39[i, 0] != null) ? array39[i, 0].ToString() : "");
                            excel.excelvalue[38] = ((array40 != null && array40[i, 0] != null) ? array40[i, 0].ToString() : "");
                            excel.excelvalue[39] = ((array41 != null && array41[i, 0] != null) ? array41[i, 0].ToString() : "");
                            excel.excelvalue[40] = ((array42 != null && array42[i, 0] != null) ? array42[i, 0].ToString() : "");
                            excel.excelvalue[41] = ((array43 != null && array43[i, 0] != null) ? array43[i, 0].ToString() : "");
                            excel.excelvalue[42] = ((array44 != null && array44[i, 0] != null) ? array44[i, 0].ToString() : "");
                            excel.excelvalue[43] = ((array45 != null && array45[i, 0] != null) ? array45[i, 0].ToString() : "");
                            excel.excelvalue[44] = ((array46 != null && array46[i, 0] != null) ? array46[i, 0].ToString() : "");
                            excel.excelvalue[45] = ((array47 != null && array47[i, 0] != null) ? array47[i, 0].ToString() : "");
                            excel.excelvalue[46] = ((array48 != null && array48[i, 0] != null) ? array48[i, 0].ToString() : "");
                            excel.excelvalue[47] = ((array49 != null && array49[i, 0] != null) ? array49[i, 0].ToString() : "");
                            excel.excelvalue[48] = ((array50 != null && array50[i, 0] != null) ? array50[i, 0].ToString() : "");
                            excel.excelvalue[49] = ((array51 != null && array51[i, 0] != null) ? array51[i, 0].ToString() : "");
                            excel.excelvalue[50] = ((array52 != null && array52[i, 0] != null) ? array52[i, 0].ToString() : "");
                            excel.excelvalue[51] = ((array53 != null && array53[i, 0] != null) ? array53[i, 0].ToString() : "");
                            excel.excelvalue[52] = ((array54 != null && array54[i, 0] != null) ? array54[i, 0].ToString() : "");
                            excel.excelvalue[53] = ((array55 != null && array55[i, 0] != null) ? array55[i, 0].ToString() : "");
                            excel.excelvalue[54] = ((array56 != null && array56[i, 0] != null) ? array56[i, 0].ToString() : "");
                            excel.excelvalue[55] = ((array57 != null && array57[i, 0] != null) ? array57[i, 0].ToString() : "");
                            excel.excelvalue[56] = ((array58 != null && array58[i, 0] != null) ? array58[i, 0].ToString() : "");
                            excel.excelvalue[57] = ((array59 != null && array59[i, 0] != null) ? array59[i, 0].ToString() : "");
                            excel.excelvalue[58] = ((array60 != null && array60[i, 0] != null) ? array60[i, 0].ToString() : "");
                            excel.excelvalue[59] = ((array61 != null && array61[i, 0] != null) ? array61[i, 0].ToString() : "");
                            excel.excelvalue[60] = ((array62 != null && array62[i, 0] != null) ? array62[i, 0].ToString() : "");
                            excel.excelvalue[61] = ((array63 != null && array63[i, 0] != null) ? array63[i, 0].ToString() : "");
                            excel.excelvalue[62] = ((array64 != null && array64[i, 0] != null) ? array64[i, 0].ToString() : "");
                            excel.excelvalue[63] = ((array65 != null && array65[i, 0] != null) ? array65[i, 0].ToString() : "");
                            excel.excelvalue[64] = ((array66 != null && array66[i, 0] != null) ? array66[i, 0].ToString() : "");
                            excel.excelvalue[65] = ((array67 != null && array67[i, 0] != null) ? array67[i, 0].ToString() : "");
                            excel.excelvalue[66] = ((array68 != null && array68[i, 0] != null) ? array68[i, 0].ToString() : "");
                            excel.excelvalue[67] = ((array69 != null && array69[i, 0] != null) ? array69[i, 0].ToString() : "");
                            excel.excelvalue[68] = ((array70 != null && array70[i, 0] != null) ? array70[i, 0].ToString() : "");
                            excel.excelvalue[69] = ((array71 != null && array71[i, 0] != null) ? array71[i, 0].ToString() : "");
                            if (excel != null)
                            {
                                list.Add(excel);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TextLogger.WriteLog(ex.ToString());
                    }
                }
            }
            return list;
        }
        //*/
    }
}
