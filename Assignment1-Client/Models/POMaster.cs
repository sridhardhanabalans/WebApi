using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1_Api.Models
{
    public class POMaster
    {
        public string PONO { get; set; }
        public DateTime PODATE { get; set; }
        [Display(Description="Suppliers")]
        public string SUPLNO { get; set; }
    }
}