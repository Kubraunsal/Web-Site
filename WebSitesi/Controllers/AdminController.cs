using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSitesi.Models.Siniflar;


namespace WebSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int id)
        {
            var ag = c.AnaSayfas.Find(id);
            return View("AnaSayfaGetir", ag);
        }

        public ActionResult AnaSayfaGüncelle(AnaSayfa x)
        {
            var ag = c.AnaSayfas.Find(x.id);
            ag.isim = x.isim;
            ag.profil = x.profil;
            ag.unvan = x.unvan;
            ag.aciklama = x.aciklama;
            ag.iletisim = x.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult İkonListesi()
        {
            var deger = c.iconlars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(İconlar p)
        {
            c.iconlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }

        public ActionResult ikonGetir(int id)
        {
            var ig = c.iconlars.Find(id);
            return View("ikonGetir", ig);
        }

        public ActionResult ikonGüncelle(İconlar x)
        {
            var ig = c.iconlars.Find(x.id);
            ig.ikon = x.ikon;
            ig.link = x.link;
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }

        public ActionResult ikonSil(int id)
        {
            var sl = c.iconlars.Find(id);
            c.iconlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("İkonListesi");
        }
    }
}