using RAiso.Factory;
using RAiso.Models;
using System;
using System.Linq;

namespace RAiso.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static int GenerateID()
        {
            int newID = db.MsUsers.Select(x => x.UserID).ToList().LastOrDefault();
            if (newID == 0)
            {
                newID = 1;
            }
            else
            {
                newID++;
            }

            return newID;
        }

        public static MsUser UsernameCheck(string userName)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserName == userName);
        }

        public static void RegisterUser(String userName, DateTime userDOB, String userGender, String userAddress, String userPassword, String userPhone)
        {
            int userId = GenerateID();
            MsUser createUser = UserFactory.Create(userId, userName, userDOB, userGender, userAddress, userPassword, userPhone, "Customer");
            db.MsUsers.Add(createUser);
            db.SaveChanges();
        }

        public static void UpdateUser(int userId, string userName, string userGender, DateTime userDOB, string userPhone, string userAddress, string userPassword)
        {
            MsUser user = db.MsUsers.FirstOrDefault(x => x.UserID == userId);
            user.UserName = userName;
            user.UserGender = userGender;
            user.UserDOB = userDOB;
            user.UserPhone = userPhone;
            user.UserAddress = userAddress;
            user.UserPassword = userPassword;

            db.SaveChanges();
        }

        public static MsUser GetUser(string userName, string userPassword)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserName.Equals(userName) && x.UserPassword.Equals(userPassword));
        }

        public static MsUser GetUserByUserId(int userId)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserID == userId);
        }
    }
}