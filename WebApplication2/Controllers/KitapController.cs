using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class KitapController : Controller
    {
        // GET: KitapDetay
        /*public ActionResult Index()
        {
            return View();
        }*/


        kutuphaneDBEntities db = new kutuphaneDBEntities();
        public ActionResult Detay(int id)
        {
            MyViewModel moddel = new MyViewModel();
            moddel.tblkitaplar = db.TBLKITAPLARs.Find(id);
            if(moddel.tblkitaplar.kitapIslem == null)
            {
                moddel.tblislemler.islemKisi = 0;
                moddel.tblislemler.islemTarih = DateTime.Now.Date;
            }
            else
            {
                moddel.tblislemler = db.TBLISLEMLERs.Find(moddel.tblkitaplar.kitapIslem);
                moddel.kisininAdi = db.TBLKISILERs.Find(moddel.tblislemler.islemKisi).kisiAd;
            }
            //var kitap = db.TBLKITAPLARs.Find(id);
            //var islem = db.TBLISLEMLERs.Find(kitap.kitapIslem);
            return View(moddel);
        }
        [HttpGet]
        public ActionResult Checkout(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(int id, TBLKISILER yenikisi)
        {
            var yenikisim = db.TBLKISILERs.Add(yenikisi);

            TBLISLEMLER yeniislem = new TBLISLEMLER();
            yeniislem.islemTarih = DateTime.Now.Date;
            yeniislem.islemKisi = yenikisim.kisiID;
            var yeniislemim = db.TBLISLEMLERs.Add(yeniislem);

            db.TBLKITAPLARs.Find(id).kitapIslem = yeniislemim.islemID;
            db.TBLKITAPLARs.Find(id).kitapDurum = "OUT";
            db.SaveChanges();

            return RedirectToAction("../");
        }
        [HttpGet]
        public ActionResult Checkin(int id)
        {
            var kitap = db.TBLKITAPLARs.Find(id);
            var islem = db.TBLISLEMLERs.Find(kitap.kitapIslem);
            var kisi = db.TBLKISILERs.Find(islem.islemKisi);
            Paslanacak toPass = new Paslanacak();
            toPass.kitapadi = kitap.kitapBaslik;
            toPass.kisiadi = kisi.kisiAd;
            toPass.telefonno = kisi.kisiTelefon;
            DateTime tarih = (DateTime)islem.islemTarih;
            tarih = tarih.AddDays(15);
            TimeSpan difference = DateTime.Now.Date.Subtract(tarih);
            int ceza = 0;
            if(difference.TotalDays > 0)
            {
                int temp = (int)difference.TotalDays;
                ceza = temp * 5;
            }
            toPass.cezamiktar = ceza.ToString();
            toPass.beklenenteslim = tarih.ToString();
            toPass.gercekteslim = DateTime.Now.Date.ToString(); 
            return View(toPass);
        }
        [HttpPost]
        public ActionResult Checkin(int id, int? addd)
        {
            if(addd == null)
            {

            }
            db.TBLKITAPLARs.Find(id).kitapDurum = "IN";
            db.TBLKITAPLARs.Find(id).kitapIslem = null;
            db.SaveChanges();
            return RedirectToAction("../");
        }
    }
}