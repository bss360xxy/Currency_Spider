namespace ModelEntity
{
    /// <summary>
    /// 任务json基类
    /// </summary>
    public class TaskJsonBase:JsonBase
    {
        public string guid { set; get; } = string.Empty;
    }
}