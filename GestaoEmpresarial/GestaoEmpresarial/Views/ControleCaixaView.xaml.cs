using GestaoEmpresarial.Models;
using GestaoEmpresarial.ViewModels;

namespace GestaoEmpresarial.Views;

public partial class ControleCaixaView : ContentPage
{
	public ControleCaixaView()
	{
		InitializeComponent();
		BindingContext = new ControleCaixaViewModel();
	}
}