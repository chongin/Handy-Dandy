namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class BookingDetailPage : ContentPage
{
	public BookingDetailPage(BookingDetailViewModel viewModel)
	{
        InitializeComponent();
        AddPickerItems();
        this.BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    private void AddPickerItems()
    {
        hoursPicker.Items.Add("1");
        hoursPicker.Items.Add("2");
        hoursPicker.Items.Add("3");
    }
}
