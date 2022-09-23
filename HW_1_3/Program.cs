using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_1_3
{
    class Converter
    {
        decimal eur_to_uah;
        decimal usd_to_uah;
        public Converter(decimal eur_to_uah, decimal usd_to_uah)
        {
            this.eur_to_uah = eur_to_uah;
            this.usd_to_uah = usd_to_uah;
        }
        public decimal UahToEur(decimal num)
        {
            return num / eur_to_uah;
        }
        public decimal UahToUsd(decimal num)
        {
            return num / usd_to_uah;
        }
        public decimal EurToUah(decimal num)
        {
            return num * eur_to_uah;
        }
        public decimal UsdToUah(decimal num)
        {
            return num * usd_to_uah;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input price for converition in format <uah per usd> <uah per eur>");
            Converter conv;
            while (true)
            {
                var cur = Console.ReadLine().Split(' ');
                Decimal x, y;
                if (!Decimal.TryParse(cur[0], out x) || !Decimal.TryParse(cur[1], out y))
                    Console.WriteLine("Wrong format");
                else
                {
                    conv = new Converter(y, x);
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Input query for converition in format <currency 1 (from {UAH, EUR, USD})> <currency 2 from {UAH, EUR, USD}> <ammount of currency 1>");
                var cur = Console.ReadLine().ToUpper().Split(' ');
                Decimal ans;
                if (cur.Length != 3 ||
                    !new String[] { "UAH", "USD", "EUR" }.Contains(cur[0]) ||
                    !new String[] { "UAH", "USD", "EUR" }.Contains(cur[1]) ||
                    !Decimal.TryParse(cur[2], out ans))
                    Console.WriteLine("Wrong format");
                else
                {
                    ans = Decimal.Parse(cur[2]);
                    if (cur[0] == cur[1]) Console.WriteLine(ans);
                    else if(cur[0] == "EUR" && cur[1] == "USD")
                    {
                        Console.Write(conv.UahToUsd(conv.EurToUah(ans)));
                    }
                    else if (cur[0] == "EUR" && cur[1] == "UAH")
                    {
                        Console.Write(conv.EurToUah(ans));
                    }
                    else if (cur[0] == "USD" && cur[1] == "UAH")
                    {
                        Console.Write(conv.UsdToUah(ans));
                    }
                    else if (cur[0] == "USD" && cur[1] == "EUR")
                    {
                        Console.Write(conv.UahToEur(conv.UsdToUah(ans)));
                    }
                    else if (cur[0] == "UAH" && cur[1] == "USD")
                    {
                        Console.Write(conv.UahToUsd(ans));
                    }
                    else if (cur[0] == "UAH" && cur[1] == "EUR")
                    {
                        Console.Write(conv.UahToEur(ans));
                    }
                    Console.Write(" "); Console.WriteLine(cur[1]);
                }
            }
        }
    }
}
