using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface x_ISectionDetailRepository
    {
        Task<SectionDetail> SelectById(int id, string sLanguageCode);
        Task<IEnumerable<SectionDetail>> SelectAll( string sLanguageCode);
        Task UpdateById(SectionDetail entity);
        Task Insert(SectionDetail entity);
        Task DeleteById(int Id);
        Task SaveSectionDetail(SectionDetail entity);
    }
}
