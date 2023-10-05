using ContagemApp.Classes;
using ContagemApp.ViewModels;

namespace ContagemApp.Pages;

public partial class Resultados : ContentPage
{
	ResultadosViewModel viewModel;
	public Resultados(List<ImagesReceiveRequest> images)
	{
		BindingContext = viewModel = new ResultadosViewModel(images);
		InitializeComponent();
	}
}