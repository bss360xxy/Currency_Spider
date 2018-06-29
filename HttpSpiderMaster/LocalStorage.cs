using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpSpiderMaster
{
    //本地存储
    public class LocalStorage
    {
        /// <summary>
        /// 配置字典
        /// </summary>
        public static Dictionary<String, String> Config_Dic { set; get; } = new Dictionary<string, string>();
    }
}
