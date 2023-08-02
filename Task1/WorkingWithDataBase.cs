using Microsoft.EntityFrameworkCore;
using System.Data;
using Task1.Models;

namespace Task1
{
    internal class WorkingWithDataBase
    {
        public delegate void FileHandler(string message);
       public event FileHandler? Notify;

        public static void Message(string message) 
        {
            Console.WriteLine(message);
        }

        // executing a stored procedure
        public void AvgAndSum()
        {
            using Task1DataBaseContext db = new();
            using System.Data.Common.DbCommand command = db.Database.GetDbConnection().CreateCommand();
            command.CommandText = "dbo.AvgAndSum";
            command.CommandType = CommandType.StoredProcedure;
            db.Database.OpenConnection();
            using System.Data.Common.DbDataReader result = command.ExecuteReader();
            var list = result.Cast<IDataRecord>()
     .Select(dr => new { Sum = dr.GetValue(0), Avg = dr.GetValue(1), FileId = dr.GetValue(2), FileName = dr.GetValue(3), })
     .ToList();
            foreach (var record in list)
            {
                Console.WriteLine($"Sum={record.Sum}, Avg={record.Avg}, FileIdInDataBase={record.FileId}, FileName={record.FileName}");
            }

            db.Database.CloseConnection();
        }

        // function to write files to database
        public void ReadFromFilesAndWrite(string path)
        {
            using (Task1DataBaseContext db = new())
            {
                foreach (string file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                {
                    Models.File file1 = new();
                    int count = System.IO.File.ReadLines(file).Count();
                    file1.FileName = new FileInfo(file).Name;
                    db.Update(file1);
                    db.SaveChanges();
                    using StreamReader streamReader = new(file);
                    while (!streamReader.EndOfStream)
                    {
                        string? s = streamReader.ReadLine();
                        string[] text = s.Split("||");
                        Models.Line line = new()
                        {
                            Date = DateTime.Parse(text[0]),
                            EngLetters = text[1],
                            RuLetters = text[2],
                            RandomInt = int.Parse(text[3]),
                            RandomFractional = float.Parse(text[4]),
                            FileId = file1.FileId,
                        };
                        db.Add(line);
                        Notify?.Invoke($"number of lines left {count--}, file name = {file1.FileName}");
                    }

                    Console.WriteLine($"saving process in progress");
                    db.SaveChanges();
                }
            }
        }
    }
}
