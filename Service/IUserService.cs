using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        void CreateUser(User user);

        void UpdateUser(User user);

        User DeleteUser(int id);

        int TotalUsers();

        void UpdateUserProfile(UserProfileDTO userProfile);

        //List<getprofile> GetUserProfile(int id);

        public getprofile GetUserProfile(int id);


        public List<NotifyByAdmin> GetNotfiByAdmin(int p_userid);


       bool checkNotifcation(int userid);




    }
}
