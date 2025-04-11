using EntitiesTest.Entities;
using EntitiesTest.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntitiesTest.Application.Interfaces;

namespace EntitiesTest.Infrastructure.Repositories
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly TendersDbContext _context;

        public EvaluationRepository(TendersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evaluation>> GetAllAsync()
        {
            return await _context.Evaluations
                .Include(e => e.Bid)
                .Include(e => e.Tender)
                .Include(e => e.Evaluator)
                .ToListAsync();
        }

        public async Task<Evaluation> GetByIdAsync(Guid id)
        {
            return await _context.Evaluations
                .Include(e => e.Bid)
                .Include(e => e.Tender)
                .Include(e => e.Evaluator)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Evaluation evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
        }

        public async Task UpdateAsync(Evaluation evaluation)
        {
            _context.Evaluations.Update(evaluation);
        }

        public async Task DeleteAsync(Guid id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
            }
        }

        public async Task<IEnumerable<Evaluation>> GetByTenderIdAsync(Guid tenderId)
        {
            return await _context.Evaluations
                .Where(e => e.TenderId == tenderId)
                .Include(e => e.Bid)
                .Include(e => e.Evaluator)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
