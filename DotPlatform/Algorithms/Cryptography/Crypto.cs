﻿namespace DotPlatform.Algorithms.Cryptography
{
    /// <summary>
    /// 加密基础类
    /// </summary>
    public abstract class Crypto
    {
        private const string scrambledKey = "dotplatform";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public abstract string Encrypt(string encryptString);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public abstract string Decrypt(string decryptString);

        /// <summary>
        /// 获取默认的秘钥
        /// </summary>
        protected virtual string ScrambledKey
        {
            get { return scrambledKey; }
        }
    }
}
