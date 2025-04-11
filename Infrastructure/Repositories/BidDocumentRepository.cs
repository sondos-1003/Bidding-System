using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Infrastructure.Repositories
{
    public class BidDocumentRepository : IBidDocumentRepository
    {
        private readonly TendersDbContext _context;

        public BidDocumentRepository(TendersDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BidDocument document)
        {
            await _context.BidDocuments.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BidDocument>> GetDocumentsByBidIdAsync(Guid bidId)
        {
            return await _context.BidDocuments
                                 .Where(d => d.BidId == bidId)
                                 .ToListAsync();
        }
    }
}
