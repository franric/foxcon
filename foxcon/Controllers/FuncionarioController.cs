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
            using(var db = new foxEntitySql())
            {
                var list = from e in db.EMPLOYEES
                           join d in db.DEPARTAMENTOS on e.ID_DEPARTAMENTO equals d.ID
                           select new FuncionarioModel()
                           {
                               ID = e.ID,
                               NAME = e.NAME,
                               NOMEDEPARTAMENTO = d.NAME,
                               SALARY = e.SALARY,
                               GENDER = e.GENDER,
                               ACTIVE = e.ACTIVE,
                               MODFIELD_AT = e.MODFIELD_AT,
                           };

                return View(list.ToList());
            }            
        }

        public ActionResult ListaDEPARTAMENTOS()
        {
            using (var depLista = new foxEntitySql())
            {
                return PartialView(depLista.DEPARTAMENTOS.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EMPLOYEES fun)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var dbFunCreate = new foxEntitySql())
                {
                    fun.CREATED_AT = DateTime.Now;
                    fun.MODFIELD_AT = DateTime.Now;
                    fun.ACTIVE = "A";

                    dbFunCreate.EMPLOYEES.Add(fun);
                    dbFunCreate.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Erro ao tentar inserir o funcionário: " + e);
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var dbfunEdit = new foxEntitySql())
                {
                    EMPLOYEES funEdit = dbfunEdit.EMPLOYEES.Find(id);

                    funEdit.SALARY = Convert.ToDecimal(funEdit.SALARY);

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
                fun.SALARY = Convert.ToDecimal(fun.SALARY);

                if (!ModelState.IsValid)
                    return View();


                using (var dbFunEdit = new foxEntitySql())
                {
                    EMPLOYEES funEdit = dbFunEdit.EMPLOYEES.Find(fun.ID);
                    funEdit.NAME = fun.NAME;
                    funEdit.ID_DEPARTAMENTO = fun.ID_DEPARTAMENTO;
                    funEdit.GENDER = fun.GENDER;
                    funEdit.SALARY = fun.SALARY;
                    funEdit.MODFIELD_AT = DateTime.Now;

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
                using (var db = new foxEntitySql())
                {
                    var list = from e in db.EMPLOYEES
                               join d in db.DEPARTAMENTOS on e.ID equals d.ID
                               where e.ID == id
                               select new FuncionarioModel()
                               {
                                   ID = e.ID,
                                   NAME = e.NAME,
                                   NOMEDEPARTAMENTO = d.NAME,
                                   SALARY = e.SALARY,
                                   GENDER = e.GENDER,
                                   ACTIVE = e.ACTIVE,
                                   MODFIELD_AT = e.MODFIELD_AT,
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

        public ActionResult Delete(int id)
        {
            using (var dbFunDelete = new foxEntitySql())
            {
                EMPLOYEES funDelete = dbFunDelete.EMPLOYEES.Find(id);

                dbFunDelete.EMPLOYEES.Remove(funDelete);
                dbFunDelete.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}