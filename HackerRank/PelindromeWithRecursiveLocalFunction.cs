using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class PelindromeWithRecursiveLocalFunction
    {
       /* There are many ways to determine if a word is a palindrome, but let's say this is an interview question for a new junior developer job and you are required to write it as a recursive function in C# using a local function.

        Below is one way to leverage a recursive C# local function, IsPalindrome, within another function, IsWordPalindrome.*/

        /// <summary>
        /// Determines if a single word is a palindrome.
        /// </summary>
        /// <param name="word">a word</param>
        /// <returns>true if palindrome, otherwise false</returns>
        /// 
        public static bool IsWordPalindrome(string word)
        {
            if(word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }
            if(word.Length < 2)
            {
                return true;
            }

            return IsPelindrom(0, word.Length - 1);

            bool IsPelindrom(int first, int last)
            {
                if(first >= last)
                {
                    return true;
                }

                if (char.ToLower(word[first]) != char.ToLower(word[last]))
                {
                    return false;
                }

                return IsPelindrom(first + 1, last - 1);
            }
        }

    }
}
