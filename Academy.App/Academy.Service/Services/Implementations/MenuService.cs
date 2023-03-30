using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IGroupService _groupService = new GroupService();
        private readonly IStudentService _studentService = new StudentService();
        public async Task ShowMenuAsync()
        {

            Show();
            int.TryParse(Console.ReadLine(), out int result);
            while (result != 0)
            {
                switch (result)
                {
                    case 1:
                        Console.Clear();
                      await CreateGroup();
                        break;
                    case 2:
                        Console.Clear();
                       await ShowAllGroup();
                        break;
                    case 3:
                        Console.Clear();
                        await ShowGroup();
                        break;
                    case 4:
                        Console.Clear();
                      await  UpdateGroup();
                        break;
                    case 5:
                        Console.Clear();
                       await RemoveGroup();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateStudent();
                        break;
                    case 7:
                        Console.Clear();

                        await ShowAllStudents();
                        break;
                    case 8:
                        Console.Clear();

                        await GetStudentById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateStudent();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveStudent();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("please choose valid option");
                        break;

                }
                Console.ForegroundColor = ConsoleColor.White;

                Show();
                int.TryParse(Console.ReadLine(), out result);
            }
        }

        private void Show()
        {
            Console.WriteLine("1.Create Group");
            Console.WriteLine("2.Show All Group");
            Console.WriteLine("3.Get Group By Id");
            Console.WriteLine("4.Update Group");
            Console.WriteLine("5.Remove Group");
            Console.WriteLine("6.Create Student");
            Console.WriteLine("7.Show All Student");
            Console.WriteLine("8.Get Studnet By Id");
            Console.WriteLine("9.Update Student");
            Console.WriteLine("10.Remove Student");
            Console.WriteLine("0.Remove Student");
        }
        private async Task CreateGroup()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add GroupLimit Count :");
            string StudentLimitStr = Console.ReadLine();
            int.TryParse(StudentLimitStr, out int StudentLimit);
            Console.WriteLine("Choose GroupCategory :");

            var Enums = Enum.GetValues(typeof(GroupCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int groupCategory);

            try
            {
                Enums.GetValue(groupCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("GroupCategory is not valid");
                return;
            }
           string message= await _groupService.CreateAsync(StudentLimit, (GroupCategory)groupCategory);
            Console.WriteLine(message);
        }
        private async Task ShowAllGroup()
        {
            List<Group> groups = await _groupService.GetAllAsync();
            Console.ForegroundColor=ConsoleColor.Blue;
            foreach (var item in groups)
            {
                Console.WriteLine(item);
            }
        }
        private async Task ShowGroup()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter group Id");
            int.TryParse(Console.ReadLine(),out int id);

            Group group = await _groupService.GetAsync(id);
         
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(group);
        }
        private async Task UpdateGroup()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add Group Id");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Add Group Limit");
            int.TryParse(Console.ReadLine(), out int Limit);

          string message=   await _groupService.UpdateAsync(id,Limit);
            Console.WriteLine(message);
        }
        private async Task RemoveGroup()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add Group Id");

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _groupService.RemoveAsync(id);
            Console.WriteLine(message);
        }

        private async Task CreateStudent()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter FullName");
            string fullname = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();

            Console.WriteLine("Enter Age");

            int.TryParse(Console.ReadLine(), out int age);

            Console.WriteLine("Enter average");

            double.TryParse(Console.ReadLine(), out double average);

            Console.WriteLine("Enter Group no");

            string GroupNo = Console.ReadLine();

            string message =await _studentService.CreateAsync(fullname,Email,age,average,GroupNo);

            Console.WriteLine(message);
        }

        private async Task ShowAllStudents()
        {
            List < Student > Students= await _studentService.GetAllAsync();

            Console.ForegroundColor=ConsoleColor.Blue;
            foreach (var item in Students)
            {
                Console.WriteLine(item);
            }

        }

        private async Task GetStudentById()
        {
            Console.WriteLine("enter student id");
            int.TryParse(Console.ReadLine(), out int id);
            Student student = await _studentService.GetAsync(id);
            Console.WriteLine(student);
        }

        private async Task UpdateStudent()
        {

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Id");

            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Enter FullName");
            string fullname = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();

            Console.WriteLine("Enter Age");

            int.TryParse(Console.ReadLine(), out int age);

            Console.WriteLine("Enter average");

            double.TryParse(Console.ReadLine(), out double average);

            string message = await _studentService.UpdateAsync(id,fullname,average,age,Email);
            Console.WriteLine(message);
        }

        private async Task RemoveStudent()
        {
            Console.WriteLine(" enter id");

            int.TryParse(Console.ReadLine(),out int id);
            string message=await _studentService.RemoveAsync(id);
            Console.WriteLine(message);
        }
    }
}
