using System;
using DotPlatform.Application.Services.Dto;
using DotPlatform.AutoMapper;
using DotPlatform.RBAC.Domain.Models.Tenants;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 租户 DTO 对象
    /// </summary>
    [AutoMapFrom(typeof(RbacTenant))]
    public class TenantDto : IEntityDto
    {
        /// <summary>
        /// 获取或设置租户 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置租户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置租户的显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置租户描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置租户所在区域的时差
        /// </summary>
        public int TimeDifference { get; set; }

        /// <summary>
        /// 获取或设置租户的语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示菜单是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示租户是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
