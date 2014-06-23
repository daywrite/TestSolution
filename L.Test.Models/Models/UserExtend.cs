using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Models
{
    public class UserExtend : EntityBase<int>
    {
        public UserExtend() { }

        public int UserID { get; set; }

        public string TelePhone { get; set; }

        public User User { get; set; }
    }
}
