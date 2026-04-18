using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Git日志
    /// </summary>
    public class GitLog
    {
        /// <summary>
        /// 日志Hash值
        /// </summary>
        public string Commit { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Author))
                    return string.Empty;
                return Author.Split(' ')[0];
            }
        }

        /// <summary>
        /// 作者邮件地址
        /// </summary>
        public string AuthorMail
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Author))
                    return string.Empty;
                return Author.Split(' ')[1].TrimStart('<').TrimEnd('>');
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
