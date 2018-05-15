using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace NEH
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {//tworzenie obiektu typu plik
                File file = new File();
                //deklaracja listy
                //wczytywanie bazy z pliku
                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());

                try
                {
                    using (StreamReader sr = new StreamReader("NEH" + liczba + ".DAT"))
                    {
                        string tmp = sr.ReadLine();
                        string[] bitsTmp = tmp.Split(' ');
                        file.numberOfTasks = Int32.Parse(bitsTmp[0]);
                        file.numberOfMachines = Int32.Parse(bitsTmp[1]);

                        Task[] tabOfTasks = new Task[file.numberOfTasks + 1];

                    for (int j = 0; j < file.numberOfTasks + 1; j++)
                        {
                        Task task = new Task() { id = j, TimeOnMachineTab = new int[file.numberOfMachines + 1], StartOfTask = new int[file.numberOfMachines + 1] };
                           tabOfTasks[j] = task ;
                            tabOfTasks[j].TimeOnMachineTab[0] = 0;
                        }

                        for (int k = 0; k < file.numberOfMachines + 1; k++)
                        {
                            tabOfTasks[0].TimeOnMachineTab[k] = 0;
                        }



                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            for(int k = 0; k < file.numberOfMachines; k++)
                            {
                                tabOfTasks[j+1].TimeOnMachineTab[k+1] = Int32.Parse(bits[k]);
                            }
                        }

                    int C = 0;
                    int Cmax = 0;
                    int[] sum = new int[file.numberOfTasks + 1];
                        for (int j = 1; j < file.numberOfTasks + 1; j++)
                        {
                            for (int k = 1; k < file.numberOfMachines + 1; k++)
                            {
                                     sum[j] += tabOfTasks[j].TimeOnMachineTab[k];
                            }
                            Console.WriteLine();
                        }
                    Array.Sort(sum, tabOfTasks);
                    Array.Reverse(tabOfTasks);
                    foreach (var s in sum)
                    {
                        Console.WriteLine(s);
                    }
                    foreach (var s in tabOfTasks)
                    {
                        Console.WriteLine(s.id);
                    }

                    ArrayList taskTabTmp = new ArrayList();
                    Task tmp1;
                    Task tmp2;
                    Task tmp3;
                    int cMinTmpTaskIndex = 0;
                    int cMinTmp = 0;

                    int cMax0 =0, cMax1=0,cMax=0;

                    //////WYBIERANIE z dwóch pierwszych zadań która kombinacja jest lepsza(ma krótsze cMax)
                    taskTabTmp.Add(tabOfTasks[tabOfTasks.Length - 1]);
                    taskTabTmp.Add(tabOfTasks[0]);
                    taskTabTmp.Add(tabOfTasks[1]);
                    for (int j = 1; j <= 2; j++)
                    {
                        for (int k = 1; k < file.numberOfMachines + 1; k++)
                        {
                            tmp1 = (Task)taskTabTmp[j - 1];
                            tmp2 = (Task)taskTabTmp[j];
                            C = Math.Max(tmp1.StartOfTask[k] + tmp1.TimeOnMachineTab[k], tmp2.StartOfTask[k - 1] + tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                            if (j < 2)
                            {
                                tmp2.StartOfTask[k] = C - tmp2.TimeOnMachineTab[k];
                                tmp3 = (Task)taskTabTmp[j + 1];
                                tmp3.StartOfTask[k] = Math.Max(C, tmp3.StartOfTask[k - 1] + tmp3.TimeOnMachineTab[k - 1]);
                            }
                        }
                        cMax0 = C;
                    }

                    taskTabTmp[1] = tabOfTasks[1];
                    taskTabTmp[2] = tabOfTasks[0];
                    for (int j = 1; j <= 2; j++)
                    {
                        for (int k = 1; k < file.numberOfMachines + 1; k++)
                        {
                            tmp1 = (Task)taskTabTmp[j - 1];
                            tmp2 = (Task)taskTabTmp[j];
                            C = Math.Max(tmp1.StartOfTask[k] + tmp1.TimeOnMachineTab[k], tmp2.StartOfTask[k - 1] + tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                            if (j < 2)
                            {
                                tmp2.StartOfTask[k] = C - tmp2.TimeOnMachineTab[k];
                                tmp3 = (Task)taskTabTmp[j + 1];
                                tmp3.StartOfTask[k] = Math.Max(C, tmp3.StartOfTask[k - 1] + tmp3.TimeOnMachineTab[k - 1]);
                            }
                        }
                        cMax1 = C;
                    }

                    cMax = cMax1;
                    //Ostateczne wybranie
                    if(cMax0 < cMax1)
                    {
                        taskTabTmp[1] = tabOfTasks[0];
                        taskTabTmp[2] = tabOfTasks[1];
                        cMax = cMax0;
                    }

                    var t1 = (Task)taskTabTmp[0];
                    var t2 = (Task)taskTabTmp[1];
                    Console.WriteLine("PIerwszes zadanie:" + t1.id +" " + t2.id + " " + cMax);

                    int countTmp = 0;

                    int ind = 0;
                    //właściwy ALGORYTM NEH
                    for (int y = 2; y < file.numberOfTasks; y++)
                    {
                        countTmp = taskTabTmp.Count;
                        for (int x = 1; x <= countTmp ; x++)
                        {
                            taskTabTmp.Insert(x, tabOfTasks[y]);

                            foreach (var t in taskTabTmp)
                            {
                                var ttmp = (Task)t;
                                Array.Clear(ttmp.StartOfTask, 0, ttmp.StartOfTask.Length);
                            }
                            ind = 0;
                            //Zapisanie startu zadań dla wszystkich zadań na pierwszej masyznie
                            foreach (var t in taskTabTmp)
                            {
                                var tt = (Task)t;
                                tt.StartOfTask[1] = ind;
                                ind += tt.TimeOnMachineTab[1];
                            }
                            for (int j = 1; j < countTmp + 1; j++)
                            {
                                for (int k = 1; k < file.numberOfMachines + 1; k++)
                                {
                                    tmp1 = (Task)taskTabTmp[j - 1];
                                    tmp2 = (Task)taskTabTmp[j];
                                    C = Math.Max(tmp1.StartOfTask[k] + tmp1.TimeOnMachineTab[k], tmp2.StartOfTask[k - 1] + tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                                    if (j < countTmp)
                                    {
                                        tmp2.StartOfTask[k] = C - tmp2.TimeOnMachineTab[k];
                                        tmp3 = (Task)taskTabTmp[j + 1];
                                        tmp3.StartOfTask[k] = Math.Max(C, tmp3.StartOfTask[k - 1] + tmp3.TimeOnMachineTab[k - 1]);
                                    }
                                }
                            }

                            if (x==1)
                            {
                                cMinTmp = C;
                            }
                            
                            if (C <= cMinTmp)//MINIMUM
                            {
                                cMinTmp = C;
                                cMinTmpTaskIndex = x;
                            }

                            if (x < countTmp)
                            {
                            taskTabTmp.RemoveAt(x);
                            }
                            else
                            {
                                taskTabTmp.RemoveAt(x);
                                taskTabTmp.Insert(cMinTmpTaskIndex, tabOfTasks[y]);
                            }
                        }
                    }

                    foreach (var t in taskTabTmp)
                    {
                        var ttmp = (Task)t;
                        Array.Clear(ttmp.StartOfTask, 0, ttmp.StartOfTask.Length);
                    }

                    for (int j = 1; j < file.numberOfTasks + 1; j++)
                    {
                        for (int k = 1; k < file.numberOfMachines + 1; k++)
                        {
                            tmp1 = (Task)taskTabTmp[j - 1];
                            tmp2 = (Task)taskTabTmp[j];
                            C = Math.Max(tmp1.StartOfTask[k] + tmp1.TimeOnMachineTab[k], tmp2.StartOfTask[k - 1] + tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                            if (j < file.numberOfTasks)
                            {
                                tmp2.StartOfTask[k] = C - tmp2.TimeOnMachineTab[k];
                                tmp3 = (Task)taskTabTmp[j + 1];
                                tmp3.StartOfTask[k] = Math.Max(C,tmp3.StartOfTask[k-1]+tmp3.TimeOnMachineTab[k-1]);
                            }
                        }
                    }

                    Console.WriteLine("Lista:");

                    foreach (var t in taskTabTmp)
                    {
                        var ttmp = (Task)t;
                        Console.WriteLine(ttmp.id);
                    }

                    Console.WriteLine("Wynik:");
                        Console.WriteLine(Cmax + " "+C + " ");
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
