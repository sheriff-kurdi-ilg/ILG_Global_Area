
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global.DataAccess
{
    public class ContactInformationDetailRepository : IContactInformationDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public ContactInformationDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ContactInformationDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<ContactInformationDetail> lContactInformationDetails = new List<ContactInformationDetail>();

            try
            {
                lContactInformationDetails = await applicationDbContext.ContactInformationDetails.Include(m=>m.ContactInformationMaster).Where(m=>m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return lContactInformationDetails;
        }

        public async Task<ContactInformationDetail> SelectByIdAsync(int nID,string sLanguageCode)
        {
            ContactInformationDetail oContactInformationDetail = new ContactInformationDetail();

            try
            {
                oContactInformationDetail = await applicationDbContext.ContactInformationDetails.FirstOrDefaultAsync(m => m.ContactInformationID == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oContactInformationDetail;
        }

        public async Task<bool> Insert(ContactInformationDetail oContactInformationDetail)
        {
            try
            {
                applicationDbContext.ContactInformationDetails.Add(oContactInformationDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(ContactInformationDetail oContactInformationDetail)
        {
            try
            {
                applicationDbContext.Entry(oContactInformationDetail).State = EntityState.Modified;
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
                ContactInformationDetail oContactInformationDetail = applicationDbContext.ContactInformationDetails.Find(nID);

                applicationDbContext.ContactInformationDetails.Remove(oContactInformationDetail);
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
