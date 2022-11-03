using Abp.Domain.Entities;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest
{
    public class Class: Entity<int>
    {
        public Class()
        {
            StudentClasses = new List<StudentClass>();
        }
        public virtual string ClassName { get; set; }
        [ForeignKey("subject")]
        public virtual int SubjectID { get; set; }

        public virtual Subject subject { get; set; }
        public virtual List<StudentClass> StudentClasses { get; set; }
    }
}
