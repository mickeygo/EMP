using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;
using DotPlatform.Timing;

namespace WMS.Domain.Models.Inbounds
{
    /// <summary>
    /// 入库单
    /// </summary>
    public class StockIn : AggregateRoot, ISoftDelete, IMustHaveTenant, ICreationAudited, IModificationAudited, IDeletionAudited
    {
        #region Properties

        /// <summary>
        /// 入库单单据号
        /// </summary>
        [Required]
        [StringLength(15)]
        public string DocNo { get; private set; }

        /// <summary>
        /// 来源工厂
        /// </summary>
        [StringLength(4)]
        public string Plant { get; private set; }

        /// <summary>
        /// WIP 单号
        /// </summary>
        [StringLength(10)]
        public string WipNo { get; private set; }

        /// <summary>
        /// 料号
        /// </summary>
        [StringLength(20)]
        public string PartNumber { get; private set; }

        /// <summary>
        /// 单据明细数量
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// 目的工厂
        /// </summary>
        [StringLength(4)]
        public string DestPlant { get; private set; }

        /// <summary>
        /// 目的库位
        /// </summary>
        [StringLength(4)]
        public string DestLocation { get; private set; }

        /// <summary>
        /// 单据备注
        /// </summary>
        [StringLength(256)]
        public string Remark { get; private set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        [StringLength(10)]
        public string Certificate { get; private set; }

        /// <summary>
        /// 回执消息
        /// </summary>
        [StringLength(256)]
        public string AckMessage { get; private set; }

        /// <summary>
        /// 新的 WIP 单号
        /// </summary>
        [StringLength(10)]
        public string NewWipNo { get; private set; }

        /// <summary>
        /// 单据申请人
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Applicant { get; private set; }

        /// <summary>
        /// 单据申请时间
        /// </summary>
        public DateTime ApplicantDate { get; private set; }

        /// <summary>
        /// 单据入库操作人
        /// </summary>
        [StringLength(80)]
        public string InboundBy { get; private set; }

        /// <summary>
        /// 单据入库时间
        /// </summary>
        public DateTime? InboundDate { get; private set; }

        /// <summary>
        /// 入库单单据状态
        /// </summary>
        public StockInStatus Status { get; private set; }

        public Guid TenantId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public Guid? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 入库单明细
        /// </summary>
        public virtual List<StockInLine> StockInLines { get; private set; }

        #endregion

        #region Ctor

        public StockIn()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="StockIn"/>实例
        /// </summary>
        /// <param name="docNo">入库单单据号</param>
        /// <param name="plant">工厂</param>
        /// <param name="wipNo">WIP 单号</param>
        /// <param name="pn">料号</param>
        /// <param name="qty">单据明细数量</param>
        /// <param name="destPlant">目的工厂</param>
        /// <param name="destLocation">目的库位</param>
        /// <param name="remark">单据备注</param>
        /// <param name="applicant">单据申请人</param>
        public StockIn(string docNo, string plant, string wipNo, string pn, int qty, string destPlant, string destLocation, 
            string remark, string applicant)
        {
            DocNo = docNo;
            Plant = plant;
            WipNo = wipNo;
            PartNumber = pn;
            Quantity = qty;
            DestPlant = destPlant;
            DestLocation = destLocation;
            Remark = remark;
            Applicant = applicant;
            Status = StockInStatus.Opened;
            ApplicantDate = Clock.Local;

            GenerateNewId();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 添加单据明细
        /// </summary>
        /// <param name="item">要添加的单据明细</param>
        public void AddItem(StockInLine item)
        {
            if (StockInLines == null)
                StockInLines = new List<StockInLine>();

            StockInLines.Add(item);
        }

        /// <summary>
        /// 添加单据明细
        /// </summary>
        /// <param name="items">要添加的单据明细集合</param>
        public void AddItems(IEnumerable<StockInLine> items)
        {
            if (StockInLines == null)
                StockInLines = new List<StockInLine>();

            StockInLines.AddRange(items);
        }

        /// <summary>
        /// 单据入库
        /// </summary>
        /// <param name="inboundBy">入库确定人</param>
        /// <param name="inStoreDate">入库时间</param>
        public void Inbound(string inboundBy, DateTime inboundDate)
        {
            InboundBy = inboundBy;
            InboundDate = inboundDate;
            Status = StockInStatus.InStore;
        }

        /// <summary>
        /// 关闭单据
        /// </summary>
        public void CloseOrder()
        {
            Status = StockInStatus.Closed;
        }

        /// <summary>
        /// 单据回执。
        /// 提交给 SAP，若 SAP 提交成功，SAP 会回传凭证号，否则会回传错误信息
        /// </summary>
        /// <param name="certificate">SAP 凭证号</param>
        /// <param name="ackMessage">SAP 回执信息</param>
        public void Ack(string certificate, string ackMessage)
        {
            Certificate = certificate;
            AckMessage = ackMessage;
        }

        #endregion
    }
}
