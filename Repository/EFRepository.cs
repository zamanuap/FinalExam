using Microsoft.EntityFrameworkCore;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class EFRepository<T> where T: class
    {
        private readonly AppDbContext _context;

        public EFRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(T item)
        {
            
                _context.Entry(item).State = EntityState.Added;
            
            _context.SaveChanges();
        }

        
        public IList<T> GetAll()
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            
            return dbQuery.ToList();

        }

        
        public T GetSingle(Expression<Func<T, bool>> where)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            
            return dbQuery.Where(where).FirstOrDefault();
        }

        public void Remove(T item)
        {
           
                _context.Entry(item).State = EntityState.Deleted;
            
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            
                _context.Entry(item).State = EntityState.Modified;
            
            _context.SaveChanges();
        }
    }
}
