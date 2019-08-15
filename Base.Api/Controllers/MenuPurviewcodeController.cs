using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.BusinessService;
using Base.IBusinessService;
using Base.SDK.Request.Menu;
using Base.SDK.Request.MenuPurviewcode;
using Base.SDK.Request.User;
using Base.SDK.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers
{
    [Route("api/[controller]")]
    public class MenuPurviewcodeController: Controller
    {
        public IMenuPurviewcodeBiz MenuPurviewcodeBiz { get; set; }

        /// <summary>
        /// 获取菜单权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("MenuGetList")]
        [Authorize("Permission")]
        public SingleApiResponse MenuGetList([FromBody]MenuPurviewcodeGetListRequest req)
        {
            return MenuPurviewcodeBiz.MenuGetList(req);
        }

        /// <summary>
        /// 获取角色下权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("RoleGetList")]
        [Authorize("Permission")]
        public SingleApiResponse RoleGetList([FromBody]RolePurviewcodeGetListRequest req)
        {
            return MenuPurviewcodeBiz.RoleGetList(req);
        }

        /// <summary>
        /// 获取用户下权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("UserGetList")]
        [Authorize("Permission")]
        public SingleApiResponse UserGetList([FromBody]UserPurviewcodeGetListRequest req)
        {
            return MenuPurviewcodeBiz.UserGetList(req);
        }

        /// <summary>
        /// 设置角色下权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("RoleSet")]
        [Authorize("Permission")]
        public SingleApiResponse RoleSet([FromBody]RolePurviewcodeSetRequest req)
        {
            return MenuPurviewcodeBiz.RoleSet(req);
        }

        /// <summary>
        /// 获取菜单权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        [Authorize("Permission")]
        public SingleApiResponse Save([FromBody]MenuPurviewcodeSaveRequest req)
        {
            return MenuPurviewcodeBiz.Save(req);
        }
    }
}
