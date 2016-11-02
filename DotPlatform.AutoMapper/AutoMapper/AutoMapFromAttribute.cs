using System;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 映射关系源
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public class AutoMapFromAttribute : AutoMapAttribute
    {
        internal override AutoMapDirection Direction
        {
            get { return AutoMapDirection.From; }
        }

        public AutoMapFromAttribute(params Type[] targetTypes) : base(targetTypes)
        {

        }
    }
}
