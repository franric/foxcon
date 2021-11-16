using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace foxcon.Models
{
    public class DepartamentoModel
    {
        [Required]
        [Display(Name = "Nome do Departamento")]
        [MinLength(4)]
        public string name { get; set; }

        [Display(Name = "Ativo")]
        public string active { get; set; }
    }

    [MetadataType(typeof(DepartamentoModel))]
    public partial class Departamentos
    {

    }
}