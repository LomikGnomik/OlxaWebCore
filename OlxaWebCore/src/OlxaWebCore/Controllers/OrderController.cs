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
            return View(repository.Orders.OrderByDescending(x => x.DateOrder));
        }


        public ViewResult Order(int orderId)
        {
            return View(repository.Orders.FirstOrDefault(o => o.OrderID == orderId));
        }

        // ���� ������ �� �����
        [HttpPost]
        public IActionResult NewOrder(Order order, IFormFile file)
        {
            // ��������� � ����


            // order.File ="_"+file.FileName;


            repository.SaveOrder(order);

            // ��������� ����
            if (file != null)
            {

                // ���� � ����� Files
                string path = _appEnvironment.WebRootPath + "/Files/Client/" + order.OrderID + order.File;
                // ��������� ���� � ����� Files � �������� wwwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
            }
            // �������� ��� ������
            string text = order.Name + order.Email + order.Comment;
            SendMessage("lomik248@mail.ru", "������ �� �������", text);

            // �������� ������ �������
            // string textForClient = @"<table border=""0""cellpadding=""0""cellspacing=""0""style=""margin: 0;padding:0;background:#4f714f""width=""100%""><tr><td  height=""100 %"" align=""center""><center style = ""max-width: 600px; width: 100%;""><!--[if gte mso 9]><table border = ""0"" cellpadding = ""0"" cellspacing = ""0"" style = ""margin:0; padding:0""><tr><td height=""100 %""><![endif]--><table border =""0""cellpadding = ""0""cellspacing =""0""style = ""margin:0; padding:0;background:#98b398"" width = ""100%""><tr><td height=""100 %""><!--[if gte mso 9]><table border = ""0"" cellpadding = ""0"" cellspacing = ""0""><tr><td height=""100 %"" align = ""center""><table border = ""0"" cellpadding = ""0"" cellspacing = ""0"" width = ""600""align = ""center""><tr><td height=""100 %""><![endif]--><span style = ""margin-top: 30px; text-align:center; display:block; width:600px; color:#333333;font: 14px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;""><b>��������� ������!</b></span><span style = ""text-align:center; display:block; width:600px; color:#333333;font: 14px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">���������� ��� �� ��������� � OlxaWeb.</span><!--[if gte mso 9]></td></tr></table></td ><td height=""100 %"" align = ""center""><table border = ""0"" cellpadding = ""0"" cellspacing = ""0"" align = ""center""><tr><td height=""100 %""> <![endif]--></td></tr><tr><td height=""100 %""><span style = ""margin-top: 2em; text-indent: 25px; padding-left:1em; display:block; width:600px; color:#333333;font: 13px Arial, sans-serif; line-height: 20px; -webkit-text-size-adjust:none;"">��� ����� ������ � � ������ ������ �� ���������� � ���������� ������������� �����������, ��� ������ ��� ����� ������, �� �������� � ���� �� ���������� ��������� ������ ��� ��������� �������.</span></td></tr><tr><td height=""100 %""><span style = ""text-indent: 25px; margin-bottom: 1.5em;padding-left:1em; display:block; width:600px; color:#333333;font: 13px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">���� �������� �������������� ������� ������ �������� �� ���� ����� <a href = ""mailto:info@olxaweb.ru""target = ""_blank""style = ""color:#ffffff;""> info@olxaweb.ru </a></span></td></tr><tr></tr><tr><td height=""100 %""><span style = ""text-align:right;display:block; width:600px; color:#333333;font: 14px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none; margin-bottom: 50px;"">� ��������� ������������� OlxaWeb.</span></td></tr></table><!--[if gte mso 9]></td></tr></table><[endif]--></center></td></tr></table> ";
            string textForClient = @"<table border=""0""cellpadding=""0""cellspacing=""0""style=""margin: 0;padding:0;background:#4f714f""width=""100%""><tr><td  height=""100 %"" align=""center""><center style = ""max-width: 600px; width: 100%;""> 
              
                          <table border = ""0"" cellpadding = ""0"" cellspacing = ""0"" style = ""margin:0; padding:0;background:#98b398; max-width:600px""; width=""100%"">                                       
                                       <tr>
                                           <td style=""text-align:center; margin-top:10px; margin-bottom:10px;"">
                                                <!--���� ����� 1-->
                                                    <span style = ""text-align:center;padding-top:50px; display:block; width:600px; color:#333333;font: 14px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">
                                                         <b> ��������� ������!</b>
                                                    </span>
                                                <!--���� ����� 1-->     
                                            </td> 
                                        </tr>   
                                        <tr>  
                                            <td style=""text-align:center; margin-bottom:30px;"">              
                                                <!--���� ����� 2-->                                                                    
                                                    <span style = ""text-align:center; padding-bottom:10px; display:block; width:600px; color:#333333;font: 14px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">
                                                        ���������� ��� �� ��������� � OlxaWeb.                                                                     
                                                    </span>                                                                     
                                                <!--���� ����� 2-->    
                                            </td>                                                                              
                                        </tr>                                                                              
                                        <tr>                                                                              
                                            <td style=""padding-left:16px; "">
                                                <!--���� ����� 3-->
                                                    <span style = ""text-indent: 25px; display:block; width:600px; color:#333333;font: 13px Arial, sans-serif; line-height: 20px; -webkit-text-size-adjust:none;"">
                                                        ��� ����� ������ � � ������ ������ �� ���������� � ���������� ������������� �����������, ��� ������ ��� ����� ������, �� �������� � ���� �� ���������� ��������� ������ ��� ��������� �������.
                                                    </span>
                                                    <!--���� ����� 3-->
                                             </td>
         
                                        </tr>         
                                        <tr>
                                            <td style=""padding-left:16px; "">
                                                <!--���� ����� 4-->                           
                                                    <span style = ""text-indent: 25px; margin-bottom:1.5em; display:block; width:600px; color:#333333;font: 13px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">
                                                        ���� �������� �������������� ������� ������ �������� �� ���� ����� <a href = ""mailto:info@olxaweb.ru"" target = ""_blank"" style = ""color:#ffffff;""> info@olxaweb.ru </a>
                                                    </span>
                                                <!--���� ����� 4-->
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td style=""padding-left:16px; margin-top:30px; margin-bottom:60px; text-align:right; "">
                                                <!--���� ����� 5-->
                                                    <span style = ""text-align:right; margin-bottom:50px; display:block; width:600px; color:#333333;font: 13px Arial, sans-serif; line-height: 30px; -webkit-text-size-adjust:none;"">
                                                        � ��������� ������������� OlxaWeb.
                                                    </span>
                                                <!--���� ����� 5-->
                                            </td>
                                        </tr>
                            </table>                                                                          
                    </center></td></tr></table> ";

            SendMessage(order.Email, "������ �� �������� �����", textForClient);


            return View(order);
        }

        //�������� ������ ��� �� �����
        public async void SendMessage(string email, string theme, string text)
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
