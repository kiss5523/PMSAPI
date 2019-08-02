using Base.Common.Helper;
using Base.Common.Token;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.Repository.Repo;
using Base.SDK.Model.User;
using Base.SDK.Request.User;
using Base.SDK.Response;
using System.Linq;

namespace Base.BusinessService
{
    public class UserBiz : IUserBiz
    {
        private static readonly UserRepo UserRepo = new UserRepo();
        public SingleApiResponse Login(UserLoginRequest req)
        {
            var result = RepoBase.Instance.GetWhere<SS_USER>(x => x.U_NAME == req.userName).FirstOrDefault();

            if (result != null && result.U_ID > 0)
            {
                string pwd1 = MD5Encrypt.MD5(req.passWord + result.U_ENCRYPT);
                if (!result.U_DISABLED)
                {
                    if (result.U_PWD == pwd1)
                    {
                        TokenModelJwt tokenModel = new TokenModelJwt { Uid = result.U_ID, Role = result.U_ID.ToString() };
                        var jwtStr = JwtHelper.IssueJWT(tokenModel); //登录，获取到一定规则的 Token 令牌
                        return new SingleApiResponse() { Data = new LoginDto() { U_ID = result.U_ID, Token = $"Bearer {jwtStr}" } };

                    }
                    return new SingleApiResponse() { ErrCode = 105, BizErrorMsg = "密码错误" };
                }
                return new SingleApiResponse() { ErrCode = 104, BizErrorMsg = "登录系统，该用户状态为禁止登录" };
            }
            return new SingleApiResponse() { ErrCode = 103, BizErrorMsg = "用户名不存在" };
        }

        public SingleApiResponse Get(UserInfoGetRequest req)
        {
            var result = UserRepo.GetModelByUserName<UserDto>(req);

            return new SingleApiResponse() { Data = result };
        }
    }
}
