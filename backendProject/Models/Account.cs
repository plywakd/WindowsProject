using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DateTime Last_logged { get; set; }
        public DateTime Created { get; set; }


        public Account(String username, String password)
        {
            Username = username;
            Password = password;
            Last_logged = DateTime.Now;
            Created = DateTime.Now;
        }

        public Account() { }

    }
}