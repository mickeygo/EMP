using DotPlatform.Domain.Entities;

namespace DotPlatform.Notifications
{
    /// <summary>
    /// 通知消息。用于广播消息
    /// </summary>
    public class MessageNotification : Entity
    {
        /// <summary>
        /// 通知消息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public Notification Notification { get; set; }


        protected MessageNotification()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="MessageNotification"/>对象
        /// </summary>
        /// <param name="message">通知消息</param>
        public MessageNotification(string message)
        {
            Message = message;
        }
    }
}
