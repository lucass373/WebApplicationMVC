using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();

        ContactModel Create(ContactModel contacts);
 
    }
}
