using DealsOnWheelsAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DealsOnWheelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyMDBController<TEntity, TRepository> : ControllerBase
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyMDBController(TRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var item = await repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity item)
        {
            await repository.Add(item);
            return Ok();
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var item = await repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //// PUT: api/[controller]/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, TEntity item)
        //{
        //    if (id != item.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await repository.Update(item);
        //    return NoContent();
        //}
    }
}
