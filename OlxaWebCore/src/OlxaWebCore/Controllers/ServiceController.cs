using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository repository;

        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }

        public IActionResult AllService()
        {
         IEnumerable<Service> serviceUser =  repository.Services.Where(s => s.Published == true);

            ViewBag.CategoryService = serviceUser
                .Select(x => x.Category)
                .Distinct();
                
            return View(serviceUser);
        }

        //ADMIN

        public IActionResult AllServiceAdmin()
        {

            return View(repository.Services);

        }

        // �������� 
        public ViewResult CreateService() => View("EditService", new Service());

        // ��������������
        public ViewResult EditService(int serviceID) =>
            View(repository.Services
                .FirstOrDefault(p => p.ServiceID == serviceID));

        // �������������� Service
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            if (ModelState.IsValid)
            {
                repository.SaveService(service);
               // repository.SaveService(service);
                //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("AllServiceAdmin");
            }
            else
            {
                // ���-�� �� ��� �� ���������� ������ 
                return View(service);
            }
        }
        // ��������
        //   [HttpPost]
        public IActionResult DeleteService(int serviceID)
        {
            Service deletedService = repository.DeleteService(serviceID);
            if (deletedService != null)
            {
                //  TempData["message"] = $"{deletedPost.Title} was deleted";
            }
            return RedirectToAction("AllServiceAdmin");
        }
    }
}