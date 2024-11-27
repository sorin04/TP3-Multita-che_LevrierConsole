using System;
using System.Threading;

namespace CourseDeLevrier
{
    class Levrier
    {
        private static Random random = new Random();
        private int numero;
        private AutoResetEvent eventArrivee;

        public Levrier(int numero, AutoResetEvent eventArrivee)
        {
            this.numero = numero;
            this.eventArrivee = eventArrivee;
        }

        public void Run()
        {
            Console.WriteLine($"Lévrier {numero} commence la course.");

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(random.Next(1, 10));
                Console.WriteLine($"Lévrier {numero} a parcouru {i} mètres.");

                if (i % 1000 == 0)
                {
                    
                    Console.WriteLine($"Lévrier {numero} est arrivé !");
                }
            }

            
            eventArrivee.Set();
        }
    }
}
