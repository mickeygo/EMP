namespace DotPlatform.Application.Services
{
    /// <summary>
    /// 作为应用服务的基类
    /// </summary>
    public abstract class ApplicationService : IApplicationService
    {
        private bool isDisposed;

        /// <summary>
        /// 在此设置，可用于关闭与 DB 的连接并释放资源
        /// </summary>
        protected virtual void Close()
        {

        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                Close();

                isDisposed = true;
            }
        }
    }
}
