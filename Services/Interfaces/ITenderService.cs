using EntitiesTest.Entities;

namespace EntitiesTest.Application.Services.Interfaces
{
    public interface ITenderService
    {
        Task<Tender> CreateTenderAsync(Tender tender);
        Task<IEnumerable<Tender>> GetAllTendersAsync();
        Task<Tender> GetTenderByIdAsync(int id);
    }

}
