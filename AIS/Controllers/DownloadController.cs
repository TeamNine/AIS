using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS.Controllers
{
    public class DownloadController : Controller
    {
        //
        // GET: /Download/
        public ActionResult csv()
        {
            if (!(System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "files/payinfo.csv")))
                return HttpNotFound();
            byte[] fileBytes = System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "files/payinfo.csv");
            var response = new FileContentResult(fileBytes, "text/csv");
            response.FileDownloadName = "payinfo.csv";
            return response;
        }
	}
}