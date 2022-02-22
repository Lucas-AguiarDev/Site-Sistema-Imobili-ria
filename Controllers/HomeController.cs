using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvImoveis.Models;

namespace mvImoveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ImoveisService().Listar());
        }

        public IActionResult QuemSomos()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }

        
        
    }
}
