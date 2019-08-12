using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.MenuPurviewcode
{
    public class MenuPurviewcodeSaveRequest : BaseApiRequest<SingleApiResponse>
    {
        public int? M_ID { get; set; }
        public int? MPC_ID { get; set; }
        public string MPC_NAME { get; set; }
        public string MPC_CODE { get; set; }
        public bool MPC_DISABLED { get; set; }
    }
}
