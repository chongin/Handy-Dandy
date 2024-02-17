namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
