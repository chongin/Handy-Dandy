namespace Handy_Dandy.Views.Login;
using Handy_Dandy.ViewModels.Login;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel SignUpPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = SignUpPageViewModel;
    }
}
