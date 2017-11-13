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

        public TimerLight NoChangeLight { get; set; }

        public Customer()
        {
        }

        public void SetLists(List<Can> cans, List<Coin> coins)
        {
            Cans = cans;
            Coins = coins;
        }

        public void SetNoChangeLight(TimerLight noChangeLight)
        {
            NoChangeLight = noChangeLight;
        }
        public void CoinInsert(int index)
        {
            Coins[index].Inserted();
            CurrentFunds += Coins[index].Value;
        }

        public void TurnOnPurchaseLight()
        {
            foreach(Can can in Cans)
            {
                if(CurrentFunds >= can.Price)
                {
                    can.TurnOnPurchaseLight();
                }
            }
        }
        public void PurchaseCan(int Index)
        {
            if (CheckNumberOfCoins())
            {
                if (Cans[Index].PurchaseLight.IsOn() && Cans[Index].Stock > 0) { Cans[Index].Dispense(); }
                else { return; }
                Cans[Index].Stock--;
                CurrentFunds = CurrentFunds - Cans[Index].Price;
                foreach (Can can in Cans)
                {
                    if (can.Stock == 0)
                    {
                        can.TurnOnSoldOutLight();
                    }

                    if (can.PurchaseLight.IsOn())
                    {
                        can.TurnOffPurchaseLight();
                    }
                }
                ReturnChange();
            }
            else
            {
                NoChangeLight.TurnOn3Sec();
            }

        }
        public bool CheckNumberOfCoins()
        {
            foreach(Coin coin in Coins)
            {
                if(coin.NumCoins == 0)
                {
                    NoChangeLight.TurnOn3Sec();
                    return true;
                }
            }
            return false;
        }
        public void ReturnChange()
        {
            if(CurrentFunds > 0)
            {
                foreach(Coin coin in Coins)
                {
                    while(CurrentFunds >= 0)
                    {
                        if (CurrentFunds >= coin.Value)
                        {
                            CurrentFunds -= coin.Value;
                            coin.ChangeReturn();
                            coin.DisplayReturn();
                        }
                        else { break; }
                    }
                    coin.NumCoinReturn = 0;
                }
            }
            else
            {
                foreach (Can can in Cans)
                {
                    if (can.PurchaseLight.IsOn())
                    {
                        can.TurnOffPurchaseLight();
                    }
                }
                return;
            }
        }

        public void Reset()
        {
            foreach(Can cans in Cans)
            {
                cans.Stock = 4;
                cans.PurchaseLight.TurnOff();
                cans.CanDispenser.Clear();
            }
            foreach(Coin coin in Coins)
            {
                coin.CoinDispenser.Clear();
                coin.NumCoinReturn = 0;
            }
            Coins[3].NumCoins = 15;
            Coins[2].NumCoins = 10;
            Coins[1].NumCoins = 5;
            Coins[0].NumCoins = 2;
            CurrentFunds = 0;
        }
    }
}
