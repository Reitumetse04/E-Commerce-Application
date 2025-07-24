using Microsoft.AspNetCore.Mvc;
using ClearCartApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ClearCartApi.Models;
using Microsoft.AspNetCore.Authorization;


namespace ClearCartApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClearCartController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public ClearCartController(ShoppingCartContext context)
        {
            _context = context;
        }

        // DELETE api/clearcart/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            var cartItems = await _context.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return NotFound("Cart is already empty or user does not exist.");
            }

            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return Ok("Cart cleared successfully.");
        }


        // POST api/clearcart/add
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.UserId))
            {
                return BadRequest("Invalid cart item.");
            }

            await _context.CartItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok("Item added to cart.");
        }

    }
}
