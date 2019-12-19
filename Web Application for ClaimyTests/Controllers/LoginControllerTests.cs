using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Application_for_Claimy.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Application_for_Claimy.Model;

namespace Web_Application_for_Claimy.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        [TestMethod()]
        public void AuthenticateLoginTest()
        {
            AuthenticateModel authenticate = new AuthenticateModel();
            LoginController login = new LoginController();

            authenticate.Email = "test21@mail.dk";
            authenticate.Password = "Password";
            
            login.AuthenticateLogin(authenticate.Email, authenticate.Password);

            Assert.Fail();
        }
    }
}