using Infrastructure.Context;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi_silicon.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ApiContext context) : ControllerBase
{

    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var catergorise = await _context.Categories.OrderBy(o => o.CategoryName).ToListAsync();
        return Ok(CategoryFactory.Create(catergorise));
    }
}
