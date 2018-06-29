using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public enum RunerStatue { 未启动 = 0, 暂停, 运行中 }
    /// <summary>
    /// 启动器抽象基类
    /// </summary>
    public abstract class RunerBase
    {
        #region 全局变量区
        /// <summary>
        /// 是否正在运行
        /// </summary>
        public  RunerStatue Statue = RunerStatue.未启动;
        #endregion


        /// <summary>
        /// 启动
        /// </summary>
        public virtual void Start()
        {
            Statue = RunerStatue.运行中;
            Console.WriteLine("抽象基类启动方法");

        }
        /// <summary>
        /// 暂停
        /// </summary>
        public virtual void Pause()
        {
            Statue = RunerStatue.暂停;
            Console.WriteLine("抽象基类暂停方法");
        }
        /// <summary>
        /// 停止
        /// </summary>
        public virtual void Stop()
        {
            Statue = RunerStatue.未启动;
            Console.WriteLine("抽象基类停止方法");
        }

        public object ConfigConvert(String name,object value)
        {
            object v = new object();
            try
            {
                v =  LocalStorage.Config_Dic["Receive_Task_Url"] ?? "5000";
            }
            catch (Exception)
            {

                throw;
            }
            return  
        }
    }
}
