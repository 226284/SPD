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
            File file = new File();
            file.listOfTasks = new List<Task>();

            int r, p, q;


                try
                {
                    //using (StreamReader sr = new StreamReader("JACK" + i.ToString() + ".DAT"))
                    using (StreamReader sr = new StreamReader("SCHRAGE9.DAT"))
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


                        foreach (Task t in file.listOfTasks)
                        {
                            Console.WriteLine(t.r.ToString() + " " + t.p.ToString() + " " + t.q.ToString());

                        }

                        List<Task> sortedList = file.listOfTasks.OrderBy(o => o.r).ToList();

                        Console.WriteLine("Posortowane:");

                        foreach (Task t in sortedList)
                        {
                            Console.WriteLine(t.r.ToString() + " " + t.p.ToString());
                        }

                    List<Task> N = sortedList;

                    List<Task> G = new List<Task>();

                    //List<Task> sortedNByMinR = sortedList;
                    //List<Task> sortedGByMaxQ = G.OrderByDescending(o => o.q).ToList();

                    int time = 0, step = 0, cMax = 0, tTemp = 0;
                    Console.WriteLine("1");
                    while (G.Count != 0 || N.Count != 0)
                    {
                        Console.WriteLine("2");

                        Label:
                        while (N.Count != 0 && N.First().r <= time)
                        {
                            Console.WriteLine("3");

                            //Console.WriteLine("dddd"+ N.Min().ToString());
                            //Console.ReadLine();
                            G.Add(N.First());
                            G = G.OrderByDescending(o => o.q).ToList();

                            N.Remove(N.First());
                            N = N.OrderBy(o => o.r).ToList();
                        }


                        if (G.Count == 0)
                        {
                            time = N.First().r;
                            goto Label;
                        }

                        Console.WriteLine("petla");
                        Console.WriteLine("4");

                        var x = G.First() ;
                        Console.WriteLine("5");

                        G.Remove(x);
                        G = G.OrderByDescending(o => o.q).ToList();

                        step = step + 1;
                        //tTemp = time;
                        time = time + x.p;
                        cMax = Math.Max(cMax, time + x.q);
                    }

                    /* foreach (Task t in G)
                     {
                         c = Math.Max(t.r, cFirst) + t.p;
                         cFirst = cNext;
                         Console.WriteLine(cNext);
                     }

                 Console.WriteLine("Czas trwania:");
                 Console.WriteLine(cNext);*/
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
