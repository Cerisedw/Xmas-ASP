using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Models;
using Xmas.Tools;
using Xmas.Tools.Filters;
using XmasDAL.Repository;

namespace Xmas.Areas.Membre.Controllers
{
    [CustomAuthorize]
    public class CadeauController : Controller
    {
        string connString = ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;

        // GET: Membre/Cadeaux
        public ActionResult Index()
        {
            CadeauRepository cr = new CadeauRepository(connString);
            IEnumerable<CadeauInfo> listeCadeaux = CadeauTools.ListeViewToDb(cr.GetAllFromMembre(SessionUtils.ConnectedUser.IdMembre));
            return View(listeCadeaux ?? new List<CadeauInfo>());
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Current = "Cadeau";
            CadeauRepository cr = new CadeauRepository(connString);
            CadeauInfo cadeau = CadeauTools.MbDbToView(cr.Get(id));
            return View(cadeau);
        }

        [HttpPost]
        public ActionResult Edit(CadeauInfo cadeau)
        {
            ViewBag.Current = "Cadeau";
            cadeau.IdMembre = SessionUtils.ConnectedUser.IdMembre;
            CadeauRepository cr = new CadeauRepository(connString);
            if (cr.Update(CadeauTools.CadeauInfoToCadeau(cadeau)))
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(CadeauInfo cadeau)
        {
            cadeau.IdMembre = SessionUtils.ConnectedUser.IdMembre;
            CadeauRepository cr = new CadeauRepository(connString);
            if (cr.Insert(CadeauTools.CadeauInfoToCadeau(cadeau)) != null)
            {
                return RedirectToAction("Index", new { controller = "Cadeau", area = "Membre" });
            }
            else
            {
                ViewBag.Current = "Cadeau";
                return View();
            }
        }


    }
}