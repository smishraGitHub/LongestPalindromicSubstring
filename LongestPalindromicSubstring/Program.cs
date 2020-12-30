using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "aaaabbaa";
            string s = "babad";
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int i, j;
            string res = "";
            int len = 0;

            for (int g = 0; g < n; g++)
            {
                for (i = 0, j = g; j < n; i++, j++)
                {
                    if (g == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (g == 1)
                    {
                        if (s[i] == s[j]) dp[i, j] = true;
                        else dp[i, j] = false;
                    }
                    else
                    {
                        if (s[i] == s[j] && dp[i + 1, j - 1] == true) dp[i, j] = true;
                        else dp[i, j] = false;
                    }

                    if (dp[i, j])
                    {
                        len = g + 1;
                        res = s.Substring(i, g + 1);
                    }
                }
            }
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
