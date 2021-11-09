﻿
using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Repositories
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
