using System;
using System.Collections.Generic;
using System.Text;
using Base.Repository.Core;
using Dapper;

namespace Base.Repository.Repo
{
    public class RoleUserRepo : RepositoryBase
    {
        public int Delete(int? uid=null,int? rid=null)
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"DELETE FROM SS_ROLE_USER WHERE 1=1");
            var param = new DynamicParameters();
            if (uid.HasValue)
            {
                sql.Append(" AND U_ID=@U_ID");
                param.Add("@U_ID", uid);
            }
            if (rid.HasValue)
            {
                sql.Append(" AND R_ID=@R_ID");
                param.Add("@R_ID", rid);
            }

            return client.Execute(sql.ToString(), param);
        }
    }
}
