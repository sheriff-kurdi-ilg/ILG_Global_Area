using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public interface IHtmlContentDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(HtmlContentDetail oHtmlContentDetail);
        Task<IEnumerable<HtmlContentDetail>> SelectAllAsync(string sLanguageCode);
        Task<HtmlContentDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(HtmlContentDetail oHtmlContentDetail);
    }
}