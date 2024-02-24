namespace Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

public partial class MapPage : ContentPage
{
	public MapPage(MapViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
