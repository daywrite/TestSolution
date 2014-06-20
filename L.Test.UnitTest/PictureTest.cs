using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using L.Test.Models;
using L.Test.Data;
using Newtonsoft.Json;
namespace L.Test.UnitTest
{
    public class PictureTest
    {
        [Test]
        public void AddUser()
        {
            IUserRepository UserDAL = new UserRepository();

            User u = new User();

            u.Id = 0;
            u.UserName = "demo";
            u.RealName = "demo";
            u.Role = "9";
            u.PassWord = "123456";
            u.IsDeleted = false;
            u.AddDate = DateTime.Now;
            string SerialJM = JsonConvert.SerializeObject(u);
            UserDAL.Insert(u);
        }

        [Test]
        public void UpdateUser()
        {
            IUserRepository UserDAL = new UserRepository();

            User u = new User();

            u.Id = 2;
            u.UserName = "demo";
            u.RealName = "demo";
            u.Role = "9";
            u.PassWord = "654321";
            u.IsDeleted = false;
            u.AddDate = DateTime.Now;

            UserDAL.Update(u);
        }
    

    }
}
