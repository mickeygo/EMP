using System;

namespace DotPlatform.Application.Services.Dto
{
    /// <summary>
    /// 实体 DTO 对象
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IEntityDto<TKey> : IDto
    {
        TKey Id { get; set; }
    }

    /// <summary>
    /// 实体 DTO 对象。主键为 <see cref="Guid"/>
    /// </summary>
    public interface IEntityDto : IEntityDto<Guid>
    {
    }
}
