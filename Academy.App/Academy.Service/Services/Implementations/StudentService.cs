using Academy.Core.Models;
using Academy.Core.Repositories.GroupRepository;
using Academy.Data.Repositories.GroupRepository;
using Academy.Service.Services.Interfaces;


namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IGroupRepository _groupRepository=new GroupRepository();
        public async Task<string> CreateAsync(string fullname, string email,int age,double average,string groupno)
        {
            Group group = await _groupRepository.GetAsync(x=>x.GroupNo==groupno);
      
            if (group == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                return "GroupNo is not valid";
            }

            if(group.StudentLimit==group.Students.Count)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                return "Group is full";
            }

            Student student = new Student(fullname,age, email, average,group);
            student.CreatedDate= DateTime.Now;
            group.Students.Add(student);

           //await _groupRepository.UpdateAsync(group);
           Console.ForegroundColor=ConsoleColor.Green;
            return "Succesfuly created";
        }

        public async Task<List<Student>> GetAllAsync()
        {
            List<Group> groups=await _groupRepository.GetAllAsync();

            List<Student> students = new List<Student>();

            foreach (Group group in groups)
            {
                students.AddRange(group.Students);
            }
            return students;
        }

        public async Task<Student> GetAsync(int id)
        {
            List<Group> groups =await _groupRepository.GetAllAsync();

            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if (student != null)
                {
                    return student;
                }
            }
            return null;
        }

        #region Ilkin Danziyev
        //public async Task<Student> GetAsync(int id)
        //{
        //    Student? student = _groupRepository.GetAsync(x => x.Students.Any(x => x.Id == id))
        //        .Result
        //        .Students.Find(x=>x.Id==id);

        //    return student;
        //}
        #endregion

        public async Task<string> RemoveAsync(int id)
        {
            List<Group> groups = await _groupRepository.GetAllAsync();

            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if (student != null)
                {
                    item.Students.Remove(student);
                    //await _groupRepository.UpdateAsync(item);
                    Console.ForegroundColor= ConsoleColor.Green;
                    return "Succesfuly removed";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            return "Student is not found";
        }

        public async Task<string> UpdateAsync(int id,string fullname,double average,int age,string Email)
        {
            List<Group> groups = await _groupRepository.GetAllAsync();

            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if (student != null)
                {
                  

                    student.FullName = fullname;
                    student.Avarage = average;
                    student.Age = age;
                    student.Email = Email;
                    student.UpdatedDate= DateTime.Now;
                    //await _groupRepository.UpdateAsync(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfuly Updated";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            return "Student is not found";
        }
    }
}
