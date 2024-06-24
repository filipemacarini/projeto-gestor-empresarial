using GestaoEmpresarial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEmpresarial.Services;

namespace GestaoEmpresarial.ViewModels
{
    public partial class ControleCaixaViewModel : ObservableObject
	{
		[ObservableProperty]
		private MovementModel? _selectedMovimentacao;

		[ObservableProperty]
		private DateTime _date;

		[ObservableProperty]
		private Decimal _value;

		[ObservableProperty]
		private String? _description;

		[ObservableProperty]
		private FormPaymentModel _formPayment;

		public List<MovementModel> Movimentacoes { get; set; }

		public ICaixaService movementRepository;

        public ObservableCollection<FormPaymentModel> FormasPagamento { get; set; }

		public ControleCaixaViewModel(ICaixaService _movementRepository)
        {
			Date = DateTime.Today;
            Movimentacoes = new List<MovementModel>
			{
				new MovementModel
				{
					Date = new DateOnly(2024, 6, 11),
					Value = 101.34m,
					FormPayment = FormPaymentModel.Crédito,
					Description = null
				},
				new MovementModel
				{
					Date = new DateOnly(2024, 6, 11),
					Value = 160.78m,
					FormPayment = FormPaymentModel.Dinheiro,
					Description = "Luz"
				},
				new MovementModel
				{
					Date = new DateOnly(2024, 6, 11),
					Value = 120.34m,
					FormPayment = FormPaymentModel.Pix,
					Description = "Água"
				},
				new MovementModel
				{
					Date = new DateOnly(2024, 6, 11),
					Value = 60.0m,
					FormPayment = FormPaymentModel.Crédito,
					Description = "Cotrole"
				}
			};
			movementRepository = _movementRepository;
			FormasPagamento = new ObservableCollection<FormPaymentModel>((FormPaymentModel[])Enum.GetValues(typeof(FormPaymentModel)));
		}

		[RelayCommand]
		public void SelectionChanged()
		{
			Date = SelectedMovimentacao.Date.ToDateTime(TimeOnly.MinValue);
			Value = SelectedMovimentacao.Value;
			Description = SelectedMovimentacao.Description;
			FormPayment = SelectedMovimentacao.FormPayment;
		}

		[RelayCommand]
		public async void Add()
		{
			try
			{
				await movementRepository.InitializeAsync();
				await App.Current.MainPage.DisplayAlert("Alert", $"{SelectedMovimentacao.Date}, {SelectedMovimentacao.Value}, {SelectedMovimentacao.Description}, {SelectedMovimentacao.FormPayment}", "Ok");
				SelectedMovimentacao.Date = DateOnly.FromDateTime(DateTime.Now);
				await movementRepository.AddMovement(SelectedMovimentacao);
				await Refresh(movementRepository);
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
			}
		}

		[RelayCommand]
		public async void Update()
		{
			await movementRepository.InitializeAsync();
			await movementRepository.UpdateMovement(SelectedMovimentacao);
			await Refresh(movementRepository);
		}

		[RelayCommand]
		public async void Delete()
		{
			await movementRepository.InitializeAsync();

			var resp = await App.Current.MainPage.DisplayAlert("Deletar Item", $"Confirma a exclusão de R$ {SelectedMovimentacao.Value:.2m}?", "Sim", "Não");

			if (resp)
				await movementRepository.DeleteMovement(SelectedMovimentacao);

			await Refresh(movementRepository);
		}

		[RelayCommand]
		public async void Display()
		{
			await movementRepository.InitializeAsync();
			await Refresh(movementRepository);
		}

		private async Task Refresh(ICaixaService movement)
		{
			Movimentacoes.AddRange(await movement.GetMovements());
		}
	}
}
