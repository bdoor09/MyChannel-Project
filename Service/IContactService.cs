using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IContactService
    {
        List<Contact> GetAllContact();

        Contact GetContactById(int id);

        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        Contact DeleteContact(int id);
    }
}
