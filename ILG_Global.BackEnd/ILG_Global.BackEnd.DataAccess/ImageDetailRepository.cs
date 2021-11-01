﻿using ILG_Global.BackEnd.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BackEnd.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.DataAccess
{
    public class ImageDetailRepository:IImageDetailRepository
    {
        private readonly ILG_GlobalContext _context;
        private  DbSet<ImageDetail> ImageDetailEntity;

        public ImageDetailRepository(ILG_GlobalContext context)
        {
            _context = context;
            ImageDetailEntity = context.Set<ImageDetail>();
        }
        public async Task Insert(ImageDetail entity)
        {
            await _context.ImageDetails.AddAsync(entity);
        }

        public async Task<IEnumerable<ImageDetail>> SelectAll()
        {
            return await _context.ImageDetails.ToListAsync();
        }

        public async Task<ImageDetail> SelectById(int Id)
        {
            return await _context.ImageDetails.FirstOrDefaultAsync(ow => ow.ID == Id);
        }

        public async Task DeleteById(string Id)
        {
            ImageDetail ImageDetail = await _context.ImageDetails.FindAsync(Id);
            _context.ImageDetails.Remove(ImageDetail);
        }



        public async Task SaveImageDetail(ImageDetail entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(ImageDetail entity)
        {
            ImageDetailEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}