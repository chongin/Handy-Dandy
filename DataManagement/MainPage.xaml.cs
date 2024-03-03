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
}

