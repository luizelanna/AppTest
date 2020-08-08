using BookService.Data;
using BookService.Interface;
using BookService.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookService.Repository
{
    public class BookRepositorio : Repositorio<Books>, IBook
    {
        private Context<Books> context = new Context<Books>();

        public object GetFrete(int id)
        {
            var lista = context.Dados().AsQueryable();
            var dados = lista.SingleOrDefault(x => x.Id.Equals(id));
            if (dados == null)
            {
                return "";
            }
            var frete = dados.Price * 1.2;
            return frete;
        }

        public IEnumerable<Books> GetLivro(string entity, string ordem)
        {
            var dados = context.Dados().AsQueryable();
            if (ordem == "asc")
            {
                return dados.Where(x => x.Name.Contains(entity) || x.Specifications.Author.Contains(entity) || x.Specifications.OriginallyPublished.Equals(entity) || x.Specifications.Illustrators.Contains(entity) || x.Specifications.Genres.Contains(entity)).OrderBy(x => x.Price);
            }
            else if (ordem == "desc")
            {
                return dados.Where(x => x.Name.Contains(entity) ||  x.Specifications.Author.Contains(entity) || x.Specifications.OriginallyPublished.Equals(entity) || x.Specifications.Illustrators.Contains(entity) || x.Specifications.Genres.Contains(entity)).OrderByDescending(x => x.Price);
            }
            return dados.Where(x => x.Name.Contains(entity) || x.Specifications.Author.Contains(entity) || x.Specifications.OriginallyPublished.Equals(entity) || x.Specifications.Illustrators.Contains(entity) || x.Specifications.Genres.Contains(entity));
        }
    }
}
