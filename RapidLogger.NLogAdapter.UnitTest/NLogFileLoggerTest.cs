﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RapidLogger.NLogAdapter.UnitTest
{
    [TestClass]
    public class BaseNLogFileLoggerTest
    {
        private readonly string _loggerDirectory = $"C:\\Logger\\{AppDomain.CurrentDomain.FriendlyName.Replace(":", "-")}";
        private readonly string configFilePath = "nlog.config";

        private BaseNLogLogger _logWrapper;

        [TestCleanup]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Cleanup()
        {
            _logWrapper?.Stop();
            if (Directory.Exists(_loggerDirectory))
            {
                Directory.Delete(_loggerDirectory, true);
            }
        }

        [TestMethod]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Debug()
        {
            // Act
            Task task = new Task(() =>
                                 {
                                     _logWrapper = new FileLogger(configFilePath);
                                     _logWrapper.Debug("Some Info");
                                     _logWrapper.Stop();
                                 });
            task.Start();
            task.Wait();

            // Assert
            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-Debug.log";
            string logFilePath = $"{_loggerDirectory}\\{logFileName}";
            Assert.IsTrue(File.Exists(logFilePath));
        }

        [TestMethod]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Info()
        {
            // Act
            Task task = new Task(() =>
                                 {
                                     _logWrapper = new FileLogger(configFilePath);
                                     _logWrapper.Info("Some Info");
                                     _logWrapper.Stop();
                                 });
            task.Start();
            task.Wait();

            // Assert
            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-Info.log";
            string logFilePath = $"{_loggerDirectory}\\{logFileName}";
            Assert.IsTrue(File.Exists(logFilePath));
        }

        [TestMethod]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Error_Exception()
        {
            // Act
            Task task = new Task(() =>
                                 {
                                     _logWrapper = new FileLogger(configFilePath);
                                     _logWrapper.Error(new Exception("Test exception"));
                                     _logWrapper.Stop();
                                 });
            task.Start();
            task.Wait();

            // Assert
            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-Error.log";
            string logFilePath = $"{_loggerDirectory}\\{logFileName}";
            Assert.IsTrue(File.Exists(logFilePath));
        }

        [TestMethod]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Error()
        {
            // Act
            Task task = new Task(() =>
                                 {
                                     _logWrapper = new FileLogger(configFilePath);
                                     _logWrapper.Error("Some Info", new Exception("Test exception"));
                                     _logWrapper.Stop();
                                 });
            task.Start();
            task.Wait();

            // Assert
            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-Error.log";
            string logFilePath = $"{_loggerDirectory}\\{logFileName}";
            Assert.IsTrue(File.Exists(logFilePath));
        }

        [TestMethod]
        public void QuickLogger_NLogAdapter_UnitTest__BaseNLogTest__Error_NullParameterForException()
        {
            // Act
            Task task = new Task(() =>
                                 {
                                     _logWrapper = new FileLogger(configFilePath);
                                     _logWrapper.Error("Some Info", null);
                                     _logWrapper.Stop();
                                 });
            task.Start();
            task.Wait();

            // Assert
            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-Error.log";
            string logFilePath = $"{_loggerDirectory}\\{logFileName}";
            Assert.IsTrue(File.Exists(logFilePath));
        }
    }
}