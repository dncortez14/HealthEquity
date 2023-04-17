using HealthEquity.Context;
using Microsoft.AspNetCore.Mvc;

namespace HealthEquity.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiddleController : ControllerBase
    {
        private readonly CarsContext _context;

        public RiddleController(CarsContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public async Task<ActionResult<bool>> PriceRiddle(Args args)
        {
            var car = await _context.Cars.FindAsync(args.id);

            if (car == null)
            {
                return NotFound();
            }

            double minPrice = car.Price - 5000;
            double maxPrice = car.Price + 5000;

            return args.price >= minPrice && args.price <= maxPrice;
        }
    }

    public class Args
    {
        public int id { get; set; }

        public double price { get; set; }
    }
}
