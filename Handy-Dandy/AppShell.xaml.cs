using Handy_Dandy.Views.Login;

namespace Handy_Dandy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
	}
}

