using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Account
    {
        private int accountId { get; set; }
        private String username { get; set; }
        private String password { get; set; }
        private DateTime last_logged { get; set; }
        private DateTime created { get; set; }
    }
}