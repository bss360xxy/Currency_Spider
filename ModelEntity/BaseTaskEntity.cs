using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    /// <summary>
    /// 请求类型
    /// </summary>
    public enum RequestType { MiddleRequest=0,StopRequest=1}
    /// <summary>
    /// 校验类型
    /// </summary>
    public enum MatchType { CharMatch=0,RegMatch=1, XPathMatch = 2 }
    /// <summary>
    /// 代理模式
    /// </summary>
    public enum ProxyMode {None=0, IP=1,API }
    /// <summary>
    /// HTTTP请求头来源 Set 预设 Self 从本次请求中获得  Middle 从中间请求中获得
    /// </summary>
    public enum HttpHeadFrom { Set=0, Middle  }

    /// <summary>
    /// 任务实体基类
    /// </summary>
    public class BaseTaskEntity:TaskJsonBase
    {
        public List<ChildTask> taskid { set; get; } = new List<ChildTask>();

    }
}
