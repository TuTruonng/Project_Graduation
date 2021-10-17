﻿using KhoaLuanTotNghiep_BackEnd.Models;
using KhoaLuanTotNghiep_BackEnd.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManger;
        private readonly UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManger, UserManager<User> userManager)
        {
            _signInManger = signInManger;
            _userManager = userManager;
        }

        public class LoginModel
        {
            [Required]
            public string UserName { set; get; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        [HttpPost("/check-login")]
        public async Task<ActionResult<UserModel>> CheckLoginAsync()
        {
            if (_signInManger.IsSignedIn(User))
            {
                var userCurr = await _userManager.GetUserAsync(User);
                if (userCurr == null) return NotFound();
                var roles = await _userManager.GetRolesAsync(userCurr);
                return Ok(new UserModel
                {
                    UserId = userCurr.Id,
                    UserName = userCurr.UserName,
                    FullName = $"{userCurr.FirstName} {userCurr.LastName}",
                    RoleName = roles.Count > 0 ? roles[0] : "unknown",
                    Status = userCurr.IsChange.Value
                });
            }
            return NotFound();
        }


        [HttpPost("/login")]
        public async Task<ActionResult<UserModel>> LoginAsync(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var re = await _signInManger.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, true);
            if (re.IsLockedOut == true) return Forbid();
            if (re.Succeeded)
            {
                var userCurr = await _userManager.FindByNameAsync(loginModel.UserName);
                if (userCurr == null) return NotFound();
                var roles = await _userManager.GetRolesAsync(userCurr);
                return Ok(new UserModel
                {
                    UserId = userCurr.Id,
                    UserName = userCurr.UserName,
                    FullName = $"{userCurr.FirstName} {userCurr.LastName}",
                    RoleName = roles.Count > 0 ? roles[0] : "unknown",
                    Status = userCurr.IsChange.Value

                });
            }
            return NotFound();
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            if (!_signInManger.IsSignedIn(User)) return Forbid();
            await _signInManger.SignOutAsync();
            return NoContent();
        }


        public class ChangePassWordModel
        {
            [Required]
            public string OldPassword { get; set; }

            [Required]
            public string NewPassword { set; get; }
        }

        [Authorize]
        [HttpPost("/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePassWordModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.GetUserAsync(User);
            var changePassword = await _userManager.ChangePasswordAsync(user, userModel.OldPassword, userModel.NewPassword);
            if (changePassword.Succeeded) return Ok();
            var error = JsonSerializer.Serialize(changePassword.Errors);
            return Problem(error);
        }

        public class ChangePassWordFirstModel
        {
            [Required]
            public string NewPassword { set; get; }
        }

        [Authorize]
        [HttpPost("/change-password-first/{id}")]
        public async Task<IActionResult> ChangePasswordFirstAsync([FromBody] ChangePassWordFirstModel passWordFirstModel)
        {
            if (string.IsNullOrEmpty(passWordFirstModel.NewPassword)) return BadRequest();
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();
            var defaultPass = AccountHelper.GenerateAccountPass(user.UserName, user.DateOfBirth.Value);
            var changePassword = await _userManager.ChangePasswordAsync(user, defaultPass, passWordFirstModel.NewPassword);
            if (changePassword.Succeeded)
            {
                user.IsChange = true;
                await _userManager.UpdateAsync(user);
                return Ok();
            }
            var error = JsonSerializer.Serialize(changePassword.Errors);
            return Problem(error);
        }

    }
}