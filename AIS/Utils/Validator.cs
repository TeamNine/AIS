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
            int count = 0;
            //проверка ИНН 12 цифр
            Match isMatch = Regex.Match(info.FidINN, "^[0-9]{12}$");
            if (!isMatch.Success)
            {
                count++;
                errors.Add("[" + c + "].FidINN");
            }

            //Проверка адреса от 1-255 символов
            if (info.FidAdress.Length > 255 || info.FidAdress.Length < 1)
            { 
               count++;
               errors.Add("[" + c + "].FidAdress");
            }


            //Проверка площади число или число с 2 цифрами после запятой
            isMatch = Regex.Match(info.FidArea, @"^[0-9]+[,]{1}[0-9]{1,2}$");
            if (!isMatch.Success)
            {
                isMatch = Regex.Match(info.FidArea, "^[0-9]+$");
                if (!isMatch.Success)
                {
                    count++;
                    errors.Add("[" + c + "].FidArea");
            }
            }

            //Проверка суммы число или число с 2 цифрами после запятой    
            isMatch = Regex.Match(info.FidSum, @"^[0-9]+[,]{1}[0-9]{1,2}");
            if (!isMatch.Success)
            {
                isMatch = Regex.Match(info.FidSum, "^[0-9]+$");
                if (!isMatch.Success)
                { 
                    count++;
                    errors.Add("[" + c + "].FidSum");
                }
            }
            //проверка квартала год четыре цифры затем - и цифра 1-8
            isMatch = Regex.Match(info.FidPeriods, "^[0-9]{4}-[1-8]{1}$");
            if (!isMatch.Success)
            { 
                count++;
                errors.Add("[" + c + "].FidPeriods");
            }

            isMatch = Regex.Match(info.FidDate, @"^\d{2}\.\d{2}\.\d{4}$");
            if (!isMatch.Success)
            {
                count++;
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
                    count++;
                }

                if (d < old || d > n)
                {
                    count++;
                    errors.Add("[" + c + "].FidDate");
                }
            }
            return errors;
        }
    }
}