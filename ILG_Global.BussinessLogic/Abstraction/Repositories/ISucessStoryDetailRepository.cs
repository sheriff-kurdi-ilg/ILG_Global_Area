using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface ISucessStoryDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(SucessStoryDetail oSucessStoryDetail);
        Task<List<SucessStoryDetail>> SelectAllAsync(string sLanguageCode);
        Task<SucessStoryDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(SucessStoryDetail oSucessStoryDetail);
    }
}