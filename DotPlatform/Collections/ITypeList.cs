﻿using System;
using System.Collections.Generic;

namespace DotPlatform.Collections
{
    /// <summary>
    /// A shortcut for <see cref="ITypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public interface ITypeList<in TBaseType> : IList<Type>
    {
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// Checks if a type exists in the list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// Removes a type from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : TBaseType;
    }

    /// <summary>
    /// Extends <see cref="IList{Type}"/> to add restriction a specific base type.
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {

    }
}
