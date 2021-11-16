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
        public decimal ID { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public decimal ID_DEPARTAMENTO { get; set; }
        [Required]
        [Display(Name = "Nome do Funcionário")]
        public string NAME { get; set; }
        [Required]
        [Display(Name = "Salário")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SALARY { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string GENDER { get; set; }        
        [Display(Name = "Status")]
        public string ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATED_AT { get; set; }
        public Nullable<System.DateTime> MODFIELD_AT { get; set; }

        public string NOMEDEPARTAMENTO { get; set; }
    }
    
    [MetadataType(typeof(FuncionarioModel))]
    public partial class EMPLOYEES
    {

    }
}