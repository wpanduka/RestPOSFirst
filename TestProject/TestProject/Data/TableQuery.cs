using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class TableQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public TableQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<TempTbl>();
        }

        //Insert 
        public int InsertDetails(TempTbl tempTbl)
        {
            lock (locker)
            {
                return s.Insert(tempTbl);
            }
        }

        //Update 
        public int UpdateDetails(TempTbl tempTbl)
        {
            lock (locker)
            {
                return s.Update(tempTbl);
            }
        }

        //Delete 
        public int DeleteNote(TempTbl tempTbl)
        {
            lock (locker)
            {
                return s.Delete(tempTbl);
            }
        }

        //Get all 
        public IEnumerable<TempTbl> GetTablelist()
        {
            lock (locker)
            {
                return (from i in s.Table<TempTbl>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public void GetTblNam( )
        {
            lock (locker)
            {
                // return s.Table<TempTbl>().LastOrDefault();
                List<TempTbl> TblName = (from i in s.Table<TempTbl>() select i).ToList();
            }
       }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
}
