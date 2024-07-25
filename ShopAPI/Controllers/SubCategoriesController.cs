using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.DataContext;
using ShopAPI.DTOs.SubDTOs;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {

        private readonly ClassDbContext _classDbContext;
        private readonly IMapper _mapper;


        public SubCategoriesController(ClassDbContext classDbContext, IMapper mapper)
        {
            _classDbContext = classDbContext;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(SubDTO subDTO)
        {
            SubCategory subCategory = _mapper.Map<SubCategory>(subDTO);
            _classDbContext.Add(subCategory);
            _classDbContext.SaveChanges();
            return Ok(subCategory);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var data = _classDbContext.SubCategories.Include(b=>b.Brands).Include(n=>n.Category).ToList();
            return Ok(data);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            SubCategory sub = _classDbContext.SubCategories.FirstOrDefault(x => x.id == id);
            return Ok(sub);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, SubDTO subDTO)
        {

            SubCategory subCategory = _mapper.Map<SubCategory>(subDTO);
            SubCategory old = _classDbContext.SubCategories.FirstOrDefault(y => y.id == id);
            old.Name = subCategory.Name;
            old.Brands = subCategory.Brands;
            old.CategoryId = subCategory.CategoryId;

            _classDbContext.SaveChanges();
            return Ok(subCategory);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _classDbContext.SubCategories.FirstOrDefault(x => x.id == id);
            _classDbContext.Remove(data);
            _classDbContext.SaveChanges();
            return Ok(data);
        }

    }
}
