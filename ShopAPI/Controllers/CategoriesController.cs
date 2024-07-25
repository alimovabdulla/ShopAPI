using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.DataContext;
using ShopAPI.DTOs.CategoryDTOs;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ClassDbContext _classDbContext;
        private readonly IMapper _mapper;


        public CategoriesController(ClassDbContext classDbContext, IMapper mapper)
        {
            _classDbContext = classDbContext;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            _classDbContext.Add(category);
            _classDbContext.SaveChanges();
            return Ok(category);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = _classDbContext.Categories.ToList();
            return Ok(data);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {

            Category category = _classDbContext.Categories.FirstOrDefault(x => x.id == id);
            return Ok(category);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, CategoryDTO categoryDTO)
        {
            Category old = _classDbContext.Categories.FirstOrDefault(x => x.id == id);
            old.Name = categoryDTO.Name;
            _classDbContext.SaveChanges();
            return Ok(old);


        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _classDbContext.Categories.FirstOrDefault(x => x.id == id);
            _classDbContext.Categories.Remove(data);
            _classDbContext.SaveChanges();
            return Ok(data);
        }
    }
}
