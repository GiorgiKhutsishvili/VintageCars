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
            AdminTbl admin = db.AdminTbl.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password); 
            
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
            if(Session["admin"] == null)
            {
                return RedirectToAction("Login", "Administrator");
            }

            var result = new ConsumedModels
            {
                imageTbl = db.ImageTbl.ToList(),
                serviceTbl = db.ServiceTbl.ToList(),
                socialLinksTbl = db.SocialLinksTbl.ToList(),
                subscriberTbl = db.SubscriberTbl.ToList()
            };
            
            return View(result);
        }


        public ActionResult Addimage()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Administrator");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Addimage(ImageValidation image, HttpPostedFileBase postedFile)
        {
            ImageTbl tbl = new ImageTbl();

            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg"
            };

            if (postedFile == null || image.Title == null)
            {
                return View();
            }

            var fileName = Path.GetFileName(postedFile.FileName); //getting only file name(ex-img.jpg)
            var ext = Path.GetExtension(postedFile.FileName); //getting the extension(ex-.jpg)

            //extension დასამატებელია

            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension
                string myfile = name + "_" + ext; //appending the name with ext

                // store the file inside ~/project folder(Img)
                var path = Path.Combine(Server.MapPath("~/Img"), myfile);

                tbl.Image_url = image.postedFile.ToString();
                tbl.Title = image.Title;
                tbl.Image_url = path;
                tbl.CarPicture = name;
                tbl.Date = DateTime.Now;
                db.ImageTbl.Add(tbl);
                db.SaveChanges();
                postedFile.SaveAs(path);

                return RedirectToAction("Adminpanel", "Administrator");
            }
           
            else
            {
                ViewBag.message = "ატვირთეთ შემდეგი გაფართოების ფაილები: .JPG, .png, .jpg, jpeg";
            }

            return View();
        }

    }
}