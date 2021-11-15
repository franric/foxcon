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
            using(var dbFun = new foxEntitSql())
            {
                return View(dbFun.Employees.ToList());
            }            
        }
    }
}