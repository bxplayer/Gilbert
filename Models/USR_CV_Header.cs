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
    
    public partial class USR_CV_Header
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USR_CV_Header()
        {
            this.USER_CV_Education = new HashSet<USER_CV_Education>();
            this.USER_CV_WorkExperience = new HashSet<USER_CV_WorkExperience>();
        }
    
        public long ID { get; set; }
        public long IDUser { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public Nullable<long> IDState { get; set; }
        public Nullable<long> IDNationality { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<int> Age { get; set; }
        public int IDStatus { get; set; }
    
        public virtual MD_State MD_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CV_Education> USER_CV_Education { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CV_WorkExperience> USER_CV_WorkExperience { get; set; }
        public virtual USR_User USR_User { get; set; }
    }
}