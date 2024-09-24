using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.DataAccess.Concreate;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.DataAccess.Abstract
{
    public  interface IGenericDal<T> 
    {
        // todo: add include methods
        public void Add(T t);
        public T? Get(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        public List<T>? GetListAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        public void Delete(T t);
        public void Update(T t);
    }
}
