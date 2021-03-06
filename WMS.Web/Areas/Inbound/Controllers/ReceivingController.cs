﻿using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Extensions;
using WMS.Web.Client.Remote.Sfis;
using WMS.Web.Client.Models;
using WMS.DataTransferObject.Dtos;
using WMS.Application.Services;
using WMS.Web.Client.Remote.Sap;

namespace WMS.Web.Areas.Inbound.Controllers
{
    // 收货
    public class ReceivingController : BaseController
    {
        // GET: Inbound/Receiving
        public ActionResult Index()
        {
            return View();
        }

        // 收料
        [HttpPost]
        public JsonResult Receive(string qrcode, DateTime inboundDate, string remark)
        {
            try
            {
                var goodsResult = BuildStockIn(qrcode);
                if (!goodsResult.Item2)
                    return Json(false, goodsResult.Item3);

                var stockIn = goodsResult.Item1;
                stockIn.Applicant = User.Identity.Name;
                stockIn.Remark = remark;
                
                // 收料
                using (var service = IocResolver.Resolve<IInboundAppService>())
                {
                    if (service.ExistStockIn(stockIn.DocNo))
                        return Json(false, $"The inhouse no [{stockIn.DocNo}] already exists.");

                    service.CreateStockIn(stockIn);
                }

                // 过账
                string meterialDoc, errorMessage;
                if (SapClient.Post(stockIn.DocNo, stockIn.WipNo, stockIn.Plant, stockIn.PartNumber, stockIn.Quantity,
                    stockIn.DestPlant, stockIn.DestLocation, true, inboundDate, out meterialDoc, out errorMessage))
                {
                    using (var service = IocResolver.Resolve<IInboundAppService>())
                    {
                        var model = service.GetStockIn(stockIn.DocNo);
                        service.Post(model.Id, User.Identity.Name, inboundDate, meterialDoc, errorMessage);
                    }
                }
                else
                {
                    return Json(false, errorMessage);
                }

                return Json(true, meterialDoc);
            }
            catch
            {
                return Json(false, "Receive the stockin failure.");
            }
        }

        public JsonResult GetInboundInfo(string qrcode)
        {
            var goodsResult = BuildStockIn(qrcode);
            if (!goodsResult.Item2)
                return Json(false, goodsResult.Item3);

            return Json(true, goodsResult.Item1);
        }

        #region Private Methods

        private Tuple<StockInDto, bool, string> BuildStockIn(string qrcode)
        {
            StockInDto stockIn = null;

            // eg: CKB1;201637-L-0066;DSG8012PA;98993505010;12;CKH2;0000
            if (qrcode.IsNullOrEmpty())
                return Tuple.Create(stockIn, false, "The input QR Code is null or empty.");

            var infos = qrcode.SplitWithoutEmpty(';');
            var plant = infos[0];
            var inboundNo = infos[1];
            var wipNo = infos[2];
            var partNumber = infos[3];
            var expectedQty = infos[4].ToIntOrDefault();
            var destPlant = infos[5];
            var destLocation = infos[6];

            List<InhouseGoods> goods;
            string errorMsg = null;
            var client = new SfisServiceClient();
            if (!client.GetSfisRv(inboundNo, plant, out goods, out errorMsg))
                return Tuple.Create(stockIn, false, errorMsg);

            if (goods.Count != expectedQty)
                return Tuple.Create(stockIn, false, "The input qty not equal to actual qty.");

            stockIn = ConvertToStockIn(goods, destPlant, destLocation);

            return Tuple.Create(stockIn, true, (string)null);
        }

        private StockInDto ConvertToStockIn(List<InhouseGoods> goods, string destPlant, string destLocation)
        {
            var good = goods.First();

            return new StockInDto
            {
                DocNo = good.INHOUSE_NO,
                Plant = good.WERKS,
                WipNo = good.WIP_NO,
                PartNumber = good.ITEM_NO,
                Quantity = goods.Count,
                DestPlant = destPlant,
                DestLocation = destLocation,
                StockInLines = goods.Select(g => new StockInLineDto { Barcode = g.BARCODE_NO, CartonNo = g.BOX_NO }).ToList()
            };
        }

        #endregion
    }
}