using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using ExpressiveAnnotations.Attributes;

namespace AIS.Models
{
    public class Periods
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
    public class PaymentInfo
    {
        [DisplayName("ИНН индивидуального предпринимателя")]
        public string FidINN { get; set; }
        [DisplayName("Адрес торгового объекта")]
        public string FidAdress { get; set; }
        [DisplayName("Площадь торгового объекта")]
        public string FidArea { get; set; }
        [DisplayName("Сумма уплаченного сбора")]
        public string FidSum { get; set; }
        [DisplayName("Период произведения оплаты")]
        public string FidPeriods { get; set; }
        [DisplayName("Дата осуществления платежа")]
        public string FidDate { get; set; }
    }
}