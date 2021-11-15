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

        public ActionResult Editar(int id)
        {
            try
            {
                using (var dbDepEdit = new foxEntitSql())
                {
                    Departamentos depEdit  = dbDepEdit.Departamentos.Find(id);

                    return View(depEdit);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error ao tentar editar o departamento" + e.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Departamentos dep)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var dbDepEdit = new foxEntitSql())
                {
                    Departamentos depEdit = dbDepEdit.Departamentos.Find(dep.id);
                    depEdit.name = dep.name;
                    
                    dbDepEdit.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error ao tentar editar o departameto " + e);
                return View();
            }
        }

        public ActionResult Detalhes(int id)
        {
            try
            {
                using (var dbDepDetalhes = new foxEntitSql())
                {
                    Departamentos depDetalhes = dbDepDetalhes.Departamentos.Find(id);
                    return View(depDetalhes);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Erro ao buscar os detalhes do departamento " + e.Message);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (var dbDepDelete = new foxEntitSql())
            {
                Departamentos depDelete = dbDepDelete.Departamentos.Find(id);

                dbDepDelete.Departamentos.Remove(depDelete);
                dbDepDelete.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}