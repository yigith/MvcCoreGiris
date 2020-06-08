using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;
using MvcCoreGiris.Services;

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

        public IActionResult Yeni()
        {
            var lns = (LuckyNumberService)HttpContext.RequestServices.GetService(typeof(LuckyNumberService));
            ViewBag.SansliSayi = lns.LuckyNumber;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Yeni(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                db.Add(kisi); //db.Kisiler.Add(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişi başarıyla eklenmiştir.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(kisi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.Update(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişinin bilgileri başarıyla güncellenmiştir.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                return NotFound();
            }

            db.Remove(kisi);
            db.SaveChanges();
            TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişi başarıyla silinmiştir.";
            return RedirectToAction(nameof(Index));
        }
    }
}
