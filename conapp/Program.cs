using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using XmlDeserializersTestApp.Extensions;

namespace XmlDeserializersTestApp
{



    class Program
    {
 

        static void Main(string[] args)
        {
            for (int j = 0; j < 2; j++)
            {
                foreach (var i in new long[] { 1, 1,10, 100, 1000, 10000, 100000, 500000 })
                {
                    Program.RunTest(Program.GetDeserializers<List<AccountAddedEventData>>(), i);
                }
            }
            Console.ReadLine();
        }


        static void RunTest(List<IDeserializer<List<AccountAddedEventData>>> deserializers, long count)
        {

            string items = Program.GetSerializedObjects(count);

            Console.WriteLine("Running test for {0} items", count);

            foreach (var ds in deserializers)
            {
                var sw = Stopwatch.StartNew();

                RunDeserialization<List<AccountAddedEventData>>(ds, items);

                sw.Stop();

                Console.WriteLine("{3}. {0} process {1} elements in {2} ms.",
                    ds.GetName(),
                    count,
                    new TimeSpan(sw.ElapsedTicks).TotalMilliseconds,
                    deserializers.IndexOf(ds) + 1
                    );
            }
            Console.WriteLine("Done");

        }

        static List<IDeserializer<T>> GetDeserializers<T>()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(t => t.GetTypes())
              .Where(t => t.IsClass && typeof(IDeserializer<T>).IsAssignableFrom(t));

            List<IDeserializer<T>> deserializers = new List<IDeserializer<T>>();

            foreach (var t in types)
            {
                deserializers.Add((IDeserializer<T>)Activator.CreateInstance(t));
            }
            return deserializers;
        }

        static List<AccountAddedEventData> GetObjectForSerialization(long count)
        {

            DateTime now = DateTime.Now;
            var l = new List<AccountAddedEventData>();
            while (--count >=0 )
                
            l.Add(new AccountAddedEventData()
            {
                actual = now,
                dboId = "213423424",
                id = 4496,
                number = "40702810270010000001",
                formattedNumber = "40702.810.2.70010000001",
                info = "ООО Навинком",
                salias = "newname4496",
                balance = 461859152,
                limit = 0,
                beginDate = now,
                endDate =   now,
                currency = 0,
                status = "new",
                bic = "044583340",
                correspondentAccount = "301018100000000003",
                name = "МОСКОВСКИЙ ФИЛИАЛ ОАО КБ РЕГИОНАЛЬНЫЙ КРЕДИ  Г.МОСКВА",
                payee = "Общество с ограниченной  ответственностью Навинком",
                clientRef = 2342343
            });
            return l;
                 
        }

        static string GetSerializedObjects(long count)
        {
            var s =  GetObjectForSerialization(count).XmlSerialize();
            return s;

        }

        static void RunDeserialization<T>(IDeserializer<T> ds, string items)
        {
                ds.Deserialize(items);
        }

    }








}
