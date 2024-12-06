using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync();
        Task<StudentsEntity> GetStudentByIdAsync(int studentId);
        Task<StudentsEntity> AddStudentAsync(StudentsEntity student);
        Task<StudentsEntity> UpdateStudentAsync(StudentsEntity student);
        Task DeleteStudentAsync(int studentId);
    }
}
