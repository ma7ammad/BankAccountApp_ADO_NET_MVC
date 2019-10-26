using BankMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankMVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Error(string message)
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel.Error = message;
            return View(errorModel);
        }
    }
}