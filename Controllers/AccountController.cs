using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wrap.Data;
using Wrap.Model;
using Wrap.Services;

namespace Wrap.Controllers
{
    [ApiController]
    [Route("[controller]")]     

    public class AccountController : Controller
    {
        private readonly AccountContext _context;
        private readonly SmtpService _email;


        public AccountController(AccountContext context, SmtpService email)
        {
            _context = context;
            _email = email;
        }
        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            return _context.Account != null ?
                         View("Index", await _context.Account.ToListAsync()) :
                         Problem("Error");

        }
        [HttpPost(Name = "DeleteAcc")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var acc = await _context.Account.FindAsync(id);
            _context.Account.Remove(acc);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Account());
        }
        [HttpPost("Create", Name ="Create")]
        public async Task<IActionResult> Create1([FromForm] Account acc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(acc);
        }
        [HttpPost("Email", Name = "Email")]
        public IActionResult Email()
        {
            _email.SendEmail();
           return RedirectToAction("Index");
        }

    }
}
