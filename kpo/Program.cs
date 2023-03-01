using System;
using System.IO;

namespace kpo
{
    internal class Program
    {
        static int AdatBe(string preText)
        {
            while (true)
            {
                Console.Write(preText);
                string adat = Console.ReadLine();
                int ertek = 0;
                try
                {
                    ertek = int.Parse(adat);
                }
                catch (Exception)
                {
                    Console.Write("\n");
                    continue;
                }
                if (ertek > 2 || ertek < 0)
                {
                    Console.Write("\n");
                    continue;
                }
                return ertek;
            }
        }
        static int[] Order(int f, int s)
        {
            if (f > s)
            {
                return new int[] { f, s , 0};
            }
            else if (s > f)
            {
                return new[] { s, f , 1};
            }
            return null;
        }
        static int Evaluate(int[] a)
        {
            int[] ordered = Order(a[0], a[1]);
            int eredmeny = 0;
            if (!(ordered is null))
            {
                switch ($"{ordered[0]}-{ordered[1]}")
                {
                    case "0-1":
                        eredmeny = 1;
                        break;
                    case "0-2":
                        eredmeny = 2;
                        break;
                    case "1-0":
                        eredmeny = 1;
                        break;
                    case "1-2":
                        eredmeny = 2;
                        break;
                    case "2-0":
                        eredmeny = 2;
                        break;
                    case "2-1":
                        eredmeny = 1;
                        break;

                }
                if (ordered[2] != 0)
                {
                    if (eredmeny == 1)
                    {
                        eredmeny = 2;
                    }
                    else
                    {
                        eredmeny = 1;
                    }
                }
            }
            return eredmeny;
        }
        static void Main(string[] args)
        {
            Console.Write("1. Feladat:\n");
            int[] elsomeccs = { AdatBe("Kérem az első játékos választását kódolva (0-kő, 1-papír, 2-olló):"), AdatBe("Kérem a második játékos választását kódolva (0-kő, 1-papír, 2-olló):") };
            Console.Write("2. Feladat:\n");
            Console.Write("\tEredmények kódolva (0-döntetlen, 1-első nyert, 2-második nyert):");
            Console.Write(Evaluate(elsomeccs).ToString());
            Console.Write("\n3. Feladat:\n");
            string[] adat = File.ReadAllLines(@"..\\..\jatek.txt");
            Console.Write($"\tTovábbi játékok száma: {adat.Length} db\n");
            Console.Write("4. Feladat: Statisztika\n");
            int[] meccsek = new int[3];
            for (int i = 0; i < adat.Length; i++)
            {
                meccsek[Evaluate(Array.ConvertAll(adat[i].Split('-'), int.Parse))]++;
            }
            Console.Write($"\tDöntetlenek száma: {meccsek[0]} db\n");
            Console.Write($"\tElső játékos nyert: {meccsek[1]} db\n");
            Console.Write($"\tMásodik játékos nyert: {meccsek[2]} db\n");
            Console.ReadKey();
        }
    }
}
