//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gilbert.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MD_EducationRequired
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MD_EducationRequired()
        {
            this.CR_AD_Detail = new HashSet<CR_AD_Detail>();
        }
    
        public long ID { get; set; }
        public string SDescrip { get; set; }
        public string LDescrip { get; set; }
        public Nullable<int> IDStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CR_AD_Detail> CR_AD_Detail { get; set; }
    }
}
