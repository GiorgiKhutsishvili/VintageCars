using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VintageCars.Models
{
    public class SocialLinksModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "სავალდებულო ველი")]
        public string LinkName { get; set; }

        [Required(ErrorMessage = "სავალდებულო ველი")]
        public string SocialLinks { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        public HttpPostedFileBase file { get; set; }
    }
}