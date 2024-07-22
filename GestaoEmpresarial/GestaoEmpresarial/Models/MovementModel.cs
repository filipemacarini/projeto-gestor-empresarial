using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Models
{
	[Table("Movimentos")]
    public class MovementModel
    {
		[PrimaryKey, AutoIncrement]
		public Int32 Id { get; set; }

		[NotNull]
        public DateTime Date { get; set; }

		[NotNull]
		public Decimal Value { get; set; }

		[NotNull]
		public FormPaymentModel FormPayment { get; set; }

		[NotNull, MaxLength(300)]
        public String? Description { get; set; }
	}
}
