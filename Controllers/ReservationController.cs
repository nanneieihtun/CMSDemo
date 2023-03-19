using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAdmin.Controllers
{
    public class ReservationController : Controller
    {
        // GET: /<controller>/
        private readonly HotelDBContext _context;

        public ReservationController(HotelDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string search = null)
        {
            var movies = from m in _context.Reservations
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(s => s.Name.Contains(search));
            }

            return View(await movies.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
