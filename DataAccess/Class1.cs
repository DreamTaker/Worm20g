using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace DataAccess
{
    public class ADODTS
    {

        /// <summary>
        /// Demo of Distributed Transactions
        /// </summary>
        /// <param name="conn1"></param>
        /// <param name="com1"></param>
        /// <param name="conn2"></param>
        /// <param name="com2"></param>
        /// <remarks>uses System.Transactions
        /// Ensure Windows Service - Distributed Transaction Coordinator - is running.
        /// </remarks>
        public static String PerformDistTrans(String connString1,String commandText1,String connString2,String commandText2)
        {
            string retVals = string.Empty;

            try
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    using(SqlConnection conn1 = new SqlConnection(connString1))
                    {
                        SqlCommand command1 = new SqlCommand(commandText1,conn1);
                        conn1.Open();
                        var retVal = command1.ExecuteNonQuery();

                        using(SqlConnection conn2 = new SqlConnection(connString2))
                        {
                            SqlCommand command2 = new SqlCommand(commandText2,conn2);
                            conn2.Open();
                            retVal = command2.ExecuteNonQuery();
                        }

                    }

                    ts.Complete();
                    retVals = "Complete";;
                }
            }
            catch(Exception ex)
            {
                retVals = ex.Message;
            }
            finally
            {

            }

            return retVals;
        }

    }

}
