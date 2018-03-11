using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicRangeQuery
{
    class Program
    {

        public static int[] solution(string S, int[] P, int[] Q)
        {
            int[] newA = new int[S.Length];
            int x = 0;
            foreach (char c in S)
            {
                if (c == 'A')
                {
                    newA[x] = 1;
                    x++;
                }
                else if (c == 'C')
                {
                    newA[x] = 2;
                    x++;
                }
                else if (c == 'G')
                {
                    newA[x] = 3;
                    x++;
                }
                else
                {
                    newA[x] = 4;
                    x++;
                }
            }

            int M = P.Length;
            int[] result = new int[M];

            for (int i = 0; i < M; i++)
            {
                
                int Llimit = P[i];
                int Ulimit = Q[i];
                int Nlength = Ulimit - Llimit + 1;
                int[] subarray = new int[Nlength]  ;
                Array.Copy(newA, Llimit, subarray, 0, Nlength);

                if (subarray.Length != 0)
                {
                    int v = subarray.Min();
                    result[i] = v;
                }
                else
                    result[i] = newA[Ulimit];
                    
            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", solution("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 })));
            Console.ReadLine();
        }
    }
}
