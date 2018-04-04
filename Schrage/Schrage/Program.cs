using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Schrage
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                File file = new File();
                file.listOfTasks = new List<Task>();

                Schrage schrage = new Schrage();

                int r, p, q;

                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());

                try
                {
                    //using (StreamReader sr = new StreamReader("JACK" + i.ToString() + ".DAT"))
                    using (StreamReader sr = new StreamReader("SCHRAGE" + liczba + ".DAT"))
                    {
                        file.numberOfTasks = Int32.Parse(sr.ReadLine());

                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            r = int.Parse(bits[0]);
                            p = int.Parse(bits[1]);
                            q = int.Parse(bits[2]);

                            Task task = new Task(r, p, q);

                            file.listOfTasks.Add(task);
                            //Console.WriteLine(file.listOfTasks.Last().r.ToString() + " " + file.listOfTasks.Last().p.ToString());
                        }

                        schrage.Schrage_run(file);

                        Console.WriteLine("a: " + schrage.a + "   b: " + schrage.b + "   c: " + schrage.c);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Problem z odczytaniem pliku");
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }

        }
    }
}
