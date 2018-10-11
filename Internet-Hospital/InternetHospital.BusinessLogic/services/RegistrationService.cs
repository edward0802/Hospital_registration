using InternetHospital.BusinessLogic.Interfaces;
using InternetHospital.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetHospital.BusinessLogic.services
{
    public class RegistrationService : IRegistrationService
    {


        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}


            // WE CAN split this functionality on different parts (create role, addRole, create user, register user)
        public Task<ActionResult> RegistrateDoctor(UserRegistrationModel vm)
        {
            //var user = Mapper.Map<User>(vm); 
            throw new NotImplementedException();
        }

        public Task<ActionResult> RegistratePatient(UserRegistrationModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
