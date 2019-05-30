using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszyProjekt
{
    class Pi
    {
        public static event Action<double> Calculated;
        private static double Compute(object numberOfPoints)
        {
            uint n = (uint)numberOfPoints;
            uint result = 0;
            double x, y;
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < n;i++)
            {
                x = random.NextDouble();
                y = random.NextDouble();
                if (x * x + y * y < 1.0) result++;
            }
            return (4.0 / n) * result;
        }


        public async static void ComputeAsync(uint numberOfPoints)
        {
            var task = new Task<double>(new Func<object, double> ( (n) =>  Compute(n) ), numberOfPoints);
            task.Start();
            double result = await task;
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(new Action(() => { result =  awaiter.GetResult();Console.WriteLine(""+result); }));
            Console.WriteLine("" + result);
            Calculated?.Invoke(result);
        }

        public async static void ComputeAsyncMultasks(int numberOfTasks, uint numberOfPoints)
        {
            var tasks = new Task<double>[numberOfTasks];
            var results = new double[numberOfTasks];
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = new Task<double>(new Func<object, double>((n) => Compute(n)), numberOfPoints);
                tasks[i].Start();
                
            }
            for (int i = 0; i < numberOfTasks; i++)
                results[i] = await tasks[i];
            var result = 0.0;
            foreach (var r in results)
                result += r;
            Calculated?.Invoke(result / numberOfTasks);
        }
            
    }
}
