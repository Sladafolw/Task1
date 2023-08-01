using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Task1.Models;

namespace Task1
{
    static class WorkingWithDataBase
    {//выполнение хранимой процедуры
        public static void AvgAndSum()
        {
            using (Task1DataBaseContext db = new Task1DataBaseContext())
            {
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "dbo.AvgAndSum";
                    command.CommandType = CommandType.StoredProcedure;
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        
                        var list = result.Cast<IDataRecord>()
                 .Select(dr => new { Sum = dr.GetValue(0), Avg = dr.GetValue(1), FileId = dr.GetValue(2), FileName = dr.GetValue(3), })
                 .ToList();
                        foreach (var record in list)

                        {
                            Console.WriteLine($"Sum={record.Sum}, Avg={record.Avg}, FileIdInDataBase={record.FileId}, FileName={record.FileName}");
                        }
                        db.Database.CloseConnection();

                    }
                }
            }
        }//функция записи файлов в бд
        public static void ReadFromFilesAndWrite(string path)
        {
            int count = 0;
            using (Task1DataBaseContext db = new Task1DataBaseContext())
            {
                foreach (var file in Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly))
                {
                    Models.File file1 = new Models.File();
                    //count= System.IO.File.ReadLines(file).Count(); //это значительно снизит производительность, пусть файлов будет именно 1000000
                    count = 100000;
                    file1.FileName = new FileInfo(file).Name;
                    db.Update(file1);
                    db.SaveChanges();
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var s = streamReader.ReadLine();
                            string[] text = s.Split("||");
                            Models.Line line = new Models.Line()
                            {
                                Date = DateTime.Parse(text[0]),
                                EngLetters = text[1],
                                RuLetters = text[2],
                                RandomInt = int.Parse(text[3]),
                                RandomFractional = float.Parse(text[4]),
                                FileId = file1.FileId
                            };
                            db.Add(line);
                            Console.WriteLine($"number of lines left {count--}, file name = {file1.FileName}");
                        }
                        Console.WriteLine($"saving process in progress");
                        db.SaveChanges();
                    }
                }
            }

        }
    }
}
