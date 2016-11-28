using System;
using System.Collections.Generic;
using DotPlatform.Extensions;

namespace DotPlatform.Notifications
{
    /// <summary>
    /// 用于存储通知数据
    /// </summary>
    [Serializable]
    public class NotificationData
    {
        /// <summary>
        /// 获取通知的数据类型，返回 full class name
        /// </summary>
        public virtual string Type
        {
            get { return GetType().FullName; }
        }

        /// <summary>
        /// Shortcut to set/get <see cref="Properties"/>.
        /// </summary>
        public object this[string key]
        {
            get { return Properties[key]; }
            set { Properties[key] = value; }
        }

        /// <summary>
        /// 用于向通知中添加自定义属性
        /// </summary>
        public Dictionary<string, object> Properties
        {
            get { return _properties; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _properties = value;
            }
        }
        private Dictionary<string, object> _properties;

        /// <summary>
        /// 初始化一个新的<see cref="NotificationData"/>实例
        /// </summary>
        public NotificationData()
        {
            Properties = new Dictionary<string, object>();
        }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}
