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
        IEnumerable<Models.CustomerEntity> GetAll();
        Models.CustomerEntity GetByEmail(string email);
        Models.CustomerEntity Create(Models.CustomerEntity customer, string password);
        void Update(Models.CustomerEntity customer, string password = null);
        void Delete(string email);
    }

    public class CustomerService : ICustomer
    {
        private CustomerContext _context;

        public CustomerService (CustomerContext context)
        {
            _context = context;
        }

        public Models.CustomerEntity Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var customer = _context.Customers.SingleOrDefault(x => x.Id_Email == email);

            // check if email exists
            if (customer == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
                return null;

            // authentication successful
            return customer;
        }

        public IEnumerable<Models.CustomerEntity> GetAll()
        {
            return _context.Customers;
        }

        public Models.CustomerEntity GetById(string email)
        {
            return _context.Customers.Find(email);
        }

        public Models.CustomerEntity Create(Models.CustomerEntity customer, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Customers.Any(x => x.Id_Email == customer.Id_Email))
                throw new AppException("Username \"" + customer.Id_Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void Update(Models.CustomerEntity customerParam, string password = null)
        {
            var customer = _context.Customers.Find(customerParam.Id_Email);

            if (customer == null)
                throw new AppException("User not found");

            // update Name if it has changed
            if (!string.IsNullOrWhiteSpace(customerParam.Name) && customerParam.Name != customerParam.Name)
            {
                // throw error if the new Name is already taken
                if (_context.Customers.Any(x => x.Name == customerParam.Name))
                    throw new AppException("Username " + customerParam.Name + " is already taken");

                customer.Name = customerParam.Name;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(customer.Adress))
                customer.Adress = customerParam.Adress;

            if (!string.IsNullOrWhiteSpace(customer.PhoneNumber))
                customer.PhoneNumber = customerParam.PhoneNumber;

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