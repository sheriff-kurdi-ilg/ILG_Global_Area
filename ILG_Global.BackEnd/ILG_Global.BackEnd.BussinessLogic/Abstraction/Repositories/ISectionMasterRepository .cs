using ILG_Global.BackEnd.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Repositories
{
    public interface ISectionMasterRepository
    {
        Task<SectionMaster> SelectById(int id);
        Task<IEnumerable<SectionMaster>> SelectAll();
        Task UpdateById(SectionMaster entity);
        Task Insert(SectionMaster entity);
        Task DeleteById(int Id);
        Task SaveSectionMaster(SectionMaster entity);
    }
}
