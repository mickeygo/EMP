using System;
using DotPlatform.Application.Services;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.Tests.SampleApplication.Application
{
    /// <summary>
    /// 产品应用服务
    /// </summary>
    public interface IProductAppService : IApplicationService
    {
        /// <summary>
        /// 获取
        /// </summary>
        Product Get(Guid productId);

        /// <summary>
        /// 创建
        /// </summary>
        void Create(Product product);

        /// <summary>
        /// 更新
        /// </summary>
        void Update(Product product);

        /// <summary>
        /// 删除
        /// </summary>
        void Delete(Guid productId);
    }
}
