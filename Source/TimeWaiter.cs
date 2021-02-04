// TimeWaiter.cs
// Created by xiaojl Feb/04/2021
// 协程等待器

namespace Coroutine
{
    // 协程时间等待
    public class TimeWaiter
    {
        // 剩余等待时间
        public int time = 0;

        // 构造器，指明等待时间（单位 ms）
        public TimeWaiter(int time)
        {
            this.time = time;
        }
    }
}
