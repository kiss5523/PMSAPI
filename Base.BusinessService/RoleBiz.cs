using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.Repository.Repo;
using Base.SDK.Request.Role;
using Base.SDK.Response;
using System;
using System.Linq;

namespace Base.BusinessService
{
    public class RoleBiz : IRoleBiz
    {
        private static readonly RoleRepo RoleRepo = new RoleRepo();
        private static readonly RoleUserRepo RoleUserRepo = new RoleUserRepo();
        public SingleApiResponse GetList(RoleGetListRequest req)
        {
            var result = RoleRepo.GetList<SS_ROLE>(req);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse Save(RoleSaveRequest req)
        {
            if (req.R_ID.HasValue)
            {
                return EditRole(req);
            }

            return AddRole(req);
        }

        public SingleApiResponse MemberGetList(MemberGetListRequest req)
        {
            var result = RoleRepo.MemberGetList<SS_USER>(req);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse OtherMemberGetList(OtherMemberGetListRequest req)
        {
            var users = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_DISABLED == false).ToList();
            var members = RoleRepo.MemberGetList<SS_USER>(new MemberGetListRequest() { R_ID = req.R_ID });
            users.RemoveAll(x => members.Contains(x));
            return new SingleApiResponse() { Data = users };
        }

        public SingleApiResponse MemberAdd(MemberAddRequest req)
        {
            var newRoles = req.U_IDS.Select(x => new SS_ROLE_USER() { U_ID = x, R_ID = req.R_ID }).ToList();
            RepoBase.Instance.BulkInsert(newRoles, "");
            return new SingleApiResponse();
        }

        public SingleApiResponse MemberDelete(MemberDeleteRequest req)
        {
            foreach (var U_ID in req.U_IDS)
            {
                RoleUserRepo.Delete(U_ID, req.R_ID);
            }
            return new SingleApiResponse();
        }

        private SingleApiResponse AddRole(RoleSaveRequest req)
        {
            var user = new SS_ROLE()
            {
                R_NAME = req.R_NAME,
                R_DESC = req.R_DESC,
                Branch_ID = 0,
                R_ORDERID = req.R_ORDERID
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
