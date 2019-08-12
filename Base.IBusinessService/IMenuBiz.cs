using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Request.Menu;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IMenuBiz
    {
        SingleApiResponse MenuGetList(MenuGetListRequest req);

        SingleApiResponse ChangeSort( MenuChangeSortRequest req);

        SingleApiResponse Save(MenuSaveRequest req);

        SingleApiResponse SetDisable(MenuSetDisableRequest req);
    }
}
