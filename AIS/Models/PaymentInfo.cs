using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using ExpressiveAnnotations.Attributes;

namespace AIS.Models
{
    public class PaymentInfo
    {
        [RequiredIf("FidAdress != null || FidArea != null || FidSum != null", ErrorMessage = "1")]
        [StringLength(12, MinimumLength = 12)]
        public string FidINN { get; set; }

        [RequiredIf("FidINN != null || FidArea != null || FidSum != null", ErrorMessage = "2")]
        [StringLength(256)]
        public string FidAdress { get; set; }

        [RequiredIf("FidINN != null || FidAdress != null || FidSum != null", ErrorMessage = "3")]
        [Range(0,1000)]
        public string FidArea { get; set; }

        [RequiredIf("FidINN != null || FidAdress != null || FidArea != null", ErrorMessage = "4")]
        [Range(0, 100000)]
        public string FidSum { get; set; }
        public string FidQuarter { get; set; }
        public string FidQYear { get; set; }

        [RequiredIf("FidINN != null || FidAdress != null || FidArea != null || FidSum != null", ErrorMessage = "5")]
        [AssertThat("Date(2015,1,1) <= FidDate && FidDate <= Now()", ErrorMessage = "17")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.mm.yyyy}")]
        public DateTime? FidDate { get; set; }

        public PaymentInfo()
        {
            FidINN = FidAdress = FidArea = FidSum = String.Empty;
            FidDate = DateTime.Today;
        }
    }
}