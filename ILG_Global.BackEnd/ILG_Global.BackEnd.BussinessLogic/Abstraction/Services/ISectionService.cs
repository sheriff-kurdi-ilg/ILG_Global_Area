﻿using ILG_Global.BackEnd.BussinessLogic.Models;
using ILG_Global.BackEnd.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Abstraction.Services
{
    public interface ISectionService
    {
        Task<SectionDetailViewModel> SelectByIdAsync(int nID);
        Task<List<SectionDetailViewModel>> SelectAllAsync();
      //  Task<IEnumerable<SectionDetailViewModel>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(SectionDetailViewModel oEntity);
        Task<bool> Update(SectionDetailViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);



        List<SectionDetailViewModel> lConvertToVMs(IEnumerable<SectionDetail> lSectionsDetails);
        SectionDetailViewModel oConvertToVM(SectionDetail oSectionDetail);
        SectionDetail oConvertToDataModel(SectionDetailViewModel oSectionDetailVM);
    }
}
