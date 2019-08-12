using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.Repository.Repo;
using Base.SDK.Request.Role;
using Base.SDK.Response;

namespace Base.BusinessService
{
    public class RoleBiz: IRoleBiz
    {
        private static readonly RoleRepo RoleRepo = new RoleRepo();
        public SingleApiResponse GetList(RoleGetListRequest req)
        {
            var result = RoleRepo.GetList<SS_ROLE>(req);
            return new SingleApiResponse(){Data = result};
        }

        public SingleApiResponse Save(RoleSaveRequest req)
        {
            if (req.R_ID.HasValue)
            {
                return EditRole(req);
            }

            return AddRole(req);
        }

        private SingleApiResponse AddRole(RoleSaveRequest req)
        {
            var user = new SS_ROLE()
            {
                R_NAME=req.R_NAME,
                R_DESC=req.R_DESC,
                Branch_ID=0,
                R_ORDERID =req.R_ORDERID
            };

            var id = RepoBase.Instance.Add(user);
            return new SingleApiResponse();
        }

        private SingleApiResponse EditRole(RoleSaveRequest req)
        {
            var role = RepoBase.Instance.GetWhere<SS_ROLE>(x => x.R_ID == req.R_ID).FirstOrDefault();
            if (role == null) return new SingleApiResponse() { BizErrorMsg = "无此角色", ErrCode = 1001 };

            role.R_NAME = req.R_NAME;
            role.R_DESC = req.R_DESC;
            role.R_ORDERID = req.R_ORDERID;

            RepoBase.Instance.Update(role);
            return new SingleApiResponse();
        }
    }
}
