using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Models;
using Xmas.Tools;
using XmasDAL;
using XmasDAL.Repository;

namespace Xmas.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        string connString = @"Data Source=WAD-12\ADMINSQL;Initial Catalog=XmasDb;User ID=aspuser;Password=test1234=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: Membre/Home
        public ActionResult Index()
        {
            if (Session["ConnectedUser"] != null)
            {
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }else
            {
                return View();
            }
        }

        public ActionResult Profil()
        {
            if(SessionUtils.ConnectedUser != null)
            {
                string[] dir = Directory.GetFiles(HttpContext.Server.MapPath("/Content/img/"), $"{SessionUtils.ConnectedUser.IdMembre}.*");
                if (dir.Count() > 0)
                {
                    string x = dir[0].Substring(dir[0].LastIndexOf(@"\") + 1);
                    SessionUtils.ConnectedUser.ImgProfil = "/Content/img/" + x;
                }
                    return View();

            }
            return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
        }

        [HttpGet]
        public ActionResult ProfilModif()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProfilModif(MembreInfo m, HttpPostedFileBase file)
        {
            m.IdMembre = SessionUtils.ConnectedUser.IdMembre;
            MembreRepository mr = new MembreRepository(connString);
            if (mr.Update(MembreVtoDb.MbviewToDb(m)))
            {
                if(file != null)
                {

                    string[] dir = Directory.GetFiles(HttpContext.Server.MapPath("/Content/img/"), $"{SessionUtils.ConnectedUser.IdMembre}.*");
                    if (dir.Count() > 0)
                    {
                        foreach(string imgPath in dir)
                        {
                            System.IO.File.Delete(imgPath);
                        }
                    }

                    var fileExtension = (file.ContentType).Substring((file.ContentType).LastIndexOf('/') + 1);
                    m.ImgProfil = $"/Content/img/{m.IdMembre}.{fileExtension}";
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("/Content/img/"), $"{m.IdMembre}.{fileExtension}"));
                }
                SessionUtils.ConnectedUser = m;
                return RedirectToAction("Profil", new { controller = "Home", area = "Membre" });
            }
            return View();
        }


        public ActionResult Groupe()
        {
            GroupeRepository gr = new GroupeRepository(connString);
            IEnumerable<GroupeInfo> listeGroupes = GroupeTools.ListeViewToDb(gr.GetAllFromMembre(SessionUtils.ConnectedUser.IdMembre));
            return View(listeGroupes ?? new List<GroupeInfo>());
        }


        [HttpPost]
        public ActionResult Login(MembreInfo m)
        {
            MembreRepository mr = new MembreRepository(connString);
            MembreInfo membre = MembreVtoDb.MbDbToView(mr.getByLogin(MembreVtoDb.MbviewToDb(m)));
            if (membre != null)
            {
                SessionUtils.ConnectedUser = membre;
                return RedirectToAction("Profil", new { controller = "Home", area = "Membre" });
            }

            return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
        }

        [HttpPost]
        public ActionResult SignUp(MembreInfo m)
        {
            MembreRepository mr = new MembreRepository(connString);
            mr.Insert(MembreVtoDb.MbviewToDb(m));
            return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
        }

        public ActionResult LogOff()
        {
            SessionUtils.ConnectedUser = null;
            return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
        }
    }
}