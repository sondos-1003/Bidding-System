using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Infrastructure.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly TendersDbContext _context;

        public TenderRepository(TendersDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Tender tender)
        {
            await _context.Tenders.AddAsync(tender);
            await _context.SaveChangesAsync();
        }

        public async Task<Tender> GetByIdAsync(int id)
        {
            return await _context.Tenders.FindAsync(id);
        }

        public async Task<IEnumerable<Tender>> GetAllAsync()
        {
            return await _context.Tenders.ToListAsync();
        }


        public async Task UpdateAsync(Tender tender)
        {
            _context.Tenders.Update(tender);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tender = await GetByIdAsync(id);
            if (tender != null)
            {
                _context.Tenders.Remove(tender);
                await _context.SaveChangesAsync();
            }
        }
    }
}
