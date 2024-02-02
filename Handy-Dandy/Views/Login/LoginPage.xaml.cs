using Handy_Dandy.ViewModels.Login;
using Microsoft.Maui.Controls;
namespace Handy_Dandy.Views.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = loginPageViewModel;
	}

    public async void SignUpLabel_Tapped(object sender, EventArgs e)
    {
        // Handle the sign-up click event
        // Put your sign-up logic here
        //await Shell.Current.GoToAsync("//SignUpPage");
        AppShell.Current.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        });
    }
}
