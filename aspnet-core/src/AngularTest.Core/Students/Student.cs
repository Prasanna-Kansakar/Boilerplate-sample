using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest
{
    public class Student: Entity<int>
    {
        public Student()
        {
            StudentClasses = new List<StudentClass>();
        }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual float AverageGrade { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual List<StudentClass> StudentClasses { get; set; }
    }
}
