using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.User
{
    public class UserSetDisableRequest : BaseApiRequest<SingleApiResponse>
    {
        public int U_ID { get; set; }
        public bool U_DISABLED { get; set; }
    }
}
