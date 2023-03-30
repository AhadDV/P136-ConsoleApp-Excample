using Academy.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Models
{
    public class Student:BaseModel
    {
        private static int _id;
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public double Avarage { get; set; }
        public Group Group { get; set; }

        public Student(string fullName, int age, string email, double avarage, Group group)
        {
            _id++;
            Id= _id;
            FullName = fullName;
            Age = age;
            Email = email;
            Avarage = avarage;
            Group = group;
        }

        public override string ToString()
        {
            return $"FullName:{FullName} Group {Group.GroupNo}";
        }
    }
}
