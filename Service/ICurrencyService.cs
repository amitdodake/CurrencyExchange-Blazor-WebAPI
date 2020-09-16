using CurrencyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Service
{
    public interface ICurrencyService
    {
        public Task<Rate> ConvertTo(string cur1, string cur2);
    }
}
