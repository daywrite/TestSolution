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

    public class TestTest
    {
        [Test]
        public void AddUser()
        {
            string strUri = @"http://localhost:8492/api/Test";
            EHttpMethod Method = EHttpMethod.Post;
            string queryCondition = "";

            User u = new User();
            u.Id = 0;
            u.UserName = "demo";
            u.RealName = "demo";
            u.Role = "9";
            u.PassWord = "123456";
            u.IsDeleted = false;
            u.AddDate = DateTime.Now;

            Object objToSend = u;
            long tick = 0;

            User _user = ClientHelper.JsonRequest<User>(strUri, Method, queryCondition, objToSend, tick);
        }
    }
}
