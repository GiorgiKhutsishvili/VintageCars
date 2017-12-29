using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VintageCars.Models
{
    [Table("ImageTbl")]
    public class ImageValidation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        public HttpPostedFileBase file { get; set; }

        [Display(Name = "test")]
        [Required(ErrorMessage = "დასათაურება")]
        public string Title { get; set; }
    }
}