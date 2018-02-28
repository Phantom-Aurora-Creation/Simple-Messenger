using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessager
{
    class Messager
    {
        #region 消息的拼接
        /// <summary>
        /// 把参数拼接成一条完整的消息
        /// </summary>
        /// <param name="type">消息类型</param>
        /// <param name="name">发送者</param>
        /// <param name="msg">消息内容</param>
        /// <returns>完整的普通消息</returns>
        public static string MessageMaker(MsgType type, string name, string msg)
        {
            string strOut = "{{\"type\":\"" + type + "\", \"name\":\"" + name + "\", \"msg\":\"" + msg + "\"}}";
            return strOut;
        }

        /// <summary>
        /// 把参数拼接成一条完整的握手消息
        /// </summary>
        /// <param name="type">此处只能为MsgType.Handshake</param>
        /// <param name="name">发送端</param>
        /// <param name="pw">授权码</param>
        /// <returns>完整的握手消息</returns>
        public static string MessageMaker(MsgType type, SendName name, string pw)
        {
            string strOut = "{{\"type\":\"Handshake\", \"name\":\"" + name + "\", \"msg\":\"" + SHA512(pw) + "\"}}";
            return strOut;
        }
        #endregion

        #region 消息类型的枚举
        /// <summary>
        /// 消息类型
        /// </summary>
        public enum MsgType
        {
            Handshake, 
            Minecraft, 
            QQ, 
            Command, 
            Error
        };

        /// <summary>
        /// 握手消息发送端类型
        /// </summary>
        public enum SendName
        {
            QQ,
            Plugin,
            MCMOD,
            Console
        };
        #endregion 

        #region  SHA256加密算法
        /// <summary>
        /// SHA256函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>SHA512结果(返回长度为44字节的字符串)</returns>
        public static string SHA512(string str)
        {
            byte[] SHA512Data = Encoding.Default.GetBytes(str);
            SHA512Managed SHA512 = new SHA512Managed();
            byte[] Result = SHA512.ComputeHash(SHA512Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }
        #endregion
    }
}
