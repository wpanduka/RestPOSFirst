﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class CustomerQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public CustomerQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<CustomersDB>();
        }

        //Insert 
        public int InsertDetails(CustomersDB custDB)
        {
            lock (locker)
            {
                return s.Insert(custDB);
            }
        }

        //Update 
        public int UpdateDetails(CustomersDB custDB)
        {
            lock (locker)
            {
                return s.Update(custDB);
            }
        }

        //Delete 
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                return s.Delete<CustomersDB>(id);
            }
        }

        //Get all 
        public IEnumerable<CustomersDB> GetCustomerList()
        {
            lock (locker)
            {
                return (from i in s.Table<CustomersDB>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public CustomersDB GetCustName(string name)
        {
            lock (locker)
            {
                return s.Table<CustomersDB>().LastOrDefault(t => t.Username.Equals(name));
            }
        }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
}
