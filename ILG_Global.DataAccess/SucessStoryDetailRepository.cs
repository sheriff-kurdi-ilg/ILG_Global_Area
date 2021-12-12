
using ILG_Global.BussinessLogic.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global.DataAccess
{
    public class SucessStoryDetailRepository : ISucessStoryDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public SucessStoryDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
                 public async Task<List<SucessStoryDetail>> SelectAllEnabledAsync(string sLanguageCode)
        {
            List<SucessStoryDetail> lSucessStoryDetails = new List<SucessStoryDetail>();

            try
            {
                lSucessStoryDetails = 
                    await applicationDbContext.SucessStoryDetails
                    .Include(m => m.SucessStoryMaster)
                    .Where(m => m.LanguageCode == sLanguageCode && m.SucessStoryMaster.IsEnabled).ToListAsync();
            }
            catch (Exception)
            {

            }

            return lSucessStoryDetails;
        }

        public async Task<List<SucessStoryDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<SucessStoryDetail> lSucessStoryDetails = new List<SucessStoryDetail>();

            try
            {
                lSucessStoryDetails = await applicationDbContext.SucessStoryDetails.Include(m=> m.SucessStoryMaster).Where(m=>m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception)
            {

            }

            return lSucessStoryDetails;
        }

        public async Task<SucessStoryDetail> SelectByIdAsync(int nID,string sLanguageCode)
        {
            SucessStoryDetail oSucessStoryDetail = new SucessStoryDetail();

            try
            {
                oSucessStoryDetail = await applicationDbContext.SucessStoryDetails.FirstOrDefaultAsync(m => m.SucessStoryID == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oSucessStoryDetail;
        }

        public async Task<bool> Insert(SucessStoryDetail oSucessStoryDetail)
        {
            try
            {
                applicationDbContext.SucessStoryDetails.Add(oSucessStoryDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(SucessStoryDetail oSucessStoryDetail)
        {
            try
            {
                applicationDbContext.Entry(oSucessStoryDetail).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteByID(int nID)
        {
            try
            {
                SucessStoryDetail oSucessStoryDetail = applicationDbContext.SucessStoryDetails.Find(nID);

                applicationDbContext.SucessStoryDetails.Remove(oSucessStoryDetail);
                applicationDbContext.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
