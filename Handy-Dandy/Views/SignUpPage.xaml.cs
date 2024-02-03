namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel SignUpPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = SignUpPageViewModel;
    }
}
