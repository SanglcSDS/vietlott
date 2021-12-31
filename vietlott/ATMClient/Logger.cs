﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ATMClient
{
    public static class Logger
    {
        private static string FILE_LOG = ConfigurationManager.AppSettings["fileLog"];
        public static object _locked = new object();
        public static void Log(string message)
        {
            try
            {
                lock (_locked)
                {
                    string fileLog = PathLocation(FILE_LOG) + "AtmLog.txt";

                    string _message = string.Format("{0}{1}", message, Environment.NewLine);
                    File.AppendAllText(fileLog, _message);

                }


            }
            catch (Exception ex)
            {
                Logger.Log(string.Format("The process failed: {0}", ex.ToString()));
            }
        }
        public static string PathLocation(string value)
        {
            try
            {
                if (Directory.Exists(value))
                {
                    return value;
                }
                DirectoryInfo di = Directory.CreateDirectory(value);
            }
            catch (Exception ex)
            {
                Logger.Log(string.Format("The process failed: {0}", ex.ToString()));

            }
            return value;



        }



    }
}
