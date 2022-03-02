using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        kutuphaneDBEntities db = new kutuphaneDBEntities();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAPLARs.ToList();
            return View(kitaplar);
        }

    }
}