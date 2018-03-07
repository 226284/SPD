using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    using (StreamReader sr = new StreamReader("SCHRAGE1.DAT"))
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

                    List<Task> N = file.listOfTasks;

                    List<Task> G = new List<Task>();

                    int time = 0, step = 0, cMax = 0;
                    
                    while (G.Count != 0 || N.Count != 0)
                    {
                        do
                        {
                            while (N.Count != 0 && N.Min(c => c.r) <= time)
                            {
                                //Console.WriteLine("dddd"+ N.Min().ToString());
                                //Console.ReadLine();
                                G.Add(N.Min());
                                N.Remove(N.Min());

                            }

                            if (G.Count == 0)
                            {
                                time = N.Min().r;
                            }
                        } while (G.Count == 0);

                        var x = G.Max();
                        G.Remove(G.Max());

                        step = step + 1;
                        time = time + x.q;
                    }

                       /* foreach (Task t in sortedList)
                        {
                            cNext = Math.Max(t.r, cFirst) + t.p;
                            cFirst = cNext;
                            Console.WriteLine(cNext);
                        }
                    
                    Console.WriteLine("Czas trwania:");
                    Console.WriteLine(cNext);*/
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
