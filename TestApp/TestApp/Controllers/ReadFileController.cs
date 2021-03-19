using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    public class ReadFileController : Controller
    {
        public IActionResult Index()
        {
            var retVal = new Service.FileService().GetData();
            return View(retVal);
        }
    }
}
