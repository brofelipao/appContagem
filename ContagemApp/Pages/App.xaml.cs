namespace ContagemApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		var appNav = new NavigationPage(new MainPage());
		appNav.BackgroundColor = Colors.Black;
        MainPage = appNav;
	}
}
