using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public class ContactsRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ContactsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }


        public List<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToList();
        }


        public ContactModel Create(ContactModel contacts)
        {
           _databaseContext.Contacts.Add(contacts);
            _databaseContext.SaveChanges();

            return contacts;
        }

      
    }
}
