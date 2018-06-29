using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpSpiderMaster
{
    /// <summary>
    /// 任务接收
    /// </summary>
   public class TaskReceiver : RunerBase
    {
        #region 默认配置
        int Receive_Delay = 5000;
        String Receive_Task_Url = "http://127.0.0.1";
        int Receive_Thread = 1;
        #endregion

        #region 预声明
        Task task;
        #endregion

        public TaskReceiver()
        {
            Receive_Delay = ConfigConvert(nameof(Receive_Delay),Receive_Delay); 
            Receive_Task_Url = ConfigConvert(nameof(Receive_Task_Url), Receive_Task_Url);
            Receive_Delay = ConfigConvert(nameof(Receive_Delay), Receive_Delay);
        }
        /// <summary>
        /// 重写启动方法
        /// </summary>
        public override void Start()
        {
            if (Statue == RunerStatue.运行中)
            {
                task =  Task.Run(()=> { RunerStartFunc(); });
            }
            else
            {
                Console.WriteLine("任务接收模块已经启动或暂停!");
            }
        }

        private void RunerStartFunc()
        {
            while(Statue == RunerStatue.运行中)
            {
                //这里写获取任务代码

                //这里写任务数据校验代码

                Thread.Sleep(Receive_Delay);
            }
        }
    }
}
