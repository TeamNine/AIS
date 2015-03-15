using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIS.Models;

namespace AIS.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var list = new List<PaymentInfo> { new PaymentInfo(), new PaymentInfo(), new PaymentInfo()};
            list[0].IsUse = true;
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(List<PaymentInfo> paymentInfo)
        {
            return View(paymentInfo);
        }
    }
}
