using Handy_Dandy.ViewModels;
namespace Handy_Dandy.Views;


public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
       if (EmailValidator.IsNotValid)
        {
            DisplayAlert("Validation Failed", "Email format is not valid.", "OK");
            return;
        }

        if (PasswordValidator.IsNotValid)
        {
            string errorMessage = "";
            foreach (var error in PasswordValidator.Errors)
            {
                errorMessage += error.ToString() + "\n";
            }
            DisplayAlert("Validation Failed", $"Password is not valid:\n{errorMessage}", "OK");
            return;
        }
        (BindingContext as LoginPageViewModel)?.LoginCommand.Execute(null);
    }
}
