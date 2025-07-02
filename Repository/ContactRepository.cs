using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class ContactRepository: IContactRepository
    {

        private readonly IDbContext dbContext;
        public ContactRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Contact> GetAllContact()
        {
            IEnumerable<Contact> result = dbContext.Connection.Query<Contact>("Contact_Package.GET_ALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contact GetContactById(int id)
        {
            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contact>("Contact_Package.GET_CONTACT_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateContact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("NAMES", contact.Name, DbType.String, direction: ParameterDirection.Input);
            p.Add("SUBJECTS", contact.Subject, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENTS", contact.Content, DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAILS", contact.Email, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", contact.Homeid, DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.Connection.Execute("Contact_Package.CREAT_NEW_CONTACT", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateContact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("cid", contact.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMES", contact.Name, DbType.String, direction: ParameterDirection.Input);
            p.Add("SUBJECTS", contact.Subject, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENTS", contact.Content, DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAILS", contact.Email, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", contact.Homeid, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Contact_Package.UPDATE_CONTACT", p, commandType: CommandType.StoredProcedure);

        }

        public Contact DeleteContact(int id)
        {
            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contact>("Contact_Package.DELETE_CONTACT", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
