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
        [HttpPost("GetList")]
        public SingleApiResponse GetList([FromBody]MenuPurviewcodeGetListRequest req)
        {
            return MenuPurviewcodeBiz.GetList(req);
        }

        /// <summary>
        /// 获取菜单权益列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public SingleApiResponse Save([FromBody]MenuPurviewcodeSaveRequest req)
        {
            return MenuPurviewcodeBiz.Save(req);
        }
    }
}
