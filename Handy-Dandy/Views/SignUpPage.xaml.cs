namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel SignUpPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = SignUpPageViewModel;
    }

    private void OnSignUpClicked(object sender, EventArgs e)
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
        (BindingContext as SignUpPageViewModel)?.SignUpCommand.Execute(null);
    }
}
