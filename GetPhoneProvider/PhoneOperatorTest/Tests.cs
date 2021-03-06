﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
 
    using System.Diagnostics;
    using System.Linq;
    using GetPhoneOperator;
using System.Collections.Generic;

    [TestClass]
    public class ReverseWordsTests
    {
        logic logic = new logic(new Dictionary<int, string>() {
        {8063, "life"},
        {8098, "kievstar"},
        {8066, "mts"},
        {8091, "utel"},
        {8044, "ground line"}
        });

        [TestMethod]
        public void Test()
        {

            // Initialize
            var cases = new[] { 
              new {logic = logic, arg = 80634997252,  res = "life"},
              new {logic = logic, arg = 80984997252,  res = "kievstar"},
              new {logic = logic, arg = 80664997252,  res = "mts"},
              new {logic = logic, arg = 80914997252,  res = "utel"},
              new {logic = logic, arg = 80444997252,  res = "ground line"},
                };


            cases.ToList().ForEach((val) =>
            {
                Assert.AreEqual(val.res, val.logic.GetOperatorName(val.arg));
            });

        }

        [TestMethod]
        public void PerformanceTest()
        {
            RunWithMeasuring(() => { logic.GetOperatorName(80634997252); }, 100000);
        }

        public static void RunWithMeasuring(Action actionToRun, int runTimes)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < runTimes; i++)
            {
                actionToRun();
            }
            
            
            sw.Stop();

            Console.WriteLine("Test");

            Console.WriteLine(string.Format("{0}: execution time: {1} ticks", actionToRun.Method.Name, (double)sw.ElapsedTicks / runTimes));
        }
    }
}
