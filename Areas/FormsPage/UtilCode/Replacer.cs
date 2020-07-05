using System.Text.RegularExpressions;


namespace InsertToForm.UtilCode
{
    public class Replacer
    {
        public string newDoc (string docText, string LastName, string FirstName, string MiddleName, string BirthDate, string LoanSum)
        {
            Regex regexLastName = new Regex(@"\[.{0,250}lastName.{0,250}\]");
            docText = regexLastName.Replace(docText, LastName);

            Regex regexFirstName = new Regex(@"\[.{0,250}firstName.{0,250}\]");
            docText = regexFirstName.Replace(docText, FirstName);

            Regex regexMiddleName = new Regex(@"\[.{0,250}middleName.{0,250}\]");
            docText = regexMiddleName.Replace(docText, MiddleName);

            Regex regexBirthDate = new Regex(@"\[.{0,250}birthDate.{0,250}\]");
            docText = regexBirthDate.Replace(docText, BirthDate);

            Regex regexLoanSum = new Regex(@"\[.{0,250}loanSum.{0,250}\]");
            docText = regexLoanSum.Replace(docText, LoanSum);

            return docText;
        }

    }
}