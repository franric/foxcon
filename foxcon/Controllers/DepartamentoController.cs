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
            using (foxEntitySql depList = new foxEntitySql())
            {
                return View(depList.DEPARTAMENTOS.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DEPARTAMENTOS dep)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                dep.ACTIVE = "A";
                dep.CREATED_AT = DateTime.Now;
                dep.MODFIELD_AT = DateTime.Now;

                using (var depCreate = new foxEntitySql())
                {
                    depCreate.DEPARTAMENTOS.Add(dep);
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
                using (var dbDepEdit = new foxEntitySql())
                {
                    DEPARTAMENTOS depEdit  = dbDepEdit.DEPARTAMENTOS.Find(id);

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
        public ActionResult Editar(DEPARTAMENTOS dep)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var dbDepEdit = new foxEntitySql())
                {
                    DEPARTAMENTOS depEdit = dbDepEdit.DEPARTAMENTOS.Find(dep.ID);
                    
                    depEdit.NAME = dep.NAME;
                    depEdit.MODFIELD_AT = DateTime.Now;

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
                using (var dbDepDetalhes = new foxEntitySql())
                {
                    DEPARTAMENTOS depDetalhes = dbDepDetalhes.DEPARTAMENTOS.Find(id);
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
            using (var dbDepDelete = new foxEntitySql())
            {
                DEPARTAMENTOS depDelete = dbDepDelete.DEPARTAMENTOS.Find(id);

                dbDepDelete.DEPARTAMENTOS.Remove(depDelete);
                dbDepDelete.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}