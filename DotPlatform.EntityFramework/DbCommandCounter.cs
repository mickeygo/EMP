namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// DB 计数器， 记录某一次 DbContext 操作中外部执行的 Add、Update 和 Delete 数目
    /// </summary>
    public class DbCommandCounter
    {
        /// <summary>
        /// Add Command 计数器
        /// </summary>
        public int AddCounter { get; private set; }

        /// <summary>
        /// Update Command 计数器
        /// </summary>
        public int UpdateCounter { get; private set; }

        /// <summary>
        /// Delete Command 计数器
        /// </summary>
        public int DeleteCounter { get; private set; }

        /// <summary>
        /// Add Command 自增
        /// </summary>
        internal void AddIncrease()
        {
            AddCounter++;
        }

        /// <summary>
        /// Update Command 自增
        /// </summary>
        internal void UpdateIncrease()
        {
            UpdateCounter++;
        }

        /// <summary>
        /// Delete Command 自增
        /// </summary>
        internal void DeleteIncrease()
        {
            DeleteCounter++;
        }

        /// <summary>
        /// 重置所有的计数器
        /// </summary>
        internal void Reset()
        {
            AddCounter = 0;
            UpdateCounter = 0;
            DeleteCounter = 0;
        }

        /// <summary>
        /// 当前 DbContext 是否有执行过任何 Command 命令操作
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return AddCounter > 0 || UpdateCounter > 0 || DeleteCounter > 0;
        }

        /// <summary>
        /// Override, 显示 Add、Update 和 Delete 计数器的数目
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"AddCounter: {AddCounter}; UpdateCounter: {UpdateCounter}; DeleteCounter: {DeleteCounter}";
        }
    }
}
