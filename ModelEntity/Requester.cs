using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
   public class Requester: RequestMustInfo
    {

    }

    /// <summary>
    /// 基本请求信息
    /// </summary>
    public class RequestMustInfo
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public String RequestUrl { set; get; } = String.Empty;
        /// <summary>
        /// 请求方式
        /// </summary>
        public String Method { set; get; } = String.Empty;



    }
}
