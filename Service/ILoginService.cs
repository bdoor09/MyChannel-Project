using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface ILoginService
    {
        public string GenearteToken(Login login);
        //void Register(string firstname, string lastname, int age, string email, string city, string country, DateTime dateOfBirth, DateTime registerDate, string username, string password);

        //void Register2(string firstName, string lastName, int age, string email, string city, string country, DateTime dateOfBirth, DateTime registerDate, string username, string password);
        public void Register(Register register);

        public Login GetByUserName(string usernme);
    }
}
