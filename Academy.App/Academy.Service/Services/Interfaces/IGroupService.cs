using Academy.Core.Enums;
using Academy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Service.Services.Interfaces
{
    public interface IGroupService
    {
        public Task<string> CreateAsync(int StudentLimit, GroupCategory groupCategory);
        public Task<string> UpdateAsync(int id, int limit);
        public Task<string> RemoveAsync(int id);
        public Task<Group> GetAsync(int id);
        public Task<List<Group>> GetAllAsync();
        public Task<List<Student>> GetStudentsByGroup(string no);
    }
}