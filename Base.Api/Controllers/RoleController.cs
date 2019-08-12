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
    }
}
