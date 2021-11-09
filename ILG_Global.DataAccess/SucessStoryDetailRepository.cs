using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public class SucessStoryDetailRepository
    {
        private readonly ILG_GlobalContext _context;
        private DbSet<SucessStoryDetail> SucessStoryDetailEntity;

        public SucessStoryDetailRepository(ILG_GlobalContext context)
        {
            _context = context;
            SucessStoryDetailEntity = context.Set<SucessStoryDetail>();
        }
        public async Task Insert(SucessStoryDetail entity)
        {
            await _context.SucessStoryDetails.AddAsync(entity);
        }

        public async Task<IEnumerable<SucessStoryDetail>> SelectAll()
        {
            return await _context.SucessStoryDetails.Include(c => c.SucessStoryMaster).ToListAsync();
        }

        public async Task<SucessStoryDetail> SelectById(int Id)
        {
            return await _context.SucessStoryDetails.Include(c => c.SucessStoryMaster).FirstOrDefaultAsync(ow => ow.ID == Id);
        }

        public async Task DeleteById(int Id)
        {
            SucessStoryDetail SucessStoryDetail = await _context.SucessStoryDetails.FindAsync(Id);
            _context.SucessStoryDetails.Remove(SucessStoryDetail);
        }



        public async Task SaveSucessStoryDetail(SucessStoryDetail entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(SucessStoryDetail entity)
        {
            SucessStoryDetailEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
