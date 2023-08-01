using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    static class WorkingWithFile
    {// Слияние файла согласно заданию
        public static void MergeFilesToOne(string path, string? word, string newPath)
        {
            if (word == null)
            {
                ReadFromFilesInDirectoryAndMerge(path, newPath);
            }
            else
            {
                ReadFromFilesInDirectoryAndMerge(path, newPath, word);
            }
        } //слияние в 1 файл без указания
        public static void ReadFromFilesInDirectoryAndMerge(string path, string newPath)
        {
            if (File.Exists(newPath))
                File.Delete(newPath);
            using (FileStream fileStream = File.Open(newPath, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                    {

                        var s = File.ReadAllText(file);
                        streamWriter.Write(string.Join(Environment.NewLine, s));

                    }

                }
            }
        }   //слияние в 1 файл при указании что удалять
        public static void ReadFromFilesInDirectoryAndMerge(string path, string newPath, string word)
        {
            if (File.Exists(newPath))
                File.Delete(newPath);
            int count = 0;
            using (FileStream fileStream = File.Open(newPath, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                    {
                        using (StreamReader streamReader = new StreamReader(file))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                var s = streamReader.ReadLine();
                                if (s.ToString().Contains(word))
                                {
                                    count++;
                                    continue;
                                }
                                streamWriter.WriteLine(s);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count + "number of deleted");
        }
        //создание 100 файлов
        public static void Create100()
        {
            RandomStrings myString = new RandomStrings();
            int i = 0;
            Parallel.For(1, 100, (k) =>
            {
                using (FileStream fileStream = File.Open($@"C:\Users\dsdsd\source\repos\Task1\Task1\100txtFiles\{++i}.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
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
