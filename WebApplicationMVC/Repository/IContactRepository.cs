using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public interface IContactRepository
    {

        ContactModel ListId(int id);

        List<ContactModel> GetAll();

        ContactModel Create(ContactModel contacts);

        ContactModel Update(ContactModel contacts);

        bool Delete(int id);

    }
}
