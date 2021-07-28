using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IniHelper
    {
        //[section]
        //key=value

        /// <summary>
        /// ini文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 内容缓冲区大小，默认512
        /// </summary>
        public int BufferSize { get; set; } = 512;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="defaultValue">读取异常时的默认值</param>
        /// <param name="returnValue">读取的键对应的值，如果该键不存在则返回空值</param>
        /// <param name="size">内容缓冲区大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="defaultValue">读取异常时的默认值</param>
        /// <param name="returnValue">读取的键对应的值，如果该键不存在则返回空值</param>
        /// <param name="size">内容缓冲区大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string defaultValue, Byte[] returnValue, int size, string filePath);

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="section">要写入的段落名</param>
        /// <param name="key">要写入的键，如果该键存在则覆盖</param>
        /// <param name="value">写入的键对应的值</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        public IniHelper(string IniPath = null)
        {
            SetIniFilePath(IniPath);
        }

        /// <summary>
        /// 设置ini文件路径
        /// </summary>
        /// <param name="filePath">ini文件路径</param>
        public void SetIniFilePath(string filePath = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Settings.ini";
            else
                FilePath = filePath;
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
                //throw new FileNotFoundException("配置文件不存在");
            }
        }

        /// <summary>
        /// 读取值
        /// </summary>
        /// <param name="section">要读取的键值所在段落</param>
        /// <param name="key">要读取值的键</param>
        /// <returns>读取到的键值</returns>
        public string Read(string section, string key)
        {
            StringBuilder value = new StringBuilder();
            GetPrivateProfileString(section, key, null, value, BufferSize, FilePath);
            return value.ToString();
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="section">要写入的键值所在段落</param>
        /// <param name="key">要写入值的键</param>
        /// <param name="value">要写入的值</param>
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, FilePath);
        }

        /// <summary>
        /// 删除所有段落
        /// </summary>
        public void DeleteAllSections()
        {
            Write(null, null, null);
        }

        /// <summary>
        /// 删除段落
        /// </summary>
        /// <param name="section">要删除的段落</param>
        public void DeleteSection(string section)
        {
            Write(section, null, null);
        }

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="section">要删除的键所在段落</param>
        /// <param name="key">要删除的键</param>
        public void DeleteKey(string section, string key)
        {
            Write(section, key, null);
        }

        /// <summary>
        /// 键是否存在
        /// </summary>
        /// <param name="section">要判断的键所在段落</param>
        /// <param name="key">要判断的键</param>
        /// <returns>键是否存在</returns>
        public bool KeyExists(string section, string key)
        {
            return !string.IsNullOrWhiteSpace(Read(section, key));
        }
    }
}
