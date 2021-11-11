
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global.DataAccess
{
    public class OurServiceDetailRepository : IOurServiceDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public OurServiceDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<OurServiceDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<OurServiceDetail> lOurServiceDetails = new List<OurServiceDetail>();

            try
            {
                lOurServiceDetails = await applicationDbContext.OurServiceDetails.Include(m=> m.OurServiceMaster).Where(m=>m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception)
            {

            }

            return lOurServiceDetails;
        }

        public async Task<OurServiceDetail> SelectByIdAsync(int nID,string sLanguageCode)
        {
            OurServiceDetail oOurServiceDetail = new OurServiceDetail();

            try
            {
                oOurServiceDetail = await applicationDbContext.OurServiceDetails.FirstOrDefaultAsync(m => m.OurServiceID == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oOurServiceDetail;
        }

        public async Task<bool> Insert(OurServiceDetail oOurServiceDetail)
        {
            try
            {
                applicationDbContext.OurServiceDetails.Add(oOurServiceDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(OurServiceDetail oOurServiceDetail)
        {
            try
            {
                applicationDbContext.Entry(oOurServiceDetail).State = EntityState.Modified;
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
                OurServiceDetail oOurServiceDetail = applicationDbContext.OurServiceDetails.Find(nID);

                applicationDbContext.OurServiceDetails.Remove(oOurServiceDetail);
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
