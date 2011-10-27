using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBed
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeService = new Services.TimeServiceClient();

            if (args.Length == 0)
            {
                Console.WriteLine(timeService.GetServerTime());
            }
            else
            {
                Console.WriteLine(timeService.GetFormattedServerTime(args[0]));
            }
        }
    }
}
