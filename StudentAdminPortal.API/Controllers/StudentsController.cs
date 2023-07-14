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
            var students = await studentRepository.GetStudentsAsync();
            
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

        [HttpGet]
        [Route("[Controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId) {
            var student = await studentRepository.GetStudentAsync(studentId);

            if(student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
            
        
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request) {

            if (await studentRepository.Exists(studentId))
            {
                var updateStudent= await studentRepository.UpdateStudent(studentId,mapper.Map<DataModel.Student>(request));
                if(updateStudent != null)
                {
                    return Ok(mapper.Map<Student>(updateStudent));
                }
            
            }
            
                return NotFound();
            
        }

        [HttpDelete]
        [Route("[Controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId) 
        {
            if (await studentRepository.Exists(studentId)) 
            {   
                //delete student
               var student =  await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            
            }
            
            return NotFound();
        
        }

    }
}
