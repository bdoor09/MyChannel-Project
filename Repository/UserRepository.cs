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
    public class UserRepository: IUserRepository
    {
        private readonly IDbContext dbContext;
        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> GetAllUsers()
        {

            IEnumerable<User> result = dbContext.Connection.Query<User>("User_Package.GET_ALL", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public User GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<User>("User_Package.GET_USER_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("First_NAME", user.Firstname, DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_Name", user.Lastname, DbType.String, direction: ParameterDirection.Input);
            p.Add("age", user.Age, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("email", user.Emaile, DbType.String, direction: ParameterDirection.Input);
            p.Add("city", user.City, DbType.String, direction: ParameterDirection.Input);
            p.Add("coun", user.Country, DbType.String, direction: ParameterDirection.Input);
            p.Add("BIRTHDAY_DATE", user.Dateofbirth, DbType.Date, direction: ParameterDirection.Input);
            p.Add("REGISTER_DATE", user.Registerdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", user.Phonenumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMA", user.Image, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("User_Package.CREAT_NEW_USER", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("uid", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("First_NAME", user.Firstname, DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_Name", user.Lastname, DbType.String, direction: ParameterDirection.Input);
            p.Add("age", user.Age, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("email", user.Emaile, DbType.String, direction: ParameterDirection.Input);
            p.Add("city", user.City, DbType.String, direction: ParameterDirection.Input);
            p.Add("coun", user.Country, DbType.String, direction: ParameterDirection.Input);
            p.Add("REGISTER_DATE", user.Registerdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", user.Phonenumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", user.Phonenumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMA", user.Image, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("User_Package.UPDATE_USER", p, commandType: CommandType.StoredProcedure);

        }

        public User DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<User>("User_Package.DELETE_USER", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int TotalUsers()
        {
            int count = dbContext.Connection.QuerySingle<int>("User_Package.TotalRegisteredUsers", commandType: CommandType.StoredProcedure);
            return count;
        }

        public void UpdateUserProfile(UserProfileDTO userProfile)
        {
            var p = new DynamicParameters();
            p.Add("p_user_id", userProfile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_firstname", userProfile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_lastname", userProfile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_age", userProfile.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_email", userProfile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_city", userProfile.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_country", userProfile.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_date_of_birth", userProfile.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_phonenumber", userProfile.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image", userProfile.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_username", userProfile.Username, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("User_Package.update_user_profile", p, commandType: CommandType.StoredProcedure);
        }

        //public List<getprofile> GetUserProfile (int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("user_id",id, dbType: DbType.Int32, direction:ParameterDirection.Input);
        //    var result = dbContext.Connection.Query<getprofile>("User_Package.GetUserProfile", p, commandType: CommandType.StoredProcedure);
        //    return result.ToList();


        //}

        public getprofile GetUserProfile(int id)
        {
            var p = new DynamicParameters();
            p.Add("user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<getprofile>("User_Package.GetUserProfile", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();


        }


        public List<NotifyByAdmin> GetNotfiByAdmin(int p_userid)
        {
            var p = new DynamicParameters();
            p.Add("p_userid", p_userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<NotifyByAdmin>("User_Package.Get_Notfy_By_Admin", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool checkNotifcation(int userid)

        {

            var p = new DynamicParameters();
            p.Add("p_userid", userid, DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Query<Payment>("User_Package.Get_Notfy_By_Admin", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() != null ? true : false;

        }




    }
}
