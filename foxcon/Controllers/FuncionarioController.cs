using foxcon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foxcon.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            using(var db = new foxEntitSql())
            {
                var list = from e in db.Employees
                           join d in db.Departamentos on e.id_departamento equals d.id
                           select new FuncionarioModel()
                           {
                               id = e.id,
                               name = e.name,
                               nomeDepartamento = d.name,
                               salary = e.salary,
                               gender = e.gender,
                               active = e.active,
                               created_at = e.created_at,
                           };

                return View(list.ToList());
            }            
        }

        public ActionResult ListaDepartamentos()
        {
            using (var depLista = new foxEntitSql())
            {
                return PartialView(depLista.Departamentos.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees fun)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var dbFunCreate = new foxEntitSql())
                {
                    fun.created_at = DateTime.Now;
                    fun.active = "A";

                    dbFunCreate.Employees.Add(fun);
                    dbFunCreate.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Erro ao tentar inserir o funcionário");
                return View();
            }
        }
    }
}