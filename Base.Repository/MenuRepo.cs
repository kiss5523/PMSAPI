using Base.Domain.Entitys;
using Base.Repository.Core;
using Base.SDK.Request.Menu;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Repository
{
    public class MenuRepo : RepositoryBase
    {
        public IEnumerable<T> MenuGetList<T>(MenuGetListRequest req) where T : class
        {
            var client = DBProxy.CreateClient();
            var sql = new StringBuilder(@"SELECT
                      sm.*,srmp.R_ID
                    FROM SS_MENU sm
                    JOIN SS_ROLE_MENU_PURVIEWCODE srmp
                      ON sm.M_CODE = srmp.MPC_CODE
                    INNER JOIN (SELECT
                        sru.R_ID
                      FROM SS_USER su
                      LEFT JOIN SS_ROLE_USER sru
                        ON su.U_ID = sru.U_ID
                      WHERE 1=1  ");
            var param = new DynamicParameters();

            if (req.U_ID.HasValue)
            {
                sql.Append(" AND sru.U_ID = @U_ID");
                param.Add("@U_ID", req.U_ID);
            }

            sql.Append(@") t
            ON srmp.R_ID = t.R_ID
            WHERE sm.M_DISABLED = 0 ");

            if (!string.IsNullOrEmpty(req.M_NAME))
            {
                sql.Append(" AND sm.M_NAME_C LIKE @M_NAME_C");
                param.Add("@M_NAME_C", $"%{req.M_NAME}%");
            }
            return client.Query<T>(sql.ToString(), param);
        }

        public bool ChangeSort(MenuChangeSortRequest req)
        {
            var menu = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_ID == req.M_ID.Value).FirstOrDefault();
            var menus = RepoBase.Instance.GetWhere<SS_MENU>(x => x.M_PARENTID == menu.M_PARENTID);
            if (req.ActionType.Value == 1)
            {
                var minOrderId = menus.Min(x => x.M_ORDERID);
                //如果已经是最上面的
                if (menu.M_ORDERID == minOrderId)
                {
                    return false;
                }

                //和最上面的交换
                var preMenu = menus.Where(x => x.M_ORDERID < menu.M_ORDERID).OrderByDescending(x => x.M_ORDERID).First();
                var temp = preMenu.M_ORDERID;
                preMenu.M_ORDERID = menu.M_ORDERID;
                menu.M_ORDERID = temp;
                RepoBase.Instance.Update(preMenu);
            }
            else
            {
                var maxOrderId = menus.Max(x => x.M_ORDERID);
                //如果已经是最下面的
                if (menu.M_ORDERID == maxOrderId)
                {
                    return false;
                }

                //和最下面的交换
                var nextMenu = menus.Where(x => x.M_ORDERID > menu.M_ORDERID).OrderBy(x => x.M_ORDERID).First();
                var temp = nextMenu.M_ORDERID;
                nextMenu.M_ORDERID = menu.M_ORDERID;
                menu.M_ORDERID = temp;
                RepoBase.Instance.Update(nextMenu);
            }

            RepoBase.Instance.Update(menu);
            return true;
            //var client = DBProxy.CreateClient();
            //var param = new DynamicParameters();
            //param.Add("@id", req.M_ID.Value);
            //param.Add("@sortType", req.ActionType.Value);
            //param.Add("@result", 0, DbType.Int32, ParameterDirection.Output);
            //var resExecute = client.Execute("sp_change_S_Menu_Sort", param, null, null, CommandType.StoredProcedure);  //0
            //return Convert.ToInt32(param.Get<object>("@result"));
        }
    }
}
