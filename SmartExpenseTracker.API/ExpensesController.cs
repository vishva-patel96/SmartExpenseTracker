using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;

namespace SmartExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/expenses
        [HttpGet]
        public async Task<ActionResult<List<ExpenseResponseDto>>> GetAll()
        {
            var expenses = await _expenseService.GetAllAsync();

            // ✅ Map to DTOs with category information
            var expenseDtos = expenses.Select(e => new ExpenseResponseDto
            {
                Id = e.Id,
                Amount = e.Amount,
                Date = e.Date,
                CategoryId = e.CategoryID,
                CategoryName = e.category?.Name ?? "Unknown"  // ✅ Extract the name
            }).ToList();

            return Ok(expenseDtos);
        }


        // POST: api/expenses
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateExpenseDto dto)
        {
            var expense = new Expense(dto.Amount, dto.Date, dto.CategoryId);
            await _expenseService.AddAsync(expense);
            return Ok(new { message = "Expense created successfully" });
        }


        

        // DELETE: api/expenses/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _expenseService.DeleteAsync(id);
            return Ok(new { message = "Expense deleted successfully" });
        }
    }

    // DTOs (Data Transfer Objects)
    public class CreateExpenseDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateExpenseDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
    public class ExpenseResponseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }  // Category name included!
    }
}