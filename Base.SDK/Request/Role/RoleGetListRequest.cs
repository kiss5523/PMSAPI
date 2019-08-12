using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Role
{
    public class RoleGetListRequest : BaseApiRequest<SingleApiResponse>
    {
        public string R_NAME { get; set; }
    }
}
