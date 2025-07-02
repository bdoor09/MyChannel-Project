using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return (userRepository.GetUserById(id));
        }

        public void CreateUser(User user)
        {
            userRepository.CreateUser(user);

        }
        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        public User DeleteUser(int id)
        {
            return (userRepository.DeleteUser(id));
        }

        public int TotalUsers()
        {
            return userRepository.TotalUsers();
        }

        public void UpdateUserProfile(UserProfileDTO userProfile)
        {
            userRepository.UpdateUserProfile(userProfile);
        }

        //public List<getprofile> GetUserProfile(int id)
        //{
        //    return userRepository.GetUserProfile(id);
        //}

        public getprofile GetUserProfile(int id)
        {
            return userRepository.GetUserProfile(id);
        }

        public List<NotifyByAdmin> GetNotfiByAdmin(int p_userid)
        {
            return userRepository.GetNotfiByAdmin(p_userid);
        }



        public bool checkNotifcation(int userid)
        {
            return userRepository.checkNotifcation(userid);
        }









    }
}
