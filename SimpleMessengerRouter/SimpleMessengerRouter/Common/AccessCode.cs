using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerRouter.Common
{
    class AccessCode
    {
        /// <summary>
        /// 获取授权码
        /// </summary>
        /// <param name="Password">密码</param>
        /// <returns>授权码</returns>
        public static string GetAccessCode(string Password)
        {
            return "SMV9AC0D" + MD5(MD5(Password) + Time());
        }

        public static string MD5(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(strText));
            return Encoding.Default.GetString(result);
        }

        public static string Time()
        {
            string str = DateTime.Now.ToString("yyyyMMddHHmm");
            return str;
        }
    }
}
