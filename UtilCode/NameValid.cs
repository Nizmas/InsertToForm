using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace InsertToForm.UtilCode
{
    public class NameValid
    {
        public bool isValidFolder (string name)
        {
            if (name.Length < 5) return false;
            if (name.Length > 15) return false;
            if (Regex.IsMatch(name, ".*(<|>|~|`|:|\").*")) return false;
            if (name.Contains("?") | name.Contains("&") | name.Contains("*") | name.Contains("|") | name.Contains("\\")) return false;
            return true;
        }
    }
}


/*/ (косая черта)
\ (обратная косая черта)
| (вертикальный стержень или символ трубы)
? (вопросительный знак)
* (звездочка)
    name.Contains("<") | name.Contains(">") | name.Contains("^") | name.Contains(":") | name.Contains("\"")*/