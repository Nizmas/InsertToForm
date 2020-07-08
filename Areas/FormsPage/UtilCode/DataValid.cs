using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// проверка корректности введенных значений
/// </summary>
namespace InsertToForm.UtilCode
{
    public class DataValid
    {
        public bool IsValidDatas (string lastName, string firstName, string middleName, string birthDate, int loanSum)
        {
            if (!Regex.IsMatch(lastName, "^[А-Я]{1}[а-я]{1,29}$")) return false;
            if (!Regex.IsMatch(firstName, "^[А-Я]{1}[а-я]{1,29}$")) return false;
            if (!Regex.IsMatch(middleName, "^[А-Я]{1}[а-я]{1,29}$")) return false;
            if (!Regex.IsMatch(birthDate, @"^[0-3]\d\.[0-1]\d\.[1-2](0|9)\d\d$")) return false;
            if (loanSum > 10000 | loanSum < 1000) return false;
            return true;
        }
    }
}