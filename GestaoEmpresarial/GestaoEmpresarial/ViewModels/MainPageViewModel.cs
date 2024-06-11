using GestaoEmpresarial.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestaoEmpresarial.ViewModels
{
	public class MainPageViewModel
	{
		public ICommand ControleCaixaTappedCommand =>
			new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new ControleCaixaView()));

		public ICommand EstatisticasTappedCommand =>
			new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new EstatisticasView()));

		public ICommand AnotacoesTappedCommand =>
			new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new AnotacoesView()));
	}
}
