//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace foxcon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPARTAMENTOS
    {
        public DEPARTAMENTOS()
        {
            this.EMPLOYEES = new HashSet<EMPLOYEES>();
        }
    
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public string ACTIVE { get; set; }
        public System.DateTime CREATED_AT { get; set; }
        public System.DateTime MODFIELD_AT { get; set; }
    
        public virtual ICollection<EMPLOYEES> EMPLOYEES { get; set; }
    }
}
