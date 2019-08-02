using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Api.AuthHelper.OverWrite;
using Base.Common.Token;
using Base.IBusinessService;
using Base.SDK.Request.User;
using Base.SDK.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public IUserBiz UserBiz { get; set; }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]//不受授权控制，任何人都可访问
        public SingleApiResponse Login([FromBody]UserLoginRequest req)
        {
            return UserBiz.Login(req);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [Authorize("Permission")]
        public SingleApiResponse Get([FromBody]UserInfoGetRequest req)
        {
            return UserBiz.Get(req);
        }
    }
}