using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using InternetHospital.BusinessLogic.Models;
using InternetHospital.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using InternetHospital.BusinessLogic.Interfaces;

namespace InternetHospital.WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMailService _mailService;

        public SignupController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMailService mailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        #region
        // GET: api/Signup/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion

        // POST: api/Signup
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRegistrationModel vm)
        {
            var user = Mapper.Map<User>(vm); // because our user in our Bd doesn't have FK to Role table, But Roles table has

            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(user.Email) == null)
                {
                    if (vm.Role == "Patient" || vm.Role == "patient")
                    {
                        if (await _roleManager.FindByNameAsync(vm.Role) == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(vm.Role));
                            // IdentityResult.Succeeded
                        }

                        var result = await _userManager.CreateAsync(user, vm.Password);
                        if (result.Succeeded)
                        {
                            // add role to our user
                            await _userManager.AddToRoleAsync(user, vm.Role);

                            //send confirmation message to email
                            var codes = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var callbackUrl = Url.Action(
                                "ConfirmEmail",
                                "Signup",
                                new {userId = user.Id, code = codes},
                                protocol: HttpContext.Request.Scheme
                            );

                            await _mailService.SendMsgToEmail(user.Email, "Confirm Your account, please",
                                 $"Confirm registration folowing the link: <a href='{callbackUrl}'>Confirm email NOW</a>");

                            return Ok("Your account is created. Confirm your account on email!");
                            //return Redirect("http://localhost:44390/Views/ConfirmEmail.html");  // http://localhost:51483/Views/ConfirmEmail.html
                        }


                    }
                    else if (vm.Role == "Doctor" || vm.Role == "doctor")
                    {
                        if (await _roleManager.FindByNameAsync(vm.Role) == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(vm.Role));
                        }



                    }
                    // if else (moderator) - will do it later
                    else
                    {
                        return BadRequest("Role type doesn't match conditions! must be only a Doctor or a patient");
                    }


                    return Ok(vm);
                }
                else
                {
                    return BadRequest("This email is already exist!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Wrong form!");
                return BadRequest(ModelState);
            }

           
            #region Some responding logic
            //// we also need to add automapper for mapping vm to user DB entity
            //// example of logic
            //if (vm.Role == "Doctor")
            //{

            //}
            //else if (vm.Role == "Patient")
            //{

            //}
            //else
            //{
            //    return BadRequest("Invalid request");
            //}

            //// again use automapper to map our user DB entity to vm
            //return Ok(vm);
            ////return Redirect("http://localhost:51483/someConfirmationInfo.html");
            #endregion
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("lost userId or token!");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Not such users in DB to confirm");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            return Ok("Email Confirmed!");
        }





    }
}
