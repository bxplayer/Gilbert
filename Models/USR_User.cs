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
    
    public partial class USR_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USR_User()
        {
            this.USR_CV_Header = new HashSet<USR_CV_Header>();
        }
    
        public long ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Telephone { get; set; }
        public string UserPhoto { get; set; }
        public string Password { get; set; }
        public int IDStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USR_CV_Header> USR_CV_Header { get; set; }
    }
}
