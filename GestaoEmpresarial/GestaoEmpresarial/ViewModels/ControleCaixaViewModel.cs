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

namespace GestaoEmpresarial.ViewModels
{
    public class ControleCaixaViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		public List<MovementModel> Movimentacoes { get; set; }
        public ObservableCollection<FormPaymentModel> FormasPagamento { get; set; }
		private MovementModel _selectedMovimentacao { get; set; }
		public MovementModel SelectedMovimentacao
		{
			get => _selectedMovimentacao;
			set
			{
				_selectedMovimentacao = value;
				OnPropertyChanged();
			}
		}
        public ICommand SelectionChangedCommand { get; set; }
		private DateTime _date { get; set; }
		public DateTime Date
		{
			get => _date;
			set
			{
				_date = value;
				OnPropertyChanged();
			}
		}

		private Decimal _value { get; set; }
		public Decimal Value
		{
			get => _value;
			set
			{
				_value = value;
				OnPropertyChanged();
			}
		}

		private String _description { get; set; }
		public String Description
		{
			get => _description;
			set
			{
				_description = value;
				OnPropertyChanged();
			}
		}

		private FormPaymentModel _formPayment { get; set; }
		public FormPaymentModel FormPayment
		{
			get => _formPayment;
			set
			{
				_formPayment = value;
				OnPropertyChanged();
			}
		}
		public ControleCaixaViewModel()
        {
            Movimentacoes = new List<MovementModel>
			{
				new MovementModel(new DateTime(2024, 6, 11), 101.34m, FormPaymentModel.Crédito, null),
				new MovementModel(new DateTime(2024, 6, 11), 160.78m, FormPaymentModel.Dinheiro, "Luz"),
				new MovementModel(new DateTime(2024, 6, 11), 120.34m, FormPaymentModel.Pix, "Água"),
				new MovementModel(new DateTime(2024, 6, 11), 60, FormPaymentModel.Crédito, "Cotrole"),
			};
			FormasPagamento = new ObservableCollection<FormPaymentModel>((FormPaymentModel[])Enum.GetValues(typeof(FormPaymentModel)));
			SelectionChangedCommand = new Command(async () =>
			{
				Date = SelectedMovimentacao.Date;
				Value = SelectedMovimentacao.Value;
				Description = SelectedMovimentacao.Description;
				FormPayment = SelectedMovimentacao.FormPayment;
			});
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
