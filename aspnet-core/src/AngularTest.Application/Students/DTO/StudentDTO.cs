using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest.Students.DTO
{
    [AutoMapFrom(typeof(Student))]
    [AutoMapTo(typeof(Student))]
    public class StudentDTO : EntityDto
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Address { get; set; }
        public  float AverageGrade { get; set; }
    }
}
