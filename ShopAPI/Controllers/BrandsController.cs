using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.DataContext;
using ShopAPI.DTOs.BrandDTOs;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ClassDbContext _classDbContext;
        private readonly IMapper _mapper;


        public BrandsController(ClassDbContext classDbContext, IMapper mapper)
        {
            _classDbContext = classDbContext;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BrandDTO brandDTO)
        {
            Brand brand = _mapper.Map<Brand>(brandDTO);
            _classDbContext.Add(brand);
            _classDbContext.SaveChanges();
            return Ok(brand);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = _classDbContext.Brands.ToList();
            return Ok(data);
        }
        [HttpGet("Get")]
        public async Task <IActionResult> Get(int id)
        {
            var data = _classDbContext.Brands.FirstOrDefault(x=>x.id == id);
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id , BrandDTO brandDTO)
        {

            Brand old = _classDbContext.Brands.FirstOrDefault(X=>X.id==id);
            old.Name = brandDTO.Name;
         
            old.SubCategoryId = brandDTO.SubCategoryId;
            _classDbContext.SaveChanges();
            return Ok(old);
        }

        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            Brand exiting =  _classDbContext.Brands.FirstOrDefault(x=>x.id==id);
            _classDbContext.Remove(exiting);
            _classDbContext.SaveChanges();
            return Ok(exiting);
        }
    
    }
}
