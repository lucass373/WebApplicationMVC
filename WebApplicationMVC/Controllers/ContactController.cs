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


        public IActionResult Update(int id)
        {
            ContactModel contact = _contactRepository.ListId(id);

            return View(contact);
        }


        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.ListId(id);

            return View(contact);
        }


        public IActionResult Delete(int id)
        {
            try
            {
            bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["msgSuccess"] = "Contact deleted with success!";
                }
                else
                {
                    TempData["msgError"] = "Contact can't br deleted, try again!";
                }

            return RedirectToAction("Index");
            }
            catch(Exception error)
            {
                TempData["msgError"] = $"Contact can't br deleted, try again! error:{error.Message}";
                return RedirectToAction("Index");
            }


        }


        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Create(contact);
                    TempData["msgSuccess"] = "Contact created with success!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception error)
            {
                TempData["msgError"] = $"The Contact can't be added, try again. Error details: {error.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["msgSuccess"] = "Contact updated with success!";
                    return RedirectToAction("Index");

                }
                return View(contact);

            }
            catch (Exception error)
            {
                TempData["msgError"] = $"The Contact can't be added, try again. Error details: {error.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
