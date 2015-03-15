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
            var periods = new List<SelectListItem>();
            for (var i = 2015; i < 2021; i++)
            {
                for (var j = 1; j < 5; j++)
                {
                    periods.Add(item: new SelectListItem(){Text = String.Format("{0} квартал {1} год", j, i), Value = ((i - 2015)+(j-1)).ToString(CultureInfo.InvariantCulture)});                    
                }
            }
            ViewBag.periodsList = periods;
            var list = new List<PaymentInfo> { new PaymentInfo(), new PaymentInfo(), new PaymentInfo()};
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(List<PaymentInfo> paymentInfo)
        {
            return View(paymentInfo);
        }
    }
}
