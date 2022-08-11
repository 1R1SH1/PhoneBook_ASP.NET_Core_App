using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook_ASP.NET_Core_App.ContextFolder;
using PhoneBook_ASP.NET_Core_App.Models.Classes;
using System.Threading.Tasks;

namespace PhoneBook_ASP.NET_Core_App.Controllers
{
    public class NoteController : Controller
    {
        private readonly DataContext _db = new();
        public Notes _Notes { get; set; }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> AllView()
        {
            ViewBag.Notes = await _db.Note.ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var note = await _db.Note.FirstOrDefaultAsync(x => x.Id == id);

            if (note == null)
            {
                return RedirectToAction(nameof(AllView));
            }

            return View(note);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Notes notes)
        {
            _db.Note.Add(notes);
            await _db.SaveChangesAsync();
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _Notes = await _db.Note.FindAsync(id);

            if (_Notes != null)
            {
                _db.Note.Remove(_Notes);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AllView));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Notes n = await _db.Note.SingleAsync(i => i.Id == id);
            return View(n);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Notes notes)
        {
            _db.Note.Update(notes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(AllView));
        }
    }
}
