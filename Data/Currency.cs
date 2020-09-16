using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Data
{
    //public class Currency
    //{
    //    public Rates Curr { get; set; }
    //    public string Base { get; set; }
    //    public string Date { get; set; }
    //}

    //public class Rates
    //{
    //    public String Cur { get; set; }
    //    public decimal Rate { get; set; }
    //}

    public class Rate
    {
        public String FromCur { get; set; }
        public String ToCur { get; set; }
        public decimal ConvertedValue { get; set; }
    }    
}
