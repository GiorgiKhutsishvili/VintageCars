using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VintageCars.Models
{
    
    public class ImageModel
    {

        public Int32 Id { get; set; }

        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase postedFile { get; set; }

        [Required(ErrorMessage = "სავალდებულო ველი")]
        public string Title { get; set; }
    }
}