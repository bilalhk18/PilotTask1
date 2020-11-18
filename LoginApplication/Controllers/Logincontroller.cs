using Domain.Entities;
using LoginApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginApplication.Controllers
{
    public class Logincontroller : BaseController
    {
        //For user login  
        [Route("Api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            User user = Domain.Entities.User.AuthenticateUser(context, Lg.UserName, Lg.Password).Result;

            if (user != null)
            {
                return new Response
                {
                    Status = "Success",
                    Message = Lg.UserName
                };
            }
            else 
            {
                return new Response
                {                   
                    Status = "Invalid",
                    Message = "Invalid User."
                };

            };
        }
        
    }
}
