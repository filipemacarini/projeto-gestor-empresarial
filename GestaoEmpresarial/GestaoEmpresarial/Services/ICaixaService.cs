using GestaoEmpresarial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Services
{
    public interface ICaixaService
    {
        Task InitializeAsync();
        Task<List<MovementModel>> GetMovements();
        Task<MovementModel> GetMovement(int id);
        Task AddMovement(MovementModel movement);
        Task UpdateMovement(MovementModel movement);
        Task DeleteMovement(MovementModel movement);
    }
}
