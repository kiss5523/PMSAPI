﻿using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Request.Role;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IRoleBiz
    {
        SingleApiResponse GetList(RoleGetListRequest req);

        SingleApiResponse Save(RoleSaveRequest req);
    }
}