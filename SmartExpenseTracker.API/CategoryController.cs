using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Infrastructure;

namespace SmartExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ExpenseDbContext _context;

        public CategoriesController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await _context.Category.ToListAsync();
            return Ok(categories);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var category = new Category(dto.Name);
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Category created successfully", id = category.Id });
        }
    }

    // DTO
    public class CreateCategoryDto
    {
        public string Name { get; set; }
    }
}
