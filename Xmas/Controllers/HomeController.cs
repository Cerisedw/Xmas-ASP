using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Entities;
using Xmas.Models;
using Xmas.Tools;
using XmasDAL;

namespace Xmas.Controllers
{
    public class HomeController : Controller
    {
        string connString = ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;
        public ActionResult Index()
        {
            MembreRepository mr = new MembreRepository(connString);


            List<Membre> listeMembres = mr.GetAll().ToList();
            List<MembreInfo> listeMembresInfo = new List<MembreInfo>();

            foreach (Membre membre in listeMembres) {

                string[] dir = Directory.GetFiles(HttpContext.Server.MapPath("/Content/img/"), $"{membre.id}.*");

                string x = dir[0].Substring(dir[0].LastIndexOf(@"\") + 1);
                string y = "/Content/img/" + x;


                listeMembresInfo.Add(new MembreInfo(){  
                    IdMembre = membre.id, Nom = membre.Nom,
                    Prenom = membre.Prenom, Surnom = membre.Surnom,
                    Courriel = membre.Courriel, MotDePasse = membre.MotDePasse,
                    ImgProfil = y
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