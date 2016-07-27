using DotPlatform.Utils;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// <see cref="object"/>对象扩展类
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 将对象转换为动态类型
        /// </summary>
        /// <param name="o">要转换的对象实例</param>
        /// <returns></returns>
        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }
    }
}
