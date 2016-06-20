﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotPlatform.Algorithms.Cryptography
{
    /// <summary>
    /// AES (Advanced Encryption Standard) Rijndael 对称加密
    /// </summary>
    public sealed class AESCrypto : Crypto
    {
        private static readonly Encoding encoding = Encoding.UTF8;   // 编码方式与加密时相同

        internal AESCrypto()
        {
        }

        public override string Encrypt(string encryptString)
        {
            return Encrypt(encryptString, this.ScrambledKey);
        }

        public override string Decrypt(string decryptString)
        {
            return Decrypt(decryptString, this.ScrambledKey);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="scrambledKey">对称秘钥</param>
        /// <returns>加密后的字符串，以 Base64 位输出</returns>
        public static string Encrypt(string encryptString, string scrambledKey)
        {
            var secretkey = GenerateSecretkey(scrambledKey);
            return Encrypt(encryptString, secretkey.Item1, secretkey.Item2);
        }

        private static string Encrypt(string encryptString, byte[] key, byte[] iv)
        {
            var datas = encoding.GetBytes(encryptString);

            using (var aes = Aes.Create())
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                cryptoStream.Write(datas, 0, datas.Length);
                cryptoStream.FlushFinalBlock();

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="scrambledKey">对称秘钥</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string decryptString, string scrambledKey)
        {
            var secretkey = GenerateSecretkey(scrambledKey);
            return Decrypt(decryptString, secretkey.Item1, secretkey.Item2);
        }

        private static string Decrypt(string decryptString, byte[] key, byte[] iv)
        {
            var datas = Convert.FromBase64String(decryptString);

            using (var aes = Aes.Create())
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Write))
            {
                cryptoStream.Write(datas, 0, datas.Length);
                cryptoStream.FlushFinalBlock();
                return encoding.GetString(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// 生成秘钥
        /// Item1: Key; Item2: IV
        /// </summary>
        /// <param name="scrambledKey"></param>
        /// <returns></returns>
        private static Tuple<byte[], byte[]> GenerateSecretkey(string scrambledKey)
        {
            using (var sha256 = SHA256.Create())
            using (var md5 = MD5.Create())
            {
                var key = sha256.ComputeHash(Encoding.UTF8.GetBytes(scrambledKey));
                var iv = md5.ComputeHash(Encoding.UTF8.GetBytes(scrambledKey));

                return Tuple.Create(key, iv);
            }
        }
    }
}
