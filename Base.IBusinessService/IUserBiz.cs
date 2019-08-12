using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Request.User;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IUserBiz
    {
        SingleApiResponse Login( UserLoginRequest req);

        SingleApiResponse Get(UserInfoGetRequest req);

        SingleApiResponse GetList(UserInfoGetListRequest req);

        SingleApiResponse Save( UserInfoSaveRequest req);

        SingleApiResponse SetDisable(UserSetDisableRequest req);
    }
}
