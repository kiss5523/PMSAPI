using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.MenuPurviewcode
{
    public class RolePurviewcodeSetRequest: BaseApiRequest<SingleApiResponse>
    {
        public int R_ID { get; set; }

        public IEnumerable<string> MPC_CODEs { get; set; }
    }
}
