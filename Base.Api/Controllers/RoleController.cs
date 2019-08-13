using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.BusinessService;
using Base.IBusinessService;
using Base.SDK.Request.Role;
using Base.SDK.Response;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        public IRoleBiz IRoleBiz { get; set; }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("GetList")]
        //[Authorize("Permission")]
        public SingleApiResponse GetList([FromBody]RoleGetListRequest req)
        {
            return IRoleBiz.GetList(req);
        }

        /// <summary>
        /// 角色Save
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        //[Authorize("Permission")]
        public SingleApiResponse Save([FromBody]RoleSaveRequest req)
        {
            return IRoleBiz.Save(req);
        }

        /// <summary>
        /// 角色下成员
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("MemberGetList")]
        //[Authorize("Permission")]
        public SingleApiResponse MemberGetList([FromBody]MemberGetListRequest req)
        {
            return IRoleBiz.MemberGetList(req);
        }

        /// <summary>
        /// 不在此角色下的成员
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("OtherMemberGetList")]
        //[Authorize("Permission")]
        public SingleApiResponse OtherMemberGetList([FromBody]OtherMemberGetListRequest req)
        {
            return IRoleBiz.OtherMemberGetList(req);
        }

        /// <summary>
        /// 添加成员到此角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("MemberAdd")]
        //[Authorize("Permission")]
        public SingleApiResponse MemberAdd([FromBody]MemberAddRequest req)
        {
            return IRoleBiz.MemberAdd(req);
        }

        /// <summary>
        /// 从此角色删除成员
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("MemberDelete")]
        //[Authorize("Permission")]
        public SingleApiResponse MemberDelete([FromBody]MemberDeleteRequest req)
        {
            return IRoleBiz.MemberDelete(req);
        }
    }
}
