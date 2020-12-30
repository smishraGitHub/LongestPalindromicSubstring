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
            string s = "aacabdkacaa";
            string s1 = "";

            //Reverse string
            for(int i=s.Length-1;i>=0;i--)
            {
                s1 = s1 + s[i];
            }

            int[,] temp_table = LCS_table(s, s1, s.Length);

            string Result = LongestPalindromicSubstring(s, s1, s.Length, temp_table);
            Console.WriteLine("Longest Palindromic Substring "+Result);
            Console.ReadLine();

        }

        public static string LongestPalindromicSubstring(string x, string y, int m,int[,] temp)
        {
            string s = "";
            int n = m;
            Dictionary<string, int> ds = new Dictionary<string, int>();

            while(m>0 && n>0)
            {
                if(x[m-1]==y[n-1])
                {
                    s = s + x[m - 1];
                    m--;
                    n--;
                }
                else
                {
                    if (s != "" && !ds.ContainsKey(s))
                    {
                        ds.Add(s, s.Length);
                        s = "";
                    }


                    if (temp[m-1,n] >= temp[m,n-1])
                    {
                        m--;
                    }
                    else
                    {
                        n--;
                    }
                }

                
            }

            //if (s != "" && !ds.ContainsKey(s))
            //{
            //    ds.Add(s, s.Length);
            //    s = "";
            //}

            var max = ds.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;


            //var myKey = ds.FirstOrDefault(x1 => x1.Value == max).Key;

            //foreach(string item in ds.Keys)
            //{
            //    if(!Ispalindrom(item))
            //}

            return max;
        }
        //Check and Return if string is palindrome

        
        /////////////////
        public static int[,] LCS_table(string x,string y,int m)
        {
            int[,] temp = new int[m + 1, m + 1];

            for(int i=0;i<m+1;i++)
            {
                for(int j=0;j<m+1;j++)
                {
                    if (i == 0 || j == 0)
                        temp[i, j] = 0;
                }
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        temp[i, j] = 1 + temp[i - 1, j - 1];
                    }
                    else
                    {
                        temp[i, j] = Math.Max(temp[i - 1, j], temp[i, j - 1]);
                    }
                }
            }

            return temp;

        }
    }
}
