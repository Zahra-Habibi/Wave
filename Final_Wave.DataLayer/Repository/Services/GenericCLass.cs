using Final_Wave.DataLayer.Contexxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Services
{
    public class GenericCLass<Tentity> where Tentity:class
    {

        private readonly ApplicationContext _context;
        private DbSet<Tentity> _Table;

        public GenericCLass(ApplicationContext context)
        {
            _context = context;
            _Table = context.Set<Tentity>();
        }

        public virtual async Task Create(Tentity entity)
        {
            await _Table.AddAsync(entity);
        }

        public virtual void Update(Tentity entity)
        {
            _Table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<Tentity> GetByIdAsync(object id)
        {
            return await _Table.FindAsync(id);
        }


        public virtual void Delete(Tentity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _Table.Attach(entity);
            }
            _Table.Remove(entity);
        }

        public virtual async Task DeleteByIdAsync(object id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public virtual void DeleteByRange(Expression<Func<Tentity, bool>> whereVariable = null)
        {
            IQueryable<Tentity> query = _Table;
            if (whereVariable != null)
            {
                query = query.Where(whereVariable);
            }
            _Table.RemoveRange(query);
        }

        public virtual async Task<IEnumerable<Tentity>> GetEntitiesAsync(Expression<Func<Tentity, bool>> whereVariable = null,
                              Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> orerbyVariable = null,
                              string joinString = "")
        {
            IQueryable<Tentity> query = _Table;
            if (whereVariable != null)
            {
                query = query.Where(whereVariable);
            }
            if (orerbyVariable != null)
            {
                query = orerbyVariable(query);
            }
            if (joinString != "")
            {
                foreach (string item in joinString.Split(','))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }
    }
}
