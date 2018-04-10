using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    
    public class NetworkCheck
    {
        public static bool IsNetworkConnected()
        {
            bool retVal = false;

            try
            {
                retVal = CrossConnectivity.Current.IsConnected;
                return retVal;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
        //int x = 0;
        //public static bool IsInternet()
        //{
        //    if (CrossConnectivity.Current.IsConnected)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        // write your code if there is no Internet available  
        //        //int y = 1;
        //        return false;

        //    }
        //}
    }
}
