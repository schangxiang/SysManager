
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using SysManager.Common.Utilities.Exports;

namespace SysManager.Common.UnitTest
{
    [TestClass]
    public class ExportsUnitTest
    {
        /// <summary>
        /// 测试导出
        /// </summary>
        [TestMethod]
        public void Test_ExcelExport()
        {
            try
            {
                //实例化导出Excel实例，按配置导出
                Utilities.Exports.ExcelExporter exporter = new ExcelExporter();
                exporter.ExportToFile<LineStoreStockView>("线边仓功能 数据", new string[] {
"记录编号","物料编码","物料名称","型号规格","物料分类","物料大类","批次号","线边库位号","数量","单位", "当前存放库位"  }, 
new System.Collections.Generic.List<LineStoreStockView>(), //导出数据源
c => c.Id, c => c.MatId, c => c.MatName, c => c.MatSpec, c => c.MatType, c => c.MatLargeTypeId, c => c.BatchNo, c => c.LineStorageBinId, c => c.Quantity, c => c.Unit, c => c.StoreDisplayName);
                //打开导出所在的文件夹
                System.Diagnostics.Process.Start("explorer", System.IO.Path.Combine(exporter.GetDirectoryPath(), "FileDownloads"));
            }
            catch (Exception ex)
            {
                //Messager.ShowMessage(ex.Message, true);
            }
        }
        /// <summary>
        /// 测试导入
        /// </summary>
        [TestMethod]
        public void Test_ExcelImporter()
        {
            try
            {
                //选择文件
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = ".xlsx";
                dialog.Filter = "Excel表格文件 (.xlsx)|*.xlsx";
                if (dialog.ShowDialog() == true)
                {
                    //将数据转为Datatable
                    var datas = Utilities.Exports.ExcelImporter.ExcelToDataTable(dialog.FileName, true, 10, 1);
                    var importList = new System.Collections.Generic.List<LineStoreEntity>();


                    foreach (DataRow item in datas.Rows)
                    {
                        //提取数据
                        var aa = new LineStoreEntity
                        {
                            Id = (long)item[0],
                            MatId = (string)item[1],
                            MatName = (string)item[2],
                            MatSpec = (string)item[3],
                            MatType = (string)item[4],
                            MatLargeTypeId = (string)item[5],
                            BatchNo = (string)item[6],
                            LineStorageBinId = (string)item[7],
                            Quantity = (decimal)item[8],
                            Unit = (string)item[9],
                            creator = "",
                            createTime = DateTime.Now,
                            lastModifier ="",
                            lastModifyTime = DateTime.Now,
                            operationNote = "Exccel导入"
                        };
                        importList.Add(aa);
                        
                    }

                    //批量插入数据
                    /*
                    using (MftDbContext _dbContext = new MftDbContext(SystemConfig.SqlConnectionString))
                    {
                        var trans = _dbContext.BeginTransaction();
                        try
                        {
                            _dbContext.LineStoreEntity.BulkInsert(importList, trans);
                            _dbContext.LineStoreHistoryRecordEntity.BulkInsert(importHistoryRecordList, trans);
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }

                    }

                    MessageBox.Show("数据导入成功");
                    _viewModel.LoadData();
                    //*/
                }
            }
            catch (Exception ex)
            {
                //Messager.ShowMessage(ex.Message, true);
            }
        }
    }
}
