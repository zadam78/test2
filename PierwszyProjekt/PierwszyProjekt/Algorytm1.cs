using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszyProjekt
{
    class Algorytm1
    {
        int numberOfTasks;
        Task<double>[] myTasks;
        Func<object,double> func;
        object args;
        double result = 0.0;

        public Algorytm1(int numberOfTasks,Func<object, double> func,object args)
        {
            this.numberOfTasks = numberOfTasks;
            myTasks = new Task<double>[numberOfTasks];
            this.func =func;
            this.args = args;
        }

        public double StartComputation()
        {
            double result = 0.0;
            for (int i = 0; i < numberOfTasks; i++)
            {
                myTasks[i] = new Task<double>(func, args);
                myTasks[i].Start();
            }
            //Task.WaitAll();
            //foreach (var t in myTasks)
            //{
            //    result += t.Result;
            //}
            return result;
        }
    }
}
