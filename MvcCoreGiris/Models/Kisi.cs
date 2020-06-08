using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Models
{
    public class Kisi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunlu.")]
        [Display(Name = "Ad")]
        public string KisiAd { get; set; }
    }
}
