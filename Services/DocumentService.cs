using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.DTOs;
using EntitiesTest.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IBidDocumentRepository _documentRepository;

        public DocumentService(IBidDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<BidDocument> UploadDocumentAsync(BidDocumentUploadDto dto)
        {
            var document = new BidDocument
            {
                Id = Guid.NewGuid(),
                BidId = dto.BidId,
                Name = dto.Name,
                Description = dto.Description,
                FilePath = dto.FilePath,
                FileSize = dto.FileSize,
                ContentType = dto.ContentType,
                DocumentType = (DocumentType)dto.DocumentType,
                UploadedAt = DateTime.UtcNow
            };

            await _documentRepository.AddAsync(document);
            return document;
        }

        public async Task<List<BidDocument>> GetDocumentsByBidIdAsync(Guid bidId)
        {
            return await _documentRepository.GetDocumentsByBidIdAsync(bidId);
        }
    }
}
