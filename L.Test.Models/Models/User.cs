using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Models
{
    public class User : EntityBase<int>
    {
        public User()
        {
            UserExtends = new List<UserExtend>();
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 角色-Administrator, Normal
        /// </summary>
        public string Role { get; set; }

        public virtual ICollection<UserExtend> UserExtends { get; set; }
    }
}
