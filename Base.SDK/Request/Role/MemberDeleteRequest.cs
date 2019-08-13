using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Role
{
    public class MemberDeleteRequest : BaseApiRequest<SingleApiResponse>
    {
        public int R_ID { get; set; }
        public int[] U_IDS { get; set; }
    }
}
