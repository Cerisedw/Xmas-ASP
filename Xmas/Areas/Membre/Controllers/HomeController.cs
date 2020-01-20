using System;
using System.Collections.Generic;
using System.Configuration;
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
    //[CustomAuthorize]
    public class HomeController : Controller
    {
        string connString = ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;

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


        //Login

        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            MembreRepository mr = new MembreRepository(connString);
            MembreInfo membre = MembreVtoDb.MbDbToView(mr.getByLogin(MembreVtoDb.loginToDb(m)));
            if (membre != null)
            {
                SessionUtils.IsConnected = true;
                SessionUtils.ConnectedUser = membre;
                return RedirectToAction("Profil", new { controller = "Home", area = "Membre" });
            }
            else
            {
                ViewBag.ErrorLoginMessage = "Erreur Login/Mot de passe";
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegisterModel m, HttpPostedFileBase file)
        {
            if (file.ContentLength > 80000)
            {
                ViewBag.ErrorMessage = "Le fichier est trop lourd.";
                return View("Index");
            }
            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br>";
                    }
                }
            }
            else
            {
                MembreRepository mr = new MembreRepository(connString);
                MembreInfo membre = MembreVtoDb.MbDbToView(mr.Insert(MembreVtoDb.registerToView(m)));
                if (membre != null)
                {
                    if (file != null)
                    {

                        var fileExtension = (file.ContentType).Substring((file.ContentType).LastIndexOf('/') + 1);
                        try
                        {
                            file.SaveAs(Path.Combine(HttpContext.Server.MapPath("/Content/img/"), $"{membre.IdMembre}.{fileExtension}"));
                            membre.ImgProfil = $"/Content/img/{membre.IdMembre}.{fileExtension}";
                        }
                        catch (Exception)
                        {
                            ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                            throw;
                        }
                        ViewBag.SuccessMessage = "Vous pouvez vous connecter";
                    }else
                    {
                        ViewBag.ErrorMessage = "Erreur lors de l'insertion";
                    }
                }
            }
            return View("Index");
        }

        public ActionResult LogOff()
        {
            SessionUtils.ConnectedUser = null;
            SessionUtils.IsConnected = false;

            return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
        }



    }
}