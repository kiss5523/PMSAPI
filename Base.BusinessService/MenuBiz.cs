using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.SDK.Request.Menu;
using Base.SDK.Response;
using System.Linq;

namespace Base.BusinessService
{
    public class MenuBiz : IMenuBiz
    {
        private static readonly MenuRepo MenuRepo = new MenuRepo();
        public SingleApiResponse MenuGetList(MenuGetListRequest req)
        {
            var result = MenuRepo.MenuGetList<SS_MENU>(req);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse ChangeSort(MenuChangeSortRequest req)
        {
            var result = MenuRepo.ChangeSort(req);
            return result ? new SingleApiResponse() { Data = "移动成功" } : new SingleApiResponse() { ErrMsg = "移动失败" };
        }

        public SingleApiResponse Save(MenuSaveRequest req)
        {
            var menu = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_NAME == req.M_NAME_C).FirstOrDefault();
            if (menu != null) return new SingleApiResponse() { ErrMsg = "此菜单已存在!", ErrCode = 1001 };

            if (req.M_ID.HasValue)
                return MenuEdit(req);
            return MenuAdd(req);
        }

        public SingleApiResponse SetDisable(MenuSetDisableRequest req)
        {
            var menu = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_ID == req.M_ID).FirstOrDefault();
            if (menu == null) return new SingleApiResponse() { BizErrorMsg = "无此菜单", ErrCode = 1001 };
            menu.M_DISABLED = req.M_DISABLED;
            RepoBase.Instance.Update(menu);
            return new SingleApiResponse();
        }

        private SingleApiResponse MenuEdit(MenuSaveRequest req)
        {
            var menu = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_ID == req.M_ID.Value).FirstOrDefault();
            if (menu == null) return new SingleApiResponse() { ErrMsg = "此菜单不存在!", ErrCode = 1001 };
            menu.M_PARENTID = req.M_PARENTID;
            menu.M_NAME_C = req.M_NAME_C;
            menu.M_CODE = req.M_CODE;
            menu.M_PATH = req.M_PATH;
            menu.M_ICON = req.M_ICON;
            menu.M_DISABLED = req.M_DISABLED;
            RepoBase.Instance.Update(menu);
            return new SingleApiResponse();
        }

        private SingleApiResponse MenuAdd(MenuSaveRequest req)
        {
            var menus = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_PARENTID == req.M_PARENTID);
            var maxOrderId = menus.Max(x => x.M_ORDERID);
            var menu = new SS_MENU()
            {
                M_PARENTID = req.M_PARENTID,
                M_NAME = req.M_NAME_C,
                M_NAME_C = req.M_NAME_C,
                M_CODE = req.M_CODE,
                M_PATH = req.M_PATH,
                M_ICON = req.M_ICON,
                M_ORDERID = maxOrderId + 1,
                M_ORDERPATH = "",
                M_LINK = ""
            };
            RepoBase.Instance.Add(menu);
            return new SingleApiResponse();
        }
    }
}
