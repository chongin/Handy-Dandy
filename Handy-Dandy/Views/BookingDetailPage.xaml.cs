namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class BookingDetailPage : ContentPage
{
	public BookingDetailPage(BookingDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
