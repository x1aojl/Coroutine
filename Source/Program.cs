// Program.cs
// Created by xiaojl Feb/04/2021
// 协程测试

using System;
using System.Collections;
using Coroutine;

class Program
{
    static void Main(string[] args)
    {
        // 启动测试协程
        CoroutineManager.Instance.StartCoroutine(Test());

        // 当前时间，单位毫秒
        long time = DateTime.Now.Ticks / 10000;

        while (true)
        {
            // 当前帧的时间戳
            long now = DateTime.Now.Ticks / 10000;

            // 与上一帧的时间间隔
            int deltaTime = (int)(now - time);

            // 帧驱动
            CoroutineManager.Instance.OnTimeElapsed(deltaTime);
            time = now;
        }
    }

    // 每隔1秒打印1次
    static IEnumerator Test()
    {
        // 第1秒
        yield return new TimeWaiter(1000);
        Console.WriteLine("1");

        // 第2秒
        yield return new TimeWaiter(1000);
        Console.WriteLine("2");

        // 第3秒
        yield return new TimeWaiter(1000);
        Console.WriteLine("3");
    }
}
