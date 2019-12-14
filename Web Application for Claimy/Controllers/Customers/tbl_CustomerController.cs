using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using Web_Application_for_Claimy.Models;
using WebGrease.Css.Ast;

namespace Web_Application_for_Claimy.Controllers.Customers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class tbl_CustomerController : ControllerBase
    {
        private helper.ICustomer _customerService;
        private IMapper _mapper;
        private readonly Appsettings _appSettings;

        public tbl_CustomerController(
            helper.ICustomer _customerService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _customerService = customerService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var customer = _customerService.Authenticate(model.Email, model.Password);

            if (customer == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, customer.Id_Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Email = customer.Id_Email,
                Name = customer.Name,
                Adress = customer.Adress,
                PhoneNumber = customer.PhoneNumber,
                CountryNumber = customer.CountryNumber,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]Models.Customers.RegisterCustomer model)
{
// map model to entity
            var customer = _mapper.Map<CustomerEntity>(model);

            try
            {
                // create user
                _customerService.Create(customer, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customer = _customerService.GetAll();
            var model = _mapper.Map<IList<Models.Customers.CustomerModel>>(customer);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string email)
        {
            var customer = _customerService.GetByEmail(email);
            var model = _mapper.Map<Models.Customers.CustomerModel>(customer);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string email, [FromBody]Models.Customers.CustomerUpdate model)
        {
            // map model to entity and set id
            var customer = _mapper.Map<CustomerEntity>(model);
            customer.Id_Email = email;

            try
            {
                // update user 
                _customerService.Update(customer, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string email)
        {
            _customerService.Delete(email);
            return Ok();
        }
    }
}