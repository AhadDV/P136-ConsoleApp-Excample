using Academy.Core.Models;
using Academy.Core.Repositories.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Data.Repositories.GroupRepository
{
    public class GroupRepository:Repository<Group>,IGroupRepository
    {
    }
}
