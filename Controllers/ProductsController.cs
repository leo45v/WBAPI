using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBAPI.Models;
using WBAPI.Repositories;

namespace WBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Get() => Ok(_repo.GetAll());

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _repo.Add(p);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repo.Get(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updated)
        {
            var result = _repo.Update(id, updated);
            return result ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.Delete(id);
            return result ? Ok() : NotFound();
        }
    }
}
