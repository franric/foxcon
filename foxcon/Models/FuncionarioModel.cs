using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace foxcon.Models
{
    public class FuncionarioModel
    {
        public int id_departamento { get; set; }
        [Required]
        [Display(Name = "Nome do Empresgado")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Salário")]
        public decimal salary { get; set; }
        [Display(Name = "Genero")]
        public string gender { get; set; }
        [Display(Name = "Genero")]
        public string active { get; set; }
    }
    
    [MetadataType(typeof(FuncionarioModel))]
    public partial class Employees
    {

    }
}