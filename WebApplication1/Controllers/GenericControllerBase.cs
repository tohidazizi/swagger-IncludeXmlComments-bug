using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericControllerBase<T, U> : MyControllerBase
        where T : class, new()
        where U : class, new()
    {
        // GET: api/GenericControllerBase
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return new List<T>(new[] { new T(), new T() });
        }

        // GET: api/GenericControllerBase/5
        [HttpGet("{id}", Name = "Get")]
        public T Get(int id)
        {
            return new T();
        }

        // POST: api/GenericControllerBase
        [HttpPost]
        public void Post([FromBody] U value)
        {
        }

        // PUT: api/GenericControllerBase/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] T value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
