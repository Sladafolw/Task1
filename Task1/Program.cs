using Task1;

int a = 0; string pathTo100; string pathTo1;
while (true)
{
    Console.WriteLine(" input  path to 100 files");
    pathTo100 = @Console.ReadLine() ?? "C:\\Users\\dsdsd\\source\\repos\\Task1\\Task1\\100txtFiles\\";
    Console.WriteLine(" input  path to 1 files");
    pathTo1 = @Console.ReadLine() ?? @"C:\\Users\\dsdsd\\source\\repos\\Task1\\Task1\\1txtFiles\\1txt\";
    if (Directory.Exists(pathTo100) && Directory.Exists(pathTo1)) { break; }
}
do
{

    Console.WriteLine(" input 1 if you want create 100 files,\n input 2 if you want merge files to one,\n input 3 if you want add data to sql,\n input 4 if you want calculate sum of all integers and median of fractional numbers,\n input 5 to Close");
    try
    {
        a = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    switch (a)
    {
        case 1://создание 100 файлов
            WorkingWithFile.Create100(pathTo100);
            Console.WriteLine("successfully");
            break;
        case 2://слияние файлов в 1, либо с удалением строк с определенным словом, либо без удаления. 
            Console.WriteLine("If you want delete lines with your word input 1 else input 2");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("input your Word");
                string word = Console.ReadLine() ?? "afaf";
                WorkingWithFile.MergeFilesToOne(pathTo100, word, pathTo1);
            }
            else
            {
                WorkingWithFile.MergeFilesToOne(pathTo100, null, pathTo1);

            }
            break;
        case 3:// Вызов  функции записи файлов в бд
            WorkingWithDataBase.ReadFromFilesAndWrite(pathTo100);
            break;
        case 4:// Вызов функции с выполнением хранимой процедуры
            try
            {
                WorkingWithDataBase.AvgAndSum();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }

            break;
        case 5:
            Environment.Exit(1);
            break;
        default:
            break;
    }
}
while (true);
