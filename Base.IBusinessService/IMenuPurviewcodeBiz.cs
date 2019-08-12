using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Request.MenuPurviewcode;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IMenuPurviewcodeBiz
    {
        SingleApiResponse GetList(MenuPurviewcodeGetListRequest req);

        SingleApiResponse Save(MenuPurviewcodeSaveRequest req);
    }
}
