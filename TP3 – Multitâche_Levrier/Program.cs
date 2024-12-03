using System;
using System.Collections.Generic;
using System.Threading;

namespace CourseDeLevrier
{
    class CourseDeLevrier
    {
        private List<Levrier> levriers;
        private List<int> classement;

        public CourseDeLevrier()
        {
            levriers = new List<Levrier>();
            classement = new List<int>();
        }
        public void AjouterLevrier(Levrier levrier)
        {
            levriers.Add(levrier);
        }
        public void AjouterAuClassement(int numero)
        {
            classement.Add(numero);
        }
        public void Demarrer()
        {
            List<Thread> threads = new List<Thread>();
            foreach (var levrier in levriers)
            {
                Thread thread = new Thread(levrier.Courir);
                threads.Add(thread);
                thread.Start();
            }
            foreach (var levrier in levriers)
            {
                levrier.AttendreArrivee();
            }

            AfficherClassement();
        }

        private void AfficherClassement()
        {
            Console.WriteLine("\nClassement final :");
            for (int i = 0; i < classement.Count; i++)
            {
                Console.WriteLine($"Position {i + 1}: Lévrier {classement[i]}");
            }
            Console.WriteLine("La course est terminée !");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entrez le nombre de Lévriers dans la course : ");
            int nombreLeveriers = int.Parse(Console.ReadLine());
            CourseDeLevrier course = new CourseDeLevrier();
            for (int i = 1; i <= nombreLeveriers; i++)
            {
                Levrier levrier = new Levrier(i, course);
                course.AjouterLevrier(levrier);
            }

         
            course.Demarrer();
        }
    }
}
