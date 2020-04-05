using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace CSapp_S7NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Plc plc = new Plc(CpuType.S71200, "192.168.1.200", 0, 1);
            plc.Open();

            plc.Write("DB1.DBX0.0", false);
            bool db1Bool1 = (bool)plc.Read("DB1.DBX0.0");
            Console.WriteLine("DB1.DBX0.0:=" + db1Bool1);

            plc.Write("DB1.DBD2", 0);
            int db1Dint1 = ((uint)plc.Read("DB1.DBD2")).ConvertToInt();
            Console.WriteLine("DB1.DBD2:=" + db1Dint1);

            Console.WriteLine("Press any key to Continue:");
            Console.ReadKey();
        }
    }
}