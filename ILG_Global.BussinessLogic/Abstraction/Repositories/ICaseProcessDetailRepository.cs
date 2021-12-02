using ILG_Global.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public interface ICaseProcessDetailRepository
    {

        #region Select Methods
        public Task<IEnumerable<CaseProcessDetail>> SelectAllAsync(string sLanguageCode);
        public Task<CaseProcessDetail> SelectByIdAsync(int nID, string sLanguageCode);

        #endregion


        #region Insert Methods

        public  Task<bool> Insert(CaseProcessMaster oCaseProcessMaster);
        public  Task<bool> Insert(CaseProcessDetail oCaseProcessDetail);

        #endregion


        #region Update Methods
        public  Task<bool> UpdateMaster(CaseProcessMaster oCaseProcessMaster);
        public  Task<bool> UpdateDetail(CaseProcessDetail oCaseProcessDetail);

        #endregion

        #region Delete Methods
        public  Task<bool> DeleteByID(int nID);
        #endregion
    }
}