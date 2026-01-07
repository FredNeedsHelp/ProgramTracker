using System.Diagnostics;

List<Process> OL = new List<Process>();
Panel(false);

 void ListProccesses(string ProgramName)
{
    Process[] list = Process.GetProcessesByName(ProgramName);
    if(list.Length == 0)
    {
        Console.WriteLine("Program Not Found or Not Running, Try Again");
    }
    else
    {
        OL.Add(list[0]);
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Program Succesfully Added, your program ID in the list is " + OL.Count);
        Console.ResetColor();
    }  
    Panel(true);
}

void TrackProgramUsage(int IDlist)
{   
    //Add Usage Timer Here
    TimeSpan TS = DateTime.Now - OL[IDlist].StartTime;
    float Time;
    string Unit = "Unexpected Error";
    if(MathF.Round((float)TS.TotalHours) <= 0)
    {
        Time = MathF.Round((float)TS.TotalMinutes);
        Unit = " Minutes";
    }
    else
    {
        Time = MathF.Round((float)TS.TotalHours);
        Unit = " Hours";
    }
    Console.WriteLine("Elapsed Time Since Launch:" + Time + Unit);
    Panel(true);
}

void Panel(bool tryagain)
{
    Console.Title = "Panel";
    if (tryagain) {Console.WriteLine("\n"); }
    Console.WriteLine("1. Add Program to List 2. Track Program from List");
    string sec = Console.ReadLine();
    if(sec == "1")
    {
        Console.Title = "Add Program Name to List";
        Console.WriteLine("Input Program Name: ");
        string IDName = Console.ReadLine();
        if (IDName == null) { Console.WriteLine("Null Exception Found"); return; }
        ListProccesses(IDName);
    }
    else if(sec == "2")
    {
        Console.Title = "Track Program";
        Console.WriteLine("List ID of Program: ");
        string IDlist = Console.ReadLine();
        int.TryParse(IDlist, out int N);
        if (N - 1 >= 0 && N - 1 < OL.Count)
        {
            TrackProgramUsage(N - 1);
        }
        else
        {
            Console.WriteLine("ID not found, try again");
            Panel(true);
        }
    }          
    else
    {
        Console.WriteLine("None of the options detected, try again");
        Panel(true);
    }
}

