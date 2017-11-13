using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Customer
    {
        List<Can> Cans;
        List<Coin> Coins;
        public int CurrentFunds { get; set; }
        public int Difference { get; set; }

        public Customer()
        {
        }

        public void SetLists(List<Can> cans, List<Coin> coins)
        {
            Cans = cans;
            Coins = coins;
        }

        public void CoinInsert(int index)
        {
            Coins[index].Inserted();
            CurrentFunds += Coins[index].Value;
        }

        public void TurnOnPurchaseLight()
        {
            foreach(Can c in Cans)
            {
                if(CurrentFunds >= c.Price)
                {
                    c.TurnOnPurchaseLight();
                }
            }
        }
        public void PurchaseCan(int Index)
        {
            if(Cans[Index].PurchaseLight.IsOn() && Cans[Index].Stock > 0) { Cans[Index].Dispense(); }
            else { return; }
            Cans[Index].Stock--;
        }
        public void CalculateChange()
        {
            for(int i = Coins.Count-1; i >= 0; i--)
            {
                if (CurrentFunds >= Coins[i].Value) { Coins[i].NumCoinReturn++; Coins[i].NumCoins--; }
                Coins[i].CoinDispenser.Actuate(Coins[i].NumCoinReturn);
            }
            CurrentFunds = 0;
        }

        public void Reset()
        {
            foreach(Can cans in Cans)
            {
                cans.Stock = 4;
                cans.PurchaseLight.TurnOff();
                cans.CanDispenser.Clear();
            }
            Coins[0].NumCoins = 15;
            Coins[1].NumCoins = 10;
            Coins[2].NumCoins = 5;
            Coins[3].NumCoins = 2;
            CurrentFunds = 0;
        }
    }
}
