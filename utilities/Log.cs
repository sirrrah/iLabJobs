using System;
using log4net;

namespace iLabJobs.utilities
{
    class Log
    {
        // Initialize Log4net logs
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // print logs at the beginning of each test case
        public static void StartTestCase(string TestCaseName)
        {
            log.Info("*************************************************************************************************");
            log.Info("* ---------------------------------------  " + TestCaseName + " ---------------------------------------- *");
            log.Info("*************************************************************************************************");
        }

        //print logs for the ending of the test case
        public static void EndTestCase()
        {
            log.Info("***************************************             " + "-E-N-D-" + "             ***************************************");
        }

        //methods to call throughout the test test script to log
        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Warn(string message)
        {
            log.Warn(message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static void Fatal(string message)
        {
            log.Fatal(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
