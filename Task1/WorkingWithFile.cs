namespace Task1
{
    internal static class WorkingWithFile
    {
        // Merging a file according to the task
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
        }

        // merging into 1 file without specifying
        public static void ReadFromFilesInDirectoryAndMerge(string path, string newPath)
        {
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            using FileStream fileStream = File.Open(newPath + "1.txt", FileMode.Create);
            using StreamWriter streamWriter = new(fileStream);
            foreach (string file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
            {
                string s = File.ReadAllText(file);
                streamWriter.Write(string.Join(Environment.NewLine, s));
            }
        }

        // merging into 1 file when specifying what to delete
        public static void ReadFromFilesInDirectoryAndMerge(string path, string newPath, string word)
        {
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            int count = 0;
            using (FileStream fileStream = File.Open(newPath + "1.txt", FileMode.Create))
            {
                using StreamWriter streamWriter = new (fileStream);
                foreach (string file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                {
                    using StreamReader streamReader = new (file);
                    while (!streamReader.EndOfStream)
                    {
                        string? s = streamReader.ReadLine();
                        if (s.ToString().Contains(word))
                        {
                            count++;
                            continue;
                        }

                        streamWriter.WriteLine(s);
                    }
                }
            }

            Console.WriteLine(count + "number of deleted");
        }

        // creating 100 files
        public static void Create100(string path)
        {
            RandomStrings myString = new ();
            int i = 0;
            Parallel.For(0, 100, (k) =>
           {
               using FileStream fileStream = File.Open($@"{path}{++i}.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
               using StreamWriter streamWriter = new (fileStream);
               for (int j = 0; j < 100000; j++)
               {
                   streamWriter.WriteLine(myString.RandomString());
               }
           });
        }
    }
}
