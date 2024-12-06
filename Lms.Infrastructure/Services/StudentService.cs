using Lms.Domain.Interfaces;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentsEntity> AddStudentAsync(StudentsEntity student)
        {
            return await _studentRepository.AddStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<StudentsEntity> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task<StudentsEntity> UpdateStudentAsync(StudentsEntity student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
