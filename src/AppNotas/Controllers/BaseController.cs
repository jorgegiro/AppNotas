using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.Controllers
{
    public class BaseController : Controller
    {
        public UserManager<IdentityUser<int>> UserManager { get; set; }

        public BaseController(UserManager<IdentityUser<int>> userManager)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            UserManager = userManager;
        }

        protected Task<IdentityUser<int>> GetCurrentUser()
        {
            return UserManager.GetUserAsync(User);
        }
    }
}
