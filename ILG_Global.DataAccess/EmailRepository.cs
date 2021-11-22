
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global.DataAccess
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public EmailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<ShareViaEmailSubscriber>> SelectAll()
        {
            List<ShareViaEmailSubscriber> lEmails = new List<ShareViaEmailSubscriber>();
            lEmails = await applicationDbContext.ShareViaEmailSubscriber.ToListAsync();

            return lEmails;
        }

        public async Task<ShareViaEmailSubscriber> SelectById(int nID)
        {
            ShareViaEmailSubscriber oEmail = new ShareViaEmailSubscriber();

            try
            {
                oEmail = await applicationDbContext.ShareViaEmailSubscriber.FirstOrDefaultAsync(m => m.ID == nID);
            }
            catch (Exception oException)
            {

            }

            return oEmail;
        }

        public async Task Insert(ShareViaEmailSubscriber oEmail)
        {
            try
            {
                await applicationDbContext.ShareViaEmailSubscriber.AddAsync(oEmail);
                applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public async Task UpdateById(ShareViaEmailSubscriber oEmail)
        {
            try
            {
                applicationDbContext.Entry(oEmail).State = EntityState.Modified;
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        public async Task DeleteById(int nID)
        {
            try
            {
                ShareViaEmailSubscriber oEmail = applicationDbContext.ShareViaEmailSubscriber.Find(nID);

                applicationDbContext.ShareViaEmailSubscriber.Remove(oEmail);
                await applicationDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
            }
        }
    }
}
