using System;
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

        SingleApiResponse MemberGetList(MemberGetListRequest req);

        SingleApiResponse OtherMemberGetList(OtherMemberGetListRequest req);

        SingleApiResponse MemberAdd(MemberAddRequest req);

        SingleApiResponse MemberDelete(MemberDeleteRequest req);

        SingleApiResponse Delete(RoleDeleteRequest req);
    }
}
