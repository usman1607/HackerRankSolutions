using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    //https://www.hackerrank.com/challenges/one-week-preparation-kit-jesse-and-cookies/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-week-preparation-kit&playlist_slugs%5B%5D=one-week-day-six
    public class JesseAndCookies
    {
        public static void Solution()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            int result = Cookies1(k, A);


            Console.WriteLine(result);
        }

        /* Most efficient C# solution, but PriorityQueue only work in .net 6.0
        public static int Cookies2(int k, List<int> A)
        {
            int st = A.Count;
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            foreach (var item in A)
            {
                queue.Enqueue(item, item);
            }
            
            while (queue.Peek() < k && queue.Count >= 2)
            {
                int n = queue.Dequeue() + (2 * queue.Dequeue());
                queue.Enqueue(n, n);
            }
            return queue.Peek() >= k ? st - queue.Count : -1;
        }*/

        public static int Cookies1(int k, List<int> A)
        {
            var st = A.Count;
            while (Min(A, out int min) < k && A.Count >= 2)
            {
                A.Remove(min);
                int sweet = min + (2 * Min(A, out int min2));
                A.Remove(min2);
                A.Add(sweet);
            }
            return A[0] >= k ? st - A.Count : -1;
        }

        private static int Cookies(int k, List<int> A)
        {
            var st = A.Count;
            return operations(A);
            int operations(List<int> list)
            {
                int min;
                if (Min(A, out min) >= k)
                {
                    return st - list.Count;
                }
                if (list.Count == 1)
                {
                    return -1;
                }

                A.Remove(min);
                int sweet = min + (2 * Min(A, out int min2));
                A.Remove(min2);
                A.Add(sweet);                
                
                return operations(list);
            }
        }

        public static int Min(List<int> self, out int min)
        {
            min = self[0];
            for (int i = 1; i < self.Count; ++i)
            {
                if (self[i] < min)
                {
                    min = self[i];
                }
            }
            return min;
        }
    }
}


/*
 * Java solution:
  public static int cookies(int k, List<Integer> A) {
    
        PriorityQueue<Integer> myQueue = new PriorityQueue<>(A);
        int initialSize = A.size();
        while(myQueue.peek() < k && myQueue.size() >= 2){
            myQueue.add(myQueue.poll() + (2 * myQueue.poll()));
        }
        return myQueue.peek() >= k ? initialSize - myQueue.size() : -1;
    }
 */

