using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using storage;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Apache thrift client");

            try
            {
                TTransport transport = new TSocket("localhost", 9090);
                TProtocol protocol = new TBinaryProtocol(transport);
                StorageService.Client client = new StorageService.Client(protocol);

                transport.Open();
                try
                {
                    client.ping();
                    Console.WriteLine("ping()");

                    var list = client.storagePoints();
                    var result = client.read(0);
                    bool r = client.write(0, "new value");
                    result = client.read(0);
                
                }
                finally
                {
                    transport.Close();
                }
            }
            catch (TApplicationException x)
            {
                Console.WriteLine(x.StackTrace);
            }
        }
    }
}
