using System;
using SAP.Middleware.Connector;
using DotPlatform.Plugin.SAP.Rfc.Exceptions;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 连接基类
    /// </summary>
    public abstract class RfcConnection : IRfcConnection
    {
        private readonly string _connectionString;
        private RfcDestination _destination;

        /// <summary>
        /// 获取一个<see cref="bool"/>，表示 RFC 连接是否已开启
        /// </summary>
        public bool IsOpen { get; private set; }

        public IRfcProvider RfcProvider
        {
            get { return new RfcProvider(_destination); }
        }

        /// <summary>
        /// 初始化一个新的<see cref="RfcConnection"/>实例
        /// </summary>
        /// <param name="connectionString">
        /// 使用字符串，如 "NAME=Test;USER=bcuser;PASSWD=sapadmin2;CLIENT=001;LANG=EN;ASHOST=sap-vm;SYSNR=00"
        /// </param>
        protected RfcConnection(string connectionString)
        {
            _connectionString = connectionString;
            EnsureConnectionIsOpen();
        }

        public abstract IRfcCommand CreateCommand();

        public virtual void Close()
        {
            IsOpen = false;
        }

        public void Dispose()
        {
            Close();
        }

        #region Private Methods

        private void EnsureConnectionIsOpen()
        {
            if (!IsOpen)
            {
                try
                {
                    var configParameters = ConvertStringToConfigParameters(_connectionString);
                    _destination = RfcDestinationManager.GetDestination(configParameters);
                    IsOpen = true;
                }
                catch (Exception ex)
                {
                    throw new RfcConnectionException("Could not connect to SAP.", ex);
                }
            }
        }

        private RfcConfigParameters ConvertStringToConfigParameters(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var rfcConfigParameters = new RfcConfigParameters();
            foreach (var param in connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var keyValue = param.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var key = keyValue[0].Trim().ToUpper();
                var value = keyValue[1].Trim();

                if (!rfcConfigParameters.ContainsKey(key))
                    rfcConfigParameters.Add(key, value);
            }

            return rfcConfigParameters;
        }

        #endregion
    }
}
