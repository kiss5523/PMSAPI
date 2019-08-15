using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.MenuPurviewcode
{
    public class UserPurviewcodeGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? U_ID { get; set; }
    }
}
