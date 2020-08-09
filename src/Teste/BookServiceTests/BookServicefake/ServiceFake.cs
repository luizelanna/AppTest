using BookService.Interface;
using BookService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookServiceTests.BookServicefake
{
    public class ServiceFake : IBook
    {
        private readonly List<Books> books;


        public ServiceFake()
        {
            books = new List<Books>
            {

            };
        }

        public List<Books> GetAll()
        {
            return books;
        }

        public object GetFrete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Books> GetLivro(string entity, string ordem)
        {
            var result = 
        }
    }
}
