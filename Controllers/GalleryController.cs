using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelAdmin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAdmin.Controllers
{
    public class GalleryController : Controller
    {
        // GET: /<controller>/
        private readonly HotelDBContext _context;

        private readonly IHostingEnvironment _appEnvironment;


        public GalleryController(HotelDBContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhotoLists.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.PhotoLists.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Create
        public IActionResult GalleryForm()
        {
            return View();
        }

        // POST: Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> GalleryForm(PhotoViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        foreach (var Image in files)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var file = Image;
        //                var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
        //                if (file.Length > 0)
        //                {
        //                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(fileStream);
        //                        model.PhotoUrl = fileName;
        //                    }

        //                }
        //            }
        //        }
        //        _context.Add(model);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //    }
        //    return View(model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GalleryForm(PhotoViewModel model)
        {
        //    string file = null;
        //    if (model.Photos != null)
        //    {
        //        string upload = Path.Combine(_appEnvironment.WebRootPath, "images");
        //        file = Guid.NewGuid().ToString() + "_" + model.Photos.FileName;
        //        string filePath = Path.Combine(file, upload);
        //        model.Photos.CopyTo(new FileStream(filePath, FileMode.Create));
        //    }
        //    PhotoList list = new PhotoList
        //    {
        //        Type = model.Type,
        //        PhotoUrl = model.Photos
        //    };
            return View();
        }
    }
}
