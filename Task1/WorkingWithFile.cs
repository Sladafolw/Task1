using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class WorkingWithFile
    {
        public static void MergeFilesToOne(string Path) 
        { 
        }
        public static void Create100()
        {
            RandomStrings myString= new RandomStrings();
            int i = 0;
            Parallel.For(1, 100, (k) =>
            {
                    using (FileStream fileStream = File.Open($@"C:\Users\dsdsd\source\repos\Task1\Task1\100txtFiles\{++i}.txt", FileMode.Create))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            for (int j = 0; j < 100000; j++)
                            {
                                streamWriter.WriteLine(myString.RandomString());
                            }
                        }
                    }
            });
        }
    }
}
