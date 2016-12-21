using System;

namespace DotPlatform
{
    /// <summary>
    /// Name 与 Value 对应关系，多对多对应
    /// </summary>
    [Serializable]
    public class NameValue<T>
    {
        public string Name { get; set; }

        public T Value { get; set; }

        public NameValue()
        {

        }
        
        public NameValue(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }
    }

    /// <summary>
    /// Name 与 Value 对应关系，多对多对应
    /// </summary>
    [Serializable]
    public class NameValue : NameValue<string>
    {
        public NameValue()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="NameValue"/>实例
        /// </summary>
        /// <param name="name">Name 值</param>
        /// <param name="value">Value 值</param>
        public NameValue(string name, string value) 
            : base(name, value)
        {

        }
    }
}
