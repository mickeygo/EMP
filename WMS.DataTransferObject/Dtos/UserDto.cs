using System;
using DotPlatform.Application.Services.Dto;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.AutoMapper;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 用户 DTO 对象
    /// </summary>
    [AutoMapFrom(typeof(RbacUser))]
    public class UserDto : IEntityDto
    {
        /// <summary>
        /// 获取或设置用户 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置用户邮件
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 获取或设置用户工号
        /// </summary>
        public string EmployeeNo { get; set; }

        /// <summary>
        /// 获取或设置用户英文名
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// 获取或设置用户本地名
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// 获取或设置用户组织
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 获取或设置用户部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 获取或设置用户职位
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// 获取或设置用户电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 获取或设置用户分机
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 获取或设置租户.为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取用户所在的租户信息
        /// </summary>
        public TenantDto Tenant { get; private set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示用户是否已被删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
    }
}
