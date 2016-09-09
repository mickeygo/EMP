namespace WMS.Domain.Models.Warehouses
{
    public class TickSetting
    {
        /// <summary>
        /// X 轴上起始刻度
        /// </summary>
        public int XTickFrom { get; }

        /// <summary>
        /// X 轴上目标刻度
        /// </summary>
        public int XTickTo { get; }

        /// <summary>
        /// Y 轴上起始刻度
        /// </summary>
        public int YTickFrom { get; }

        /// <summary>
        /// Y 轴上目标刻度
        /// </summary>
        public int YTickTo { get; }

        /// <summary>
        /// 初始化一个新的<see cref="TickSetting"/>实例
        /// </summary>
        /// <param name="xTickFrom">X 轴上起始刻度</param>
        /// <param name="xTickTo">X 轴上目标刻度</param>
        /// <param name="yTickFrom">Y 轴上起始刻度</param>
        /// <param name="yTickTo">Y 轴上目标刻度</param>
        public TickSetting(int xTickFrom, int xTickTo, int yTickFrom, int yTickTo)
        {
            XTickFrom = xTickFrom;
            XTickTo = xTickTo;
            YTickFrom = yTickFrom;
            YTickTo = yTickTo;
        }
    }
}
