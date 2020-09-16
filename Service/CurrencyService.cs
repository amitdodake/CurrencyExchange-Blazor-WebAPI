using CurrencyExchange.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.Service
{
    public class CurrencyService: ICurrencyService
    {
        private readonly HttpClient httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            
                this.httpClient = new HttpClient { BaseAddress = new Uri("https://api.exchangeratesapi.io") };
        }

        public async Task<Rate> ConvertTo(string cur1, string cur2)
        {
            if (cur1.Length != 3 || cur2.Length != 3)
                return new Rate { FromCur = "", ToCur = "", ConvertedValue = -1 };
            
            decimal v1 = 0;
           // HttpClient httpClient = new HttpClient();
            string content = "";
            HttpResponseMessage response = await httpClient.GetAsync("https://api.exchangeratesapi.io/latest?base=" + cur1 + "&symbols=" + cur1 + "," + cur2);
            content = await response.Content.ReadAsStringAsync();

            v1 = await Task.Run(() => JObject.Parse(content)["rates"][cur2].Value<decimal>());
            
            return new Rate { ToCur = cur2, FromCur=cur1, ConvertedValue = v1 };
        }
    }
}
