using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Application_for_Claimy.helper;
using Web_Application_for_Claimy.Models;
using Web_Application_for_Claimy.Models.Customers;

namespace Web_Application_for_Claimy.Controllers.Customers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class tbl_CustomerController : ControllerBase
    {
        private ICustomer _customerService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public tbl_CustomerController(
            ICustomer customerService,
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
            var customer = _customerService.Authenticate(model.fld_Email, model.fld_Password);

            if (customer == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, customer.fld_Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Email = customer.fld_Email,
                Name = customer.fld_Name,
                Adress = customer.fld_Adress,
                PhoneNumber = customer.fld_Phone_No,
                CountryNumber = customer.fld_Country_Number,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterCustomer model)
        {
            // map model to entity
            var customer = _mapper.Map<CustomerEntity>(model);

            try
            {
                // create user
                _customerService.Create(customer, model.fld_Password);
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
            var customers = _customerService.GetAll();
            var model = _mapper.Map<IList<CustomerModel>>(customer);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string email)
        {
            var customer = _customerService.GetByEmail(email);
            var model = _mapper.Map<CustomerModel>(customer);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string email, [FromBody]CustomerUpdate model)
        {
            // map model to entity and set id
            var customer = _mapper.Map<CustomerEntity>(model);
            customer.fld_Email = email;

            try
            {
                // update user 
                _customerService.Update(customer, model.fld_Password);
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