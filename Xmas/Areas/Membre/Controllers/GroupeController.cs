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
    public class GroupeController : Controller
    {
        string connString = ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;

        // GET: Membre/Groupe
        public ActionResult Index()
        {
            GroupeRepository gr = new GroupeRepository(connString);
            IEnumerable<GroupeInfo> listeGroupes = GroupeTools.ListeViewToDb(gr.GetAllFromMembre(SessionUtils.ConnectedUser.IdMembre));
            return View(listeGroupes ?? new List<GroupeInfo>());
        }

        // GET: Membre/Groupe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Membre/Groupe/Create
        public ActionResult Create()
        {
            EvenementRepository er = new EvenementRepository(connString);
            List<EvenementInfo> listeEvents = EvenementTools.ListeViewToDb(er.GetAll());
            return View(listeEvents);
        }

        // POST: Membre/Groupe/Create
        [HttpPost]
        public ActionResult Create(GroupeInfo groupe)
        {
            // Ajouter l'ajout du groupe avec l'id de l'evenement contenu dans evenement afin d'ajouter le groupe au membre de la session
            GroupeRepository gr = new GroupeRepository(connString);
            if(gr.InsertWithAdmin(GroupeTools.MbviewToDb(groupe), SessionUtils.ConnectedUser.IdMembre) != null)
            {
                return RedirectToAction("Index", new { controller = "Groupe", area = "Membre" });

            }
            else
            {
                ViewBag.Current = "Groupe";
                return View();
            }
        }

        // GET: Membre/Groupe/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Current = "Groupe";
            GroupeRepository gr = new GroupeRepository(connString);
            EditGroupeInfo groupeEdit = GroupeTools.GroupeToEdit(gr.Get(id));
            return View(groupeEdit);
        }

        // POST: Membre/Groupe/Edit/5
        [HttpPost]
        public ActionResult Edit(GroupeInfo groupe)
        {
            ViewBag.Current = "Groupe";
            GroupeRepository gr = new GroupeRepository(connString);
            if (gr.Update(GroupeTools.MbviewToDb(groupe)))
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        // GET: Membre/Groupe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Membre/Groupe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
