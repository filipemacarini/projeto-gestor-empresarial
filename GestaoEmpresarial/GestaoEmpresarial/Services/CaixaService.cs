using GestaoEmpresarial.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Services
{
    public class CaixaService : ICaixaService
    {
        private SQLiteAsyncConnection _dbConnection;

		public async Task AddMovement(MovementModel movement)
		{
			await _dbConnection.InsertAsync(movement);
		}

		public async Task DeleteMovement(MovementModel movement)
		{
			await _dbConnection.DeleteAsync(movement);
		}

		public async Task<MovementModel> GetMovement(int id)
		{
			return await _dbConnection.Table<MovementModel>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<MovementModel>> GetMovements()
		{
			return await _dbConnection.Table<MovementModel>().ToListAsync();
		}

		public async Task InitializeAsync()
		{
			await SetUpDb();
		}

		public async Task UpdateMovement(MovementModel movement)
		{
			await _dbConnection.UpdateAsync(movement);
		}

		private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Caixa.db3");

                _dbConnection = new(dbPath);
                await _dbConnection.CreateTableAsync<MovementModel>();
            }
        }
    }
}
