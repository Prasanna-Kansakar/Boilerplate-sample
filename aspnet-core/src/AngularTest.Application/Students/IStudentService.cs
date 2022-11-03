using Abp.Application.Services;
using AngularTest.Students.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest.Students
{
    public interface IStudentService: IApplicationService
    {
        Task<List<StudentDTO>> CreateStudent(StudentDTO student);
        Task<List<StudentDTO>> UpdateStudent(StudentDTO student);
        Task<List<StudentDTO>> DeleteStudent(int id);
        Task<List<StudentDTO>> GetAll();
        Task<List<Class>> GetallClass();
        Task<List<StudentDTO>> GetAllwithInActive();
        Task<object> Details(int id);
        Task<List<StudentClassDTO>> GetStudent(int id);
    }
}
