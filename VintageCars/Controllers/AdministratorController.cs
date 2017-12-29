using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VintageCars.Models;

namespace VintageCars.Controllers
{
    public class AdministratorController : Controller
    {

        VintageCarsDBEntities db = new VintageCarsDBEntities();
        

        public ActionResult Login()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Adminpanel", "Administrator");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Login login)
        {
            AdminTbl admin = db.AdminTbls.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password); 
            
            if(admin == null)
            {
                ViewBag.message = "მომხმარებლის სახელი ან პაროლი არასწორია";
                return View();
            }
            else
            {
                Session["admin"] = admin;
                return RedirectToAction("Adminpanel", "Administrator");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Administrator");
        }


        public ActionResult Adminpanel()
        {
            return View();
        }


        public ActionResult Addimage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addimage(ImageValidation image, FormCollection fc, HttpPostedFileBase file)
        {
            ImageTbl tbl = new ImageTbl();

            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
            };

            tbl.Id = image.Id;
            tbl.Image_url = file.ToString();
            tbl.Title = image.Title;

            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-img.jpg)
            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)

            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension
                string myfile = name + "_" + tbl.Id + ext; //appending the name with id

                // store the file inside ~/project folder(Img)
                var path = Path.Combine(Server.MapPath("~/Img"), myfile);
                tbl.Image_url = path;
                tbl.CarPicture = name;
                tbl.Date = DateTime.Now;
                db.ImageTbls.Add(tbl);
                db.SaveChanges();
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
            }

            return View();
        }

    }
}