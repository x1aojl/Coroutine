// Coroutine.cs
// Created by xiaojl Feb/04/2021
// 协程

using System.Collections;

namespace Coroutine
{
    public class Coroutine
    {
        // 要执行的迭代器
        private IEnumerator e;

        // 结束标记
        private bool finished;

        // 构造器，需要提供对应的迭代器
        public Coroutine(IEnumerator e)
        {
            this.e = e;
            finished = false;
        }

        // 推动协程
        public void Next(int timeElapsed)
        {
            object obj = e.Current;
            if ((obj is TimeWaiter) && ((TimeWaiter)obj).time > 0)
                // 时间等待
                ((TimeWaiter)obj).time -= timeElapsed;
            else if ((obj is Coroutine) && !((Coroutine)obj).Finished)
                // 如果还有子协程，则先等子协程处理完
                return;
            else
                finished = !e.MoveNext();
        }

        // 协程是否已经结束
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
    }
}
