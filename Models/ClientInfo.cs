using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsertToForm.Models
{
    public class ClientInfo
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDate { get; set; }
        public string LoanSum { get; set; }
        public string Image { get; set; }
        public string TemplateName { get; set; }
        public string FolderName { get; set; }
    }
}