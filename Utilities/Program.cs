using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace Tasks {
    class Program {
        static void Main(string[] args) {
            
            Console.WriteLine("Welcome to the Task Master");
            Console.WriteLine("What do you want to do?");
            WhatsUp();
        }
        static void WhatsUp() {
            var command = Console.ReadLine();
            RunCommand(command);
        }
        static void RunCommand(string command) {
            var response = "";
            switch (command) {
                case "help":
                    response = "Help text here";
                    break;
                case "exit":
                case "quit":
                    Console.WriteLine("bye!");
                    Environment.Exit(0);
                    break;
                case "minify":
                    Console.WriteLine("Squeezing... ");
                    //Minifier.SqueezeFiles();
                    break;
                case "prunelog":
                    Dev.PruneLog();
                    break;
                default:
                    response = "Don't know that one";
                    break;
            }
            Console.WriteLine(response);
            WhatsUp();

        }

    }
}
