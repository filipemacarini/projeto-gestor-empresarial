using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Models
{
    public class MovementModel
    {
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }
        public FormPaymentModel FormPayment { get; set; }
        public String? Description { get; set; }

		public MovementModel(DateTime date, decimal value, FormPaymentModel formPayment, string? description)
		{
			Date = date;
			Value = value;
			FormPayment = formPayment;
			Description = description;
		}
	}
}
