using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AIS.Models;
using AIS.Utils;

namespace AIS.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var list = new List<PaymentInfo> { new PaymentInfo() { IsUse = true } };
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(List<PaymentInfo> paymentInfo)
        {
            var errors = new List<String>();
            for (int i = 0; i < paymentInfo.Count; i++)
                if (paymentInfo[i].IsUse)
                {
                    paymentInfo[i].FidArea = paymentInfo[i].FidArea.TrimEnd(',', '.');
                    paymentInfo[i].FidSum = paymentInfo[i].FidSum.TrimEnd(',', '.');
                    errors.AddRange(Validator.IsValid(paymentInfo[i], i));
                    //errors += Validator.IsValid(info);
                }

            if (errors.Count == 0)
            {
                ModelState.Clear();
                var csv = new StringBuilder();
                foreach (var info in paymentInfo)
                {
                    if (info.IsUse)
                        // 352700029778;"123123, Москва, ул.Локомотивная, д.1";7,1;4970;2015-1;21.01.2015
                        csv.AppendLine(String.Format(new CultureInfo("de-DE"), "{0};\"{1}\";{2:0.##};{3:0.##};{4};{5}", info.FidINN, info.FidAdress, Double.Parse(info.FidArea), Double.Parse(info.FidSum), info.FidPeriods, info.FidDate));
                }
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "files/payinfo.csv", csv.ToString(), Encoding.UTF8);
                var list = new List<PaymentInfo> { new PaymentInfo() { IsUse = true } };
                ViewBag.File = true;
                return View(list);
            }
            ViewBag.Errors = true;
            return View(paymentInfo);

        }
    }
}
