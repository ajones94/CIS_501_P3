using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Can
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public CanDispenser CanDispenser { get; set;}

        public Light PurchaseLight { get; set; }

        public Light SoldOutLight { get; set;}

        public Can(CanDispenser canDispenser, Light purchaseLight, Light soldoutLight, int numCans, string canName, int canPrice)
        {
            this.Name = canName;
            this.Stock = numCans;
            this.Price = canPrice;
            this.CanDispenser = canDispenser;
            this.PurchaseLight = purchaseLight;
            this.SoldOutLight = soldoutLight;
        }

        public void Dispense()
        {
            CanDispenser.Actuate();
        }
        public void TurnOnPurchaseLight()
        {
            PurchaseLight.TurnOn();
        }

        public void TurnOffPurchaseLight()
        {
            PurchaseLight.TurnOff();
        }
    }
}
