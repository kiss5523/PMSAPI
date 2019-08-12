using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class SS_ROLE:EntityBase
    {
        [Key]
        public int R_ID { get; set; }
        public string R_NAME { get; set; }
        public string R_DESC { get; set; }
        public int Branch_ID { get; set; }
        public int R_ORDERID { get; set; }
    }
}
