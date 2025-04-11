using EntitiesTest.Application.Interfaces;
using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.DTOs;
using EntitiesTest.Entities;

namespace EntitiesTest.Application.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITenderRepository _tenderRepository;

        public EvaluationService(
            IEvaluationRepository evaluationRepository,
            IBidRepository bidRepository,
            IUserRepository userRepository,
            ITenderRepository tenderRepository)
        {
            _evaluationRepository = evaluationRepository;
            _bidRepository = bidRepository;
            _userRepository = userRepository;
            _tenderRepository = tenderRepository;
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync()
        {
            return await _evaluationRepository.GetAllAsync();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(Guid id)
        {
            return await _evaluationRepository.GetByIdAsync(id);
        }

        public async Task CreateEvaluationAsync(EvaluationDto dto)
        {
            var bid = await _bidRepository.GetByIdAsync(dto.BidId);
            var evaluator = await _userRepository.GetByIdAsync(dto.EvaluatorId);

            if (bid == null || evaluator == null)
            {
                throw new Exception("Bid or Evaluator not found.");
            }

            var evaluation = new Evaluation
            {
                Id = Guid.NewGuid(),
                BidId = bid.Id,
                TenderId = bid.TenderId,
                EvaluatorId = evaluator.Id,
                EvaluationDate = DateTime.UtcNow,
                Notes = dto.Comments,
                Scores = new List<CriterionScore>() // Handle this if needed
            };

            await _evaluationRepository.AddAsync(evaluation);
        }

        public async Task UpdateEvaluationAsync(Guid id, EvaluationDto dto)
        {
            var evaluation = await _evaluationRepository.GetByIdAsync(id);
            if (evaluation == null)
            {
                throw new Exception("Evaluation not found.");
            }

            evaluation.Notes = dto.Comments;
            // optionally update scores or other fields

            await _evaluationRepository.UpdateAsync(evaluation);
        }

        public async Task DeleteEvaluationAsync(Guid id)
        {
            await _evaluationRepository.DeleteAsync(id);
        }
    }

}
