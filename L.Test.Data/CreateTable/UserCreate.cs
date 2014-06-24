using L.Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data
{
    /// <summary>
    /// 实体类-数据表映射——用户信息
    /// </summary>   
    public class UserCreate : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——用户信息
        /// </summary>
        public UserCreate()
        {
            //主键
            HasKey(c => c.Id);
            
            Property(c => c.UserName).IsRequired().HasMaxLength(20);
            Property(c => c.RealName).IsRequired().HasMaxLength(20);
            Property(c => c.Role).IsRequired().HasMaxLength(10);
            Property(c => c.PassWord).IsRequired().HasMaxLength(200);

            Property(p => p.IsDeleted).IsRequired().HasColumnType("bit");
            Property(p => p.AddDate).IsRequired().HasColumnType("DateTime");
        }
    }
}
