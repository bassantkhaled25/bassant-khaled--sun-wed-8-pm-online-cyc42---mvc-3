using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PL.ViewModel;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;           //RoleManager => IdentityRole
        private readonly ILogger<IdentityRole> _logger;
        private readonly UserManager<ApplicationUser> _userManager;         //userManager (to get users) => IdentityUser(ApplicationUser : IdentityUser .. فبتعامل مع ال AppUser => زودت فيه حاجات + وارث من الاساسي  )

        public RoleController(RoleManager<IdentityRole> roleManager, ILogger<IdentityRole> logger, UserManager<ApplicationUser> userManager)

        {
            _roleManager = roleManager;
            _logger = logger;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel rolemodel)
        {
            if (ModelState.IsValid)

            {
                var role = new IdentityRole            //auto mapping=>RoleViewModel=>identityrole

                {
                    Name = rolemodel.Name,

                };

                var result = await _roleManager.CreateAsync(role);           //take (identity role)

                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                else

                {
                    foreach (var item in result.Errors)
                        _logger.LogError(item.Description);
                }
            }

            return View(rolemodel);
        }

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);


            if (role is null)
                return NotFound();

            var roleviewmodel = new RoleViewModel
            {

                Id = role.Id,
                Name = role.Name,
            };

            return View(viewName, roleviewmodel);
        }



        public async Task<IActionResult> Update(string id)

        {
            return await Details(id, "Update");

        }

        [HttpPost]

        public async Task<IActionResult> Update(string id, RoleViewModel roleViewModel)
        {
            if (id != roleViewModel.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);

                    if (role is null)
                        return NotFound();

                    role.Name = roleViewModel.Name;
                    role.NormalizedName = roleViewModel.Name.ToUpper();

                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)

                    {
                        _logger.LogInformation("User Updated Successfully");
                        return RedirectToAction(nameof(Index));
                    }

                    else

                        foreach (var item in result.Errors)
                            _logger.LogError(item.Description);
                }
                catch (Exception ex)

                {
                    _logger.LogError(ex.Message);

                }

            }

            return View(roleViewModel);            //return view with data
        }




        public async Task<IActionResult> Delete(string id)

        {
            try
            {

                var user = await _roleManager.FindByIdAsync(id);

                if (user is null)
                    return NotFound();

                var result = await _roleManager.DeleteAsync(user);


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


        public async Task<IActionResult> AddOrRemoveUsers(string roleId)

        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
                return NotFound();

                 ViewBag.RoleId = roleId;                                      //عشان احتفظ بال list

                var users = await _userManager.Users.ToListAsync();

                var UsersInRole = new List<UserInRoleViewModel>();                      //list 

                foreach (var user in users)

                {
                    var UserInrole = new UserInRoleViewModel                    //ApplicationUser => UserInRoleView

                    {
                        UserId = user.Id,
                        UserName = user.UserName

                    };

                    if (await _userManager.IsInRoleAsync(user, role.Name))           //userName/id + rolename(ex:Admin)
                        UserInrole.IsSelected=true;                                  //عشان اعرف اليوزر ده في الروول او لا
                    else
                        UserInrole.IsSelected=false;

                    UsersInRole.Add(UserInrole);                               //add in list (usersInRole)
                }

                return View(UsersInRole);                                       //return view with list
        }

        

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers (string roleId,List<UserInRoleViewModel>users)

        {
            var role = await _roleManager.FindByIdAsync(roleId);                          //role id

            if (role is null)
                return NotFound();


           if (ModelState.IsValid)

           {
              foreach (var user in users)                                              // هلف ع الusers in RoleViewModel

              {
                 var AppUser = await _userManager.FindByIdAsync(user.UserId);          //يجيب ال user in Role

                 if(AppUser is not null)

                 {
                      if (user.IsSelected && !await _userManager.IsInRoleAsync(AppUser, role.Name))        //checked user ((and)) doesnot have the role => add role
                     await _userManager.AddToRoleAsync(AppUser, role.Name);                       
                      else if (!user.IsSelected && await _userManager.IsInRoleAsync(AppUser, role.Name))   //unchecked user ((and)) has the role => remove role
                     await _userManager.RemoveFromRoleAsync(AppUser, role.Name);

                 }

              }

                return RedirectToAction("Update", new {id=roleId });
               
           }

            return View(users);                                            //list of users



        }







    } 
}
    

    


