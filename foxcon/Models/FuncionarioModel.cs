using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace foxcon.Models
{
    public class FuncionarioModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int id_departamento { get; set; }
        [Required]
        [Display(Name = "Nome do Funcionário")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Salário")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal salary { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string gender { get; set; }        
        [Display(Name = "Status")]
        public string active { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string nomeDepartamento { get; set; }
    }
    
    [MetadataType(typeof(FuncionarioModel))]
    public partial class Employees
    {

    }
}