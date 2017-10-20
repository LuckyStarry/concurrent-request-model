using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public static class Logger
    {
        public static void Record(Object obj)
        {
            Logger.Record(obj.ToString());
        }

        public static void Record(string format, params object[] args)
        {
            Logger.Record(string.Format(format, args));
        }

        public static void Record(string message)
        {
            Console.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss"), message));
        }
    }
}
