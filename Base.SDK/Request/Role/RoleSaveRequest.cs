using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Role
{
    public class RoleSaveRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? R_ID { get; set; }
        public string R_NAME { get; set; }
        public string R_DESC { get; set; }
        public int R_ORDERID { get; set; }
    }
}
