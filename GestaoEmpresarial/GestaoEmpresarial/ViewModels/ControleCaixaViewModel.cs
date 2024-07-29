using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEmpresarial.Models;
using GestaoEmpresarial.Services;
using System.Collections.ObjectModel;

namespace GestaoEmpresarial.ViewModels
{
	public partial class ControleCaixaViewModel : ObservableObject
	{
		[ObservableProperty]
		private MovementModel? _selectedMovimentacao;

		[ObservableProperty]
		private decimal _subtotal;

		private Int32 Id { get; set; }

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
			Id = SelectedMovimentacao.Id;
			Date = SelectedMovimentacao.Date;
			Value = SelectedMovimentacao.Value;
			Description = SelectedMovimentacao.Description;
			FormPayment = SelectedMovimentacao.FormPayment;
		}

		[RelayCommand]
		public async Task Add()
		{
			if (Description == null) Description = "";
			await movementRepository.InitializeAsync();
			await movementRepository.AddMovement(new MovementModel
			{
				Date = Date,
				Value = Value,
				Description = Description,
				FormPayment = FormPayment
			});
			Display();
		}

		[RelayCommand]
		public async Task Update()
		{
			if (SelectedMovimentacao == null) return;
			await movementRepository.InitializeAsync();
			await movementRepository.UpdateMovement(new MovementModel()
			{
				Id = SelectedMovimentacao.Id,
				Date = Date,
				Value = Value,
				Description = Description,
				FormPayment = FormPayment,
			});
			Display();
		}

		[RelayCommand]
		public async Task Delete()
		{
			if (SelectedMovimentacao == null) return;
			await movementRepository.InitializeAsync();

			var resp = await App.Current.MainPage.DisplayAlert("Deletar Item", $"Confirma a exclusão de:\nData: {SelectedMovimentacao.Date.ToShortDateString()}\nValor: R$ {SelectedMovimentacao.Value.ToString("F2")}\nDescrição: {SelectedMovimentacao.Description}\nForma de Pag.: {SelectedMovimentacao.FormPayment}", "Sim", "Não");

			if (resp)
			{
				await movementRepository.DeleteMovement(SelectedMovimentacao);
				Display();
			}
		}

		public void Display()
		{
			Movimentacoes.Clear();
			Refresh(movementRepository);
		}

		private async void Refresh(ICaixaService movement)
		{
			foreach (var item in await movement.GetMovements())
				Movimentacoes.Add(item);
			Subtotal = Movimentacoes.Sum(v => v.Value);
		}
	}
}
