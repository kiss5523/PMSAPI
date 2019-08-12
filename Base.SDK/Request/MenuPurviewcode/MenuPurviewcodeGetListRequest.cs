using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.MenuPurviewcode
{
    public class MenuPurviewcodeGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int M_ID { get; set; }
    }
}
