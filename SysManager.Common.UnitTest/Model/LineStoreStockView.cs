namespace SysManager.Common.UnitTest
{
    /// <summary>
    /// 线边仓功能 实体模型类
    /// </summary>s
    public class LineStoreStockView 
    {
        /// <summary>
        /// 记录编号  ,主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MatId { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MatName { get; set; }

        /// <summary>
        /// 型号规格
        /// </summary>
        public string MatSpec { get; set; }

        /// <summary>
        /// 物料分类
        /// </summary>
        public string MatType { get; set; }

        /// <summary>
        /// 物料大类
        /// </summary>
        public string MatLargeTypeId { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 线边库位号
        /// </summary>
        public string WorkShopId { get; set; }
        /// <summary>
        /// 线边库位号
        /// </summary>
        public string LineStoreId { get; set; }
        /// <summary>
        /// 线边库位号
        /// </summary>
        public string LineStorageBinId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 选中标记
        /// </summary>
        public bool IsSelected { get; set; }

        public decimal ReturnQuantity { get; set; }
        /// <summary>
        /// 源ERP库位
        /// </summary>

        public string SourceStoreBinId { get; set; }
        /// <summary>
        /// 当前ERP库位
        /// </summary>
        public string TargetStoreBinId { get; set; }

        public string LineStoreName { get; set; }

        public string StorageBinName { get; set; }

        public string StoreDisplayName { get { return LineStoreName + StorageBinName; } }

        /// <summary>
        /// 供应商
        /// </summary>
        public string MaterialSupplier { get; set; }
        /// <summary>
        /// 上料中
        /// </summary>
        public string ChargingInNumber { get; set; }
        /// <summary>
        /// 退料中
        /// </summary>
        public string ReturnInNumber { get; set; }

        /// <summary>
        /// 是否摘单增加的退料（如果值为1则是摘单增加的原材料）
        /// </summary>
        public int IsPick { get; set; }
    }

    //public class LineStoreGroupByStore
    //{

    //}
}