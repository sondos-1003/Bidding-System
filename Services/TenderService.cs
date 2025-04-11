using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.Entities;
using EntitiesTest.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace EntitiesTest.Application.Services
{
    public class TenderService :ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<Tender> CreateTenderAsync(Tender tender)
        {
            if (tender == null)
            {
                return null;
            }

            // You can add additional validation here if needed

            await _tenderRepository.AddAsync(tender);
            return tender; // Returning the created tender
        }

        public async Task<IEnumerable<Tender>> GetAllTendersAsync()
        {
            return await _tenderRepository.GetAllAsync();
        }

        public async Task<Tender> GetTenderByIdAsync(int id)
        {
            return await _tenderRepository.GetByIdAsync(id);
        }
    }
}
