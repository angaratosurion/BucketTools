using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Autorename
{
    public static class RenameLogger
    {
        internal static Logger logman = NLog.LogManager.GetLogger("Autorename");
        public static void errorhandling(Exception e)
        {
            try
            {
                logman.Fatal(e.Message, e);


            }
            catch (Exception exception9)
            {
                new StackOverflowException().GetType();
                exception9.GetType();
            }

        }
        public static void LogMessage(string message)
        {
            if (message != null)
            {
                Logger Logman = LogManager.GetLogger("Autorenamelog");
                Logman.Info(message);
            }


        }
    }
    }
