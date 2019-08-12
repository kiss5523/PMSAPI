using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.Menu
{
    public class MenuSaveRequest :BaseApiRequest<SingleApiResponse>
    {
        public int? M_ID { get; set; }
        public int M_PARENTID { get; set; }
        public string M_NAME_C { get; set; }
        public string M_CODE { get; set; }
        public string M_PATH { get; set; }
        public string M_ICON { get; set; }   
        public bool M_DISABLED { get; set; }
    }
}
