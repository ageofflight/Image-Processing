﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

namespace OpenImage
{
    class HiPerfTimer
    {
        //引用win32 API中的QueryPerformanceCounter()方法
        //该方法用来查询任意时刻高精度计数器的实际值
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        //引用Win32 API中的QueryPerformanceFrequency()方法
        //该方法返回高精度计数器每秒的计数值
        [DllImport("kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long startTime, stopTime;
        private long freq;

        //构造函数
        public HiPerfTimer()
        {
            startTime = 0;
            stopTime = 0;

            if(QueryPerformanceFrequency(out freq)==false)
            {
                //不支持高性能计数器
                throw new Win32Exception();
            }
        }

        //开始计时
        public void Start()
        {
            //让等待线程工作
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);
        }

        //结束计时
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }

        //返回计时结果(ms)
        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) * 1000 / (double)freq;
            }
        }
    }
}
