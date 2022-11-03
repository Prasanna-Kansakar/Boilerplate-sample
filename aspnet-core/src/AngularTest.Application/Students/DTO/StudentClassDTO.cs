using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTest.Students.DTO
{
    public class StudentClassDTO : EntityDto
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Address { get; set; }
        public  float AverageGrade { get; set; }
        public string ClassName { get; set; }
        public string SubjectName  {get; set; }
        public bool IsAssigned { get; set; }
    }
}
