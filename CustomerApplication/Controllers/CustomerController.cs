using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApplication.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult LoadCustomer()
        {
            return View("CustomerScreen");
        }
        public IActionResult Add(Customer customer)
        {
            return View(customer);
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}