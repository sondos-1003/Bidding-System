using EntitiesTest.Entities;

namespace EntitiesTest.Application.Services.Interfaces
{
    public interface IBidService
    {
        Task<Bid> SubmitBidAsync(Bid bid);

      
        Task<List<Bid>> GetBidsForTenderAsync(Guid tenderId);
        
          
       Task<Bid> GetByIdAsync(Guid id); // <-- Add this line
        
    }

}
