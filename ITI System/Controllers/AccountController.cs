using ITI_System.Models;
using ITI_System.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITI_System.Controllers
{
    public class AccountController : Controller

    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
      
        

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser RegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                //mapping
                user.UserName = RegisterViewModel.UserName;
                user.Address = RegisterViewModel.Address;
                user.PasswordHash = RegisterViewModel.PassWord;
                //create cookie
              IdentityResult result=await userManager.CreateAsync(user, RegisterViewModel.PassWord);
                if(result.Succeeded)
                {
                    var result2 = await userManager.AddToRoleAsync(user, "Student"); 
                    if (!result2.Succeeded)
                    {
                        foreach (var err in result2.Errors)
                            Console.WriteLine(err.Description);
                    }

                    //if Authentication ==have acookie then sign in
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View("Register",RegisterViewModel);

        }

        [HttpGet]
        public IActionResult login()
        {
            return View("login");
        }
        
        public async Task<IActionResult> Login(loginUserViewModel loginUserView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                //check for name
             user= await userManager.FindByNameAsync(loginUserView.Name);
                if(user!=null)
                {
                    //check for pass
                    bool found = await userManager.CheckPasswordAsync(user, loginUserView.password);
                    if(found==true)
                    {
                        await signInManager.SignInAsync(user, loginUserView.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Passowrd is wrong :( ");
                    }
                }

            }
            return View("login", loginUserView);
        }

        public async Task<IActionResult> signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

        public IActionResult test()
        {
            if(User.Identity.IsAuthenticated)
            {
                Claim idcliam=User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id= idcliam.Value;
                return Content($"{User.Identity.Name}\n {id}");
     

            }
            return Content("not authenticated");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserNameAvailable(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"User name {UserName} is already taken.");
            }
        }

    }
}
