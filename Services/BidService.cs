using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Application.Services
{
    public class BidService :IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        // Submitting a new bid
        public async Task<Bid> SubmitBidAsync(Bid bid)
        {
            if (bid == null)
            {
                return null;
            }

            await _bidRepository.AddAsync(bid);
            return bid;
        }
        public async Task<Bid> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var bid = await _bidRepository.GetByIdAsync(id);
            return bid;
        }
        // Getting all bids for a specific tender
        public async Task<List<Bid>> GetBidsForTenderAsync(Guid tenderId)
        {
            if (tenderId == Guid.Empty)
            {
                return null;
            }

            var bids = await _bidRepository.GetBidsForTenderAsync(tenderId);
            return bids;
        }
    }
}
