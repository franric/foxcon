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

        public ActionResult Editar(int id)
        {
            try
            {
                using (var dbfunEdit = new foxEntitSql())
                {
                    Employees funEdit = dbfunEdit.Employees.Find(id);

                    funEdit.salary = Convert.ToDecimal(funEdit.salary);

                    return View(funEdit);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error ao tentar editar o funcionário" + e.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Editar(FuncionarioModel fun)
        {
            try
            {
                fun.salary = Convert.ToDecimal(fun.salary);

                if (!ModelState.IsValid)
                    return View();


                using (var dbFunEdit = new foxEntitSql())
                {
                    Employees funEdit = dbFunEdit.Employees.Find(fun.id);
                    funEdit.name = fun.name;
                    funEdit.id_departamento = fun.id_departamento;
                    funEdit.gender = fun.gender;
                    funEdit.salary = fun.salary;

                    dbFunEdit.SaveChanges();

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
                using (var db = new foxEntitSql())
                {
                    var list = from e in db.Employees
                               join d in db.Departamentos on e.id_departamento equals d.id
                               where e.id == id
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

                    return View(list.FirstOrDefault());
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Erro ao buscar os detalhes do departamento " + e.Message);
                return View();
            }
        }


    }
}