using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class NoPrefixSet
    {
        public static void Solution()
        {
            //List<string> words = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => ATemp).ToList();
            
            var input = File.ReadAllLines("test.txt"); //test.txt is in \bin\Debug\net5.0
            var words = input.ToList();

            var all = new HashSet<string>();
            var prx = new HashSet<string>();
            foreach (var word in words)
            {
                if (prx.Contains(word))
                {
                    Console.Write($"BAD SET\n{word}");
                    return;
                }
                int len = word.Length;
                while (len > 0)
                {
                    var pr = word.Substring(0, len);
                    if (all.Contains(pr))
                    {
                        Console.Write($"BAD SET\n{word}");
                        return;
                    }
                    prx.Add(pr);
                    len--;
                }
                all.Add(word);
            }
            Console.Write("GOOD SET");

        }

    }
}
