using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszyProjekt
{
    class Algorytm
    {
        private static double res = 0.0;
        public static event Action<double> Wynik,WynikMultiTask;
        public static  void Oblicz(object n2)
        {
           
            uint n = (uint)n2;
            
            Random random = new Random(DateTime.Now.Millisecond);
            double x, y;
            double wynik = 0.0;
            for (int i = 0; i < n; i++)
            {
                x = random.NextDouble();
                y = random.NextDouble();
                if (x * x + y * y < 1.0)
                    wynik += 1.0;
            }

            if(Wynik!=null)
                Wynik(4.0 * wynik / n);
        }

        public static void ObliczAsync(uint n)
        {
            
            object n0 = (object)n;

            var t=new Task(new Action<object>(Oblicz), n0);
            t.Start();
            
         }

        public  void ObliczAsyncMultiTask(uint n,int nTask)
        {
            var resTask = new double[nTask];
            object n0 = (object)n;

            var t = new Task[nTask];
            for (int i = 0; i < nTask; i++)
            {
                t[i] = new Task(new Action<object>(Oblicz), n0);
                t[i].Start();
                Wynik += Algorytm_Wynik;
            }
            Task.WaitAll();
            
            if(WynikMultiTask!=null)WynikMultiTask(res / nTask);
        }

        private static void Algorytm_Wynik(double obj)
        {
            res += obj;
            
        }
    }
}
