using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");

           string ret = ADODTS.PerformDistTrans(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=DB12;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"
                ,"INSERT INTO [dbo].[Table] (Id,Text12) VALUES (1,'T12-1')"
                ,@"Data Source=ORION\DEVINSTANCE;Initial Catalog=DBDI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"
                ,"INSERT INTO [dbo].[Table] (DBDIText) VALUES ('DBDI-1')");

            Console.WriteLine(ret);

            while(true)
            { }
        }
    }
}
