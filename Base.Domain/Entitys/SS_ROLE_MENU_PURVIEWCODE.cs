using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class SS_ROLE_MENU_PURVIEWCODE: EntityBase
    {
        [Key]
        public int R_ID { get; set; }
        public string MPC_CODE { get; set; }
    }
}
