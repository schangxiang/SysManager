using System;

namespace SysManager.Common.UnitTest
{
    /// <summary>
    /// 线边仓功能 实体模型类
    /// </summary>s

    public class LineStoreEntity 
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
        /// 车间编码
        /// </summary>
        public string WorkShopId { get; set; }
        /// <summary>
        /// 线边库编号
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

       

        public decimal FeedQuantity { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;
        public string Unit { get { return _unit == "KM" ? "M" : _unit; } set { _unit = value; } }

        /// <summary>
        /// 选中标记
        /// </summary>
        public bool IsSelected { get; set; }

        private decimal _returnQuantity;
        public decimal ReturnQuantity { get { return _returnQuantity; } set { _returnQuantity = value; } }

        public bool HasError { get { return Quantity - ReturnQuantity > 0; } }
        /// <summary>
        /// 源ERP库位
        /// </summary>
        public string SourceStoreBinId { get; set; }
        /// <summary>
        /// 当前ERP库位
        /// </summary>
        public string TargetStoreBinId { get; set; }
        /// <summary>
        /// 新增id区分上料时的替代料skyyang
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string MaterialSupplier { get; set; }
        /// <summary>
        /// 来料确认时间 xuyang 20191225
        /// </summary>
        public DateTime? ConfirmTime { get; set; }
        /// <summary>
        /// 摘单ID唯一码
        /// </summary>
        public string PickId  { get; set; }
        /// <summary>
        /// 摘单状态
        /// </summary>
        public int IsPick { get; set; }

        #region 新加字段 【Editby shaocx,2020-02-25】

        /// <summary>
        /// 创建人
        /// </summary>
        public string creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string lastModifier { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime lastModifyTime { get; set; }

        /// <summary>
        /// 操作说明
        /// </summary>
        public string operationNote { get; set; }

        /// <summary>
        /// 变化数量
        /// </summary>
        
        public decimal ChangeQuantity { get; set; }

        #endregion
    }

    //public class LineStoreGroupByStore
    //{

    //}
}