using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class SS_USER : EntityBase
    {
        [Key]
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
        public string U_PWD { get; set; }
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

        public override bool Equals(object obj)
        {
            return obj is SS_USER && Equals((SS_USER)obj);
        }

        public bool Equals(SS_USER other)
        {
            return U_ID == other.U_ID &&
                   U_NAME == other.U_NAME &&
                   U_PWD == other.U_PWD &&
                   Manage_ID == other.Manage_ID &&
                   U_ENCRYPT == other.U_ENCRYPT &&
                   U_REALNAME == other.U_REALNAME &&
                   U_EMAIL == other.U_EMAIL &&
                   U_MOBILE == other.U_MOBILE &&
                   U_TEL == other.U_TEL &&
                   U_PREVLOGINTIME == other.U_PREVLOGINTIME &&
                   U_PREVLOGINIP == other.U_PREVLOGINIP &&
                   U_LASTLOGINTIME == other.U_LASTLOGINTIME &&
                   U_LASTLOGINIP == other.U_LASTLOGINIP &&
                   U_LOGINTIMES == other.U_LOGINTIMES &&
                   U_ERRORTIMES == other.U_ERRORTIMES &&
                   U_CREATETIME == other.U_CREATETIME &&
                   U_UPDATETIME == other.U_UPDATETIME &&
                   U_DISABLED == other.U_DISABLED &&
                   U_LASTMODIFYPASSWORDTIME == other.U_LASTMODIFYPASSWORDTIME &&
                   U_LOCKSCREEN == other.U_LOCKSCREEN &&
                   U_PHOTO == other.U_PHOTO;
        }
    }
}
