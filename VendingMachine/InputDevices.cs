﻿//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        int Index;
        Customer Customer;
        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        public CoinInserter(Customer customer, int index)
        {
            Index = index;
            Customer = customer;
        }
        public void CoinInserted()
        {
            Customer.CoinInsert(Index);
            Customer.TurnOnPurchaseLight();
        }

    }

    public class PurchaseButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        Customer Customer;
        int Index;
        public PurchaseButton(Customer customer, int index)
        {
            Customer = customer;
            Index = index;
        }
        public void ButtonPressed()
        {
            Customer.PurchaseCan(Index);
        }
    }

    public class CoinReturnButton
    {
        // add a field to specify an object that Button Pressed will visit
        Customer Customer;
        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field
        public CoinReturnButton(Customer customer)
        {
            Customer = customer;
        }
        public void ButtonPressed()
        {
            Customer.ReturnChange();
        }
    }
}
