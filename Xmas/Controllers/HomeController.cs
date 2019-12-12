using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Entities;
using Xmas.Models;
using XmasDAL;

namespace Xmas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            MembreRepository mr = new MembreRepository();

            List<Membre> listeMembres = mr.GetAll().ToList();
            List<MembreInfo> listeMembresInfo = new List<MembreInfo>();

            foreach (Membre membre in listeMembres) {
                listeMembresInfo.Add(new MembreInfo(){  
                    IdMembre = membre.id, Nom = membre.Nom,
                    Prenom = membre.Prenom, Surnom = membre.Surnom,
                    Courriel = membre.Courriel, MotDePasse = membre.MotDePasse,
                    ImgProfil = "https://robohash.org/" + membre.Surnom + ".png"
                });
            }

            return View(listeMembresInfo);
        }

        public ActionResult TirageAuSortExemple() {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}