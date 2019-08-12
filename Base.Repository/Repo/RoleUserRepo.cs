using System;
using System.Collections.Generic;
using System.Text;
using Base.Repository.Core;
using Dapper;

namespace Base.Repository.Repo
{
    public class RoleUserRepo : RepositoryBase
    {
        public int Delete(int uid)
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"DELETE FROM SS_ROLE_USER WHERE U_ID=@U_ID");
            var param = new DynamicParameters();
                param.Add("@U_ID", uid);
            return client.Execute(sql.ToString(), param);
        }
    }
}
