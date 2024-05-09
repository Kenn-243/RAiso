using RAiso.Models;
using System;

namespace RAiso.Factory
{
    public class UserFactory
    {
        public static MsUser Create(int userId, String userName, DateTime userDOB, String userGender, String userAddress, String userPassword, String userPhone, String userRole)
        {
            return new MsUser()
            {
                UserID = userId,
                UserName = userName,
                UserDOB = userDOB,
                UserGender = userGender,
                UserAddress = userAddress,
                UserPassword = userPassword,
                UserPhone = userPhone,
                UserRole = userRole
            };
        }
    }
}