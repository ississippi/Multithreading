



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
var ws = new WebServer();
Thread monitoringThread = new Thread(ws.MonitorQueue);
monitoringThread.Start();
// 1. Enqueue the requests
Console.WriteLine("Server is running. Type 'exit' to stop.");
while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        break;
    }

    ws.SubmitRequest(input);
}
// ============================================================
