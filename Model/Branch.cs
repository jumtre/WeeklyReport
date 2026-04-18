using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 分支
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 工作目录
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// 显示值
        /// </summary>
        public string Display
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Memo))
                    return this.Name;
                else
                    return this.Name + "【" + this.Memo + "】";
            }
        }

        /// <summary>
        /// 项目
        /// </summary>
        public Project Project { get; set; }
    }
}
