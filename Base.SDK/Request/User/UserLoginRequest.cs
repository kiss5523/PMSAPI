using Base.SDK.Base;
using Base.SDK.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.SDK.Request.User
{
    public class UserLoginRequest : BaseApiRequest<SingleApiResponse>
    {
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}
