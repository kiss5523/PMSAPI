using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.User
{
    public class UserInfoSaveRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? U_ID { get; set; }
        public string U_NAME { get; set; }
        public string U_PWD { get; set; }
        public int[] U_RoleIds { get; set; }
        public string U_REALNAME { get; set; }
        public string U_EMAIL { get; set; }
        public string U_MOBILE { get; set; }
        public string U_TEL { get; set; }    
        public bool U_DISABLED { get; set; }
        public string U_PHOTO { get; set; }
    }
}
