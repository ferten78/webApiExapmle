using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiTest.Model;

namespace webApiTest.Controllers
{
    public class UserController : ApiController
    {
           
        //    /api/User/GetAllUser 
        //    /api/User/GetUser?name=fatih
        //    /api/User/GetUser?lName=fatihf&fName=erten


        [HttpGet]
        public List<User> GetAllUser()
        {
            var responseList = new List<User>();

            using (webApiEntities contex = new webApiEntities())
            {
                try
                {
                    responseList = contex.User.ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }


            return responseList;
        }

        [HttpGet]
        public List<User> GetUser(string name)
        {
            var responseList = new List<User>();

            using (webApiEntities contex = new webApiEntities())
            {
                try
                {
                    responseList = contex.User.Where(x => x.FirstName.Contains(name)).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }


            return responseList;
        }

        [HttpGet]
        public string AddUser(string fName, string lName)
        {
            string result = "";
            if (!string.IsNullOrEmpty(fName) && !string.IsNullOrEmpty(lName))
            {
                User newUser = new User();


                using (webApiEntities contex = new webApiEntities())
                {
                    try
                    {
                        newUser.FirstName = fName;
                        newUser.LastName = lName;

                        contex.User.Add(newUser);
                        contex.SaveChanges();

                        result = "Eklendi";
                    }
                    catch (Exception)
                    {

                        result = "Eklenemedi";
                    }

                }
            }
            return result;
        }
    }
}
