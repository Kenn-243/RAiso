using RAiso.Models;
using RAiso.Repository;
using System;

namespace RAiso.Handlers
{
    public class UserHandler
    {
        public static bool CheckName(string userName)
        {
            MsUser userWithSameName = UserRepository.UsernameCheck(userName);
            if (userWithSameName != null)
            {
                return true;
            }
            
            return false;
        }

        public static string RegisterUser(string userName, DateTime userDOB, string userGender, string userAddress, string userPassword, string userPhone)
        {
            UserRepository.RegisterUser(userName, userDOB, userGender, userAddress, userPassword, userPhone);
            return "Success";
        }

        public static string LoginUser(string userName, string userPassword)
        {
            MsUser user = UserRepository.GetUser(userName, userPassword);
            if(user != null)
            {
                return "Success";
            }
            
            return "Wrong email or password";
        }

        public static string UpdateUser(int userId, string userName, string userGender, DateTime userDOB, string userPhone, string userAddress, string userPassword)
        {
            MsUser user = UserRepository.GetUserByUserId(userId);
            if(user != null)
            {
                UserRepository.UpdateUser(userId, userName, userGender, userDOB,userPhone,userAddress,userPassword);
                return "Success";
            }

            return "User Not Found";
        }

        public static MsUser GetUserByUserId(int userId)
        {
            MsUser user = UserRepository.GetUserByUserId(userId);
            if(user != null)
            {
                return user;
            }

            return null;
        }

        public static MsUser GetUser(string userName, string userPassword)
        {
            MsUser user = UserRepository.GetUser(userName, userPassword);
            if(user != null)
            {
                return user;
            }

            return null;
        }
    }
}