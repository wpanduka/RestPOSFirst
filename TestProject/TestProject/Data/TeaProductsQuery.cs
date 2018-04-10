using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class TeaProductsQuery
    {
        static object locker = new object();

        SQLiteConnection sqlcon;

        //Getting connection and creating table
        public TeaProductsQuery()
        {
            sqlcon = DependencyService.Get<ISQLite>().GetConnection();
            sqlcon.CreateTable<TeaProductsDB>();

        }

        //Insert Note
        public int InsertDetails(TeaProductsDB notesDB)
        {
            lock (locker)
            {
                return sqlcon.Insert(notesDB);
            }
        }

        //Update Note
        public int UpdateDetails(TeaProductsDB noteDB)
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
                return sqlcon.Delete<TeaProductsDB>(id);
            }
        }

        //Get all Notes
        public IEnumerable<TeaProductsDB> GetProductList()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<TeaProductsDB>() select i).ToList();
            }
        }

        //Get number of products single call
        public int GetNoOfProducts()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<TeaProductsDB>() select i).ToList().Count;
            }
        }


        //Get specific Note by ID
        public TeaProductsDB GetNote(int id)
        {
            lock (locker)
            {
                return sqlcon.Table<TeaProductsDB>().FirstOrDefault(t => t.Id == id);
            }
        }

        //Dispose
        public void Dispose()
        {
            sqlcon.Dispose();
        }
    }
}
