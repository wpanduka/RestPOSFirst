using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class TotalQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public TotalQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<TotalTbl>();
        }

        //Insert 
        public decimal InsertDetails(TotalTbl totalTbl)
        {
            lock (locker)
            {
                return s.Insert(totalTbl);
            }
        }

        //Update 
        public decimal UpdateDetails(TotalTbl totalTbl)
        {
            lock (locker)
            {
                return s.Update(totalTbl);
            }
        }

        //Delete 
        public decimal DeleteNote(TotalTbl totalTbl)
        {
            lock (locker)
            {
                return s.Delete(totalTbl);
            }
        }

        //Get all 
        public IEnumerable<TotalTbl> GetTablelist()
        {
            lock (locker)
            {
                return (from i in s.Table<TotalTbl>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public void GetTblNam()
        {
            lock (locker)
            {
                // return s.Table<TempTbl>().LastOrDefault();
                List<TotalTbl> TotalID = (from i in s.Table<TotalTbl>() select i).ToList();
            }
        }

        public decimal GetTotal()
        {
            decimal gtot = 0;
            lock (locker)
            {
                List<TotalTbl> items = (from i in s.Table<TotalTbl>() select i).ToList();

                foreach (TotalTbl x in items)
                {
                    try
                    {
                        gtot += x.ItmTotal;
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

        public string GetallRecords()
        {
            string output = "";
            output += "Retriving data";
            var table = s.Table<TotalTbl>();
            foreach (var item in table)
            {
                output += "\n" + "Item ID :" + item.Id + "\n" + "Item Name :" + item.ItmID + "\n" + "Item Qty :" + item.ItmTotal + "\n" ;
            }

            return output;
        }
    }
}
