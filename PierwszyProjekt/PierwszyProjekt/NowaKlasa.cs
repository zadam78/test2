using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PierwszyProjekt
{
    class NowaLKlasa
    {
        Task<double> task;

        public static Task<double> Licz()
        {
            return new Task<double>(() => { Thread.Sleep(1000); return 10.0; }); 
        }
    }
}
