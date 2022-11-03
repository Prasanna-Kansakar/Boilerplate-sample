using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest
{
    public class Subject : Entity<int>
    {
        public Subject()
        {
            Classes = new List<Class>();
        }
        public virtual string SubjectName { get; set; }
        public virtual List<Class> Classes { get; set; }
    }
}
