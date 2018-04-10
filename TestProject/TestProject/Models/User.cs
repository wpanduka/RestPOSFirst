﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class User
    {
        [PrimaryKey]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public bool CheckInformation()
        {
            //if (Username.Equals("admin") && Password.Equals("admin"))
            //    return true;
            //else
            //    return false;

            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;               
        }

    }
}
