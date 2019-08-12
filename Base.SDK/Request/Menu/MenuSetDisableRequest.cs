using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Menu
{
    public class MenuSetDisableRequest : BaseApiRequest<SingleApiResponse>
    {
        public int M_ID { get; set; }
        public bool M_DISABLED { get; set; }
    }
}
