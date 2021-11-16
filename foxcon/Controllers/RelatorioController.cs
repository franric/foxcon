using foxcon.Models;
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
            string sql = @"select sum(salary) as salary, d.name as nomeDepartamento from Employees e left join Departamentos d on e.id_departamento = d.id group by d.name";
            
            using (var rel = new foxEntitySql())
            {
                var data = rel.Database.SqlQuery<FuncionarioModel>(sql).ToList();
                return View(data);
            }            
        }
    }
}