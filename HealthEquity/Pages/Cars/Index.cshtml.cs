using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthEquity.Context;
using HealthEquity.Models;

namespace HealthEquity.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarsContext _context;

        public IndexModel(CarsContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cars != null)
            {
                Car = await _context.Cars.ToListAsync();
            }
        }
    }
}
