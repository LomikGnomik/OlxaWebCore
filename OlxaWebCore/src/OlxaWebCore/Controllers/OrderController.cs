using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Services;
using OlxaWebCore.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OlxaWebCore.Controllers
{
  //  [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        IHostingEnvironment _appEnvironment;

        public OrderController(IOrderRepository repo, IHostingEnvironment appEnvironment)
        {
            repository = repo;
            _appEnvironment = appEnvironment;
        }

        
        public ViewResult OrderList()
        {
            return View(repository.Orders);
        }

        
        public ViewResult Order(int orderId)
        {
            return View(repository.Orders.FirstOrDefault(o=>o.OrderID==orderId));
        }


        // приём данных из формы
        [HttpPost]
        public IActionResult NewOrder( Order order, IFormFile file)
        {
            // Сохранить файл
            if (file != null)
            {
                // путь к папке Files
                string path = "/Files/Client/"+ file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                     file.CopyToAsync(fileStream);
                }
            }
            // сохранить в базу
            repository.SaveOrder(order);

            // отослать нам письмо
            // отослать письмо клиенту
            // вернуть страницу с благодарностью
            return View();
        }

        
        public async Task<IActionResult> SendMessage() //отправка заказа нам на почту
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("somemail@mail.ru", "Тема письма", "Тест письма: тест!");
            return RedirectToAction("Index");
        }
    }
}