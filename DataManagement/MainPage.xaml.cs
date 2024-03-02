using Firebase.Database;
using Newtonsoft.Json;
using DataManagement.Models;
using Firebase.Database.Query;

namespace DataManagement;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    async void UploadButton_Clicked(object sender, EventArgs e)
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

                        AppData categories = JsonConvert.DeserializeObject<AppData>(jsonData);
              
                        var firebaseClient = new FirebaseClient("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/");

                        foreach (var category in categories.Categories)
                        {
                            await firebaseClient.Child("categories").Child(category.CategoryId).PutAsync(category);
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


