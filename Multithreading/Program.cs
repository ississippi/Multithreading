



using Multithreading;

//var bs = new BasicSyntax();
//bs.Demo();
//Console.ReadLine();

//var dc = new DivideAndConquer();
//dc.Demo();
//Console.ReadLine();

// ============================================================
// Multithreaded webserver demo
// ============================================================
//var ws = new WebServer();
//Thread monitoringThread = new Thread(ws.MonitorQueue);
//monitoringThread.Start();
//// 1. Enqueue the requests
//Console.WriteLine("Server is running.");
//Console.WriteLine("Type 'b' to book a ticket.");
//Console.WriteLine("Type 'c' to cancel.");
//Console.WriteLine("Type 'exit' to stop.");
//while (true)
//{
//    string? input = Console.ReadLine();
//    if (input?.ToLower() == "exit")
//    {
//        break;
//    }

//    ws.SubmitRequest(input);
//}
// ============================================================

//var xl = new ExclusiveLock();
//xl.Demo();

//var mx = new MutexDemo();
//mx.Demo();

//var sm = new SemaphoreDemo();
//sm.Demo();

var ase = new AutoResetEventDemo();
ase.Demo();

