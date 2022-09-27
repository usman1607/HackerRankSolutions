using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            
            NoPrefixSet.Solution();
            Console.WriteLine(IsPangram("The quicumps over the lazy dog"));
            
            JesseAndCookies.Solution();

            SimpleTextEditor.TextEditor();

            Console.WriteLine( PelindromeWithRecursiveLocalFunction.IsWordPalindrome("Racecary"));

            //var clouds = new List<int> { 0, 0, 1, 0, 0, 1, 0 };
            //var clouds = new List<int> { 0, 0 };
            //var clouds = new List<int> { 0, 1 };
            var clouds = new List<int> { 0, 0, 0, 0, 1, 0 };
            Console.WriteLine(jumpingOnClouds(clouds));


            //var path = "UDDDUDUU";
            var path = "UUDDDDUU";
            var steps = 8;
            //Console.WriteLine(countingValleys(steps, path));


            var input = "345";
            //Console.WriteLine(ChangeToInt(input));

            int num = 12345;
            //Console.WriteLine(ReverseInt(num));

            var bribes = new List<int>() { 1, 2, 5, 3, 4, 7, 8, 6 };
            Console.WriteLine(minimumSwaps(bribes.ToArray()));
        }
        public static bool IsPangram(string str)
        {
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (str.IndexOf(i, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Get the minimum number of swap to sort the array...
        //Question link == https://www.hackerrank.com/challenges/minimum-swaps-2/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays&h_r=next-challenge&h_v=zen
        // Complete the minimumSwaps function below.

        //Failed the time complexity...
        static int minimumSwaps2(int[] arr)
        {

            int ans = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != (i + 1))
                {
                    ans++;
                    Swap(arr.ToList(), i, Array.IndexOf(arr, i + 1));
                }
            }
            return ans;
        }

        static int minimumSwaps(int[] arr)
        {

            Dictionary<int, int> dic = new();
            for(int i = 0; i < arr.Length; i++)
            {
                dic.Add(arr[i], i);
            }

            int ans = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != (i + 1))
                {
                    int temp = arr[i];
                    Swap(arr, i, dic[i+1]);
                    SwapDicPosition(dic, i+1, temp);
                    ans++;
                }
            }
            return ans;
        }

        public static void Swap(int[] input, int x, int y)
        {
            int temp = input[y];
            input[y] = input[x];
            input[x] = temp;
        }

        static void SwapDicPosition(Dictionary<int,int> dic, int x, int y)
        {
            int temp = 0;
            temp = dic[x];
            dic[x] = dic[y];
            dic[y] = temp;
        }

        public static void minimumBribes(List<int> q)
        {
            int count = 0;
            for(int i = q.Count-1; i > 0; i--)
            {
                if((q[i] - (i+1)) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                if(q[i] != (i + 1))
                {
                    if((i-1 >= 0) && q[i-1] == (i + 1))
                    {
                        count++;
                        Swap(q, (i - 1), i);
                    }
                    else if((i-2 >= 0) && q[i-2] == (i + 1))
                    {
                        count += 2;
                        Swap(q, i - 2, i - 1);
                        Swap(q, i - 1, i);
                    }
                    else
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }

            }
            Console.WriteLine(count);
        }
        
        public static void Swap(List<int> input, int x, int y)
        {
            int temp = input[y];
            input[y] = input[x];
            input[x] = temp;
        }

        public static int countingValleys(int steps, string path)
        {
            int result = 0;
            int count = 0;
            for (int i = 0; i < steps; i++)
            {
                if (path[i] == 'U')
                {
                    count++;

                }
                else if (path[i] == 'D')
                {
                    count--;
                }

                if (count < 0 && path[i] == 'D')
                {
                    result++;
                }

            }
            return result;
        }

        public static int jumpingOnClouds(List<int> clouds)
        {
            int jumps = 0;
            int move;
            if (clouds.Count == 1)
            {
                return jumps;
            }
            if (clouds.Count == 2)
            {
                return clouds[1] != 1 ? jumps+1 : jumps;
            }

            for(int i = 0; i < clouds.Count - 2; i += move)
            {
                move = 1;
                if(clouds[i+2] != 1)
                {
                    move = 2;
                }
                jumps++;
            }

            return jumps;
        }

        public static long repeatedString(string s, long n)
        {

            long a = s.Count(c => (c == 'a'));
            long aCount = (n / s.Length) * a;

            return (n % s.Length == 0) ? aCount : s.Substring(0, (int)(n % s.Length)).Count(c => (c == 'a')) + aCount;

        }

        public static int ChangeToInt(string input)
        {
            int num = 0;
            for(int i = 0, j = input.Length - 1; i < input.Length; i++, j--)
            {
                int digit = input[j] - '0';
                num += digit * (int)Math.Pow(10, i);
            }
            return num;
        }

        public static int ReverseInt(int input)
        {
            var result = 0;
            while(input != 0)
            {
                var rem = input % 10;
                result = (result * 10) + rem;
                input /= 10;
            }

            return result;
        }
    }
}
