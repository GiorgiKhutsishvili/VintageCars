using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VintageCars.Models
{
    public class Login
    {
        [Required(ErrorMessage = "ჩაწერეთ ელ.ფოსტა")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "ჩაწერილი ელ.ფოსტა არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [EmailAddress(ErrorMessage = "გთხოვთ ჩაწეროთ სწორედ ელ.ფოსტის მისამართ")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "ელ.ფოსტის ფორმატი არასწორია.")]

        public string Email { get; set; }

        
        [Required(ErrorMessage = "ჩაწერეთ პაროლი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}