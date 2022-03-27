using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OmnivusV1.Models;
using OmnivusV1.Models.Data;

namespace OmnivusV1.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region SignUp
        public IActionResult SignUp(string returnUrl = null)
        {
            if(_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new SignUpModel();

            if (returnUrl != null)
                model.ReturnUrl = returnUrl;
            else
                model.ReturnUrl = "/";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var roleName = "User";

                if (!_userManager.Users.Any())
                    roleName = "Admin";

                var user = new AppUser()
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Adress = model.Adress,
                    PostalCode = model.PostalCode,
                    City = model.City,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (model.ReturnUrl == null || model.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(model.ReturnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            return View();
        }


        #endregion

        #region Sign in
        public IActionResult SignIn(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new SignInModel();

            if (returnUrl != null)
                model.ReturnUrl = returnUrl;
            else
                model.ReturnUrl = "/";


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                    if (model.ReturnUrl == null || model.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(model.ReturnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password, please try again");

            return View();
        }



        #endregion

        #region Sign out
        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        #endregion

    }
}
