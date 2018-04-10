using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace TestProject.Data
{
    class IPQuery
    {
        static object locker = new object();

        SQLiteConnection IPD;

        public IPQuery()
        {
            IPD = DependencyService.Get<ISQLite>().GetConnection();
            IPD.CreateTable<IPaddressDB>();
        }

        //Insert 
        public int InsertDetails(IPaddressDB ipaddressDB)
        {
            lock (locker)
            {
                return IPD.Insert(ipaddressDB);
            }
        }

        //Update 
        public int  UpdateDetails(IPaddressDB ipaddressDB)
        {
            lock (locker)
            {
                return IPD.Update(ipaddressDB);
            }
        }

        //Delete 
        public int DeleteNote(IPaddressDB ipaddressDB)
        {
            lock (locker)
            {
                return IPD.Delete(ipaddressDB);
            }
        }

        //Get all 
        public IEnumerable<IPaddressDB> GetTicketlist()
        {
            lock (locker)
            {
                return (from i in IPD.Table<IPaddressDB>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public void TicketNam()
        {
            lock (locker)
            {
                // return s.Table<TempTbl>().LastOrDefault();
                List<IPaddressDB> TikName = (from i in IPD.Table<IPaddressDB>() select i).ToList();
            }
        }

        //Dispose
        public void Dispose()
        {
            IPD.Dispose();
        }
    }
}
