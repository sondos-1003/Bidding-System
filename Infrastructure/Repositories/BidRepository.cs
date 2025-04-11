using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiesTest.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly TendersDbContext _context;

        public BidRepository(TendersDbContext context)
        {
            _context = context;
        }
        public async Task<List<Bid>> GetBidsForTenderAsync(Guid tenderId)
        {
            return await _context.Bids
                                 .Where(b => b.TenderId == tenderId)
                                 .ToListAsync();
        }
        public async Task AddAsync(Bid bid)
        {
            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bid>> GetBidsByTenderIdAsync(Guid tenderId)
        {
            return await _context.Bids
                .Include(b => b.Bidder)
                    .ThenInclude(bi => bi.User)
                .Include(b => b.TechnicalProposal)
                .Include(b => b.Documents)
                .Include(b => b.FinancialDetails)
                .Where(b => b.TenderId == tenderId)
                .ToListAsync();
        }

        public async Task<Bid> GetByIdAsync(Guid id)
        {
            return await _context.Bids.Include(b => b.Bidder).ThenInclude(bi => bi.User).Include(b => b.TechnicalProposal).Include(b => b.Documents).Include(b => b.FinancialDetails)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Bid bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var bid = await GetByIdAsync(id);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
