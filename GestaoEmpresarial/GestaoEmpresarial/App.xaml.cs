using GestaoEmpresarial.Services;

namespace GestaoEmpresarial
{
	public partial class App : Application
	{
		public App(ICaixaService caixaService)
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage(caixaService));
		}
	}
}
