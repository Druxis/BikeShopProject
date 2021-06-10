
using ApplicationService.DTOs;
using Microsoft.Ajax.Utilities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BicycleController : Controller
    {
        // GET: Bicycle
        public ActionResult Index(string query)
        {
            List<BicycleVM> bicycleVM = new List<BicycleVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetBicycles(query))
                {
                    bicycleVM.Add(new BicycleVM(item));
                }

            }

            return View(bicycleVM);
        }

        public ActionResult Create(BicycleVM bicycleVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BicycleDTO bicycleDTO = new BicycleDTO
                        {
                            Name = bicycleVM.Name,
                            YearOfManufacture = bicycleVM.YearOfManufacture,
                            Sex = bicycleVM.Sex,
                            SerialNumber = bicycleVM.SerialNumber,
                            Type = bicycleVM.Type
                        };
                        service.PostBicycle(bicycleDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteBicycle (id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BicycleVM bicycleVM = new BicycleVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                bicycleVM = new BicycleVM(service.GetBicycleById(id));
            }
            return View(bicycleVM);
        }

        public ActionResult Edit(int id, string query)
        {
            BicycleVM bicycleVM = new BicycleVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                bicycleVM = new BicycleVM(service.GetBicycleById(id));
            }
            return View(bicycleVM);
        }

        [HttpPost]
        public ActionResult Edit(BicycleVM bicycleVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BicycleDTO bicycleDTO = new BicycleDTO
                        {
                            Id = bicycleVM.Id,
                            Name = bicycleVM.Name,
                            YearOfManufacture = bicycleVM.YearOfManufacture,
                            Sex = bicycleVM.Sex,
                            SerialNumber = bicycleVM.SerialNumber,
                            Type = bicycleVM.Type

                        };
                        service.PostBicycle(bicycleDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

    }
}