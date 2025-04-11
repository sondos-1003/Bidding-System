using EntitiesTest.DTOs;
using EntitiesTest.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Application.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<BidDocument> UploadDocumentAsync(BidDocumentUploadDto dto);
        Task<List<BidDocument>> GetDocumentsByBidIdAsync(Guid bidId);
    }
}
