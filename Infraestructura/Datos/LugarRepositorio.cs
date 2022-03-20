using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class LugarRepositorio : ILugarRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public LugarRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;            
        }

        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await _bd.Lugares
                            .Include(p => p.Pais)
                            .Include(c => c.Categoria)
                            .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _bd.Lugares
                            .Include(p => p.Pais)
                            .Include(c => c.Categoria)
                            .ToListAsync();
        }
    }
}