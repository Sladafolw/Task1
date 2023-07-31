using Task1;

int a = 0;
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
            WorkingWithFile.Create100();
            Console.WriteLine("successfully");
            break;
        case 2:
            WorkingWithFile.Create100();
            Console.WriteLine("successfully");
            break;
        case 3:
            WorkingWithFile.Create100();
            Console.WriteLine("successfully");
            break;
        case 4:
            WorkingWithFile.Create100();
            Console.WriteLine("successfully");
            break;
        case 5:
            Environment.Exit(1);
            break;
        default:
            break;
    }
}
while (true);
