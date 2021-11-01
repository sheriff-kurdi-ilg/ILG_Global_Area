using ILG_Global.BackEnd.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Repositories
{
    public interface IImageDetailRepository
    {
        Task<ImageDetail> SelectById(int id);
        Task<IEnumerable<ImageDetail>> SelectAll();
        Task UpdateById(ImageDetail entity);
        Task Insert(ImageDetail entity);
        Task DeleteById(string Id);
        Task SaveImageDetail(ImageDetail entity);
    }
}
