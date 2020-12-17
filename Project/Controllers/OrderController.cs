using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Linq;
using Project.Services;
namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                SendMessage(order.Email);
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }

        public async void SendMessage(string email)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, "Order", "Thanks for placing order! We'll ship your goods as soon as possible.");
        }
    }
}