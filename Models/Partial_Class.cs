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

    public partial class JobsPostulate
    {
        public CR_AD_Header cR_AD_Header { get; set; }
        public USR_User uSR_User { get; set; }
        public USR_CV_Header uSR_CV_Header { get; set; }

        public List<long> uSER_CR_Postulate { get; set; }
    }
}