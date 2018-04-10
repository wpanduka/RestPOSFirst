using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class TicketQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public TicketQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<TicketNumber>();
        }

        //Insert 
        public int InsertDetails(TicketNumber ticketNumber)
        {
            lock (locker)
            {
                return s.Insert(ticketNumber);
            }
        }

        //Update 
        public int UpdateDetails(TicketNumber ticketNumber)
        {
            lock (locker)
            {
                return s.Update(ticketNumber);
            }
        }

        //Delete 
        public int DeleteNote(TicketNumber ticketNumber)
        {
            lock (locker)
            {
                return s.Delete(ticketNumber);
            }
        }

        //Get all 
        public IEnumerable<TicketNumber> GetTicketlist()
        {
            lock (locker)
            {
                return (from i in s.Table<TicketNumber>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public void TicketNam()
        {
            lock (locker)
            {
                // return s.Table<TempTbl>().LastOrDefault();
                List<TicketNumber> TikName = (from i in s.Table<TicketNumber>() select i).ToList();
            }
        }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
    
}
