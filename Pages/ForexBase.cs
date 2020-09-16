using CurrencyExchange.Data;
using CurrencyExchange.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Pages
{
    public class ForexBase:ComponentBase
    {
        [Inject]
        public ICurrencyService CurrencyService { get; set; }
        public Rate ConvertedCurrency { get; set; }
        public Rate Currency { get; set; }
        public List<CurrencyDescriptions> curz { get; set; }
        
        protected override void OnInitialized()
        {
            ConvertedCurrency = new Rate();
            Currency = new Rate();

            curz = new List<CurrencyDescriptions> {
                new CurrencyDescriptions(String.Empty, "Choose Currency"),

                new CurrencyDescriptions("USD", "United States Dollar"),
                new CurrencyDescriptions("JPY", "Japanese yen"),
                new CurrencyDescriptions("BGN", "Bulgarian Lev"),
                new CurrencyDescriptions("CZK", "Czech Koruna"),
                new CurrencyDescriptions("DKK", "Danish Krone"),
                new CurrencyDescriptions("GBP", "Pound sterling"),
                new CurrencyDescriptions("HUF", "Hungarian Forint"),
                new CurrencyDescriptions("PLN", "Poland złoty"),
                new CurrencyDescriptions("RON", "Romanian Leu"),
                new CurrencyDescriptions("SEK", "Swedish Krona"),
                new CurrencyDescriptions("CHF", "Swiss Franc"),
                new CurrencyDescriptions("ISK", "Icelandic Króna"),
                new CurrencyDescriptions("NOK", "Norwegian krone"),
                new CurrencyDescriptions("HRK", "Croatian kuna"),
                new CurrencyDescriptions("RUB", "Russian Ruble "),
                new CurrencyDescriptions("TRY", "Turkish lira "),
                new CurrencyDescriptions("AUD", "Australian Dollar"),
                new CurrencyDescriptions("BRL", "Brazilian Real"),
                new CurrencyDescriptions("CAD", "Canadian dollar"),
                new CurrencyDescriptions("CNY", "Chinese Yuan "),
                new CurrencyDescriptions("HKD", "Hong Kong Dollar"),
                new CurrencyDescriptions("IDR", "Indonesian rupiah"),
                new CurrencyDescriptions("ILS", "Israeli new shekel"),
                new CurrencyDescriptions("INR", "Indian Rupees"),
                new CurrencyDescriptions("KRW", "Korean won"),
                new CurrencyDescriptions("MXN", "Mexican Peso"),
                new CurrencyDescriptions("MYR", "Malaysian Ringgit "),
                new CurrencyDescriptions("NZD", "New Zealand Dollar"),
                new CurrencyDescriptions("PHP", "Philippine peso"),
                new CurrencyDescriptions("SGD", "Singapore Dollar"),
                new CurrencyDescriptions("THB", "Thai Baht "),
                new CurrencyDescriptions("ZAR", "South African Rand")
            };
        }
        public async Task ConvertCurrencyValue()
        {
            if (Currency.FromCur == "- CHOOSE CURRENCY" || Currency.ToCur == "- CHOOSE CURRENCY")
            {
                ConvertedCurrency.ConvertedValue = -1;
            }
            else if (!String.IsNullOrWhiteSpace(Currency.FromCur) && !String.IsNullOrWhiteSpace(Currency.ToCur))
            {
                ConvertedCurrency = await CurrencyService.ConvertTo(Currency.FromCur.ToUpper(), Currency.ToCur.ToUpper());
            }
            else
            {
                ConvertedCurrency.ConvertedValue = -1;
            }


        }
    }

    public class CurrencyDescriptions
    {
            

            public CurrencyDescriptions(string v1, string v2)
            {
                Code = v1;
                Description = v2;
            }

            public String Code { get; set; }
            public String Description { get; set; }        
    }
}
