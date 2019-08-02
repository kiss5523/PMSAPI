using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Repository.Core;
using Base.SDK.Request.User;
using Dapper;

namespace Base.Repository.Repo
{
    public class UserRepo : RepositoryBase
    {
        public T GetModelByUserName<T>(UserInfoGetRequest req) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT * FROM SS_USER su WHERE 1=1 ");
            var param = new DynamicParameters();

            if (req.U_ID.HasValue)
            {
                sql.Append(" AND U_ID=@U_ID");
                param.Add("@U_ID", req.U_ID);
            }
            return client.Query<T>(sql.ToString(), param).FirstOrDefault();
        }
    }
}
