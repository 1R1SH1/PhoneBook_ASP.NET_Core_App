using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook_ASP.NET_Core_App.Models.Interfaces;

namespace PhoneBook_ASP.NET_Core_App.Controllers
{
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private readonly IRepository _noteStorage;

        public NoteController(ILogger<NoteController> logger, IRepository noteStorage)
        {
            _logger = logger;
            _noteStorage = noteStorage;
        }

        public IActionResult Index()
        {
            var notes = _noteStorage.GetAll();

            return View(notes);
        }

        public IActionResult Details(int id)
        {
            var note = _noteStorage.GetById(id);

            if (note == null)
            {
                return RedirectToAction("Index");
            }

            return View(note);
        }
    }
}
