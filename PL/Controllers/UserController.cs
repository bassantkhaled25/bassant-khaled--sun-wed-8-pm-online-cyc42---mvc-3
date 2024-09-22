using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.ViewModel;
using System.Linq.Expressions;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManager ,ILogger<UserController> logger)

        {
            _userManager = userManager;
            _logger = logger;
        }


        public async Task<IActionResult> Index(string SearchValue)

        {
            List<ApplicationUser> users;

            if (string.IsNullOrEmpty(SearchValue))


            users = await _userManager.Users.ToListAsync();

            else

            {
                users = await _userManager.Users.Where(user => user.NormalizedEmail.Trim().Contains(SearchValue.Trim().ToUpper())).ToListAsync();

            }

            return View(users);


        }



        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);


            if (user is null)
                return NotFound();

            if (viewName=="Update")
            {
                var userViewModel = new UserViewModel                     //manual mapping( ApplicationUser => view model)

                {
                    Id = user.Id,
                    UserName = user.UserName

                };


                return View(viewName, userViewModel);
            }

            return View(viewName, user);
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)

        {
            return await Details(id, "Update");

        }


        [HttpPost]

        public async Task<IActionResult> Update(string id, UserViewModel userViewModel)   //عملت userviewmodel => عشان ابعت الحاجه اللي عاوزها بس
        {
            if (id != userViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try

                {
                    var user = await _userManager.FindByIdAsync(id);

                    if (user is null)
                        return NotFound();

                    user.UserName = userViewModel.UserName;
                    user.NormalizedUserName = userViewModel.UserName.ToUpper();

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)

                    {
                        _logger.LogInformation("User Updated Successfully");
                        return RedirectToAction(nameof(Index));
                    }

                    foreach (var item in result.Errors)
                        _logger.LogError(item.Description);
                }
                catch (Exception ex)

                {
                    _logger.LogError(ex.Message);

                }
               
            }

            return View(userViewModel);            //return view with data
        }


        public async Task<IActionResult> Delete(string id)

        {
            try
            {

                var user = await _userManager.FindByIdAsync(id);

                if (user is null)
                    return NotFound();

                var result = await _userManager.DeleteAsync(user);


                if (result.Succeeded)

                    return RedirectToAction(nameof(Index));


                foreach (var item in result.Errors)
                    _logger.LogError(item.Description);
            }

            catch (Exception ex)


            {
                _logger.LogError(ex.Message);
            }

            return RedirectToAction(nameof(Index));



        








        }











    }
}
