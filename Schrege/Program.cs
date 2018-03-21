using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Schrege
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                File file = new File();
                file.listOfTasks = new List<Task>();

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

                    SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
                    SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(new Comparison<float>((i1, i2) => i2.CompareTo(i1)));

                    foreach (Task t in file.listOfTasks)
                    {
                        Console.WriteLine(t.r.ToString() + " " + t.p.ToString() + " " + t.q.ToString());
                    }

                    //przepisywanie zawartości
                    foreach (Task t in file.listOfTasks)
                    {
                        N.Enqueue(t, t.r);
                    }

                    int time = 0, step = 0, cMax = 0, tTemp = 0;
                    Console.WriteLine("1");
                    while (G.Count != 0 || N.Count != 0)
                    {
                        Console.WriteLine("2");

                        Label:
                        while (N.Count != 0 && N.First.r <= time)
                        {
                            Console.WriteLine("3");

                            var tmp = N.Dequeue();
                            G.Enqueue(tmp, tmp.q);
                        }

                        if (G.Count == 0)
                        {
                            time = N.First.r;
                            goto Label;
                        }

                            Console.WriteLine("petla");
                            Console.WriteLine("4");

                        var x = G.First;
                        Console.WriteLine("5");

                        G.Dequeue();

                            step = step + 1;
                            //tTemp = time;
                            time = time + x.p;
                            cMax = Math.Max(cMax, time + x.q);
                        }

                    Console.WriteLine("6");

                    Console.WriteLine("toooo:");

                    Console.WriteLine(cMax);
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
