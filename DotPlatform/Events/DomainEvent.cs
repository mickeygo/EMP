﻿using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Events
{
    /// <summary>
    /// 领域事件基类。领域事件涉及到领域实体的操作。
    /// </summary>
    [Serializable]
    public abstract class DomainEvent : IDomainEvent
    {
        #region Properties

        /// <summary>
        /// 获取事件 Id
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// 获取事件源
        /// </summary>
        public IEntity Source { get; private set; }

        /// <summary>
        /// 获取事件产生的时间
        /// </summary>
        public DateTimeOffset TimeStamp { get; protected set; }

        /// <summary>
        /// 获取事件的版本号
        /// </summary>
        public int Version { get; protected set; }

        #endregion

        #region Ctor

        protected DomainEvent(IEntity entity)
        {
            this.Source = entity;
        }

        #endregion
    }
}