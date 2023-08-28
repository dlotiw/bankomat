using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankomat
{
    internal static class Wydawanie
    {

        public static int[] banknoty { get; set; } = {10,20,50,100,200,500};
       
        public static int[] k { get; set; }

        public static int[] ilosc_banknotow { get; set; } = { 5, 5, 5, 5, 5, 5 };
        public static int[] log { get; set; } = { 0, 0, 0, 0, 0, 0 };
        public static int[] reszka { get; set; }

      
       

        public static int Suma()
        {
            int suma=0;
            int i = 0;
            foreach (int x in banknoty)
            {
                suma += x * ilosc_banknotow[i];
                i++;
            }
            return suma;
        }
        public static int? Dynamic(int amount, int[] coins, int[] limits, out int[] change)
        {
            int[][] coinsUsed = new int[amount + 1][];
            for (int i = 0; i <= amount; ++i)
            {
                coinsUsed[i] = new int[coins.Length];
            }

            int[] minCoins = new int[amount + 1];
            for (int i = 1; i <= amount; ++i)
            {
                minCoins[i] = int.MaxValue - 1;
            }

            int[] limitsCopy = new int[limits.Length];
            limits.CopyTo(limitsCopy, 0);

            for (int i = 0; i < coins.Length; ++i)
            {
                while (limitsCopy[i] > 0)
                {
                    for (int j = amount; j >= 0; --j)
                    {
                        int currAmount = j + coins[i];
                        if (currAmount <= amount)
                        {
                            if (minCoins[currAmount] > minCoins[j] + 1)
                            {
                                minCoins[currAmount] = minCoins[j] + 1;

                                coinsUsed[j].CopyTo(coinsUsed[currAmount], 0);
                                coinsUsed[currAmount][i] += 1;
                            }
                        }
                    }

                    limitsCopy[i] -= 1;
                }
            }

            if (minCoins[amount] == int.MaxValue - 1)
            {
                change = null;
                return null;
            }

            change = coinsUsed[amount];
            return minCoins[amount];
        }


    }
}
