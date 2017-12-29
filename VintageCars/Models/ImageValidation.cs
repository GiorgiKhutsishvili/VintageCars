using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VintageCars.Models
{
    
    public class ImageValidation
    {


        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        //[Required]
        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase postedFile { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ დასათაურება")]
        public string Title { get; set; }
    }
}