using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace services.Repository
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class
    {
        private readonly DBConnection _dbContext;
        private DbSet<T> _dbSet;

        public ApplicationRepository(DBConnection dbcontext)
        {
            _dbContext = dbcontext;
            _dbSet = _dbContext.Set<T>();

        }
        public async Task<T> CreateAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
        public async Task<bool> DeleteAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
      
        {
            if (useNoTracking)
            {
                return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();
            }
            else
            {
                return await _dbSet.Where(filter).FirstOrDefaultAsync();
            }
        }
        public async Task<List<T>> GetAllByAnyAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
        {
            if (useNoTracking)
            {
                return await _dbSet.AsNoTracking().Where(filter).ToListAsync();

            }
            else
            {
                return await _dbSet.Where(filter).ToListAsync();

            }
        }

        //public async Task<T> GetByNameAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _dbSet.Where(filter).FirstOrDefaultAsync();
        //}

        public async Task<T> UpdateAsync(T dbRecord)
        {
            //var studentToUpdate = await _dbSet.Where(student => student.Id == student.Id).FirstOrDefaultAsync();

            _dbContext.Update(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
            throw new ArgumentNullException("No student found");
        }

    }
}
