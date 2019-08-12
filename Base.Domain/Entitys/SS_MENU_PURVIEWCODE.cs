using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class SS_MENU_PURVIEWCODE: EntityBase
    {
        [Key]
        public int MPC_ID { get; set; }
        public int M_ID { get; set; }
        public string MPC_NAME { get; set; }
        public string MPC_NAME_C { get; set; }
        public string MPC_NAME_J { get; set; }
        public string MPC_CODE { get; set; }
        public bool MPC_DISABLED { get; set; }
    }
}
