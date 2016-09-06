using System;
using DotPlatform.Application.Services.Dto;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 用户 DTO 对象
    /// </summary>
    public class UserDto : IDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// 获取密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取用户邮件
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 获取租户.为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取租户信息
        /// </summary>
        public TenantDto Tenant { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示用户是否已被删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
