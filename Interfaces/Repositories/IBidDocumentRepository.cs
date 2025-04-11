using EntitiesTest.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Application.Interfaces.Repositories
{
    public interface IBidDocumentRepository
    {
        Task AddAsync(BidDocument document);
        Task<List<BidDocument>> GetDocumentsByBidIdAsync(Guid bidId);
    }
}
