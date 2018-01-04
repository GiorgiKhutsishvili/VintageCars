using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
        public ActionResult Addimage(ImageModel image, HttpPostedFileBase postedFile)
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

           

            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension
                string myfile = name + "_" + ext; //appending the name with ext

                // store the file inside ~/project folder(Img)
                var path = Path.Combine(Server.MapPath("~/Content/Img"), name + ext);

                tbl.Image_url = image.postedFile.ToString();
                tbl.Title = image.Title;
                tbl.Image_url = path;
                tbl.CarPicture = name;
                tbl.Extension = ext;
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

        public ActionResult Edit(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Administrator");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageTbl imageTbl = db.ImageTbl.Find(id);
            if(imageTbl == null)
            {
                return HttpNotFound();
            }
            return View(imageTbl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title")] ImageTbl model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imageTbl = db.ImageTbl.Find(model.Id);
                    if (imageTbl == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", ".jpeg"
                    };

                    var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-img.jpg)
                    var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)

                    if (allowedExtensions.Contains(ext))
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension
                        string myfile = name + "_" + ext; //appending the name with ext

                        // store the file inside ~/project folder(Img)
                        var path = Path.Combine(Server.MapPath("~/Content/Img"), name + ext);

                        imageTbl.Image_url = file.ToString();
                        imageTbl.Title = model.Title;
                        imageTbl.Image_url = path;
                        imageTbl.CarPicture = name;
                        imageTbl.Extension = ext;
                        imageTbl.Date = DateTime.Now;
                        db.SaveChanges();
                        file.SaveAs(path);
                        return RedirectToAction("Adminpanel", "Administrator");
                    }

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            db.ImageTbl.Remove(db.ImageTbl.Where(x => x.Id == Id).FirstOrDefault());
            db.SaveChanges();

            return Json("DeleteSucceeded", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Services()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Administrator");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Services(ServicesModel services, HttpPostedFileBase serviceImg)
        {
            ServiceTbl tbl = new ServiceTbl();

            var allowedExtensions = new[]
            {
                ".Jpg", ".svg", ".png", ".jpg", ".jpeg"
            };

            if(serviceImg == null || services.ServiceTitle == null)
            {
                return View();
            }

            var fileName = Path.GetFileName(serviceImg.FileName);
            var ext = Path.GetExtension(serviceImg.FileName);

            if (allowedExtensions.Contains(ext))
            {
                string name = Path.GetFileNameWithoutExtension(fileName);

                var path = Path.Combine(Server.MapPath("~/Content/ServiceImages"), name + ext);

                tbl.Image_url = services.serviceImg.ToString();
                tbl.Title = services.ServiceTitle;
                tbl.Image_url = path;
                tbl.ServicePicture = name;
                tbl.Extension = ext;
                tbl.Date = DateTime.Now;
                db.ServiceTbl.Add(tbl);
                db.SaveChanges();
                serviceImg.SaveAs(path);

                return RedirectToAction("Adminpanel", "Administrator");
            }
            else
            {
                ViewBag.message = "ატვირთეთ შემდეგი გაფართოების ფაილები: .jpg, .svg, .png, .jpg, jpeg";
            }
            return View();
        }

    }
}