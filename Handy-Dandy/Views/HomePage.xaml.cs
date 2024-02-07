namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
