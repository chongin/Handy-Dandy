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
}
