using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;

namespace MvcCoreGiris.Controllers
{
    public class KisilerController : Controller
    {
        private readonly OkulContext db;
        public KisilerController(OkulContext okulContext)
        {
            db = okulContext;
        }

        public IActionResult Index()
        {
            return View(db.Kisiler.ToList());
        }
    }
}
