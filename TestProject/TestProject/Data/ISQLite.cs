using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
