using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Jackson
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File();
            file.listOfTasks = new List<Task>();

            int r, p;


                try
                {
                    //using (StreamReader sr = new StreamReader("JACK" + i.ToString() + ".DAT"))
                    using (StreamReader sr = new StreamReader("JACK5.DAT"))
                    {
                        file.numberOfTasks = Int32.Parse(sr.ReadLine());

                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            r = int.Parse(bits[0]);
                            p = int.Parse(bits[1]);

                            Task task = new Task(r, p);

                            file.listOfTasks.Add(task);

                            //Console.WriteLine(file.listOfTasks.Last().r.ToString() + " " + file.listOfTasks.Last().p.ToString());
                        }

                        foreach (Task t in file.listOfTasks)
                        {
                            Console.WriteLine(t.r.ToString() + " " + t.p.ToString());

                        }
                        List<Task> sortedList = file.listOfTasks.OrderBy(o => o.r).ToList();

                        Console.WriteLine("Posortowane:");

                        foreach (Task t in sortedList)
                        {
                            Console.WriteLine(t.r.ToString() + " " + t.p.ToString());

                        }

                        int cFirst = 0, cNext = 0;

                        foreach (Task t in sortedList)
                        {

                            cNext = Math.Max(t.r, cFirst) + t.p;
                            cFirst = cNext;
                            Console.WriteLine(cNext);
                        }

                    Console.WriteLine("Czas trwania:");
                    Console.WriteLine(cNext);
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
