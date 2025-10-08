namespace ProcessImitationAsync;

public class Program
{
    public static void Main(string[] args)
    {
        ProcessDataHandler handler = new ProcessDataHandler();  
        
        Console.WriteLine($"Synchronous data processing started at {DateTime.Now.ToString("HH:mm:ss")}");
        handler.ProcessData("file 1");
        handler.ProcessData("file 2");
        handler.ProcessData("file 3");
        Console.WriteLine($"Synchronous data processing finished at {DateTime.Now.ToString("HH:mm:ss")}");
        
        Console.WriteLine("press any to continue...");
        Console.ReadKey(true);
        
        Console.WriteLine($"Asynchronous data processing started at {DateTime.Now.ToString("HH:mm:ss")}");
        Task.WaitAll(new Task[]
        {
            handler.ProcessDataAsync("file 1"),
            handler.ProcessDataAsync("file 2"), 
            handler.ProcessDataAsync("file 3")
        });
        Console.WriteLine($"Asynchronous data processing finished at {DateTime.Now.ToString("HH:mm:ss")}");
        
    }
}

public class ProcessDataHandler
{
    public async Task ProcessDataAsync(string dataName)
    {
        Console.WriteLine($"Async processing of {dataName} started");
        await Task.Delay(3000);
        Console.WriteLine($"Async processing of {dataName} finished");
    }

    public void ProcessData(string dataName)
    {
        Console.WriteLine($"Processing of {dataName} started");
        Thread.Sleep(3000);
        Console.WriteLine($"Processing of {dataName} finished");
    }   
    
    
}