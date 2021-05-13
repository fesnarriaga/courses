﻿using System;
using System.Linq;

namespace DesignPatterns.Strategy
{
    public class BankTransferPaymentFacade : IBankTransferPaymentFacade
    {
        public string MakeTransfer()
        {
            return new(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
