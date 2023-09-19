using EventExercise;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Timers;

//TimerSample();
//FileSystemWatcherSample();
NoisyListSample();

void NoisyListSample()
{
    NoisyList<string> list = new NoisyList<string>(new string[] { "Apple", "Banana", "Cherry" }) { Name="StringList"};
    NoisyList<int> list2 = new NoisyList<int>(new int[] { 1,2,3, }) { Name = "IntList" };
    list.OnItemAdded += 
        (l, arg) => Console.WriteLine($"{l.Name} added a new item: {arg.ItemAdded} in position {arg.ItemPositionInList} on {arg.InsertionTimestamp}");
    list2.OnItemAdded +=
        (l, arg) => Console.WriteLine($"{l.Name} added a new item: {arg.ItemAdded} in position {arg.ItemPositionInList} on {arg.InsertionTimestamp}");
    
    list.OnItemRemoved += OnItemRemoved;
    list2.OnItemRemoved +=OnItemRemoved;
    //use a method here so 2 events can call the same handler
    void OnItemRemoved<T>(NoisyList<T> arg1, (int CountBeforeRemove, int CountAfterRemove, T? ItemRemoved, DateTime RemoveTimestamp) arg2)
    {
        Console.WriteLine($"{arg2.ItemRemoved} was remove from {arg1.Name} on {arg2.RemoveTimestamp}, there are {arg2.CountAfterRemove} items now.");
    }

    list.Add("Durian");
    list2.Add(123);
    Console.WriteLine("items added");
    list.Remove("Apple");
    list2.Remove(1);
    Console.WriteLine("items removed");
    Console.WriteLine("Press enter to end the program");
    Console.ReadLine();
}



void FileSystemWatcherSample()
{
    // create instance of FSW, supply directory to watch
    // 
    using var watcher = new FileSystemWatcher(@"C:\test");
    // configure watch to notify on changes of the following attributes
    // | is a bitwise or to combine the properties to monitor for changes
    watcher.NotifyFilter = NotifyFilters.Attributes
                         | NotifyFilters.CreationTime
                         | NotifyFilters.DirectoryName
                         | NotifyFilters.FileName
                         | NotifyFilters.Size;
    // connect event handler to the events raised by the FSW
    watcher.Changed += (s, arg)=>Console.WriteLine($"{arg.Name} modified");
    watcher.Created += (s, arg) => Console.WriteLine($"{arg.Name} created");
    watcher.Deleted += (s, arg) => Console.WriteLine($"{arg.Name} deleted");
    watcher.Renamed += (s, arg) => Console.WriteLine($"{arg.Name} renamed");
    watcher.EnableRaisingEvents = true;
    Console.WriteLine("Press enter to stop the program");
    Console.ReadLine();
}

void Handler(object s, ElapsedEventArgs arg)
{
    Console.WriteLine($"Timer with following interval:{(s as System.Timers.Timer).Interval}-{arg.SignalTime}");
}

void TimerSample()
{
    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += (s, arg) => Console.WriteLine($"Timer is enabled:{(s as System.Timers.Timer).Enabled} last fired at:{arg.SignalTime} ");
    aTimer.Elapsed += Handler;
    //this is also referred to as callback in javascript
    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset = true;

    // Start the timer
    aTimer.Enabled = true;

    Console.WriteLine("Press the Enter key to remove Handler from Elaped Delegate");
    Console.ReadLine();
    aTimer.Elapsed -= Handler;

    Console.WriteLine("Press the Enter key to end the program");
    Console.ReadLine();

    
}

