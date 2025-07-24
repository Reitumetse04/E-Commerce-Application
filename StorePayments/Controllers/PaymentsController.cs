using Microsoft.AspNetCore.Mvc;
using ClothingStorePayments.Models;
using ClothingStorePayments.Data;

namespace ClothingStorePayments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment([FromBody] Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment recorded", payment.TotalAmount });
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = _context.Payments.ToList();
            return Ok(payments);
        }
    }
}
