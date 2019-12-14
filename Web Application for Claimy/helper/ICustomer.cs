using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Web_Application_for_Claimy.Models;

namespace Web_Application_for_Claimy.helper
{
    public interface ICustomer
    {
        Models.CustomerEntity Authenticate(string email, string password);
        IEnumerable<CustomerEntity> GetAll();
        Models.CustomerEntity GetByEmail(string email);
        Models.CustomerEntity Create(CustomerEntity customer, string password);
        void Update(CustomerEntity customer, string password = null);
        void Delete(string email);
    }

    public class CustomerService : ICustomer
    {
        private CustomerContext _context;

        public CustomerService (CustomerContext context)
        {
            _context = context;
        }

        public CustomerEntity Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var customer = _context.Customers.SingleOrDefault(x => x.fld_Email == email);

            // check if email exists
            if (customer == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
                return null;

            // authentication successful
            return customer;
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _context.Customers;
        }

        public CustomerEntity GetById(string email)
        {
            return _context.Customers.Find(email);
        }

        public CustomerEntity Create(CustomerEntity customer, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Customers.Any(x => x.fld_Email == customer.fld_Email))
                throw new AppException("Username \"" + customer.fld_Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void Update(CustomerEntity customerParam, string password = null)
        {
            var customer = _context.Customers.Find(customerParam.fld_Email);

            if (customer == null)
                throw new AppException("User not found");

            // update Name if it has changed
            if (!string.IsNullOrWhiteSpace(customerParam.fld_Name) && customerParam.fld_Name != customerParam.fld_Name)
            {
                // throw error if the new Name is already taken
                if (_context.Customers.Any(x => x.fld_Name == customerParam.fld_Name))
                    throw new AppException("Username " + customerParam.fld_Name + " is already taken");

                customer.fld_Name = customerParam.fld_Name;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(customer.fld_Adress))
                customer.fld_Adress = customerParam.fld_Adress;

            if (!string.IsNullOrWhiteSpace(customer.fld_Phone_No))
                customer.fld_Phone_No = customerParam.fld_Phone_No;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                customer.PasswordHash = passwordHash;
                customer.PasswordSalt = passwordSalt;
            }

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(string email)
        {
            var user = _context.Customers.Find(email);
            if (user != null)
            {
                _context.Customers.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public CustomerEntity GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}