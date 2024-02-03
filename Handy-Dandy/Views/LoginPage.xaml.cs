using Handy_Dandy.ViewModels;
using Microsoft.Maui.Controls;
namespace Handy_Dandy.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = loginPageViewModel;
	}
}
