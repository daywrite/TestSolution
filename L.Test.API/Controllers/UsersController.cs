using L.Test.Data;
using L.Test.Models;
using L.Test.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace L.Test.API.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository UserDAL = new UserRepository();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllCommunitys()
        {
            Result<IQueryable<User>> result = new Result<IQueryable<User>>();
            var jsonResult = new JsonResult();
            OperationResult OResult = null;

            try
            {
                result.Content = UserDAL.Entities;
                OResult = new OperationResult(OperationResultType.Success, "获取成功");
            }
            catch (Exception ee)
            {
                OResult = new OperationResult(OperationResultType.Error, ee.Message);
            }

            finally
            {
                result.State = OResult.ResultType.ToString();
                result.Msg = OResult.Message;
                jsonResult.Data = result;
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            }
            return jsonResult;
        }

        /// <summary>
        /// 通过ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetCommunity(int id)
        {
            Result<User> result = new Result<User>();
            var jsonResult = new JsonResult();
            OperationResult OResult = null;
            try
            {
                result.Content = UserDAL.GetByKey(id);
                //result.Content.picture = PictureBLL.Pictures.Where(p => p.ParentID == result.Content.Id && p.Type=="Community" && p.IsDefault == true).FirstOrDefault();
                if (result.Content != null)
                {
                    OResult = new OperationResult(OperationResultType.Success, "获取成功");
                }
                else
                {
                    OResult = new OperationResult(OperationResultType.Error, "获取失败");
                }

            }
            catch (Exception ee)
            {
                OResult = new OperationResult(OperationResultType.Error, ee.Message);
            }

            finally
            {
                result.State = OResult.ResultType.ToString();
                result.Msg = OResult.Message;
                jsonResult.Data = result;
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            }
            return jsonResult;
        }

        /// <summary>
        /// 添加小区信息/更新小区信息
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public JsonResult PostCommunity([FromBody]User user)
        {
            Result<User> result = new Result<User>();
            var jsonResult = new JsonResult();
            OperationResult OResult = null;
            try
            {
                if (user.Id == 0)
                {
                    int ret = UserDAL.Insert(user);
                }
                else
                {
                    int ret = UserDAL.Update(user);
                }
            }
            catch (Exception ee)
            {
                OResult = new OperationResult(OperationResultType.Error, ee.Message);
            }

            finally
            {
                result.State = OResult.ResultType.ToString();
                result.Msg = OResult.Message;
                jsonResult.Data = result;
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            }

            return jsonResult;
        }

        /// <summary>
        /// 更新小区信息
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        //public JsonResult PutCommunity(int id, [FromBody]Community community)
        //{
        //    Result<string> result = new Result<string>();
        //    var jsonResult = new JsonResult();
        //    OperationResult OResult = null;
        //    try
        //    {
        //        community.Id = id;
        //        OResult = CommunityBLL.UpdateCommunity(community);
        //    }
        //    catch (Exception ee)
        //    {
        //        OResult = new OperationResult(OperationResultType.Error, ee.Message);
        //    }

        //    finally
        //    {
        //        result.State = OResult.ResultType.ToString();
        //        result.Msg = OResult.Message;
        //        jsonResult.Data = result;
        //        jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    }

        //    return jsonResult;
        //}

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.ActionName("UpdateCommunity")]
        //public JsonResult UpdateCommunity(int id, [FromBody]Community community)
        //{
        //    Result<string> result = new Result<string>();
        //    var jsonResult = new JsonResult();
        //    OperationResult OResult = null;
        //    try
        //    {
        //        community.Id = id;
        //        OResult = CommunityBLL.UpdateCommunity(community);
        //    }
        //    catch (Exception ee)
        //    {
        //        OResult = new OperationResult(OperationResultType.Error, ee.Message);
        //    }

        //    finally
        //    {
        //        result.State = OResult.ResultType.ToString();
        //        result.Msg = OResult.Message;
        //        jsonResult.Data = result;
        //        jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    }

        //    return jsonResult;
        //}
        /// <summary>
        /// 删除小区信息
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public JsonResult DeleteCommunity(int id)
        {
            Result<string> result = new Result<string>();
            var jsonResult = new JsonResult();
            OperationResult OResult = null;
            try
            {
                int ret = UserDAL.Delete(id);
            }
            catch (Exception ee)
            {
                OResult = new OperationResult(OperationResultType.Error, ee.Message);
            }

            finally
            {
                result.State = OResult.ResultType.ToString();
                result.Msg = OResult.Message;
                jsonResult.Data = result;
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            }

            return jsonResult;
        }
    }
}
