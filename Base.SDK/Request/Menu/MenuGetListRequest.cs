using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Menu
{
    public class MenuGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? U_ID { get; set; }

        public string M_NAME { get; set; }
    }
}
