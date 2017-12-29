using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VintageCars.Models
{
    public class ImageValidation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        public HttpPostedFileBase file { get; set; }

        [Required(ErrorMessage = "დასათაურება")]
        public string Title { get; set; }
    }
}