using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Models.Inbounds
{
    /// <summary>
    /// 入库单明细
    /// </summary>
    public class StockInLine : Entity
    {
        #region Properties

        /// <summary>
        /// 入库单 Id
        /// </summary>
        public Guid StockInId { get; private set; }

        /// <summary>
        /// 入库单单据
        /// </summary>
        public virtual StockIn StockIn { get; private set; }

        /// <summary>
        /// 获取 Barcode
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Barcode { get; private set; }

        /// <summary>
        /// 获取箱号
        /// </summary>
        [Required]
        [StringLength(13)]
        public string CartonNo { get; private set; }

        #endregion

        #region Ctor

        public StockInLine()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="StockInLine"/>实例
        /// </summary>
        /// <param name="stockInId">入库单 Id</param>
        /// <param name="barcode">Barcode</param>
        /// <param name="cartonNo">箱号</param>
        public StockInLine(Guid stockInId, string barcode, string cartonNo)
        {
            StockInId = stockInId;
            Barcode = barcode;
            CartonNo = cartonNo;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 附加到入库单中
        /// </summary>
        /// <param name="stockInId"></param>
        public void AttachToMaster(Guid stockInId)
        {
            StockInId = stockInId;
        }

        #endregion
    }
}
