using GoldenCalculator.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GoldenCalculator.Services
{
    public class OperacionService
    {
        private readonly OperacionRepository _repo;
        public OperacionService(OperacionRepository repo)
        {
            _repo = repo;
        }

        public async Task AgregarOperacionAsync(Operacion operacion)
        {
            await _repo.AgregarOperacionAsync(operacion);
        }

        public async Task<List<Operacion>> ObtenerHistorialAsync()
        {
            return await _repo.ObtenerHistorialAsync();
        }
    }
} 