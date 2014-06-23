using L.Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data
{
    public class UserExtendCreate : EntityTypeConfiguration<UserExtend>
    {
        public UserExtendCreate()
        {
            HasRequired(p => p.User).WithMany(c => c.UserExtends).HasForeignKey(p => p.UserID);
        }
    }
}
