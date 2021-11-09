
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
    public class SectionMasterRepository:ISectionMasterRepository
    {
        private readonly ILG_GlobalContext _context;
        private  DbSet<SectionMaster> SectionMasterEntity;

        public SectionMasterRepository(ILG_GlobalContext context)
        {
            _context = context;
            SectionMasterEntity = context.Set<SectionMaster>();
        }
        public async Task Insert(SectionMaster entity)
        {
            await _context.SectionMasters.AddAsync(entity);
        }

        public async Task<IEnumerable<SectionMaster>> SelectAll()
        {
            return await _context.SectionMasters.ToListAsync();
        }

        public async Task<SectionMaster> SelectById(int Id)
        {
            return await _context.SectionMasters.FirstOrDefaultAsync(ow => ow.ID == Id);
        }

        public async Task DeleteById(int Id)
        {
            SectionMaster SectionMaster = await _context.SectionMasters.FindAsync(Id);
            _context.SectionMasters.Remove(SectionMaster);
        }



        public async Task SaveSectionMaster(SectionMaster entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(SectionMaster entity)
        {
            SectionMasterEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
