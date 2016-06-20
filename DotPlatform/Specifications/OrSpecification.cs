﻿using System;
using System.Linq.Expressions;

namespace DotPlatform.Specifications
{
    /// <summary>
    /// 表示一个结合的规约满足给定对象规约中的一个或全部
    /// </summary>
    /// <typeparam name="T">应用规约的对象类型</typeparam>
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        /// <summary>
        /// 初始化规约对象
        /// </summary>
        /// <param name="left">第一个规约</param>
        /// <param name="right">第二个规约</param>
        public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        { }

        /// <summary>
        /// 获取当前规约的 LINQ 表达式
        /// </summary>
        /// <returns>LINQ 表达式</returns>
        public override Expression<Func<T, bool>> GetExpression()
        {
            return this.Left.GetExpression().Or(this.Right.GetExpression());
        }
    }
}
