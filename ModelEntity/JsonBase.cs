namespace ModelEntity
{
    /// <summary>
    /// Json对象基类
    /// </summary>
    public class JsonBase
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string code { set; get; } = string.Empty;
        /// <summary>
        /// 消息
        /// </summary>
        public string message { set; get } = string.Empty;
    }
}