using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DataManagement.Models;

namespace DataManagement;


public static class MauiProgram
{
    public static void GenerateServicWorkers()
    {
        string currentDirectory = "/Users/chongin/cambrian/Handy-Dandy/DataManagement";

        string categroyFile = $"{currentDirectory}/data/categories.json";
        string jsonText = File.ReadAllText(categroyFile);
        AppData categoriesData = JsonConvert.DeserializeObject<AppData>(jsonText);

        List<string> workerIds = new List<string> {
            "worker1", "worker2", "worker3", "worker4", "worker5",
            "worker6", "worker7", "worker8", "worker9", "worker10",
            "worker11", "worker12", "worker13", "worker14", "worker15",
            "worker16", "worker17", "worker18", "worker19", "worker20"
        };


        List<ServiceWorkerModel> serviceWorkers = new List<ServiceWorkerModel>();
        foreach (var category in categoriesData.Categories)
        {
            foreach (var service in category.Services)
            {
                Random random = new Random();
                int numWorkers = random.Next(3, 9);
                List<string> selectedWorkers = new List<string>();
                for (int i = 0; i < numWorkers; i++)
                {
                    int index = random.Next(0, workerIds.Count);
                    if (selectedWorkers.IndexOf(workerIds[index]) < 0)
                    {
                        selectedWorkers.Add(workerIds[index]);
                    }
                    else
                    {
                        i--;
                    }
                }

                ServiceWorkerModel serviceWorker = new ServiceWorkerModel
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.Name,
                    WorkerIds = selectedWorkers
                };
                serviceWorkers.Add(serviceWorker);
            }
        }

        string outputJson = JsonConvert.SerializeObject(new { service_workers = serviceWorkers }, Formatting.Indented);

        string outputFilePath = $"{currentDirectory}/data/service_workers.json";
        File.WriteAllText(outputFilePath, outputJson);

        Console.WriteLine($"Service workers data saved to '{outputFilePath}'.");
    }


    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        bool generateData = false;
        if (generateData)
        {
            GenerateServicWorkers();
        }

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        return builder.Build();
    }
}
