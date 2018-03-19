using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Data.Services;
using WebProject.Models.BindingModels;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WebProject.Controllers
{

    public class PortfolioController : Controller
    {
        private ServiceMethods service = new ServiceMethods();

        [Authorize]
        public ActionResult MyPortfolio()
        {
            var model = service.GetMyPortfolio(User.Identity.Name);         
            return View(model);
        }

        public ActionResult ViewPortfolios()
        {
            var model = service.GetViewPortfoliosViewModel();
            return View("ViewPortfolios", model);
        }

        // GET: Portfolio/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(new PortfolioBindingModel());
        }

        // POST: Portfolio/Create
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PortfolioBindingModel model, HttpPostedFileBase image)
        {
            try
            {

                if (image != null)
                {
                    FileInfo file = new FileInfo(image.FileName);
                    var getEmailName = User.Identity.Name.Split('@')[0];
                    var fileName = Path.GetFileName(getEmailName + file.Extension);
                    var location = Path.Combine(
                        Server.MapPath("~/App_Data/ProfilePics"), fileName);

                    image.SaveAs(location);
                    service.UploadPortfolio(model, User.Identity.Name, location);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return View();
            }
        }

        // GET: Portfolio/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = service.GetPortfolioBindingModel(id);
            if (model != null)
                return View(model);
            else
                return RedirectToAction("Index", "Home", null);
        }

        // POST: Portfolio/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(PortfolioBindingModel model, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {
                    FileInfo file = new FileInfo(image.FileName);
                    var getEmailName = User.Identity.Name.Split('@')[0];
                    var fileName = Path.GetFileName(getEmailName + file.Extension);
                    var location = Path.Combine(
                        Server.MapPath("~/App_Data/ProfilePics"), fileName);

                    if (System.IO.File.Exists(location))
                    {
                        System.IO.File.Delete(location);
                    }

                    image.SaveAs(location);
                 
                }
                service.UpdatePortfolio(model, User.Identity.Name, "");
                return RedirectToAction("MyPortfolio", "Portfolio");  
            }
            catch
            {
                return View();
            }
        }
        // GET: Portfolio/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            service.DeletePortfolio(id);
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Details(int? id)
        {
            var model = service.Details(id);
            if(model == null)
            {
                return View("Error");
            }
            else
            return View(model);
        }

    }
}
