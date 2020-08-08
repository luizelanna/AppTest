using BookService.Interface;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _book;

        public BooksController(IBook book)
        {
            _book = book;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Books>> Get()
        {
            return _book.GetAll();
        }

        [HttpGet("buscar/{type}/{ordem?}")]
        public ActionResult<IEnumerable<Books>> GetBooks(string type, string ordem)
        {
            IEnumerable<Books> enumerable = _book.GetLivro(type, ordem);
            return enumerable.ToList();
        }

        // GET api/values/5
        [HttpGet("frete/{id}")]
        public ActionResult<string> GetFrete(int id)
        {
            var valor = _book.GetFrete(id);
            return valor.ToString();            
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
