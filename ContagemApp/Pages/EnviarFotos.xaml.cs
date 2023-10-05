using ContagemApp.ViewModels;
using System.Collections.ObjectModel;

namespace ContagemApp;

public partial class EnviarFotos : ContentPage
{
    EnviarFotosViewModel viewModel { get; set; }
    public EnviarFotos()
	{
        BindingContext = viewModel = new EnviarFotosViewModel();
        InitializeComponent();
	}

    private void capturaFotoClicked(object sender, EventArgs e)
    {
        viewModel.CapturarFoto();
    }

    private void selecioneFotoClicked(object sender, EventArgs e)
    {
        viewModel.SelecionarFoto();
    }
}