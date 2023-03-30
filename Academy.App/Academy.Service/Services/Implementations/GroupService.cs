using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories.GroupRepository;
using Academy.Data.Repositories.GroupRepository;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        public async Task<string> CreateAsync(int StudentLimit,GroupCategory groupCategory)
        {
            if (StudentLimit < 10 || StudentLimit > 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Student Limit Must be Between 10-20!!!";
            }
            Group group = new Group(groupCategory, StudentLimit);
            Console.ForegroundColor = ConsoleColor.Green;
            await _groupRepository.AddAsync(group);
            return "Succesfully Created";
        }

        public async Task<List<Group>> GetAllAsync()
            => await _groupRepository.GetAllAsync();

        public async Task<Group> GetAsync(int id)
        {
            Group group = await _groupRepository.GetAsync(x => x.Id == id);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found");
            }
            return group;
        }

        public async Task<List<Student>> GetStudentsByGroup(string no)
        {
            Group group = await _groupRepository.GetAsync(x => x.GroupNo == no);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found");
                return null;
            }
            return group.Students;
        }

        public async Task<string> RemoveAsync(int id)
        {
            

            Group group = await _groupRepository.GetAsync(x => x.Id == id);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Group is not found";
            }
            await _groupRepository.RemoveAsync(group);
            Console.ForegroundColor = ConsoleColor.Green;

            return "Succesfuly removed";
        }

        public async Task<string> UpdateAsync(int id,int limit)
        {

            Group group = await _groupRepository.GetAsync(x=>x.Id==id);


            if (group == null)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                return "Group not found";
            }

            if (limit < 10 || limit > 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Student Limit Must be Between 10-20!!!";
            }

             group.StudentLimit= limit;
            await  _groupRepository.UpdateAsync(group);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfuly updated";
        }
    }
}
