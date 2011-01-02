using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tasks {
    public class Dev {

        public static void PruneLog() {
            Console.WriteLine("Deleteing out log file");
            File.Delete(Convention.LogFile);
            Console.WriteLine("Log deleted (it will regenerate on next event)");
        }
    }
}
