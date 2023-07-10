using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
          var students=await studentRepository.GetStudentsAsync();
            
         // var domainModelStudents = new List<Student>();

         /*  foreach (var student in students)
            {
                domainModelStudents.Add(new Student() { 
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Address = new Address()
                    {
                        Id=student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress= student.Address.PostalAddress,
                    },
                    Gender=new Gender()
                    {
                        Id = student.GenderId,
                        Description =student.Gender.Description,
                    }

                
                
                });
                
            }*/
            return Ok(mapper.Map<List<Student>>(students));

        }
    }
}
