using L.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
