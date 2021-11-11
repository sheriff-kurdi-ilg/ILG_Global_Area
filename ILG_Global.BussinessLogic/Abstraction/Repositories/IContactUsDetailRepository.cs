using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface IContactInformationDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(ContactInformationDetail oContactInformationDetail);
        Task<IEnumerable<ContactInformationDetail>> SelectAllAsync(string sLanguageCode);
        Task<ContactInformationDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(ContactInformationDetail oContactInformationDetail);
    }
}