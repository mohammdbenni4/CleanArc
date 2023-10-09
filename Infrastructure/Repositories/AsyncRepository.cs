using Application.Contracts_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public AsyncRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<T> AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteAsync(T model)
        {
           _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T model)
        {
           // _context.Entry(model).State = EntityState.Modified;
           _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();

        }


    }
}
