using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.EntityFrameworkCore;
using AngularTest.EntityFrameworkCore;
using AngularTest.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest.Students
{

    public class StudentRepo :  DomainService, IStudentRepo 
    {
        private readonly IRepository<Student, int> _StudnetRepo;
        /*private readonly AngularTestDbContext _db;*/

        public StudentRepo(IRepository<Student,int> StudnetRepo/*, AngularTestDbContext db*/)
        {
            _StudnetRepo = StudnetRepo;
            /*_db = db;*/
        }

        public List<Student> GetAllActive()
        {          
            var query = _StudnetRepo.GetAll().Where(x=>x.IsActive);
            return query.ToList();
        }
    }
}
