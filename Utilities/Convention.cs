using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Tasks {
    public class Convention {

        public static string SolutionRoot {
            get {
                var taskRoot = new DirectoryInfo(TasksRoot);
                return taskRoot.Parent.FullName;
            }
        }
        public static string MailerTemplates {
            get {
                return TasksRoot + "\\MailerTemplates";
            }
        }
        public static string TasksRoot {
            get {
                //the current directory is the Debug or Release... need to back up a bit
                var current = new DirectoryInfo(Directory.GetCurrentDirectory());
                return current.Parent.Parent.FullName;
            }
        }
        public static string LogRoot {
            get {
                return WebRoot + "\\Logs";
            }
        }
        public static string LogFile {
            get {
                return LogRoot + "\\Site.log";
            }
        }
        public static string ReleaseRoot {
            get {
                return SolutionRoot + "\\Releases";
            }
        }
        public static string WebRoot {
            get {

                return SolutionRoot + "\\Web";
            }
        }
        public static string PublicDirectory {
            get {
                return WebRoot + "\\Public";
            }
        }

        public static string CssDirectory {
            get {
                return PublicDirectory + "\\css";
            }
        }
        public string ScriptDirectory {
            get {
                return PublicDirectory + "\\javascript";
            }
        }

    }
}
