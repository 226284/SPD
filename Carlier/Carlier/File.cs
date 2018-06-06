using Priority_Queue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    public class File
    {
        public int numberOfTasks;
        public List<Task> listOfTasks = new List<Task>();

        public SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
        //public SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(new Comparison<float>((i1, i2) => i2.CompareTo(i1)));

        int r, p, q;

        public File()
        {
            try
            {
                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());
                using (StreamReader sr = new StreamReader("SCHRAGE" + liczba + ".DAT"))
                {
                    numberOfTasks = Int32.Parse(sr.ReadLine());

                    for (int j = 0; j < numberOfTasks; j++)
                    {
                        string text = sr.ReadLine();
                        string[] bits = text.Split(' ');

                        r = int.Parse(bits[0]);
                        p = int.Parse(bits[1]);
                        q = int.Parse(bits[2]);

                        

                        Task task = new Task(r, p, q,j);

                        listOfTasks.Add(task);
                        //Console.WriteLine(file.listOfTasks.Last().r.ToString() + " " + file.listOfTasks.Last().p.ToString());
                    }

                    foreach (Task t in listOfTasks)
                    {
                        Console.WriteLine(t.r.ToString() + " " + t.p.ToString() + " " + t.q.ToString());
                    }

                    //przepisywanie zawartości
                    foreach (Task t in listOfTasks)
                    {
                        N.Enqueue(t, t.r);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Problem z odczytaniem pliku");
                Console.WriteLine(e.Message);
            }
        }
    }
}
