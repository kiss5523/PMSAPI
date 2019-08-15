using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Domain.Entitys;
using Base.Repository.Core;
using Base.SDK.Request.Role;
using Dapper;

namespace Base.Repository.Repo
{
    public class MenuPurviewcodeRepo : RepositoryBase
    {
        public IEnumerable<T> PurviewcodeGetList<T>(int? R_ID=null,int? U_Id=null) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT
                    DISTINCT
                      smp.MPC_ID
                     ,smp.MPC_NAME
                     ,smp.MPC_NAME_C
                     ,smp.MPC_NAME_J
                     ,smp.MPC_CODE
                     ,sm.M_NAME
                     ,sm.M_NAME_C
                    FROM SS_MENU_PURVIEWCODE smp
                    LEFT JOIN SS_ROLE_MENU_PURVIEWCODE srmp
                      ON smp.MPC_CODE = srmp.MPC_CODE
                    LEFT JOIN SS_MENU sm
                      ON smp.M_ID = sm.M_ID
                    WHERE smp.MPC_DISABLED = 0
                    AND sm.M_DISABLED = 0
                 ");
            var param = new DynamicParameters();

            if (R_ID.HasValue)
            {
                sql.Append(" AND srmp.R_ID = @R_ID");
                param.Add("@R_ID", R_ID.Value);
            }
            if (U_Id.HasValue)
            {
                var rIds = RepoBase.Instance.GetWhere<SS_ROLE_USER>(x=>x.U_ID== U_Id.Value).Select(x=>x.R_ID);
                sql.Append(" AND srmp.R_ID IN @R_ID");
                param.Add("@R_ID", rIds);
            }
            return client.Query<T>(sql.ToString(), param);
        }

        public int Delete(int? R_ID, string MPC_CODE=null)
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"DELETE FROM SS_ROLE_MENU_PURVIEWCODE WHERE 1=1 ");
            var param = new DynamicParameters();
            if (R_ID.HasValue)
            {
                sql.Append(" AND R_ID=@R_ID");
                param.Add("@R_ID", R_ID);
            }

            if (!string.IsNullOrEmpty(MPC_CODE))
            {
                sql.Append(" AND MPC_CODE=@MPC_CODE");
                param.Add("@MPC_CODE", MPC_CODE);
            }  
            return client.Execute(sql.ToString(), param);
        }
    }
}
