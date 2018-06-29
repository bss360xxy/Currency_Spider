using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpSpiderMaster
{
    /// <summary>
    /// 任务总控制器  集成RunerBase  重写三个控制方法
    /// </summary>
    class TaskControllers : RunerBase
    {
        //定义任务接收  执行 结束对象
        TaskReceiver taskReceiver;
        TaskRuner taskRuner;
        TaskSender taskSender;
        public TaskControllers()
        {
            taskReceiver   = new TaskReceiver();
            taskRuner = new TaskRuner();
            taskSender = new TaskSender();
        }
        /// <summary>
        /// 重写启动方法
        /// </summary>
        public override void Start()
        {
            if(Statue!= RunerStatue.运行中)
            {
                taskReceiver.Start();
                taskRuner.Start();
                taskSender.Start();
            }
            else
            {
                Console.WriteLine("程序已经在运行了!");
            }
            
        }

        /// <summary>
        /// 重写暂停方法
        /// </summary>
        public override void Pause()
        {
            if (Statue != RunerStatue.运行中)
            {
                taskReceiver.Pause();
            }
            else
            {
                Console.WriteLine("程序未运行了!");
            }
        }
        /// <summary>
        /// 重写暂停方法
        /// </summary>
        public override void Stop()
        {
            if (Statue != RunerStatue.运行中)
            {
                taskReceiver.Stop();
                taskRuner.Stop();
                taskSender.Stop();
            }
            else
            {
                Console.WriteLine("程序未运行了!");
            }
        }
    }
}
