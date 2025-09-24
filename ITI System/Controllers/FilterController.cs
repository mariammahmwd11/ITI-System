using ITI_System.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_System.Controllers
{
    public class FilterController : Controller
    {
        [HandleError]
        [Authorize]
        public IActionResult Index()
        {
            throw new Exception("Exception fr index");
        }
    }
}
