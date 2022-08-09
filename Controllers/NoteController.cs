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
        public Notes Notes { get; set; }

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
        public async Task<IActionResult> GetDataFromViewField(int id, string name, string surName, string patronimyc, int phoneNumber, string address, string information)
        {
            _db.Note.Add(
                    new Notes()
                    {
                        Id = id,
                        Name = name,
                        SurName = surName,
                        Patronymic = patronimyc,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        Information = information
                    });

            await _db.SaveChangesAsync();
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Notes = await _db.Note.FindAsync(id);

            if (Notes != null)
            {
                _db.Note.Remove(Notes);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AllView));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Notes = await _db.Note.FindAsync(id);

            return View(Notes);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Notes note)
        {
            _db.Note.Update(note);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(AllView));
        }
    }
}
