using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Services;
using OlxaWebCore.Models.Interfaces;

namespace OlxaWebCore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;

        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }


        public ViewResult OrderList()
        {
            return View(repository.Orders);
        }

        public ViewResult Order(int orderId)
        {
            return View(repository.Orders.FirstOrDefault(o=>o.OrderID==orderId));
        }


        // приЄм данных из формы
        public IActionResult NewOrder(string name, string email, string comment, byte file)
        {
            Order Order = new Order
            {
                Name = name,
                 Email=email,
                  Comment=comment,
                   DateOrder=DateTime.Now
            };
            repository.SaveOrder(Order);
            // сохранить в базу
            // отослать нам письмо
            // отослать письмо клиенту
            // вернуть страницу с благодарностью
            return View();
        }

        public async Task<IActionResult> SendMessage() //отправка заказа нам на почту
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("somemail@mail.ru", "“ема письма", "“ест письма: тест!");
            return RedirectToAction("Index");
        }
    }
}