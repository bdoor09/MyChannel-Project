using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class ContactService: IContactService
    {

        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)

        {

            this.contactRepository = contactRepository;

        }

        public List<Contact> GetAllContact()

        {

            return contactRepository.GetAllContact();

        }

        public Contact GetContactById(int id)

        {

            return contactRepository.GetContactById(id);

        }

        public void CreateContact(Contact contact)

        {

            contactRepository.CreateContact(contact);

        }

        public void UpdateContact(Contact contact)

        {

            contactRepository.UpdateContact(contact);

        }

        public Contact DeleteContact(int id)

        {

            return contactRepository.DeleteContact(id);

        }

    }
}
