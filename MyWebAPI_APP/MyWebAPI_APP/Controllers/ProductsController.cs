using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI_APP.Models;

namespace MyWebAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Products> products = new List<Products>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]

        public IActionResult GetByID(string id)
        {
            try
            {
                var hanghoa = products.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(ProductsVM hangHoaVM)
        {
            var product = new Products
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };
            products.Add(product);
            return Ok(new
            {
                Succsess = true ,
                Data = product,
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, Products hangHoaEdit)
        {
            try
            {
                var hanghoa = products.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id)); 
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Update 
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)

        {
            try
            {
                var hanghoa = products.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                //Delete  
                products.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
