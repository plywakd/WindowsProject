﻿using Microsoft.AspNetCore.Mvc;
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
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Last_logged { get; set; }
        public DateTime Created { get; set; }


        public Account(string username, string password)
        {
            Username = username;
            Password = password;
            Last_logged = DateTime.Now;
            Created = DateTime.Now;
        }

        public Account() { }

        public override string ToString()
        {
            return "Account : " + Username + ", created at: " + Created + ", last logged: " + Last_logged;
        }
    }

    public class AccountJSON {
        public string username { get; set; }
        public string password { get; set; }

        public Account getAccount()
        {
            return new Account(username, password);
        }
    }

}