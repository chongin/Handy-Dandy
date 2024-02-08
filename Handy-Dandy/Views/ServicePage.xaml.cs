namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;


public partial class ServicePage : ContentPage
{
	public ServicePage(ServicePageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
