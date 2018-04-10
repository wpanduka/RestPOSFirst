using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class CartQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public CartQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<CartRecord>();
        }

        //Insert 
        public int InsertDetails(CartRecord custDB)
        {
            lock (locker)
            {
                return s.Insert(custDB);
            }
        }

        //Update 
        public int UpdateDetails(CartRecord custDB)
        {
            lock (locker)
            {
                return s.Update(custDB);
            }
        }

        //Delete 
        // public int DeleteNote(int id)
        //  {
        //     lock (locker)
        //    {
        //        int a = 0;
        //        a= s.Delete<CartRecord>(id);
        //       return a;

        //   }
        // }

        //Delete 2
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                // int a = 0;
                return s.Delete<CartRecord>(id);
                //return a;

            }
        }


        //Get all 
        public IEnumerable<CartRecord> GetList()
        {
            lock (locker)
            {
                return (from i in s.Table<CartRecord>() select i).ToList();
            }

        }

        // get the total of added products 
        public Double GetTotal()
        {
            Double gtot = 0;
            lock (locker)
            {
                List<CartRecord> items = (from i in s.Table<CartRecord>() select i).ToList();

                foreach (CartRecord x in items)
                {
                    try
                    {
                        gtot += Convert.ToDouble(x.Total);
                    }
                    catch (Exception e)
                    {

                        string err = e.ToString();
                    }


                    //gtot += Convert.ToInt16(x.Total);
                    //gtot = gtot+ Convert.ToInt32(x.Total.Trim());
                    // gtot = gtot + Convert.ToInt32(x.Total.ToString().Trim());

                }
            }
            return gtot;
        }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }

        // public void DeleteList()
        //  {
        //   int x = 0;
        //     lock (locker)
        //  {
        //        List<CartRecord> items = (from i in s.Table<CartRecord>() select i).ToList();
        //        foreach (CartRecord x in items)
        //      {
        //         x = x-1 ;
        //     }
        // }
        //}

        public CartRecord GetCartLists(int id)
        {
            return s.Table<CartRecord>().FirstOrDefault(t => t.Id == id);
        }

        public string GetallRecords()
        {
            string output = "";
            output += "Retriving data";
            var table = s.Table<CartRecord>();
            foreach (var item in table)
            {
                output += "\n" + "Item ID :" + item.Id +  "\n" + "Item Name :" + item.Name + "\n" + "Item Qty :" + item.Qty + "\n" + "Item Extra Add-ons :" + item.Results + "\n";
            }

            return output;
        }
        
    }
}
