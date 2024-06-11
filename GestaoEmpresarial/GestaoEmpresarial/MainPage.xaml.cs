using GestaoEmpresarial.Views;

namespace GestaoEmpresarial
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void crdControleCaixa_Tapped(object sender, TappedEventArgs e)
		{
			await Navigation.PushAsync(new ControleCaixaView());
		}

		private async void crdEstatisticas_Tapped(object sender, TappedEventArgs e)
		{
			await Navigation.PushAsync(new EstatisticasView());
		}

		private async void crdAnotacoes_Tapped(object sender, TappedEventArgs e)
		{
			await Navigation.PushAsync(new AnotacoesView());
		}
	}

}
