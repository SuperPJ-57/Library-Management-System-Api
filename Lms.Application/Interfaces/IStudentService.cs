using Lms.Domain.Entitites;
using Lms.Domain.Models;

namespace Lms.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync();
        Task<StudentsEntity> GetStudentByIdAsync(int studentId);
        Task<StudentsEntity> AddStudentAsync(StudentsEntity student);
        Task<StudentsEntity> UpdateStudentAsync(StudentsEntity student);
        Task<DeleteOperationResult> DeleteStudentAsync(int studentId);
    }
}
