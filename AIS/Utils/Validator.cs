using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AIS.Models;

namespace AIS.Utils
{
    public class Validator
    {
        public static IEnumerable<string> IsValid(PaymentInfo info, int c)
        {
            var errors = new List<String>();

            //проверка ИНН 12 цифр
            if (String.IsNullOrEmpty(info.FidINN) || !Regex.Match(info.FidINN, "^[0-9]{12}$").Success)
            {
                errors.Add("[" + c + "].FidINN");
            }

            //Проверка адреса от 1-255 символов
            if (String.IsNullOrEmpty(info.FidAdress) || (info.FidAdress.Length > 255 || info.FidAdress.Length < 1))
            {
                errors.Add("[" + c + "].FidAdress");
            }

            //Проверка площади число или число с 2 цифрами после запятой
            if (String.IsNullOrEmpty(info.FidArea) || !Regex.Match(info.FidArea, @"^[0-9]+[,]{1}[0-9]{1,2}$").Success || !Regex.Match(info.FidArea, "^[0-9]+$").Success)
            {
                    errors.Add("[" + c + "].FidArea");
            }

            //Проверка суммы число или число с 2 цифрами после запятой    
            if (String.IsNullOrEmpty(info.FidSum) || !Regex.Match(info.FidSum, @"^[0-9]+[,]{1}[0-9]{1,2}").Success || !Regex.Match(info.FidSum, "^[0-9]+$").Success)
                {
                    errors.Add("[" + c + "].FidSum");
                }

            //проверка квартала год четыре цифры затем - и цифра 1-8
            if (String.IsNullOrEmpty(info.FidPeriods) || !Regex.Match(info.FidPeriods, "^[0-9]{4}-[1-8]{1}$").Success)
            {
                errors.Add("[" + c + "].FidPeriods");
            }

            if (String.IsNullOrEmpty(info.FidDate) || !Regex.Match(info.FidDate, @"^\d{2}\.\d{2}\.\d{4}$").Success)
            {
                errors.Add("[" + c + "].FidDate");
            }
            else
            {
                DateTime d = new DateTime(2014, 01, 01);
                DateTime n = DateTime.Now;
                DateTime old = new DateTime(2015, 01, 01);
                try
                {
                    d = Convert.ToDateTime(info.FidDate);
                }
                catch (System.FormatException)
                {
                    errors.Add("[" + c + "].FidDate");
                }

                if (d < old || d > n)
                {
                    errors.Add("[" + c + "].FidDate");
                }
            }
            return errors;
        }
    }
}