using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest
{
    public class StudentClass : Entity<int>
    {
        [ForeignKey("student")]
        public virtual int StudentID { get; set; }
        [ForeignKey("Class")]
        public virtual int ClassID { get; set; }

        public virtual Student student { get; set; }
        public virtual Class Class { get; set; }


    }
}
