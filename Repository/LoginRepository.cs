using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private readonly IDbContext dbContext;
        public LoginRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public Login GenerateToken(Login login)
        {
            var p = new DynamicParameters();
            p.Add("UserName", login.Username,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Login>("LOGIN_PACKAGE.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }



        public Login GetByUserName(string usernme)
        {
            var p = new DynamicParameters();
            p.Add("p_usename", usernme, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GetByUserName", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }




        public void Register(Register register)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_firstname", register.Firstname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_lastname", register.Lastname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_age", register.Age, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_email", register.Emaile, DbType.String, ParameterDirection.Input);
            parameters.Add("p_city", register.City, DbType.String, ParameterDirection.Input);
            parameters.Add("p_country", register.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("p_dateofbirth", register.DateOfBirth, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_registerdate", register.RegisterDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_phonenumber", register.Phonenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("p_image", register.Image, DbType.String, ParameterDirection.Input);
            parameters.Add("p_username", register.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("p_password", register.Password, DbType.String, ParameterDirection.Input);


            var result = dbContext.Connection.Execute("LOGIN_PACKAGE.Register", parameters, commandType: CommandType.StoredProcedure);
        }



    }
}
