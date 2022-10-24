using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    //https://www.hackerrank.com/challenges/one-week-preparation-kit-lego-blocks/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-week-preparation-kit&playlist_slugs%5B%5D=one-week-day-six
    public class LegoBlocks
    {
        public static int Solution(int n, int m)
        {
            const int maxLength = 4; 
            const int mod = 1000000007; 
            if (n == 1) 
            { 
                return m <= maxLength ? 1 : 0; 
            }

            var layers = new int[m];
            for (var i = 0; i < m; i++)
            {
                for (var j = i - 1; j >= Math.Max(0, i - maxLength); j--)
                {
                    layers[i] = (layers[i] + layers[j]) % mod;
                }
                if (i < maxLength)
                {
                    layers[i]++;
                }
            }

            var walls = new int[m];
            for (var i = 0; i < m; i++)
            {
                walls[i] = (int)System.Numerics.BigInteger.ModPow(layers[i], n, mod);
            }

            var validWalls = new int[m];
            for (var i = 0; i < m; i++)
            {
                validWalls[i] = walls[i];
                for (var j = 0; j < i; j++)
                {
                    var invalidWalls = (int)(((long)validWalls[j] * walls[i - j - 1]) % mod);
                    validWalls[i] -= invalidWalls;
                    if (validWalls[i] < 0)
                    {
                        validWalls[i] += mod;
                    }
                }
            }

            return validWalls[m - 1];
        }
    }
}
