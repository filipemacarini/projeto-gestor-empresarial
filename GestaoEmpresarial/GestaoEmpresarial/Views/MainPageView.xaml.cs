using GestaoEmpresarial.ViewModels;
using GestaoEmpresarial.Views;

namespace GestaoEmpresarial
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageViewModel();
		}
	}
}
