using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.Concreate;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Routing.Template;

namespace TasteMuseum.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        public void Add(T t)
        {
            using (Context context = new())
            {
                var entityToAdd = context.Entry(t);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Delete(T t)
        {
            using (Context context = new())
            {
                var entityToAdd = context.Entry(t);
                entityToAdd.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public T? Get(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,IIncludableQueryable<T,object>>? include)
        {
            using (Context context = new())
            {
                IQueryable<T> query = context.Set<T>();
                if(include != null)
                {
                    query = include(query);
                }
                if (expression != null)
                {
                    query = query.Where(expression);
                }
                return query.FirstOrDefault();
            }
        }

        public List<T>? GetListAll(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            using (Context context = new())
            {
                IQueryable<T> query = context.Set<T>();
                if (include != null)
                {
                    query = include(query);
                }
                if(expression != null)
                {
                    query = query.Where(expression);
                }
                return query.ToList();
            }
        }

        public void Update(T t)
        {
            using (Context context = new())
            {
                var entityToAdd = context.Entry(t);
                entityToAdd.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public bool CheckEntityExists(Expression<Func<T,bool>>? expression)
        {
            using(Context context = new())
            {
                if(expression == null)
                    return context.Set<T>().Any();
                return context.Set<T>().Any(expression);  
            }
        }
    }
}
