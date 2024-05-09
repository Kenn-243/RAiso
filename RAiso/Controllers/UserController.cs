using RAiso.Handlers;
using RAiso.Models;
using System;
using System.Net;
using System.Web;

namespace RAiso.Controllers
{
    public class UserController
    {
        public static bool UserOneYearOld(string userDOB)
        {
            DateTime currentDate = DateTime.Now;
            DateTime birthDate = Convert.ToDateTime(userDOB);
            int age = currentDate.Year - birthDate.Year;

            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            if (age >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsAlphanumerical(string password)
        {
            int hasLetter = 0;
            int hasDigit = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLetter(password[i]))
                {
                    hasLetter++; ;
                }
                if (char.IsDigit(password[i]))
                {
                    hasDigit++;
                }
            }

            if (hasLetter > 0 && hasDigit > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   

        public static string RegisterUser(string userName, string userDOB, string userGender, string userAddress, string userPassword, string userPhone)
        {
            bool nameNotUnique = UserHandler.CheckName(userName);
            string response;

            if(userName.Length < 5 || userName.Length > 50)
            {
                response = "Name must have 5 - 50 characters";
            }
            else if (nameNotUnique)
            {
                response = "Name must be unique";
            }
            else if (userDOB.Equals(""))
            {
                response = "DOB must be filled";
            }
            else if (UserOneYearOld(userDOB))
            {
                response = "User must be at least one year old";
            }
            else if (userGender.Equals(""))
            {
                response = "Gender must be selected";
            }
            else if (userAddress.Equals(""))
            {
                response = "Address must be filled";
            }
            else if (!IsAlphanumerical(userPassword))
            {
                response = "Password must be Alphanumerical";
            }
            else if (userPhone.Equals(""))
            {
                response = "Phone must be filled";
            }
            else
            {
                DateTime userDOBDateTime = Convert.ToDateTime(userDOB);
                response = UserHandler.RegisterUser(userName, userDOBDateTime, userGender, userAddress, userPassword, userPhone);
            }
            
            return response;
        }

        public static string LoginUser(string userName, string userPassword)
        {
            string response;

            if (userName.Length <= 0)
            {
                 response = "Name must be filled";
            }
            else if (userPassword.Length <= 0)
            {
                response = "Password must be filled";
            }
            else
            {
                response = UserHandler.LoginUser(userName, userPassword);
            }

            return response;
        }

        public static string UpdateUser(int userId, string userName, string userGender, string userDOB, string userPhone, string userAddress, string userPassword)
        {
            bool nameNotUnique = UserHandler.CheckName(userName);
            string response;

            if (userName.Length < 5 || userName.Length > 50)
            {
                response = "Name must have 5 - 50 characters";
            }
            else if (nameNotUnique)
            {
                response = "Name must be unique";
            }
            else if (userDOB.Equals(""))
            {
                response = "DOB must be filled";
            }
            else if (UserOneYearOld(userDOB))
            {
                response = "User must be at least one year old";
            }
            else if (userGender.Equals(""))
            {
                response = "Gender must be selected";
            }
            else if (userAddress.Equals(""))
            {
                response = "Address must be filled";
            }
            else if (!IsAlphanumerical(userPassword))
            {
                response = "Password must be Alphanumerical";
            }
            else if (userPhone.Equals(""))
            {
                response = "Phone must be filled";
            }
            else
            {
                DateTime userDOBDateTime = Convert.ToDateTime(userDOB);
                response = UserHandler.UpdateUser(userId, userName, userGender, userDOBDateTime, userPhone, userAddress, userPassword);
            }

            return response;
        }

        public static MsUser GetUserByUserId(int userId)
        {
            return UserHandler.GetUserByUserId(userId);
        }

        public static MsUser GetUser(string userName, string userPassword)
        {
            return UserHandler.GetUser(userName, userPassword);
        }
    }
}