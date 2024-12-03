using System;
using System.Threading;

namespace CourseDeLevrier
{
    class Levrier
    {
        private static Random random = new Random();
        private int numero;
        private AutoResetEvent eventArrivee;
        private CourseDeLevrier course;

        public Levrier(int numero, CourseDeLevrier course)
        {
            this.numero = numero;
            this.course = course;
            this.eventArrivee = new AutoResetEvent(false);
        }

        public int Numero
        {
            get { return numero; }
        }

        public void Courir()
        {
            Console.WriteLine($"Lévrier {numero} commence la course.");

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(random.Next(1, 10));
                Console.WriteLine($"Lévrier {numero} a parcouru {i} mètres.");

                if (i == 100)
                {
                    Console.WriteLine($"Lévrier {numero} est arrivé !");
                    course.AjouterAuClassement(numero); 
                    eventArrivee.Set();
                }
            }
        }
        public void AttendreArrivee()
        {
            eventArrivee.WaitOne();
        }
    }
}
