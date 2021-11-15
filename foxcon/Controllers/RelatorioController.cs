using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foxcon.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult TotalSalario()
        {
            return View();
        }
    }
}