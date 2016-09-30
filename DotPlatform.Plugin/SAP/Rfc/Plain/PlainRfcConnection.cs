namespace DotPlatform.Plugin.SAP.Rfc.Plain
{
    /// <summary>
    /// Plain Rfc 连接的实现
    /// </summary>
    public class PlainRfcConnection : RfcConnection, IRfcConnection
    {
        public PlainRfcConnection(string connectionString) : base(connectionString)
        {

        }

        public override IRfcCommand CreateCommand()
        {
            return new PlainRfcCommand(this);
        }
    }
}
