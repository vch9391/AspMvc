using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class ReadAPIController : Controller
    {
        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            var retVal = await new Service.ApiService().GetData();
            return View(retVal.list);
        }
    }
}
