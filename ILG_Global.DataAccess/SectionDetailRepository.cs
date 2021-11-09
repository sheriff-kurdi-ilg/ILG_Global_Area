
using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public class SectionDetailRepository:ISectionDetailRepository
    {
        private readonly ILG_GlobalContext _context;
        private  DbSet<SectionDetail> SectionDetailEntity;

        public SectionDetailRepository(ILG_GlobalContext context)
        {
            _context = context;
            SectionDetailEntity = context.Set<SectionDetail>();
        }
        public async Task Insert(SectionDetail entity)
        {
            await _context.SectionDetails.AddAsync(entity);
        }

        public async Task<IEnumerable<SectionDetail>> SelectAll(string sLanguageCode)
        {
            return await _context.SectionDetails.Where(m=>m.LanguageCode == sLanguageCode).Include(c => c.SectionMaster).ToListAsync();
        }

        public async Task<SectionDetail> SelectById(int Id, string sLanguageCode)
        {
            return await _context.SectionDetails.Where(m=>m.LanguageCode == sLanguageCode).Include(c=>c.SectionMaster).FirstOrDefaultAsync(ow => ow.ID == Id);
        }

        public async Task DeleteById(int Id)
        {
            SectionDetail SectionDetail = await _context.SectionDetails.FindAsync(Id);
            _context.SectionDetails.Remove(SectionDetail);
        }



        public async Task SaveSectionDetail(SectionDetail entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(SectionDetail entity)
        {
            SectionDetailEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
