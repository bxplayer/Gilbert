using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gilbert.Models
{
    public class ViewUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Telephone { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Nationality { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<ViewUserEducation> ViewUserEducation { get; set; }
        public virtual ICollection<ViewUserWorkExperience> ViewUserWorkExperience { get; set; }
        

    }

    public class ViewUserEducation
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string EducationSegment { get; set; }
        public string EducationLevel { get; set; }

    }

    public class ViewUserWorkExperience
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Position { get; set; }
        public string PositionDescrip { get; set; }
        public string TaskDescrip { get; set; }
    }
}