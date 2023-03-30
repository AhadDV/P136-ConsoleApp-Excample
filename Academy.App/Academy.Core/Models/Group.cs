using Academy.Core.Enums;
using Academy.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Models
{
    public class Group:BaseModel
    {
        private static int _id;
        public string GroupNo { get; set; }
        public List<Student> Students;
        public GroupCategory Category { get; set; }
        public int StudentLimit { get; set; }

        public Group(GroupCategory category,int studentLimit)
        {
            _id++;
            Id= _id;
            Students=new List<Student>();
            Category = category;
            StudentLimit=studentLimit;
            GroupNo = $"{category.ToString()[0]}-00{Id}";
        }

        public override string ToString()
        {
            return $"Id:{Id} GroupNo: {GroupNo} Category:{Category} StudentLimit:{StudentLimit}";
        }
    }
}
