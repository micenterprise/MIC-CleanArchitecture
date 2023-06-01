using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string Email, string Password)
    {
        var user = await _userManager.FindByEmailAsync(Email);
        if (user == null) { return Content("User not found"); }
        
        var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        return Content("Unsuccessful login");
    }
}
