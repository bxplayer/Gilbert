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
    
    public partial class MD_State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MD_State()
        {
            this.CR_Company = new HashSet<CR_Company>();
            this.USR_CV_Header = new HashSet<USR_CV_Header>();
        }
    
        public long ID { get; set; }
        public string SDescrip { get; set; }
        public string LDescrip { get; set; }
        public Nullable<int> IDStatus { get; set; }
        public int IDCountry { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CR_Company> CR_Company { get; set; }
        public virtual MD_Country MD_Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USR_CV_Header> USR_CV_Header { get; set; }
    }
}
