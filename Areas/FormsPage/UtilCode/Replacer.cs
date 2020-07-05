using System.Text.RegularExpressions;


namespace InsertToForm.UtilCode
{
    public class Replacer
    {
        public string newDoc (string docText, string lastName, string firstName, string middleName, string birthDate, int loanSum)
        {
            Regex regexLastName = new Regex(@"\[.{0,250}lastName.{0,250}\]");
            docText = regexLastName.Replace(docText, lastName);

            Regex regexFirstName = new Regex(@"\[.{0,250}firstName.{0,250}\]");
            docText = regexFirstName.Replace(docText, firstName);

            Regex regexMiddleName = new Regex(@"\[.{0,250}middleName.{0,250}\]");
            docText = regexMiddleName.Replace(docText, middleName);

            Regex regexBirthDate = new Regex(@"\[.{0,250}birthDate.{0,250}\]");
            docText = regexBirthDate.Replace(docText, birthDate);

            Regex regexLoanSum = new Regex(@"\[.{0,250}loanSum.{0,250}\]");
            docText = regexLoanSum.Replace(docText, loanSum.ToString());

            return docText;
        }
    }
}