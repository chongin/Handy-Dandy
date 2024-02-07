namespace Handy_Dandy;
using Handy_Dandy.Models;

public partial class App : Application
{
	public static UserModel CurrentUser;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

