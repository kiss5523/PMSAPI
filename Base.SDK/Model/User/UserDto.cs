using System;
using System.Collections.Generic;
using System.Text;

namespace Base.SDK.Model.User
{
    public class UserDto
    {
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
        public int Manage_ID { get; set; }
        public string U_ENCRYPT { get; set; }
        public string U_REALNAME { get; set; }
        public string U_EMAIL { get; set; }
        public string U_MOBILE { get; set; }
        public string U_TEL { get; set; }
        public DateTime U_PREVLOGINTIME { get; set; }
        public string U_PREVLOGINIP { get; set; }
        public DateTime U_LASTLOGINTIME { get; set; }
        public string U_LASTLOGINIP { get; set; }
        public int U_LOGINTIMES { get; set; }
        public int U_ERRORTIMES { get; set; }
        public DateTime U_CREATETIME { get; set; }
        public DateTime U_UPDATETIME { get; set; }
        public bool U_DISABLED { get; set; }
        public DateTime U_LASTMODIFYPASSWORDTIME { get; set; }
        public bool U_LOCKSCREEN { get; set; }
        public string U_PHOTO { get; set; }
    }
}
