using Lms.Application.DTOs;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class BookInstanceService: IBookInstanceService
    {
        private readonly IBookInstanceRepository _bookInstanceRepository;
        public BookInstanceService(IBookInstanceRepository bookInstanceRepository)
        {
            _bookInstanceRepository = bookInstanceRepository;
        }
        public async Task<BookCopies> AddBookInstanceAsync(BookCopies bCopy)
        {
            return await _bookInstanceRepository.AddBookInstanceAsync(bCopy);
        }

        public async Task<DeleteOperationResult> DeleteBookInstanceAsync(int barcode)
        {
            return await _bookInstanceRepository.DeleteBookInstanceAsync(barcode);
        }

        public async Task<IEnumerable<GetBookInstancesDto>> GetAllBookInstancesAsync()
        {
            return await _bookInstanceRepository.GetAllBookInstancesAsync();
        }

        public async Task<GetBookInstancesDto> GetBookInstanceByBarcodeAsync(int barcode)
        {
            return await _bookInstanceRepository.GetBookInstanceByBarcodeAsync(barcode);
        }

        public async Task<BookCopies> UpdateBookInstanceAsync(BookCopies bCopy)
        {
            return await _bookInstanceRepository.UpdateBookInstanceAsync(bCopy);
        }
    }
    
}
