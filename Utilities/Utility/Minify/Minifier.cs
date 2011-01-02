using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tasks.Utility.Minify {
    public class Minifier {

        public static void SqueezeFiles() {
            

            //pull the js and css files in the public/css and public/javascript dirs
            var cssAbsolute = Convention.CssDirectory;
            Console.WriteLine("Squeezing all CSS in {0}", cssAbsolute);

            var cssDir = new DirectoryInfo(cssAbsolute);
            var cssFiles =GetFilesWithExtension(cssDir,".css");
            
            foreach (var file in cssFiles) {
                SqueezeReturns(file.FullName);
            }
            var jsAbsolute = Convention.CssDirectory;
            Console.WriteLine("Squeezing all Javascript in {0}", jsAbsolute);

            var jsDir = new DirectoryInfo(jsAbsolute);
            var jsFiles = GetFilesWithExtension(jsDir, ".js");

            foreach (var file in jsFiles) {
                SqueezeReturns(file.FullName);
            }
        }

        static FileInfo[] GetFilesWithExtension(DirectoryInfo parent, string extension) {

            var result =new List<FileInfo>();
            result.AddRange(parent.GetFiles().Where(x=>x.Extension == extension).AsEnumerable());
            foreach (var dir in parent.GetDirectories()) {
                result.AddRange(GetFilesWithExtension(dir, extension).AsEnumerable());
            }

            return result.ToArray();

        }


        static void SqueezeReturns(string filePath) {
            var fileText = "";
            if (File.Exists(filePath)) {

                using (StreamReader sr = new StreamReader(filePath))
                    fileText = sr.ReadToEnd();

                
                fileText = fileText.Replace("\n", "").Replace("\r","");

                //write it back to the file
                using (StreamWriter sw = new StreamWriter(filePath, false))
                    sw.Write(fileText);


            }
        }
    }
}
