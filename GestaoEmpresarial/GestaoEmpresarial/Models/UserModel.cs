using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Models
{
    public class UserModel
    {
        public String Name { get; set; }
        public String EnterpriseName { get; set; }
        public String Password { get; set; }
		public String PhotoPath { get; set; }

		public UserModel(string name, string enterpriseName, string password, string photoPath)
		{
			Name = name;
			EnterpriseName = enterpriseName;
			Password = password;
			PhotoPath = photoPath;
		}
	}
}
