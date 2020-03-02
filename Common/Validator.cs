using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Validator
    {
        /// <summary>
        /// 验证整数
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsInteger(string input)
        {
            int i = 0;
            if (int.TryParse(input, out i))
                return true;
            else
                return false;
        }
    }
}
