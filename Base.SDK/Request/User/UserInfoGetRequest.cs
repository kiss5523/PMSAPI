using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.User
{
    public class UserInfoGetRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? U_ID { get; set; }
    }
}
