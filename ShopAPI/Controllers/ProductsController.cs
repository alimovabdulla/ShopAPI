using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.DataContext;
using ShopAPI.DTOs.ProductDTOs;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ClassDbContext _classDbContext;
        private readonly IMapper _mapper;


        public ProductsController(ClassDbContext classDbContext, IMapper mapper)
        {
            _classDbContext = classDbContext;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _classDbContext.Products.Add(product);
            _classDbContext.SaveChanges();
            return Ok(product);


        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var data = _classDbContext.Products.Include("Brand").ToList();
            return Ok(data);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _classDbContext.Products.FirstOrDefault(x => x.id == id);
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);

            Product old = await _classDbContext.Products.FirstOrDefaultAsync(x => x.id == id);
            old.SalePrice = productDTO.SalePrice;
            old.CostPrice = productDTO.CostPrice;
            old.Name = productDTO.Name;
            old.Description = productDTO.Description;
            old.BrandId = productDTO.BrandId;
            _classDbContext.SaveChanges();
            return Ok(productDTO);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            Product product = _classDbContext.Products.FirstOrDefault(x => x.id == id);
            _classDbContext.Remove(product);
            _classDbContext.SaveChanges();
            return Ok(product);
        }








    }
}
