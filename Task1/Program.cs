using Task1;

int a = 0;
string pathTo100 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../100txtFiles/");
string pathTo1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../1txtFiles/");
WorkingWithDataBase workingWithDataBase = new WorkingWithDataBase();
workingWithDataBase.Notify += (string message) => Console.WriteLine(message);
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
        case 1:
            // creating 100 files
            WorkingWithFile.Create100(pathTo100);
            Console.WriteLine("successfully");
            break;
        case 2:
            // merging files into 1, either with deletion of lines with a certain word, or without deletion.
            Console.WriteLine("If you want delete lines with your word input 1 else input 2");
            int i = 0;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

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
        case 3:
            // Calling the function of writing files to the database
            workingWithDataBase.ReadFromFilesAndWrite(pathTo100);
            break;
        case 4:
            // Calling a Function with Executing a Stored Procedure
            try
            {
                workingWithDataBase.AvgAndSum();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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