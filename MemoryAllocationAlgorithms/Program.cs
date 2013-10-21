using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int opcion;
                Console.WriteLine("Inserte el numero de procesos");
                int numProcesos = int.Parse(Console.ReadLine());

                Console.WriteLine("Inserte el numero de Espacios");
                int numEspacios = int.Parse(Console.ReadLine());

                int[] Espacios = new int[numEspacios];
                int[] Procesos = new int[numProcesos];
                int[] Espacioslista1 = new int[numEspacios];
                int[] Espacioslista2 = new int[numEspacios];
                int[] Espacioslista3 = new int[numEspacios];

                Console.WriteLine("Escoja su metodo escribiendo el numero");
                Console.WriteLine("1. FirstFit");
                Console.WriteLine("2. NextFit");
                Console.WriteLine("3. BestFit");
                Console.WriteLine("4. WorstFit");
                Console.WriteLine("5. QuickFit");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Insertar(numProcesos, numEspacios, Espacios, Procesos);
                    Console.WriteLine("FirstFit\n");
                    FirstFit(numProcesos, numEspacios, Espacios, Procesos);
                }
                else if (opcion == 2)
                {
                    Insertar(numProcesos, numEspacios, Espacios, Procesos);
                    Console.WriteLine("NextFit\n");
                    NextFit(numProcesos, numEspacios, Espacios, Procesos);
                }
                else if (opcion == 3)
                {
                    Insertar(numProcesos, numEspacios, Espacios, Procesos);
                    Console.WriteLine("BestFit\n");
                    BestFit(numProcesos, numEspacios, Espacios, Procesos);
                }
                else if (opcion == 4)
                {
                    Insertar(numProcesos, numEspacios, Espacios, Procesos);
                    Console.WriteLine("WorstFit\n");
                    WorstFit(numProcesos, numEspacios, Espacios, Procesos);
                }
                else if (opcion == 5)
                {
                    InsertarQuickFit(numProcesos, numEspacios, Espacioslista1, Espacioslista2, Espacioslista3, Procesos);
                    Console.WriteLine("QuickFit\n");
                    QuickFit(numProcesos, numEspacios, Espacioslista1, Espacioslista2, Espacioslista3, Procesos);
                }
                else
                {
                    Console.WriteLine("Escoja una opcion del menu");
                }
                Console.ReadLine();
            }
        }
        static void FirstFit(int numProcesos, int numEspacios, int[] Espacios, int[] Procesos)
        {
            bool HayEspacio = false;
            for (int i = 0; i < numProcesos; i++)
            {
                HayEspacio = false;
                for (int j = 0; j < numEspacios; j++)
                {
                    if (Procesos[i] < Espacios[j])
                    {
                        Espacios[j] = Espacios[j] - Procesos[i];
                        Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                        HayEspacio = true;
                        break;
                    }
                    else if (Procesos[i] == Espacios[j])
                    {
                        HayEspacio = true;
                        Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                        for (int k = j; k < numEspacios - 1; k++)
                        {
                            Espacios[k] = Espacios[k + 1];
                        }
                        numEspacios--;
                        break;
                    }
                }
                if (HayEspacio == false)
                {
                    Console.WriteLine("No hay Espacio para el proceso #{0}", i + 1);
                    break;
                }
            }
        }
        static void NextFit(int numProcesos, int numEspacios, int[] Espacios, int[] Procesos)
        {
            bool HayEspacio = false;
            for (int i = 0; i < numProcesos; i++)
            {
                HayEspacio = false;
                for (int j = 0; j < numEspacios; j++)
                {
                    if (Procesos[i] < Espacios[j])
                    {
                        Espacios[j] = Espacios[j] - Procesos[i];
                        Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                        HayEspacio = true;
                        break;
                    }
                    else if (Procesos[i] == Espacios[j])
                    {
                        HayEspacio = true;
                        Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                        for (int k = j; k < numEspacios - 1; k++)
                        {
                            Espacios[k] = Espacios[k + 1];
                        }
                        numEspacios--;
                        break;
                    }
                    j = (j + 1) % numEspacios;
                }
                if (HayEspacio == false)
                {
                    Console.WriteLine("No hay Espacio para el proceso #{0}", i + 1);
                    break;
                }
            }
        }
        static void BestFit(int numProcesos, int numEspacios, int[] Espacios, int[] Procesos)
        {
            bool HayEspacio = false;
            int min;
            for (int i = 0; i < numProcesos; i++)
            {
                HayEspacio = false;
                for (int j = 0; j < numEspacios; j++)
                {
                    if (Procesos[i] < Espacios[j])
                    {
                        HayEspacio = true;
                        min = j;
                        for (int k = j; k < numEspacios; k++)
                        {
                            if ((Espacios[min] > Espacios[k]) && (Procesos[i] <= Espacios[k]))
                            {
                                min = k;
                            }
                        }
                        if (Procesos[i] < Espacios[min])
                        {
                            Espacios[min] = Espacios[min] - Procesos[i];
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                            HayEspacio = true;
                            break;
                        }
                        else if (Procesos[i] == Espacios[min])
                        {
                            HayEspacio = true;
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                            for (int k = min; k < numEspacios - 1; k++)
                            {
                                Espacios[k] = Espacios[k + 1];
                            }
                            numEspacios--;
                            break;
                        }
                    }
                }
                if (HayEspacio == false)
                {
                    Console.WriteLine("No hay Espacio para el proceso #{0}", i + 1);
                    break;
                }
            }
        }
        static void WorstFit(int numProcesos, int numEspacios, int[] Espacios, int[] Procesos)
        {
            bool HayEspacio = false;
            int max;
            for (int i = 0; i < numProcesos; i++)
            {
                HayEspacio = false;
                for (int j = 0; j < numEspacios; j++)
                {
                    if (Procesos[i] <= Espacios[j])
                    {
                        HayEspacio = true;
                        max = j;
                        for (int k = j; k < numEspacios; k++)
                        {
                            if ((Espacios[max] < Espacios[k]) && (Procesos[i] <= Espacios[k]))
                            {
                                max = k;
                            }
                        }
                        if (Procesos[i] < Espacios[max])
                        {
                            Espacios[max] = Espacios[max] - Procesos[i];
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                            HayEspacio = true;
                            break;
                        }
                        else if (Procesos[i] == Espacios[max])
                        {
                            HayEspacio = true;
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} ", i + 1, Procesos[i]);
                            for (int k = max; k < numEspacios - 1; k++)
                            {
                                Espacios[k] = Espacios[k + 1];
                            }
                            numEspacios--;
                            break;
                        }
                    }
                }
                if (HayEspacio == false)
                {
                    Console.WriteLine("No hay Espacio para el proceso #{0}", i + 1);
                    break;
                }
            }
     }
        static void QuickFit(int numProcesos, int numEspacios, int[] Espacios20k,int[] Espacios40k,int[] Espacios60k, int[] Procesos)
        {
            bool HayEspacio = false;
            for (int i = 0; i < numProcesos; i++)
            {
                HayEspacio = false;
                for (int j = 0; j < numEspacios; j++)
                {
                    if (Procesos[i] <= Espacios20k[j])
                    {
                        if (Procesos[i] < Espacios20k[j])
                        {
                            Espacios20k[j] = Espacios20k[j] - Procesos[i];
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la primera lista ", i + 1, Procesos[i]);
                            HayEspacio = true;
                            break;
                        }
                        else if (Procesos[i] == Espacios20k[j])
                        {
                            HayEspacio = true;
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la primera lista ", i + 1, Procesos[i]);
                            for (int k = j; k < numEspacios - 1; k++)
                            {
                                Espacios20k[k] = Espacios20k[k + 1];
                            }
                            numEspacios--;
                            break;
                        }
                    }
                    else if (Procesos[i] <= Espacios40k[j] && Procesos[i] > Espacios20k[j])
                    {
                        if (Procesos[i] < Espacios40k[j])
                        {
                            Espacios40k[j] = Espacios40k[j] - Procesos[i];
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la segunda lista ", i + 1, Procesos[i]);
                            HayEspacio = true;
                            break;
                        }
                        else if (Procesos[i] == Espacios40k[j] && Procesos[i] > Espacios20k[j] && Procesos[i] > Espacios40k[j])
                        {
                            HayEspacio = true;
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la segunda lista ", i + 1, Procesos[i]);
                            for (int k = j; k < numEspacios - 1; k++)
                            {
                                Espacios40k[k] = Espacios40k[k + 1];
                            }
                            numEspacios--;
                            break;
                        }
                    }
                    else
                    {
                        if (Procesos[i] >= Espacios60k[j])
                        {
                            Espacios60k[j] = Espacios60k[j] - Procesos[i];
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la tercera lista ", i + 1, Procesos[i]);
                            HayEspacio = true;
                            break;
                        }
                        else if (Procesos[i] == Espacios60k[j])
                        {
                            HayEspacio = true;
                            Console.WriteLine("Memoria alojada a proceso #{0} se alojo {1} a la tercera lista ", i + 1, Procesos[i]);
                            for (int k = j; k < numEspacios - 1; k++)
                            {
                                Espacios60k[k] = Espacios60k[k + 1];
                            }
                            numEspacios--;
                            break;
                        }
                    }
                }
                if (HayEspacio == false)
                {
                    Console.WriteLine("No hay Espacio para el proceso #{0}", i + 1);
                }
            }

        }
        static void Insertar(int numProcesos, int numEspacios, int[] Espacios, int[] Procesos)
        {
            Console.WriteLine("Inserte el tamaño de los procesos");
            for (int i = 0; i < numProcesos; i++)
            {

                Procesos[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Inserte los espacios de memoria");
            for (int i = 0; i < numEspacios; i++)
            {

                Espacios[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void InsertarQuickFit(int numProcesos, int numEspacios, int[] Espacioslista1, int[] Espacioslista2, int[] Espacioslista3, int[] Procesos)
        {
            Console.WriteLine("Inserte el tamaño de los procesos");
            for (int i = 0; i < numProcesos; i++)
            {

                Procesos[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Inserte el tamaño de los procesos de la primera lista ");
            for (int i = 0; i < numEspacios; i++)
            {

                Espacioslista1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Inserte el tamaño de los procesos de la segunda lista");
            for (int i = 0; i < numEspacios; i++)
            {

                Espacioslista2[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Inserte el tamaño de los procesos de la tercera lista");
            for (int i = 0; i < numEspacios; i++)
            {

                Espacioslista3[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
