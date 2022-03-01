using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 分页用
    /// </summary>
    public class PageBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 分页获取数据信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllDataInfo(PageModel pm)
        {
            string cmdText = StoredProcedureName.GetDataWithPage;
            string[] para = {
                PageModel.ParamName_Columns,
                PageModel.ParamName_TableName,
                PageModel.ParamName_Where,
                PageModel.ParamName_OrderBy,
                PageModel.ParamName_PageIndex,
                PageModel.ParamName_PageSize,
            };
            object[] value = {
                pm.Columns,
                pm.TableName,
                pm.Where,
                pm.OrderBy,
                pm.PageIndex,
                pm.PageSize,
            };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);
            return ds;
        }
    }
}
