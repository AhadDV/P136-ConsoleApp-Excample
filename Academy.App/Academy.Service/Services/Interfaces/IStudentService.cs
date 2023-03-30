using Academy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullname, string email, int age, double average, string groupno);
        public Task<string> UpdateAsync(int id, string fullname, double average, int age, string Email);
        public Task<string> RemoveAsync(int id);
        public Task<Student> GetAsync(int id);
        public Task<List<Student>> GetAllAsync();
    }
}
