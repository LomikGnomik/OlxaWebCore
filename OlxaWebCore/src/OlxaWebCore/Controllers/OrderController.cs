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
            return View(repository.Orders.OrderByDescending(x=>x.DateOrder));
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
            string text = order.Name+order.Email+order.Comment;
            SendMessage("lomik248@mail.ru","Заявка от клиента",text);

            // отослать письмо клиенту
            SendMessage(order.Email,"Заявка на создание сайта","Заявка принята");

            return View();
        }

        //отправка заказа нам на почту
        public async void  SendMessage(string email, string theme ,string text) 
        {
            try
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(email, theme, text);
            }
            catch { }
            
        }

        [HttpPost]
        public IActionResult DeleteOrder(int orderID)
        {
            Order deletedOrder = repository.DeleteOrder(orderID);
            if (deletedOrder != null)
            {
                //  TempData["message"] = $"{deletedPost.Title} was deleted";
            }
            return RedirectToAction("OrderList");
        }
    }
}
