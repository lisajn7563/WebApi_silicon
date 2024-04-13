using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_silicon.Attributes;

namespace WebApi_silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [UseApiKey]
    public class SubscribersController(ApiContext context) : ControllerBase
    {
        public readonly ApiContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetSubscribers()
        {
            return Ok(await _context.Subscribes.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {
                if (!await _context.Subscribes.AnyAsync(x => x.Email == form.Email))
                {
                    try
                    {
                        _context.Subscribes.Add(SubscribeFactory.Create(form));
                        await _context.SaveChangesAsync();
                        return Created("", null);
                    }
                    catch { }
                    return Problem();
                }
                return Conflict();
            }
            return BadRequest();
        }
    }
}
