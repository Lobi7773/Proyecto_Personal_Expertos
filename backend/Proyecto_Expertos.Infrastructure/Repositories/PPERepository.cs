using Microsoft.EntityFrameworkCore;
using Proyecto_Expertos.Application.Interfaces;
using Proyecto_Expertos.Domain.Entities;
using Proyecto_Expertos.Infrastructure.Data;

namespace Proyecto_Expertos.Infrastructure.Repositories
{
    public class PPERepository : IPPERepository
    {
        private readonly PPEDBContext _context;

        public PPERepository(PPEDBContext context)
        {
            _context = context;
        }

        public async Task<PPE_Global> AddSync(PPE_Global ppe)
        {
            await _context.PPE_Global.AddAsync(ppe);
            await _context.SaveChangesAsync();
            return ppe;
        }

        public async Task<IEnumerable<PPE_Global>> GetAllAsync()
        {
            return await _context.PPE_Global.ToListAsync();
        }
    }
}