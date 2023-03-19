using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotelAdmin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAdmin.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: /<controller>/
        private readonly HotelDBContext _context;
        private SignInManager<AdminUser> _signManager;

        public AdminUserController(HotelDBContext context, SignInManager<AdminUser> signManager)
        {
            _context = context;
            _signManager = signManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
        return View();
        }

        [BindProperty]
        public AdminUser user { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{

        //    _context.AdminUsers.Add(user);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("/Reservation");
        //}

        #region LogIn

        [HttpPost]
        public async Task<IActionResult> Login(AdminUser model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    //{
                    //    return Redirect(model.ReturnUrl);
                    //}
                    //else
                    //{
                        return RedirectToAction("Index", "Home");
                   // }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);

            //if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            //{
            //    return RedirectToAction("LogIn");
            //}

            //ClaimsIdentity identity = null;
            //bool isAuthenticated = false;

            ////AdminUser updateEntity = new AdminUser();
            ////updateEntity.Username = username;
            ////updateEntity.Password = password;
            //AdminUser result = await _context.AdminUsers.FirstOrDefaultAsync(m => m.Username == username && m.Password == password);

            //if (result != null)
            //{
            //    identity = CreateClaimsIdentity(result);
            //    isAuthenticated = true;
            //    ViewBag.Unauthorize = "Authorize";
            //}
            //else
            //{
            //    ViewBag.Unauthorize = "Unauthorize";
            //}
            //if (isAuthenticated)
            //{
            //    var principal = new ClaimsPrincipal(identity);
            //    var props = new AuthenticationProperties();
            //    props.AllowRefresh = true;
            //    props.IsPersistent = remember;
            //    props.ExpiresUtc = DateTime.Now.AddDays(1);

            //    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            //    return RedirectToAction("Index", "Reservation");
            //}

            //return View();
        }

        private ClaimsIdentity CreateClaimsIdentity(AdminUser result)
        {
            var memID = result.ID.ToString();
            var claims = new Claim[]
            {
              new Claim("urn:Custom:MemberID", memID),
              new Claim("urn:Custom:Username", result.Username),
              new Claim("urn:Custom:Password", result.Password)
            };

            return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddDays(-1),
                AllowRefresh = false
            });
            return RedirectToAction("LogIn");
        }
        #endregion
    }
}
