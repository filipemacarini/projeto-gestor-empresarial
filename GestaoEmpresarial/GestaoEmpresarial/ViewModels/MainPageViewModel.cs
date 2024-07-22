using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEmpresarial.Models;
using GestaoEmpresarial.Services;
using GestaoEmpresarial.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestaoEmpresarial.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		public UserModel Usuario { get; set; }
		public ICaixaService MovimentosRepository { get; set; }

        public MainPageViewModel(ICaixaService movimentosRepository)
		{
			MovimentosRepository = movimentosRepository;
			Usuario = new UserModel("Filipe Emanuel Macarini Roco", "DEV FILIPE", "1234", "logo.png");
		}

		[RelayCommand]
		public async void ControleCaixaTapped()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new ControleCaixaView(MovimentosRepository));
		}

		[RelayCommand]
		public async void EstatisticasTapped()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new EstatisticasView());
		}

		[RelayCommand]
		public async void AnotacoesTapped()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new AnotacoesView());
		}
	}
}
