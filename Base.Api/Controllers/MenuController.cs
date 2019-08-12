using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.BusinessService;
using Base.IBusinessService;
using Base.SDK.Request.Menu;
using Base.SDK.Request.User;
using Base.SDK.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        public IMenuBiz MenuBiz { get; set; }
        /// <summary>
        /// 根据权限获取菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("GetList")]
        public SingleApiResponse GetList([FromBody]MenuGetListRequest req)
        {
            return MenuBiz.MenuGetList(req);
        }

        /// <summary>
        /// 菜单移动位置
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("ChangeSort")]
        public SingleApiResponse ChangeSort([FromBody]MenuChangeSortRequest req)
        {
            return MenuBiz.ChangeSort(req);
        }

        /// <summary>
        /// 菜单保存
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public SingleApiResponse Save([FromBody]MenuSaveRequest req)
        {
            return MenuBiz.Save(req);
        }

        /// <summary>
        /// 菜单保存
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("SetDisable")]
        public SingleApiResponse SetDisable([FromBody]MenuSetDisableRequest req)
        {
            return MenuBiz.SetDisable(req);
        }
    }
}