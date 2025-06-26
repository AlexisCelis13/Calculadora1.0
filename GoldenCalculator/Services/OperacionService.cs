using GoldenCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace GoldenCalculator.Services
{
    public class OperacionService
    {
        private readonly OperacionesDbContext _db;
        public OperacionService(OperacionesDbContext db)
        {
            _db = db;
        }

        public async Task AgregarOperacionAsync(Operacion operacion)
        {
            _db.Operaciones.Add(operacion);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Operacion>> ObtenerHistorialAsync()
        {
            return await _db.Operaciones.OrderByDescending(o => o.Fecha).Take(100).ToListAsync();
        }
    }
} 