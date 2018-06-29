using System;
using System.Collections.Generic;

namespace ModelEntity
{
    /// <summary>
    /// 子任务实体
    /// </summary>
    public class ChildTask
    {
        /// <summary>
        /// 子任务id
        /// </summary>
        public String childid { get; set; } = String.Empty;
        /// <summary>
        /// 请求类型
        /// </summary>
        public RequestType requesttype { get; set; } = RequestType.MiddleRequest;
        /// <summary>
        /// 校验类型
        /// </summary>
        public MatchType checktype { get; set; } = MatchType.RegMatch;
        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<String, HttpHeadInfo>  httpheads { get; set; } = new  Dictionary<string, HttpHeadInfo>();
        /// <summary>
        /// 代理信息
        /// </summary>
        public ProxyInfo proxy { get; set; } = new ProxyInfo();
        /// <summary>
        /// 请求控制器
        /// </summary>
        public RequetController requetcontroller { get; set; } = new RequetController();
        /// <summary>
        /// 校验规则
        /// </summary>
        public String checkrule { get; set; } = String.Empty;
    }

    public class RequetController
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public int timeout { get; set; } = 10000;
        /// <summary>
        /// 读写超时时间
        /// </summary>
        public int readwritetimeout { get; set; } = 10000;
        //是否开启缓冲
        public bool bufferenable { get; set; } = false;
        /// <summary>
        /// 重试次数
        /// </summary>
        public int reptime { get; set; } = 10;
    }

    public class ProxyInfo
    {
        public ProxyMode proxymode = ProxyMode.None;
        public List<String>  apis { get; set; } = new List<String>();
        public String ip { get; set; } = String.Empty;
        public String proxy_username { get; set; } = String.Empty;
        public String proxy_password { get; set; } = String.Empty;
    }

    public class HttpHeadInfo
    {
        /// <summary>
        /// 请求头来源
        /// </summary>
        public HttpHeadFrom httpheadfrom { get; set; } = HttpHeadFrom.Set;
        /// <summary>
        /// 请求头名称
        /// </summary>
        public String headname { get; set; } = String.Empty;
        /// <summary>
        /// 请求头校验类型
        /// </summary>
        public MatchType checktype { get; set; } = MatchType.RegMatch;
        /// <summary>
        /// 参考id
        /// </summary>
        public String referid  { get; set; } = String.Empty;
        /// <summary>
        /// 头参数抽取规则
        /// </summary>
        public String headrule { get; set; } = String.Empty;

    }
}