
//using Microsoft.IdentityModel.Tokens;
//using MyChannel.Core.Data;
//using MyChannel.Core.Repository;
//using MyChannel.Core.Service;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;





//namespace LearningHub2.Infra.Service
//{
//    public class LoginService : ILoginService
//    {

//        private readonly ILoginRepository LoginRepoistory;


//        public LoginService(ILoginRepository loginRepoistory)
//        {
//            this.LoginRepoistory = loginRepoistory;
//        }



//        public string GenearteToken(Login login) // return token value 
//        {

//            var identity = LoginRepoistory.GenerateToken(login); // return roleid and username if they match

//            if (identity == null)
//            {

//                return null;
//            }
//            else
//            {
//                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"));//Encode header + payload of token 
//                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
//                var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Name, identity.UserName),
//                   new Claim(ClaimTypes.Role, identity.RoleId.ToString())
//                };

//                var tokeOptions = new JwtSecurityToken(
//                                    claims: claims,
//                                     expires: DateTime.Now.AddHours(24),
//                                     signingCredentials: signinCredentials
//                        );
//                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);//
//                return tokenString;

//            }




//        }
//    }
//}


using Microsoft.IdentityModel.Tokens;
using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using System.Text;

using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using MyChannel.Core.Data;

using MyChannel.Core.Repository;

using MyChannel.Core.Service;

using System;

using System.Collections.Generic;

using System.IdentityModel.Tokens.Jwt;

using System.Linq;

using System.Security.Claims;

using System.Text;

using System.Threading.Tasks;
using MyChannel.Infra.Repository;
using System.Security.Policy;
using MyChannel.Core.DTO;

namespace LearningHub2.Infra.Service

{

    public class LoginService : ILoginService

    {

        private readonly ILoginRepository LoginRepoistory;

        public LoginService(ILoginRepository loginRepoistory)

        {

            this.LoginRepoistory = loginRepoistory;

        }




        public string GenearteToken(Login login)
        {
            var result = LoginRepoistory.GenerateToken(login);
            var getbyusername = LoginRepoistory.GetByUserName(login.Username);

            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hello oday ,hello roqaya algorthem enchode(key in singniger)"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim("roleid", result.Roleid.ToString()),
                    new Claim("userid",getbyusername.Userid.ToString()),
                    new Claim("username",getbyusername.Username.ToString())
                 



                };

                var tokeOptions = new JwtSecurityToken(
                                    claims: claims,
                                    expires: DateTime.Now.AddHours(24),
                                    signingCredentials: signinCredentials
                                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;

            }
        }

        public Login GetByUserName(string usernme)
        {
            return LoginRepoistory.GetByUserName(usernme);
        }



        //public string GenerateToken(Login login)
        //{
        //    var identity = LoginRepoistory.GenerateToken(login);

        //    if (identity == null || string.IsNullOrEmpty(identity.UserName) || identity.RoleId == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, identity.UserName),
        //    new Claim(ClaimTypes.Role, identity.RoleId.ToString())
        //};

        //        var tokenOptions = new JwtSecurityToken(
        //            claims: claims,
        //            expires: DateTime.Now.AddHours(24),
        //            signingCredentials: signinCredentials
        //        );

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return tokenString;
        //    }
        //}




        //public void Register(string firstname, string lastname, int age, string emaile, string city, string country, DateTime dateOfBirth, DateTime registerDate, string username, string password)
        //{

        //    LoginRepoistory.Register(firstname, lastname, age, emaile, city, country, dateOfBirth, registerDate, username, password);
        //}

        ////public void Register2(string firstName, string lastName, int age, string email, string city, string country, DateTime dateOfBirth, DateTime registerDate, string username, string password)
        ////{

        ////    LoginRepoistory.Register2(firstName, lastName, age, email, city, country, dateOfBirth, registerDate, username, password);

        ////}
        ///

        public void Register(Register register)
        {
            LoginRepoistory.Register(register);
        }









    }

}