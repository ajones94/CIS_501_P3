using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coin
    {
        public int NumCoins { get; set; }
        public int Value { get; set; }
        public int NumCoinReturn { get; set; }
        public CoinDispenser CoinDispenser { get; set; }

        public Coin(CoinDispenser coinDispenser, int coinValue, int numCoins)
        {
            this.CoinDispenser = coinDispenser;
            this.NumCoins = numCoins;
            this.Value = coinValue;
        }
        public void Inserted()
        {
            NumCoins++;
        }
    }
}
