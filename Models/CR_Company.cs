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
    
    public partial class CR_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CR_Company()
        {
            this.CR_User = new HashSet<CR_User>();
        }
    
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int PostCode { get; set; }
        public long IDState { get; set; }
        public string Telephone { get; set; }
        public string TaxId { get; set; }
        public int IDStatus { get; set; }
    
        public virtual MD_State MD_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CR_User> CR_User { get; set; }
    }
}