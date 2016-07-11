using System;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 映射关系目标
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AutoMapToAttribute : AutoMapAttribute
    {
        internal override AutoMapDirection Direction
        {
            get { return AutoMapDirection.To; }
        }

        public AutoMapToAttribute(params Type[] targetTypes) : base(targetTypes)
        {

        }
    }
}
