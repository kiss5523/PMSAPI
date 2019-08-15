using Base.Common.Helper;
using Base.Common.Token;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.Repository.Repo;
using Base.SDK.Model.User;
using Base.SDK.Request.User;
using Base.SDK.Response;
using System;
using System.Linq;

namespace Base.BusinessService
{
    public class UserBiz : IUserBiz
    {
        private static readonly UserRepo UserRepo = new UserRepo();
        private static readonly RoleRepo RoleRepo = new RoleRepo();
        private static readonly RoleUserRepo RoleUserRepo = new RoleUserRepo();
        public SingleApiResponse Login(UserLoginRequest req)
        {
            var user = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_NAME == req.userName).FirstOrDefault();

            if (user != null && user.U_ID > 0)
            {
                string pwd1 = MD5Encrypt.MD5(req.passWord + user.U_ENCRYPT);
                if (!user.U_DISABLED)
                {
                    if (user.U_PWD == pwd1)
                    {
                        //TokenModelJwt tokenModel = new TokenModelJwt { Uid = user.U_ID, Role = user.U_ID.ToString() };
                        var roles = RoleRepo.GetListByUid<SS_ROLE>(new UserInfoGetRequest(){ U_ID =user.U_ID}).Select(x=>x.R_ID);
                        TokenModelJwt tokenModel = new TokenModelJwt { Uid = user.U_ID, Role = string.Join(",",roles) };
                        var jwtStr = JwtHelper.IssueJWT(tokenModel); //登录，获取到一定规则的 Token 令牌

                        #region 更新user
                        //登录次数
                        user.U_LOGINTIMES++;

                        //上次登录时间和ip
                        user.U_PREVLOGINIP = user.U_LASTLOGINIP;
                        user.U_PREVLOGINTIME = user.U_UPDATETIME;

                        //本次登录时间和ip
                        user.U_LASTLOGINTIME = DateTime.Now;
                        user.U_UPDATETIME = DateTime.Now;
                        user.U_LASTLOGINIP = req.Ip;

                        RepoBase.Instance.Update(user);

                        #endregion

                        return new SingleApiResponse() { Data = new LoginDto() { U_ID = user.U_ID, Token = $"Bearer {jwtStr}" } };

                    }
                    return new SingleApiResponse() { ErrCode = 105, BizErrorMsg = "密码错误" };
                }
                return new SingleApiResponse() { ErrCode = 104, BizErrorMsg = "登录系统，该用户状态为禁止登录" };
            }
            return new SingleApiResponse() { ErrCode = 103, BizErrorMsg = "用户名不存在" };
        }

        public SingleApiResponse Get(UserInfoGetRequest req)
        {
            var result = RepoBase.Instance.GetWhere<SS_USER, UserDto>(x => x.U_ID == req.U_ID.Value).FirstOrDefault();
            //用户权限
            var roles = RoleRepo.GetListByUid<SS_ROLE>(req);
            result.U_RoleIds = roles.Select(x => x.R_ID).ToArray();
            result.U_Roles = string.Join(',', roles.Select(x => x.R_NAME));
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse GetList(UserInfoGetListRequest req)
        {
            var result = UserRepo.GetList<SS_USER>(req);
            return new SingleApiResponse() { Data = result };
        }

        public SingleApiResponse Save(UserInfoSaveRequest req)
        {
            if (req.U_ID.HasValue)
            {
                return EditUser(req);
            }

            return AddUser(req);
        }

        public SingleApiResponse SetDisable(UserSetDisableRequest req)
        {
            var user = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_ID == req.U_ID).FirstOrDefault();
            if(user==null) return new SingleApiResponse() { BizErrorMsg = "无此用户", ErrCode = 1001 };
            user.U_DISABLED = req.U_DISABLED;
            RepoBase.Instance.Update(user);
            return new SingleApiResponse();
        }

        private SingleApiResponse EditUser(UserInfoSaveRequest req)
        {
            var user = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_ID == req.U_ID).FirstOrDefault();
            if (user == null) return new SingleApiResponse() { BizErrorMsg = "无此用户", ErrCode = 1001 };
            user.U_NAME = req.U_NAME;

            if (!string.IsNullOrEmpty(req.U_PWD))
            {
                string encrypt = RandomHelper.CreateRandomStr(6);
                user.U_ENCRYPT = encrypt;
                user.U_PWD = MD5Encrypt.GetPass(req.U_PWD, encrypt);
            }

            user.U_REALNAME = req.U_REALNAME;
            user.U_EMAIL = req.U_EMAIL;
            user.U_MOBILE = req.U_MOBILE;
            user.U_TEL = req.U_TEL;
            user.U_DISABLED = req.U_DISABLED;
            user.U_PHOTO = req.U_PHOTO;
            user.U_UPDATETIME = DateTime.Now;

            RepoBase.Instance.Update(user);
            SetRoles(req.U_ID.Value, req.U_RoleIds);
            return new SingleApiResponse();
        }

        private SingleApiResponse AddUser(UserInfoSaveRequest req)
        {
            var user = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_NAME == req.U_NAME).FirstOrDefault();
            if (user != null) return new SingleApiResponse() { BizErrorMsg = "此用户已存在", ErrCode = 1002 };
            string encrypt = RandomHelper.CreateRandomStr(6);
            user = new SS_USER()
            {
                U_NAME = req.U_NAME,
                U_ENCRYPT = encrypt,
                U_PWD = MD5Encrypt.GetPass(req.U_PWD, encrypt),
                U_REALNAME = req.U_REALNAME,
                U_EMAIL = req.U_EMAIL,
                U_MOBILE = req.U_MOBILE,
                U_TEL = req.U_TEL,
                U_PHOTO = req.U_PHOTO,
                U_CREATETIME = DateTime.Now,
                U_UPDATETIME = DateTime.Now,
                U_LASTLOGINTIME = DateTime.Now,
                U_PREVLOGINTIME = DateTime.Now,
                U_LASTMODIFYPASSWORDTIME = DateTime.Now
            };

            var id= RepoBase.Instance.Add(user);
            SetRoles(Convert.ToInt32(id), req.U_RoleIds);
            return new SingleApiResponse();
        }

        private void SetRoles(int uId, int[] roleIds)
        {
            //删除原有权限
            RoleUserRepo.Delete(uid:uId);
            //Save新权限
            var newRoles = roleIds.Select(x => new SS_ROLE_USER(){U_ID = uId,R_ID = x}).ToList();
            RepoBase.Instance.BulkInsert(newRoles,"");
        }
    }
}
