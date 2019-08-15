using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Request.MenuPurviewcode;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IMenuPurviewcodeBiz
    {
        SingleApiResponse MenuGetList(MenuPurviewcodeGetListRequest req);

        SingleApiResponse RoleGetList(RolePurviewcodeGetListRequest req);

        SingleApiResponse UserGetList(UserPurviewcodeGetListRequest req);

        SingleApiResponse RoleSet(RolePurviewcodeSetRequest req);

        SingleApiResponse Save(MenuPurviewcodeSaveRequest req);
    }
}
