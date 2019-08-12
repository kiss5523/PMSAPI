using System.Linq;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.SDK.Request.MenuPurviewcode;
using Base.SDK.Response;

namespace Base.BusinessService
{
    public class MenuPurviewcodeBiz : IMenuPurviewcodeBiz
    {
        public SingleApiResponse GetList(MenuPurviewcodeGetListRequest req)
        {
            var result = RepoBase.Instance.GetWhere<SS_MENU_PURVIEWCODE>(x => x.M_ID == req.M_ID);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse Save(MenuPurviewcodeSaveRequest req)
        {

            if (req.MPC_ID.HasValue)
                return MenuPurviewcodeEdit(req);
            return MenuPurviewcodeAdd(req);
        }

        private SingleApiResponse MenuPurviewcodeAdd(MenuPurviewcodeSaveRequest req)
        {
           if(!req.M_ID.HasValue) return new SingleApiResponse() { ErrMsg = "请选择菜单!", ErrCode = 1002 };

            var menuPurviewcode = RepoBase.Instance.GetWhere<SS_MENU_PURVIEWCODE>(x => x.M_ID == req.M_ID && x.MPC_NAME==req.MPC_NAME).FirstOrDefault();
            if (menuPurviewcode != null) return new SingleApiResponse() { ErrMsg = "此权益已存在!", ErrCode = 1003 };
            menuPurviewcode=new SS_MENU_PURVIEWCODE()
           {
               M_ID = req.M_ID.Value,
               MPC_NAME = req.MPC_CODE,
               MPC_NAME_C = req.MPC_NAME,
               MPC_CODE = req.MPC_CODE
           };
            RepoBase.Instance.Add(menuPurviewcode);
            return new SingleApiResponse();
        }

        private SingleApiResponse MenuPurviewcodeEdit(MenuPurviewcodeSaveRequest req)
        {
            var menuPurviewcode = RepoBase.Instance.GetWhere<SS_MENU_PURVIEWCODE>(x => x.MPC_ID==req.MPC_ID).FirstOrDefault();
            if(menuPurviewcode==null) return new SingleApiResponse() { ErrMsg = "此权益不存在!", ErrCode = 1001 };
            menuPurviewcode.MPC_NAME = req.MPC_NAME;
            menuPurviewcode.MPC_NAME_C = req.MPC_NAME;
            menuPurviewcode.MPC_DISABLED = req.MPC_DISABLED;
            RepoBase.Instance.Update(menuPurviewcode);
            return  new SingleApiResponse();
        }
    }
}
