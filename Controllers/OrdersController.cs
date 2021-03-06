using homework_52.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_52.Controllers
{
    public class OrdersController : Controller
    {
        private StoreContext _db;

        public OrdersController(StoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Order> orders = _db.Orders.Include(o => o.Product).ToList();
            return View(orders);

        }


        public IActionResult Create(int productId)

        {

            Product product = _db.Products.FirstOrDefault(p => p.Id == productId);
            return View(new Order { Product = product });

        }

        [HttpPost]

        public IActionResult Create(Order order)

        {

            if (order != null)

            {

                _db.Orders.Add(order);

                _db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
    }
}
