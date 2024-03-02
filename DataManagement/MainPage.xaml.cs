using Firebase.Database;
using Newtonsoft.Json;
using DataManagement.Models;
using Firebase.Database.Query;

namespace DataManagement;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    async void CategoriesBrowseButton_Clicked(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a JSON file"
        });
    }

    async void WorkersBrowseButton_Clicked(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a JSON file"
        });
    }

    async void ServiceWorkersBrowseButton_Clicked(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a JSON file"
        });
    }

    async void ConfirmButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a JSON file"
            });

            if (file != null)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string jsonData = await reader.ReadToEndAsync();

                        AppData appData = JsonConvert.DeserializeObject<AppData>(jsonData);

                        var firebaseClient = new FirebaseClient("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/");

                        //foreach (var category in appData.Categories)
                        //{
                        //    await firebaseClient.Child("categories").Child(category.CategoryId).PutAsync(category);
                        //}

                        //foreach (var worker in appData.Workers)
                        //{
                        //    await firebaseClient.Child("workers").Child(worker.WorkerID).PutAsync(worker);
                        //}

                        foreach (var serviceWorker in appData.ServiceWorkers)
                        {
                            await firebaseClient.Child("service_workers").Child(serviceWorker.ServiceId).PutAsync(serviceWorker);
                        }
                        await DisplayAlert("Success", "Data successfully uploaded to Firebase!", "OK");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}

