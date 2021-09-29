using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gilbert.Models
{
    public class Partial_Class
    {
    }

    public partial class CR_AD_Header
    {
        [Required]
        public string Details { get; set; }
    }
}