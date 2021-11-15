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
        
    }
}