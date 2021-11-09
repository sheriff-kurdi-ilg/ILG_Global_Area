
using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
{
    public interface IImageDetailRepository
    {
        Task<ImageDetail> SelectById(int id);
        Task<IEnumerable<ImageDetail>> SelectAll();
        Task UpdateById(ImageDetail entity);
        Task Insert(ImageDetail entity);
        Task DeleteById(int Id);
        Task SaveImageDetail(ImageDetail entity);
    }
}
