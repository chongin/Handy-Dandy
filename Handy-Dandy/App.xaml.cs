namespace Handy_Dandy;
using Handy_Dandy.Models;

public partial class App : Application
{
	public static User CurrentUser;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

