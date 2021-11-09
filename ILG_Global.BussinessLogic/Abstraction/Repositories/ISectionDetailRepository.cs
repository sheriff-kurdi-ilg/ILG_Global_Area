using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface ISectionDetailRepository
    {
        Task<SectionDetail> SelectById(int id);
        Task<IEnumerable<SectionDetail>> SelectAll();
        Task UpdateById(SectionDetail entity);
        Task Insert(SectionDetail entity);
        Task DeleteById(int Id);
        Task SaveSectionDetail(SectionDetail entity);
    }
}
