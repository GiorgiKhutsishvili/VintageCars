using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VintageCars.Models
{
    public class ServicesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "სავალდებულო ველი")]
        public string ServiceTitle { get; set; }

        [Required(ErrorMessage = "აირჩიეთ ფაილი")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase serviceImg { get; set; }
    }
}