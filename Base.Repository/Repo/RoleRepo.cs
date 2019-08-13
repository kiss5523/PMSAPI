using Base.Repository.Core;
using Base.SDK.Request.Role;
using Base.SDK.Request.User;
using Dapper;
using System.Collections.Generic;
using System.Text;

namespace Base.Repository.Repo
{
    public class RoleRepo : RepositoryBase
    {
        public IEnumerable<T> GetListByUid<T>(UserInfoGetRequest req) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT
                  sr.R_ID,
                  sr.R_NAME,
                  sr.R_DESC,
                  sr.Branch_ID,
                  sr.R_ORDERID
                FROM SS_ROLE sr
                LEFT JOIN SS_ROLE_USER sru
                  ON sr.R_ID = sru.R_ID
                WHERE 1 = 1
                 ");
            var param = new DynamicParameters();

            if (req.U_ID.HasValue)
            {
                sql.Append(" AND sru.U_ID = @U_ID");
                param.Add("@U_ID", req.U_ID);
            }
            return client.Query<T>(sql.ToString(), param);
        }

        public IEnumerable<T> GetList<T>(RoleGetListRequest req) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT
                  *
                FROM SS_ROLE sr
                WHERE 1 = 1
                 ");
            var param = new DynamicParameters();

            if (!string.IsNullOrEmpty(req.R_NAME))
            {
                sql.Append(" AND sr.R_NAME LIKE @R_NAME");
                param.Add("@R_NAME", $"%{req.R_NAME}%");
            }

            sql.Append(" ORDER BY sr.R_ORDERID");
            return client.Query<T>(sql.ToString(), param);
        }

        public IEnumerable<T> MemberGetList<T>(MemberGetListRequest req) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT
                  *
                FROM SS_USER su
                LEFT JOIN SS_ROLE_USER sru
                  ON su.U_ID = sru.U_ID
                WHERE 1 = 1 
                ");
            var param = new DynamicParameters();
            if (req.R_ID.HasValue)
            {
                sql.Append(" AND sru.R_ID = @R_ID");
                param.Add("@R_ID", req.R_ID);
            }
            
            return client.Query<T>(sql.ToString(), param);
        }
    }
}
