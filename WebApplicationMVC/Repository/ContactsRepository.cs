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

        public ContactModel ListId(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public ContactModel Update(ContactModel contacts)
        {
            ContactModel contactDB = ListId(contacts.Id);

            if (contactDB == null) throw new System.Exception("Error on Contact Update");

            contactDB.Name = contacts.Name;
            contactDB.Email = contacts.Email;
            contactDB.Phone = contacts.Phone;

            _databaseContext.Contacts.Update(contactDB);
            _databaseContext.SaveChanges();

            return contactDB;
        }

        public bool Delete(int id)
        {
            ContactModel contactDB = ListId(id);

            if (contactDB == null) throw new System.Exception("Error on Contact Update");

            _databaseContext.Contacts.Remove(contactDB);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
