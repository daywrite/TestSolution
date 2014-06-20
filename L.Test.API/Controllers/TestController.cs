using L.Test.Data;
using L.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace L.Test.API.Controllers
{
    public class TestController : ApiController
    {
        static readonly IUserRepository UserDAL = new UserRepository();

        /// <summary>
        /// 通过主键ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(int id)
        {
            User u = UserDAL.GetByKey(id);

            if (u == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return u;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public HttpResponseMessage PostUser(User user)
        {
            int ret = UserDAL.Insert(user);

            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            return response;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public void PutUser(int id, User user)
        {
            user.Id = id;

            if (UserDAL.Update(user) == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteUser(int id)
        {
            UserDAL.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
