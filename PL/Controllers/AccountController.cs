using DAL.Entities;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using PL.Models;
using PL.ViewModel;
using SERVIES.Helper;
using System.Security.Cryptography.X509Certificates;

namespace PL.Controllers
{
	public class AccountController : Controller

	{
		private readonly UserManager<ApplicationUser> _userManager;            //class(user manager) (signinmanager)
		private readonly SignInManager<ApplicationUser> _signInManager;

		

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)

		{
			_userManager = userManager;
			_signInManager = signInManager;

		}


		#region SignUp

		[HttpGet]
		public IActionResult SignUp()                     //SignUp

		{
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel input)

		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser

				{

					UserName = input.Email.Split("@")[0],
					Email = input.Email,
					FirstName = input.FirstName,
					LastName = input.LastName,
					IsActive = input.IsActive,


				};

				var result = await _userManager.CreateAsync(user, input.Password);

				if (result.Succeeded)

					return RedirectToAction(nameof(SignIn));

				foreach (var error in result.Errors)

				{

					ModelState.AddModelError("", error.Description);

				}


			}
			return View(input);                                    //signup view model

		}

		#endregion




		#region SignIn

		public IActionResult SignIn()

		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViweModel input)
		{
			if (ModelState.IsValid)

			{
				var user = await _userManager.FindByEmailAsync(input.Email);

				if (user is not null)

				{
					if (await _userManager.CheckPasswordAsync(user, input.Password))

					{
						var result = await _signInManager.PasswordSignInAsync(user, input.Password, input.RemeberMe, true);

						if (result.Succeeded)
							return RedirectToAction("Index", "Home");   //action/controller
					}


				}

				ModelState.AddModelError("", "Email is not Exsited Or Incorrect Password");
				return View(input);

			}

			return View(input);
		}

		#endregion




		#region SignOut

		public new async Task<IActionResult> SignOut()

		{
			await _signInManager.SignOutAsync();

			return RedirectToAction(nameof(SignIn));
		}


		#endregion


		#region forget password

		public IActionResult ForgetPassword()                           //مش نفس الاسماء

		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendEmail(ForgetPasswordViewModel input)

		{
			if (ModelState.IsValid)
				
			{
				var user = await _userManager.FindByEmailAsync(input.Email);

				if (user is not null)

				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);

					var URL = Url.Action("ResetPassword", "Account", new { Email = input.Email, Token = token }, Request.Scheme);

					var email = new Email

					{
						body = URL,
						Subject = "Reset Password",
						To = input.Email

					};

					EmailSettings.SendEmail(email);
					return RedirectToAction(nameof(CheckYourInbox));

				}

				ModelState.AddModelError("", "Email is not Existed , pls Enter a Valid one");
               
            }

			return View("ForgetPassword",input);

        }
		

        #endregion

        public IActionResult CheckYourInbox()

		{
			return View();
		}

		#region Reset Password

		public IActionResult ResetPassword(string email, string token)

		{			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel input)
		{
			if (ModelState.IsValid)
			{

				var user = await _userManager.FindByEmailAsync(input.Email);

				if (user is not null)

				{

					var result = await _userManager.ResetPasswordAsync(user, input.Token, input.NewPassword);

					if (result.Succeeded)
						return RedirectToAction(nameof(SignIn));

					foreach (var error in result.Errors)

						ModelState.AddModelError("", error.Description);
				}
			}

			return View(input);
		}


		#endregion







	}

}


