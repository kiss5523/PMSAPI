using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Menu
{
    public class MenuChangeSortRequest : BaseApiRequest<SingleApiResponse>
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int? M_ID { get; set; }

        /// <summary>
        /// 动作类型：MoveUp = 1,MoveDown = 2
        /// </summary>
        public int? ActionType { get; set; }
    }
}
