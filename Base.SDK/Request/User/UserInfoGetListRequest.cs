using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.User
{
    public class UserInfoGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        public string U_NAME { get; set; }

        public string U_REALNAME { get; set; }
    }
}
