using System.Linq;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.Repository.Repo;
using Base.SDK.Model.MenuPurviewCode;
using Base.SDK.Request.MenuPurviewcode;
using Base.SDK.Response;

namespace Base.BusinessService
{
    public class MenuPurviewcodeBiz : IMenuPurviewcodeBiz
    {
        private static readonly MenuPurviewcodeRepo MenuPurviewcodeRepo = new MenuPurviewcodeRepo();
        public SingleApiResponse MenuGetList(MenuPurviewcodeGetListRequest req)
        {
            var result = RepoBase.Instance.GetWhere<SS_MENU_PURVIEWCODE>(x => x.M_ID == req.M_ID);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse RoleGetList(RolePurviewcodeGetListRequest req)
        {
            var purviewCodeDtos = MenuPurviewcodeRepo.PurviewcodeGetList<MenuPurviewCodeDto>(R_ID:req.R_ID);
            var result = purviewCodeDtos.GroupBy(x => new {x.M_NAME, x.M_NAME_C}).Select(p=>new
            {
                M_NAME = p.Key.M_NAME,
                M_NAME_C = p.Key.M_NAME_C,
                list=p
            });
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse UserGetList(UserPurviewcodeGetListRequest req)
        {
            var purviewCodeDtos = MenuPurviewcodeRepo.PurviewcodeGetList<MenuPurviewCodeDto>(U_Id: req.U_ID);
            var result = purviewCodeDtos.GroupBy(x => new { x.M_NAME, x.M_NAME_C }).Select(p => new
            {
                M_NAME = p.Key.M_NAME,
                M_NAME_C = p.Key.M_NAME_C,
                list = p
            });
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse RoleSet(RolePurviewcodeSetRequest req)
        {
            var role = RepoBase.Instance.GetWhere<SS_ROLE>(x => x.R_ID == req.R_ID).FirstOrDefault();
            if (role == null) return new SingleApiResponse() { BizErrorMsg = "没有此角色", ErrCode = 1001 };
            var roleMenuPurviewcodes = RepoBase.Instance.GetWhere<SS_ROLE_MENU_PURVIEWCODE>(x => x.R_ID == req.R_ID).Select(x=>x.MPC_CODE);
            var deleteList = roleMenuPurviewcodes.Except(req.MPC_CODEs);
            var addList = req.MPC_CODEs.Except(roleMenuPurviewcodes).Select(x=>new SS_ROLE_MENU_PURVIEWCODE(){R_ID = req.R_ID,MPC_CODE = x});
            foreach (var purvieCode in deleteList)
            {
                MenuPurviewcodeRepo.Delete(req.R_ID, purvieCode);
            }

            RepoBase.Instance.BulkInsert(addList, "");
            return new SingleApiResponse();
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
