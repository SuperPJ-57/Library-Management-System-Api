using Lms.Application.DTOs;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Interfaces
{
    public interface IBookInstanceService
    {
        Task<IEnumerable<GetBookInstancesDto>> GetAllBookInstancesAsync();
        Task<GetBookInstancesDto> GetBookInstanceByBarcodeAsync(int barcode);
        Task<BookCopies> AddBookInstanceAsync(BookCopies bCopy);
        Task<BookCopies> UpdateBookInstanceAsync(BookCopies bCopy);
        Task<DeleteOperationResult> DeleteBookInstanceAsync(int barcode);
    }
}
