using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessager
{
    class INIWorker
    {

        #region 读取INI
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retVal">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>所要读取的信息字符串</returns>
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath
        );

        /// <summary>
        /// 读取INI方法
        /// </summary>
        /// <param name="path">INI文件路径</param>
        /// <param name="name">INI文件名</param>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <returns>所要读取的信息字符串</returns>
        public static string ReadINI(string path, string name, string section, string key)
        {
            string fullPath = "";
            if ((path != "null" || path != "") && (name != "null" || name != ""))
            {
                fullPath = path + name;
            }
            StringBuilder temp = new StringBuilder(4096);
            GetPrivateProfileString(section, key, Main.def, temp, 4096, fullPath);
            return temp.ToString();
        }
        #endregion

        #region 写入INI
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">INI节点名称</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns>若为0则表示失败，反之成功</returns>
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string val,
            string filePath
         );

        /// <summary>
        /// 写入INI方法
        /// </summary>
        /// <param name="path">INI文件路径</param>
        /// <param name="name">INI文件名</param>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        public static void WriteINI(string path, string name, string section, string key, string val)
        {
            string fullPath = "";

            if ((path != "null" || path != "") && (name != "null" || name != ""))
            {
                fullPath = path + name;
            }
            WritePrivateProfileString(section, key, val, fullPath);
        }
        #endregion
    }
}
