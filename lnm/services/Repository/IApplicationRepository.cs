using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.Repository
{
    public interface IApplicationRepository<T> // including a generic type 
    {
        Task<List<T>> GetAllAsync();
        // the parameter can take any lambda expression as a parameter
        // this function is used to retrieve a list of data based on a condition ======================= important
        Task<List<T>> GetAllByAnyAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);
        // for all list of entities

        // for single entity
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);

        Task<T> CreateAsync(T dbRecord);

        Task<T> UpdateAsync(T dbRecord);

        Task<bool> DeleteAsync(T dbRecord);

        //Task<bool> DeleteTempAsync(T dbRecord);


        // from now on use this .. to retrieve a list of specific datas using parameters


    }
}
