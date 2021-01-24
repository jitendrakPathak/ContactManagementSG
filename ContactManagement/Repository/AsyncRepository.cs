using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Repository
{
    public class AsyncRepository<T>  : IAsyncRepository<T> where T : ContactModel
    {
        protected DataDbContext Context;

        public AsyncRepository(DataDbContext context)
        {
            Context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            ContactModel contact = new ContactModel() { Id = id };
            Context.Contacts.Attach(contact);
            Context.Contacts.Remove(contact);
            return Context.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync(int id) =>  Context.Set<T>().FindAsync(id).AsTask();

        public async Task<IEnumerable<T>> ListAsync() =>  await Context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate)=> await Context.Set<T>().Where(predicate).ToListAsync();
        
        public Task<int> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}
