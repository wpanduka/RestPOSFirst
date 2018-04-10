using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    class StuwaQuery
    {
      static object locker = new object();

        SQLiteConnection s;

        public StuwaQuery()
        {
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<StuwardTbl>();
        }

        //Insert 
        public int InsertDetails(StuwardTbl stuTbl)
        {
            lock (locker)
            {
                return s.Insert(stuTbl);
            }
        }

        //Update 
        public int UpdateDetails(StuwardTbl stuTbl)
        {
            lock (locker)
            {
                return s.Update(stuTbl);
            }
        }

        //Delete 
        public int DeleteNote(StuwardTbl stuTbl)
        {
            lock (locker)
            {
                return s.Delete(stuTbl);
            }
        }

        //Get all 
        public IEnumerable<StuwardTbl> GetTablelist()
        {
            lock (locker)
            {
                return (from i in s.Table<StuwardTbl>() select i).ToList();
            }
        }


        //Get specific customer by ID
        public void GetTblNam()
        {
            lock (locker)
            {
                // return s.Table<TempTbl>().LastOrDefault();
                List<StuwardTbl> StName = (from i in s.Table<StuwardTbl>() select i).ToList();
            }
        }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
}
