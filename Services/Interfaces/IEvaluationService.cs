using EntitiesTest.DTOs;
using EntitiesTest.Entities;

namespace EntitiesTest.Application.Services.Interfaces
{
    public interface IEvaluationService
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync();
        Task<Evaluation> GetEvaluationByIdAsync(Guid id);
        Task CreateEvaluationAsync(EvaluationDto evaluationDto);
        Task UpdateEvaluationAsync(Guid id, EvaluationDto evaluationDto);
        Task DeleteEvaluationAsync(Guid id);
    }

}
