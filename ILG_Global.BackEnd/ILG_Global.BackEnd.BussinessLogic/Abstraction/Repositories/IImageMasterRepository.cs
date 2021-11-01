using ILG_Global.BackEnd.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Repositories
{
    public interface IImageMasterRepository
    {
        Task<ImageMaster> SelectById(int id);
        Task<IEnumerable<ImageMaster>> SelectAll();
        Task UpdateById(ImageMaster entity);
        Task Insert(ImageMaster entity);
        Task DeleteById(int Id);
        Task SaveImageMaster(ImageMaster entity);
    }
}
