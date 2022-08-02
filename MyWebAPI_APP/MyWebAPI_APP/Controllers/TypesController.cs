using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI_APP.Data;
using MyWebAPI_APP.Models;

namespace MyWebAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TypesController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllType()
        {
            var ListType = _context.TypeProducts.ToList();
            return Ok(ListType);
        }
        [HttpGet("{id}")]
        public IActionResult GetTypeByID(int id)
        {
            var typeProduct = _context.TypeProducts.SingleOrDefault(p => p.IdType == id);
            if(typeProduct != null )
            {
                return Ok(typeProduct);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateType(TypeProductModel typeProductModel)
        {
            try
            {
                var typeProduct = new TypeProduct
                {
                    NameType = typeProductModel.NameType,
                };
                _context.Add(typeProduct);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, typeProduct);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTypeByID(int id, TypeProductModel typeProductModel)
        {
            var typeProduct = _context.TypeProducts.SingleOrDefault(p => p.IdType == id);
            if (typeProduct != null)
            {
                typeProduct.NameType = typeProductModel.NameType;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTypeByID(int id)
        {
            var typeProduct = _context.TypeProducts.SingleOrDefault(p => p.IdType == id);
            if (typeProduct != null)
            {
                _context.Remove(typeProduct);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
