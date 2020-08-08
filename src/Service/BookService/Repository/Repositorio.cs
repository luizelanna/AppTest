using BookService.Data;
using BookService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookService.Repository
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable where TEntity : class
    {
        private Context<TEntity> context = new Context<TEntity>();
        public List<TEntity> GetAll()
        {
            return context.Dados();
        }

        public IEnumerable<TEntity> Search(TEntity entity)
        {            
            var dados = context.Dados().AsQueryable();
            return dados.Where(p=>p.Equals(entity)).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
