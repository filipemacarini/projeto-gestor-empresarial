using GestaoEmpresarial.Models;
using GestaoEmpresarial.Services;
using GestaoEmpresarial.ViewModels;

namespace GestaoEmpresarial.Views;

public partial class ControleCaixaView : ContentPage
{
	public readonly ICaixaService _service;
    public ControleCaixaView(ICaixaService service)
	{
		InitializeComponent();
		_service = service;
		BindingContext = new ControleCaixaViewModel(_service);
	}
}