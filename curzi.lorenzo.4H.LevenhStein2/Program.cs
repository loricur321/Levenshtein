using System;

namespace curzi.lorenzo._4H.LevenhStein2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LevenhStein 2 di Lorenzo Curzi 4H, 9/04/2021");

            string s = "rombo".ToLower();
            string t = "tromba".ToLower();

            Console.WriteLine($"La distanza di Levenshtein tra '{s}' e '{t}' vale: {DistanzaLevenSthein(s, t)}");
        }

        static int DistanzaLevenSthein(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            //se la lunghezza di una parola è 0 la distanza di levensthein varrà come la lunghezza dell'altra parola
            if (n == 0)
                return m;
            if (m == 0)
                return n;
            else
            {
                //inizializzazione matrice con righe m + 1, colonne n + 1
                int[,] distanze = new int[m + 1, n + 1];

                //prima riga della matrice deve contenere valori da 0 a n
                for (int i = 0; i < n + 1; i++)
                    distanze[0, i] = i;

                //prima colonna della matrice deve contenere valori da 0 a m
                for (int j = 0; j < m + 1; j++)
                    distanze[j, 0] = j;

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        int costo;
                        if (s[i] == t[j])
                            costo = 0;
                        else
                            costo = 1;

                        distanze[j + 1, i + 1] = Minimo(distanze[j + 1, i] + 1, distanze[j, i + 1] + 1, distanze[j, i] + costo);
                    }

                StampaMatrice(distanze);

                return distanze[m, n];
            }
        }

        static int Minimo(int a, int b, int c)
        {
            int retVal = a;

            if (b < retVal) 
                retVal = b;
            if (c < retVal) 
                retVal = c;

            return retVal;
        }

        static void StampaMatrice(int[,] matrix)
        {
            string ret = "\n";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    ret += $"{matrix[i, j]}   ";
                ret += "\n\n";
            }
            Console.WriteLine(ret);
        }
    }
}