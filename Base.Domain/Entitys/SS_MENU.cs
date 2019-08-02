using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class SS_MENU:EntityBase
    {
        [Key]
        public int M_ID { get; set; }
        public int M_PARENTID { get; set; }
        public int M_ORDERID { get; set; }
        public string M_NAME { get; set; }
        public string M_NAME_C { get; set; }
        public string M_NAME_J { get; set; }
        public string M_CODE { get; set; }
        public string M_PATH { get; set; }
        public string M_ORDERPATH { get; set; }
        public byte M_LEVEL { get; set; }
        public string M_ICON { get; set; }
        public string M_LINK { get; set; }
        public bool M_DISABLED { get; set; }
        public int M_CHILDREN { get; set; }
    }
}
