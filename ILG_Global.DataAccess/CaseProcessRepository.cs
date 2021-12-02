
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global.DataAccess
{
    public class CaseProcessDetailRepository : ICaseProcessDetailRepository
    {
        #region DI

        private readonly ILG_GlobalContext applicationDbContext;

        public CaseProcessDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #endregion

        #region Select Methods
        public async Task<IEnumerable<CaseProcessDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<CaseProcessDetail> lCaseProcessDetails = new List<CaseProcessDetail>();

            try
            {
                lCaseProcessDetails = await applicationDbContext.CaseProcessDetails.Include(m => m.CaseProcessMaster).Where(m => m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return lCaseProcessDetails;
        }

        public async Task<CaseProcessDetail> SelectByIdAsync(int nID, string sLanguageCode)
        {
            CaseProcessDetail oCaseProcessDetail = new CaseProcessDetail();

            try
            {
                oCaseProcessDetail = await applicationDbContext.CaseProcessDetails.FirstOrDefaultAsync(m => m.CaseProcessID == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oCaseProcessDetail;
        }

        #endregion

        #region Insert Methods

        public async Task<bool> Insert(CaseProcessMaster oCaseProcessMaster)
        {
            try
            {
                applicationDbContext.CaseProcessMasters.Add(oCaseProcessMaster);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Insert(CaseProcessDetail oCaseProcessDetail)
        {
            try
            {
                applicationDbContext.CaseProcessDetails.Add(oCaseProcessDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion

        #region Update Methods
        public async Task<bool> UpdateMaster(CaseProcessMaster oCaseProcessMaster)
        {
            try
            {
                applicationDbContext.Entry(oCaseProcessMaster).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateDetail(CaseProcessDetail oCaseProcessDetail)
        {
            try
            {
                applicationDbContext.Entry(oCaseProcessDetail).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        #endregion

        #region Delete Methods

        public async Task<bool> DeleteByID(int nID)
        {
            try
            {
                CaseProcessMaster oCaseProcessMaster = applicationDbContext.CaseProcessMasters.Find(nID);

                applicationDbContext.CaseProcessMasters.Remove(oCaseProcessMaster);
                applicationDbContext.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        #endregion
    }
}
