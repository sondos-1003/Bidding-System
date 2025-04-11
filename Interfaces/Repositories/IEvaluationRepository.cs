using EntitiesTest.Entities;
namespace EntitiesTest.Application.Interfaces
{
    public interface IEvaluationRepository
    {
        Task<IEnumerable<Evaluation>> GetAllAsync();
        Task<Evaluation> GetByIdAsync(Guid id);
        Task AddAsync(Evaluation evaluation);
        Task UpdateAsync(Evaluation evaluation);
        Task DeleteAsync(Guid id); // <- this must accept Guid
        Task<IEnumerable<Evaluation>> GetByTenderIdAsync(Guid tenderId);
        Task SaveChangesAsync();
    }
}