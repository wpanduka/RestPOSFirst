﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class CustomersDB
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public CustomersDB()
        {
        }
    }
}
