using GoldenCalculator.Models;
using System.Threading.Tasks;

namespace GoldenCalculator.Services
{
    public class OperacionRepository
    {
        private readonly OperacionService _service;
        public OperacionRepository(OperacionService service)
        {
            _service = service;
        }

        public async Task AgregarOperacionAsync(Operacion operacion)
        {
            await _service.AgregarOperacionAsync(operacion);
        }

        public async Task<List<Operacion>> ObtenerHistorialAsync()
        {
            return await _service.ObtenerHistorialAsync();
        }
    }
} 