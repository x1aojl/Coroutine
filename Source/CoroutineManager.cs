// CoroutineManager.cs
// Created by xiaojl Feb/04/2021
// 协程管理器

using System.Collections;
using System.Collections.Generic;

namespace Coroutine
{
    public class CoroutineManager
    {
        // 单例
        public static CoroutineManager Instance = new CoroutineManager();

        // 所有协程
        private List<Coroutine> coroutineLst = new List<Coroutine>();

        // 完成列表
        private List<Coroutine> finishedLst = new List<Coroutine>();

        // 启动一个协程
        public Coroutine StartCoroutine(IEnumerator e)
        {
            Coroutine co = new Coroutine(e);
            coroutineLst.Add(co);
            return co;
        }

        // 终止一个协程
        public void Stop(Coroutine co)
        {
            coroutineLst.Remove(co);
        }

        // 推动所有协程
        public void OnTimeElapsed(int timeElapsed)
        {
            finishedLst.Clear();

            // 推动每个协程
            Coroutine[] lst = coroutineLst.ToArray();
            foreach(Coroutine co in lst)
            {
                if (finishedLst.Contains(co))
                    continue;

                if (co.Finished)
                    finishedLst.Add(co);
                else
                    co.Next(timeElapsed);
            }

            // 移除已完成的迭代器
            foreach (Coroutine co in finishedLst)
                coroutineLst.Remove(co);
        }
    }
}
