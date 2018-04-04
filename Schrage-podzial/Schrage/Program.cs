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
            {//tworzenie obiektu typu plik
                File file = new File();
                //deklaracja listy
                file.listOfTasks = new List<Task>();
                //zmienne tymczasowe r,p,q
                int r, p, q;

                //wczytywanie bazy z pliku
                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());

                try
                {
                    //using (StreamReader sr = new StreamReader("JACK" + i.ToString() + ".DAT"))
                    using (StreamReader sr = new StreamReader("SCHRAGE" + liczba + ".DAT"))
                    {
                        file.numberOfTasks = Int32.Parse(sr.ReadLine());

                        //petla for, wykowyuje się tyle razy ile jest wszystkich zadan
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

                        //deklaracja kolejki zadan nieuszeregowanych
                        SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
                        //deklaracja kolejki zadan gotowych
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


                        //inicjacja wszystkich zmiennych
                        int time = 0, step = 0, cMax = 0;
                        Task e = new Task(0, 0, 0);
                        Task l = new Task(0, 0, 0);

                        while (G.Count != 0 || N.Count != 0)
                        {

                            Label:
                            while (N.Count != 0 && N.First.r <= time)
                            {

                                e = N.First;
                                G.Enqueue(e, e.q);
                                N.Dequeue();
                                if (e.q > l.q)
                                {
                                    l.p = time - e.r;
                                    time = e.r;
                                    if (l.p > 0)
                                    {
                                        G.Enqueue(l, l.q);
                                    }
                                }

                            }

                            if (G.Count == 0)
                            {
                                time = N.First.r;
                                goto Label;
                            }

                            e = G.First;

                            //Console.WriteLine("G: " + G.First.q);
                            //Console.WriteLine("N: " + N.First.r);

                            G.Dequeue();

                            step = step + 1;
                            l = e;
                            //tTemp = time;
                            time = time + e.p;
                            cMax = Math.Max(cMax, time + e.q);
                        }



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
