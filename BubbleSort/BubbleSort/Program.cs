using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BubbleSort
{
    class Program
    {
        static void BubbleSort(List<int> mylist)
        {
            for (int i=0; i<mylist.Count; i++) //räknar antal genomgångar
            {
                for(int j = 0; j < mylist.Count-1; j++)//gå igenom listan
                {
                    if (mylist[j] > mylist[j + 1])
                    {
                        int temp = mylist[j];
                        mylist[j] = mylist[j + 1];
                        mylist[j + 1] = temp;
                    }
                }
            }
        }
        static void SelectionSort(List<int> mylist)
        {
            int smallest, temp;
            for (int i = 0; i < mylist.Count - 1; i++)
            {
                smallest = i;
                for (int j = i+1; j < mylist.Count; j++)
                {
                    if (mylist[j] < mylist[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = mylist[smallest];
                mylist[smallest] = mylist[i];
                mylist[i] = temp;
            }
        }
        static void InsertionSort(List<int> mylist)
        {
            for (int i =0; i < mylist.Count - 1; i++)
            {
                for(int j = i + 1;j>0; j--)
                {
                    if (mylist[j-1] > mylist[j])
                    {
                        int temp = mylist[j-1];
                        mylist[j - 1] = mylist[j];
                        mylist[j]=temp;
                            

                    }
                }
            }
        }
        static void Test(List<int> mylist)
        {
            foreach (int i in mylist)
            {
                Console.Write(i + " ");
            }
        }


        static  void SkapaSlumpLista(List<int> mylist, int size)   
        {
            Random slump = new Random();

            for (int i = 0; i < size; i++) //stort antal slumptal i lista
            {
                mylist.Add(slump.Next(1000000));
            }


        }
        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            temp = b;
        }


        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            
            //tallista.Add(1); tallista.Add(4); tallista.Add(6); tallista.Add(2);            tallista.Add(8); tallista.Add(11); tallista.Add(22); tallista.Add(3);            tallista.Add(6);

            SkapaSlumpLista(tallista, 10000);

            //Skapa kopia av slumpad lista
            List<int> tallistacop1 = new List<int>(tallista);
            List<int> tallistacop2 = new List<int>(tallista);

            Stopwatch bubblesort = new Stopwatch();
            Stopwatch insertion = new Stopwatch();
            Stopwatch selection = new Stopwatch();

            bubblesort.Start();
            BubbleSort(tallista);           
            bubblesort.Stop();

            insertion.Start();
            InsertionSort(tallistacop1);
            insertion.Stop();

            selection.Start();
            SelectionSort(tallistacop2);
            selection.Stop();

           

            //Test(tallista);
;
            //Console.WriteLine("Sorterad " + swag.Elapsed);
            //Console.ReadLine();
        }
    }
}
