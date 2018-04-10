using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class PromotionQuery
    {

        static object locker = new object();

        SQLiteConnection sqlcon;

        //Getting connection and creating table
        public PromotionQuery()
        {
            sqlcon = DependencyService.Get<ISQLite>().GetConnection();
            sqlcon.CreateTable<PromotionDB>();

        }

        //Insert Note
        public int InsertDetails(PromotionDB notesDB)
        {
            lock (locker)
            {
                return sqlcon.Insert(notesDB);
            }
        }

        //Update Note
        public int UpdateDetails(PromotionDB noteDB)
        {
            lock (locker)
            {
                return sqlcon.Update(noteDB);
            }
        }

        //Delete Note
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                return sqlcon.Delete<PromotionDB>(id);
            }
        }

        //Get all Notes
        public IEnumerable<PromotionDB> GetProductList()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<PromotionDB>() select i).ToList();
            }
        }

        //Get number of products single call
        public int GetNoOfProducts()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<PromotionDB>() select i).ToList().Count;
            }
        }


        //Get specific Note by ID
        public PromotionDB GetNote(int id)
        {
            lock (locker)
            {
                return sqlcon.Table<PromotionDB>().FirstOrDefault(t => t.Id == id);
            }
        }

        //Dispose
        public void Dispose()
        {
            sqlcon.Dispose();
        }
    }
}
