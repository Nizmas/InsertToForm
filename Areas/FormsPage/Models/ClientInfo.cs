﻿using System;
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
        public int LoanSum { get; set; }
        public string Image { get; set; }
        public int TemplateNum { get; set; }
        public int FolderNum { get; set; }
    }
}