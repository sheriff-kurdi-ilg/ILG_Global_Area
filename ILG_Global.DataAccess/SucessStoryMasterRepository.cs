
using ILG_Global.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public class SucessStoryMasterRepository
    {

        private readonly ILG_GlobalContext _context;
        private DbSet<SucessStoryMaster> SucessStoryMasterEntity;

        public SucessStoryMasterRepository(ILG_GlobalContext context)
        {
            _context = context;
            SucessStoryMasterEntity = context.Set<SucessStoryMaster>();
        }
        public async Task Insert(SucessStoryMaster entity)
        {
            await _context.SucessStoryMasters.AddAsync(entity);
        }

        public async Task<IEnumerable<SucessStoryMaster>> SelectAll()
        {
            return await _context.SucessStoryMasters.ToListAsync();
        }

        public async Task<SucessStoryMaster> SelectById(int Id)
        {
            return await _context.SucessStoryMasters.FirstOrDefaultAsync(ow => ow.ID == Id);
        }

        public async Task DeleteById(int Id)
        {
            SucessStoryMaster SucessStoryMaster = await _context.SucessStoryMasters.FindAsync(Id);
            _context.SucessStoryMasters.Remove(SucessStoryMaster);
        }



        public async Task SaveSucessStoryMaster(SucessStoryMaster entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(SucessStoryMaster entity)
        {
            SucessStoryMasterEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
