using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum LoginResultCode
    {
        Success,
        NoRecordFound,
        InvalidName,

    }

    public class LoginResult
    {
        public LoginResult(LoginResultCode code)
        {
            Code = code;
        }

        public LoginResultCode Code { get; set; }

        public Boolean Succeeded { get { return Code == LoginResultCode.Success; } }
        public Boolean Failed { get { return Code != LoginResultCode.Success; } }

        public String Message
        {
            get
            {
                switch (Code)
                {
                    case LoginResultCode.Success:
                        return "Success";
                    case LoginResultCode.NoRecordFound:
                        return "No record found";
                    case LoginResultCode.InvalidName:
                        return "Invalid Name";

                    default:
                        return "";
                }
            }
        }

    }

    public class User
    {
        public Int32 UserId { get; set; }
        public String UserName { get; set; }

        public String Name { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }

        public static async Task<LoginResult> AddUser(DomainContext context, User user)
        {
            try
            {
                context.BeginTransaction();
                context.Users.Add(user);
                await context.CommitTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new LoginResult(LoginResultCode.Success);
        }

        

        public static async Task<User> AuthenticateUser (DomainContext context, String userName,String password)
        {
            
           User user = context.Users.Where(u => u.UserName == userName && u.Password == password).SingleOrDefault();
            return user;
        }
    }


  

}
