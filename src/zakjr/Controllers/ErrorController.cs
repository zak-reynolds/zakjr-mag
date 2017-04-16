using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zakjr.ViewModels;

namespace zakjr.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult DisplayError(int errorcode)
        {
            var vm = new ErrorViewModel()
            {
                ErrorCode = errorcode
            };
            return View(vm);
        }
    }
}