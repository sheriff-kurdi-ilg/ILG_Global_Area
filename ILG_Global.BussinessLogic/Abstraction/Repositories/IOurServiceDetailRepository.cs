using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface IOurServiceDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(OurServiceDetail oOurServiceDetail);
        Task<List<OurServiceDetail>> SelectAllAsync(string sLanguageCode);
        Task<OurServiceDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(OurServiceDetail oOurServiceDetail);
    }
}