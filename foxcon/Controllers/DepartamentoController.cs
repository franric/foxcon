using foxcon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foxcon.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            using (foxEntitSql depList = new foxEntitSql())
            {
                return View(depList.Departamentos.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departamentos dep)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                dep.active = "A";
                dep.created_at = DateTime.Now;

                using (var depCreate = new foxEntitSql())
                {
                    depCreate.Departamentos.Add(dep);
                    depCreate.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Erro ao inserir o departamento " + e.Message);
                return View();
            }
        }
    }
}