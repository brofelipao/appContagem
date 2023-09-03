namespace ContagemApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void enviarFotosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnviarFotos());
    }
}

