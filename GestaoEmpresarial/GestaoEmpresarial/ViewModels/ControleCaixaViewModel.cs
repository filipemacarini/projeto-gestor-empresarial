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

		[ObservableProperty]
		public ObservableCollection<MovementModel> _movimentacoes;

		public ICaixaService movementRepository;

        public ObservableCollection<FormPaymentModel> FormasPagamento { get; set; }

		public ControleCaixaViewModel(ICaixaService _movementRepository)
        {
			Date = DateTime.Today;
			movementRepository = _movementRepository;
			Movimentacoes = new() { };
			Refresh(movementRepository);
			FormasPagamento = new ObservableCollection<FormPaymentModel>((FormPaymentModel[])Enum.GetValues(typeof(FormPaymentModel)));
		}

		[RelayCommand]
		public void SelectionChanged()
		{
			if (SelectedMovimentacao == null) return;
			Date = SelectedMovimentacao.Date;
			Value = SelectedMovimentacao.Value;
			Description = SelectedMovimentacao.Description;
			FormPayment = SelectedMovimentacao.FormPayment;
		}

		[RelayCommand]
		public async Task Add()
		{
			await movementRepository.InitializeAsync();
			await movementRepository.AddMovement(new MovementModel
			{
				Date = Date,
				Value = Value,
				Description = Description,
				FormPayment = FormPayment
			});
			await Display();
		}

		[RelayCommand]
		public async void Update()
		{
			if (SelectedMovimentacao == null) return;
			await movementRepository.InitializeAsync();
			await movementRepository.UpdateMovement(SelectedMovimentacao);
			await Display();
		}

		[RelayCommand]
		public async void Delete()
		{
			await movementRepository.InitializeAsync();

			var resp = await App.Current.MainPage.DisplayAlert("Deletar Item", $"Confirma a exclusão de:\nData: {SelectedMovimentacao.Date.ToShortDateString()}\nValor: R$ {SelectedMovimentacao.Value.ToString("F2")}\nDescrição: {SelectedMovimentacao.Description}\nForma de Pag.: {SelectedMovimentacao.FormPayment}", "Sim", "Não");

			if (resp)
			{
				await movementRepository.DeleteMovement(SelectedMovimentacao);
				await Display();
			}
		}

		public async Task Display()
		{
			Movimentacoes.Clear();
			await Refresh(movementRepository);
		}

		private async Task Refresh(ICaixaService movement)
		{
			foreach (var item in await movement.GetMovements())
				Movimentacoes.Add(item);
		}
	}
}
