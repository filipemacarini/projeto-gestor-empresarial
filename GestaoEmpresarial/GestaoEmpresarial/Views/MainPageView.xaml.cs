using GestaoEmpresarial.Services;
using GestaoEmpresarial.ViewModels;
using GestaoEmpresarial.Views;
using Microsoft.Maui.Controls;

namespace GestaoEmpresarial
{
	public partial class MainPage : ContentPage
	{
		public readonly ICaixaService _service;
		public MainPage(ICaixaService service)
		{
			InitializeComponent();
			_service = service;
			BindingContext = new MainPageViewModel(_service);
		}
	}
}
