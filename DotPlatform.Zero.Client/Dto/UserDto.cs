using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.AutoMapper;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Application.Services.Dto;

namespace DotPlatform.Zero.Client.Dto
{
    /// <summary>
    /// 用户 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserDto : IEntityDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 租户 Id，为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 租户对象
        /// </summary>
        public virtual Tenant Tenant { get; set; }

        /// <summary>
        /// 唯一的用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 获取密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 用户邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 最后登录时间（用户当前时间）
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 用户拥有的权限集合
        /// </summary>
        public virtual List<Role> Roles { get; set; }
    }
}
