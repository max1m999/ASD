using System;
using System.Diagnostics;
namespace ASD
{
    class Program
    {
        static void Main(string[] args)
        {
            int D = 100000000;
            double N = 100000000;
            double e = 0.00004;
            double[] m = new double[D]; //генерируем массив заданной длины
            double part = 0;
            for (int i = 0; i < D-1; i++) //заполняем массив вещественными числами
            {
                m[i] = part;
                part += 1.0 / D;
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            double _sum = Sum(N, e, m, 0);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("Сумма: " + _sum);
            Console.WriteLine("Время: " + elapsedTime);
        }
        static double Sum(double N, double e, double[] m, double _Sum) // рекурсивная функция нахождения суммы
        {
            if (Math.Abs(N) <= e) return _Sum;
            else
            {
                for (int i = 0; i < m.Length-1; i++)
                {
                    while (N - m[i] >= -e)
                    {
                        _Sum += m[i]; //суммируем элементы массива
                        N -= m[i];
                    }
                }
                return Sum(N, e, m, _Sum);
            }
        }
    }
}