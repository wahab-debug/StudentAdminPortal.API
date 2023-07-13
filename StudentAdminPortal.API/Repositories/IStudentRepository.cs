using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentAdminPortal.API.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);

        Task<List<Gender>> GetGenderAsync();

        Task<bool> Exists(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId, Student request);
        
    }
}
