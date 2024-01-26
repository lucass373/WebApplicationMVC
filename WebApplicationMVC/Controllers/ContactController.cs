using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;
using WebApplicationMVC.Repository;

namespace WebApplicationMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult DeleteConfirmation()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Create(contact);
            return RedirectToAction("Index");
        }
    }
}
