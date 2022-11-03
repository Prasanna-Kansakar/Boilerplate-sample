using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AngularTest.Authorization;
using AngularTest.Students.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularTest.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using System.Runtime.Intrinsics.Arm;

namespace AngularTest.Students
{
   
    public class StudentService: ApplicationService, IStudentService
    {
        private readonly IRepository<Student, int> _MainRepo;
        private readonly IRepository<Class, int> _classRepo;
        private readonly IRepository<StudentClass, int> _StudentClassRepo;
        private readonly IRepository<Subject, int> _SubjectRepo;
        private readonly IStudentRepo _studentRepo;
       /* private readonly AngularTestDbContext _db;*/

        public StudentService(IStudentRepo studentRepo, IRepository<Student,int> MainRepo/*, AngularTestDbContext db*/, 
            IRepository<Class, int> classRepo,
            IRepository<Subject, int> SubjectRepo,
            IRepository<StudentClass, int> StudentClassRepo)
        {
            _MainRepo = MainRepo;
            _studentRepo = studentRepo;
            /*_db = db;*/
            _SubjectRepo = SubjectRepo;
            _classRepo = classRepo;
            _StudentClassRepo = StudentClassRepo;
        }

        [HttpPost]
        public async Task<List<StudentDTO>> CreateStudent(StudentDTO student) {
            _MainRepo.Insert(ObjectMapper.Map<Student>(student));
            return await GetAll();
        }

        [HttpPut]
        public async Task<List<StudentDTO>> UpdateStudent(StudentDTO student)
        {
            _MainRepo.Update(ObjectMapper.Map<Student>(student));
            return await GetAll();
        }

        [HttpDelete]
        public async Task<List<StudentDTO>> DeleteStudent(int id)
        {
            var student = _MainRepo.Get(id);
            _MainRepo.Delete(student);
            return await GetAll();
        }
        
        [HttpGet("/Getall")]
        public async Task<List<StudentDTO>> GetAll()
        {
            var students = _MainRepo.GetAll().ToList();
            return new List<StudentDTO>(ObjectMapper.Map<List<StudentDTO>>(students));

        }

        [HttpGet("/GetallClass")]
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<List<Class>> GetallClass()
        {
            var rec = _classRepo.GetAll().Include(x=>x.subject).ToList();
            return rec;

        }
        [HttpGet("/GetInactive")]

        public async Task<List<StudentDTO>> GetAllwithInActive()
        {
            var students = _MainRepo.GetAll().Include(t => t.StudentClasses).ThenInclude(x => x.Class).ThenInclude(y => y.subject).ToList();
            return new List<StudentDTO>(ObjectMapper.Map<List<StudentDTO>>(students));
        }
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int id)
        {
            try
            {

                var student = _MainRepo.GetAll().Include(t => t.StudentClasses).ThenInclude(x => x.Class).ThenInclude(y => y.subject).FirstOrDefault(x => x.Id == id);
                return (ObjectMapper.Map<StudentDTO>(student)); 
            }
            catch(Exception ex) {
                return new Student();
            }
        }

        [HttpGet("GetDetails/{id}")]

        public async Task<List<StudentClassDTO>> GetStudent(int id)
        {
            var oldrec = _MainRepo.FirstOrDefault(x => x.Id == id);
            var student = from c in _classRepo.GetAll()
                          join sb in _SubjectRepo.GetAll() on c.SubjectID equals sb.Id
                          join sc in _StudentClassRepo.GetAll().Where(x => x.StudentID == id) on c.Id equals sc.ClassID into temp
                          from t in temp.DefaultIfEmpty()
                          join s in _MainRepo.GetAll() on t.StudentID equals s.Id into temp2
                          from t2 in temp2.DefaultIfEmpty()
                          select new StudentClassDTO
                          {
                              Id = t2 == null? oldrec.Id: t2.Id ,
                              FirstName = t2 == null ? oldrec.FirstName : t2.FirstName,
                              LastName = t2 == null ? oldrec.LastName : t2.LastName,
                              Address = t2 == null ? oldrec.Address : t2.Address,
                              AverageGrade = t2 == null ? oldrec.AverageGrade : t2.AverageGrade,
                              ClassName =  c.ClassName,
                              SubjectName = sb.SubjectName,
                              IsAssigned = t == null ? false : true
                          };
           /* var student = from s in _MainRepo.GetAll()
                          join sc in _StudentClassRepo.GetAll() on s.Id equals sc.StudentID
                          join c in _classRepo.GetAll() on sc.ClassID equals c.Id 
                          join sb in _SubjectRepo.GetAll() on c.SubjectID equals sb.Id                          
                          where s.Id == id
                          select new StudentClassDTO {
                           Id = s.Id,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Address = s.Address,
                           AverageGrade = s.AverageGrade,
                           ClassName = c.ClassName,
                           SubjectName = sb.SubjectName,
                           IsAssigned = true
                          };*/
            return student.ToList();
        }

        [HttpGet("NoAuthroization")]
        [AbpAuthorize(PermissionNames.Student_Permission)]

        public async Task<string> Test()
        {
            return "Hello World";
        }
    }
}
