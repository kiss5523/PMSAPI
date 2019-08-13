using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Role
{
    public class MemberGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? R_ID { get; set; }
    }
}
