using GestaoEmpresarial.Models;
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
		public ICommand ControleCaixaTappedCommand { get; set; }
		public ICommand EstatisticasTappedCommand { get; set; }
		public ICommand AnotacoesTappedCommand { get; set; }

		public UserModel Usuario { get; set; }

        public MainPageViewModel()
		{
			ControleCaixaTappedCommand = new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new ControleCaixaView()));

			EstatisticasTappedCommand =	new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new EstatisticasView()));

			AnotacoesTappedCommand = new Command(async () =>
				await Application.Current.MainPage.Navigation.PushAsync(new AnotacoesView()));

			Usuario = new UserModel("Filipe Emanuel Macarini Roco", "DEV FILIPE", "1234", "logo.png");
		}
	}
}
