namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class BookingPage : ContentPage
{
	public BookingPage(BookingViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
