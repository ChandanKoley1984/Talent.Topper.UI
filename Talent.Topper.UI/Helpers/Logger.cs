using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Talent.Topper.UI.Helpers
{
    public class Logger
    {
        private object locker = new object();
        private static Logger _Logger;
        private StreamWriter logWriter;
        private Action asyncFileCreator;
        private string logFile;
        private bool lockTheStream;

        public Logger()
        {
            logFile = "TalentTopperLog_" + DateTime.Now.ToString("MM-dd-yyyy") + ".text";
            string filename = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + logFile;
            CreateLogFile(filename);
            logWriter = new StreamWriter(File.OpenWrite(logFile));
            asyncFileCreator = CreateNextLogfile;
            asyncFileCreator.BeginInvoke(null, null);
        }

        /// <summary>
        /// Creates the physical log file. 
        /// </summary>
        private void CreateLogFile(String fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        /// <summary>
        /// This method create a log file for next day exactly 5 second before 12am. 
        /// The next day, it redirects the logs to new file
        /// This method runs constantly on a background thread.
        /// </summary>
        private void CreateNextLogfile()
        {
            while (true)
            {
                DateTime currentDtTm = DateTime.Now;
                while (!(currentDtTm.Hour >= 23 && currentDtTm.Minute >= 59 && currentDtTm.Second >= 55))
                {
                    System.Threading.Thread.Sleep(1000);
                    currentDtTm = DateTime.Now;
                }

                logFile = "SomeLog_" + DateTime.Now.AddDays(1).ToString("MM-dd-yyyy") + ".log";
                CreateLogFile(logFile);
                lockTheStream = true;

                //wait till day changes
                while (currentDtTm.AddDays(1).Day != DateTime.Now.Day) ;

                lock (logWriter)
                {
                    logWriter.Dispose();
                    logWriter = new StreamWriter(File.OpenWrite(logFile));
                }

                lockTheStream = false;

            }
        }

        /// <summary>
        /// A helper method to create singleton instance of Logger class
        /// </summary>
        /// <returns></returns>
        public Logger GetLogger()
        {
            if (_Logger == null)
            {
                lock (locker)
                {
                    if (_Logger == null)
                    {
                        _Logger = new Logger();
                    }
                }
            }

            return _Logger;
        }


        /// <summary>
        /// Write the log
        /// </summary>
        /// <param name="logMessage">Log message to be written to log file</param>
        public void WriteLog(string logMessage)
        {
            if (lockTheStream)
            {
                lock (logWriter)
                {
                    logWriter.WriteLine(logMessage);
                }
            }
            else
            {
                logWriter.WriteLine(logMessage);
            }
        }
    }
}