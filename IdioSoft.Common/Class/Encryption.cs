using System;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Text;

namespace IdioSoft.Common.Class
{
    public static class Encryption
    {
        /// <summary>
        /// 默认值是系统账号加密用
        /// </summary>
        private static string _AESKey = "93786789020961578902763098090129";
        public static string AESKey
        {
            get
            {
                return _AESKey;
            }
            set { _AESKey = value; }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <param name="AESKey"></param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt)
        {
            if (AESKey == "")
            {
                AESKey = System.Configuration.ConfigurationManager.AppSettings["AESKey"].ToString();
            }
            if (toDecrypt == "")
            {
                return "";
            }
            try
            {
                // 256-AES key
                string keys = AESKey;
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(keys);
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (System.Exception ex)
            {

            }
            return "";
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="AESKey"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            if (AESKey == "")
            {
                AESKey = System.Configuration.ConfigurationManager.AppSettings["AESKey"].ToString();
            }
            if (toEncrypt == "")
            {
                return "";
            }
            // 256-AES key    
            string keys = AESKey;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(keys);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

    }
}
