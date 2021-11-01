using ILG_Global.BackEnd.BussinessLogic.Models;
using ILG_Global.BackEnd.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Services
{
    public interface IImageMasterService
    {
        Task<ImageMasterViewModel> SelectByIdAsync(int nID);
        Task<List<ImageMasterViewModel>> SelectAllAsync();
      //  Task<IEnumerable<ImageMasterViewModel>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(ImageMasterViewModel oEntity);
        Task<bool> Update(ImageMasterViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);



        List<ImageMasterViewModel> lConvertToVMs(IEnumerable<ImageMaster> lSectionsMasters);
        ImageMasterViewModel oConvertToVM(ImageMaster oImageMaster);
        ImageMaster oConvertToDataModel(ImageMasterViewModel oImageMasterVM);
    }
}
