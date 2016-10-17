using System;
using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc.Plain
{
    /// <summary>
    /// Plain Rfc Command
    /// </summary>
    public class PlainRfcCommand : RfcCommand
    {
        public PlainRfcCommand(IRfcConnection rfcConnection) : base(rfcConnection)
        {
        }

        protected override IRfcResult ReturnResult(IRfcFunction function)
        {
            return new PlainRfcResult(function, new PlainRfcStructureMapper(new PlainRfcValueMapper()));
        }
    }
}
