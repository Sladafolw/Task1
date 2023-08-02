namespace Task1
{
    internal static class WorkingWithFile
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
        }
        //слияние в 1 файл без указания
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
        //слияние в 1 файл при указании что удалять
        public static void ReadFromFilesInDirectoryAndMerge(string path, string newPath, string word)
        {
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            int count = 0;
            using (FileStream fileStream = File.Open(newPath + "1.txt", FileMode.Create))
            {
                using StreamWriter streamWriter = new(fileStream);
                foreach (string file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                {
                    using StreamReader streamReader = new(file);
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
        //создание 100 файлов
        public static void Create100(string path)
        {
            RandomStrings myString = new();
            int i = 0;
            _ = Parallel.For(1, 100, (k) =>
            {
                using FileStream fileStream = File.Open($@"{path}+{++i}.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
                using StreamWriter streamWriter = new(fileStream);
                for (int j = 0; j < 100000; j++)
                {
                    streamWriter.WriteLine(myString.RandomString());
                }
            });
        }
    }
}
