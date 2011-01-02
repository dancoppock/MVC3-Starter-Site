using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Site.Infrastructure.Logging {
    


    public interface ILogger {

        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception x);
        void Fatal(string message);
        void Fatal(Exception x);

    }
}
