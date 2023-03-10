using System;

namespace longestcommonsubsequnce3array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, k;

            string[] s = Console.ReadLine().Split(' ');

            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            k = int.Parse(s[2]);

            s = Console.ReadLine().Split(' ');

            int[] array1 = new int[n + 1];
            int[] array2 = new int[m + 1];
            int[] array3 = new int[k + 1];

            for (int i = 1; i <= n; i++)
            {
                array1[i] = int.Parse(s[i - 1]);
            }

            s = Console.ReadLine().Split(' ');

            for (int i = 1; i <= m; i++)
            {
                array2[i] = int.Parse(s[i - 1]);
            }

            s = Console.ReadLine().Split(' ');

            for (int i = 1; i <= k; i++)
            {
                array3[i] = int.Parse(s[i - 1]);
            }

            Console.WriteLine(Longestsubsequnce(array1, array2, array3));
        }

        private static int Longestsubsequnce(int[] array1, int[] array2, int[] array3)
        {
            int[,,] DP = new int[array1.Length, array2.Length, array3.Length];

            for (int i = 1; i < array1.Length; i++)
            {
                for (int j = 1; j < array2.Length; j++)
                {
                    for (int k = 1; k < array3.Length; k++)
                    {
                        if (array1[i] == array2[j] && array1[i] == array3[k])
                        {
                            DP[i, j, k] = DP[i - 1, j - 1, k - 1] + 1;
                        }

                        else
                        {
                            int[] states = { DP[i - 1, j, k], DP[i - 1, j - 1, k], DP[i - 1, j, k - 1], DP[i, j - 1, k], DP[i, j - 1, k - 1], DP[i, j, k - 1] };

                            if (Max(states) == DP[i - 1, j, k])
                                DP[i, j, k] = DP[i - 1, j, k];

                            else if (Max(states) == DP[i, j - 1, k])
                                DP[i, j, k] = DP[i, j - 1, k];

                            else if (Max(states) == DP[i, j, k - 1])
                                DP[i, j, k] = DP[i, j, k - 1];

                            else if (Max(states) == DP[i - 1, j - 1, k])
                                DP[i, j, k] = DP[i - 1, j - 1, k];

                            else if (Max(states) == DP[i, j - 1, k - 1])
                                DP[i, j, k] = DP[i, j - 1, k - 1];

                            else if (Max(states) == DP[i - 1, j, k - 1])
                                DP[i, j, k] = DP[i - 1, j - 1, k - 1];

                        }
                    }
                }
            }

            return DP[array1.Length - 1, array2.Length - 1, array3.Length - 1];
        }

        static int Max(int[] a)
        {
            int max = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }

            return max;
        }
    }
}
