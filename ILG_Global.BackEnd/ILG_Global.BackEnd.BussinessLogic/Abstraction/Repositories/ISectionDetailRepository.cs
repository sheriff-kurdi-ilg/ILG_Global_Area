using ILG_Global.BackEnd.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Repositories
{
    public interface ISectionDetailRepository
    {
        Task<SectionDetail> SelectById(int id);
        Task<IEnumerable<SectionDetail>> SelectAll();
        Task UpdateById(SectionDetail entity);
        Task Insert(SectionDetail entity);
        Task DeleteById(string Id);
        Task SaveSectionDetail(SectionDetail entity);
    }
}
